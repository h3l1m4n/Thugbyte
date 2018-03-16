angular.module('playerApp', [])
.controller('mainCtrl', function ($scope, $http, $interval, $timeout) {
      
    $scope.showLibraryModal = true;
    $scope.showLoading = false;
    $scope.libraryFiles = {};
    $scope.musicLibrary = [];
    $scope.playlistSongs = [];
    $scope.volumeLevel = 70;
    $scope.playerPaused = true;
    $scope.playbackSong = 'Please select track';
    $scope.playbackTimeTotal = '00:00';
    $scope.playbackTimeCurrent = '00:00';
    $scope.playbackProgress = 0;


    $scope.$watch('$viewContentLoaded', function(){
     $scope.loadFromServer();

 });

    $scope.parseFile = function(file) {

        id3(file, function(err, tags) {
            var space = "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000",
            libraryItem;

            if (tags.title == space) {
                tags.title = null;
            }
            if (tags.artist == space) {
                tags.artist = null;
            }
            if (tags.album == space) {
                tags.album = null;
            }

            relFile = file.replace(/^.*(\\|\/|\:)/, '');

            libraryItem = {
                "file": tags.fileName || file,
                "song": tags.title || tags.fileName || relFile,
                "artist": tags.artist || 'Unknown Artist',
                "album": tags.album || 'Unknown Album'
            };

            $scope.playlistSongs.push(libraryItem);
            $scope.$apply();
        });

    };


    $scope.loadFromServer = function (files) {

        var tracks = null;
        $http.get('tracks.json').success(function(data) {
            tracks = data;

            for (var i = 0; i < tracks.data.length; i++) {
                $scope.parseFile(tracks.data[i].song);
            }
        });

    };


    $scope.playSongOnClick = function (event) {
        var player = document.getElementById('player'),
        playing = document.querySelector('#playlist-list li.playing'),
        songEl = event.target.parentNode;

        playing && playing.classList.remove('playing');
        songEl.classList.add('playing');
        player.src = songEl.getAttribute('data-filename');
        player.play();

        $scope.updatePlaybackSongInfo(songEl, songEl.getAttribute('data-requestid'));
    };

    $scope.volumeDown = function () {
        $scope.volumeLevel = Math.max($scope.volumeLevel - 10, 0);
        document.getElementById('player').volume = $scope.volumeLevel / 100;
    };

    $scope.volumeUp = function () {
        $scope.volumeLevel = Math.min($scope.volumeLevel + 10, 100);
        document.getElementById('player').volume = $scope.volumeLevel / 100;
    };

    $scope.playbackPlayPause = function () {
        var player = document.getElementById('player');

        if ($scope.playerPaused === true) {
            $scope.playerPaused = false;
            player.play();
        } else {
            $scope.playerPaused = true;
            player.pause();
        }
    };

    $scope.playbackPrev = function () {
        var player = document.getElementById('player'),
        playing = document.querySelector('#playlist-list li.playing'),
        playingPrev = playing && playing.previousElementSibling,
        playlistLast = document.getElementById('playlist-list').lastElementChild;

        if (playingPrev) {
            playing.classList.remove('playing');
            playingPrev.classList.add('playing');
                //playingPrev.scrollIntoView();
                player.src = playingPrev.getAttribute('data-filename');
                player.play();

                $scope.updatePlaybackSongInfo(playingPrev, playingPrev.getAttribute('data-requestid'));
            } else {
                playing && playing.classList.remove('playing');
                playlistLast.classList.add('playing');
                //playlistLast.scrollIntoView();
                player.src = playlistLast.getAttribute('data-filename');
                player.play();

                $scope.updatePlaybackSongInfo(playlistLast, playlistLast.getAttribute('data-requestid'));
            }
        };

        $scope.playbackNext = function () {
            var player = document.getElementById('player'),
            playing = document.querySelector('#playlist-list li.playing'),
            playingNext = playing && playing.nextElementSibling,
            playlistFirst = document.getElementById('playlist-list').firstElementChild;

            if (playingNext) {
                playing.classList.remove('playing');
                playingNext.classList.add('playing');
                //playingNext.scrollIntoView();
                player.src = playingNext.getAttribute('data-filename');
                player.play();

                $scope.updatePlaybackSongInfo(playingNext, playingNext.getAttribute('data-requestid'));
            } else {
                playing && playing.classList.remove('playing');
                playlistFirst.classList.add('playing');
                //playlistFirst.scrollIntoView();
                player.src = playlistFirst.getAttribute('data-filename');
                player.play();
                $scope.updatePlaybackSongInfo(playlistFirst, playlistFirst.getAttribute('data-requestid'));

            }
        };

        $scope.updatePlaybackSongInfo = function (song, requestId) {
            if (typeof song === 'string') {
                $scope.playbackSong = song;
            } else {
                $scope.playbackSong = song.querySelector('.song').innerText;
            }



            $scope.playerPaused = false;
        };

        $scope._random = function(min, max) {
            if (max == null) {
                max = min;
                min = 0;
            }
            return min + Math.floor(Math.random() * (max - min + 1));
        };
    })
.directive('playerVolume', function () {
    return {
        restrict: 'A',
        link: function ($scope, element) {
            element.bind('click', function (e) {
                var percent = e.offsetX / this.clientWidth,
                volumeLevel = percent.toFixed(1);

                $scope.volumeLevel = volumeLevel * 100;
                document.getElementById('player').volume = $scope.volumeLevel / 100;
                $scope.$apply();
            });
        }
    };
})
.directive('audioEnded', function () {
    return {
        restrict: 'A',
        link: function ($scope, element) {
            element.bind('ended', function () {
                $scope.playbackNext();
            });
        }
    };
})
.directive('audioTimeupdate', function () {
    return {
        restrict: 'A',
        link: function ($scope, element) {
            var playerelement = element[0];

            element.bind('timeupdate', function () {
                var currentSeconds = (Math.floor(playerelement.currentTime % 60) < 10 ? '0' : '') + Math.floor(playerelement.currentTime % 60),
                currentMinutes = Math.floor(playerelement.currentTime / 60),
                totalSeconds = (Math.floor(playerelement.duration % 60) < 10 ? '0' : '') + Math.floor(playerelement.duration % 60),
                totalMinutes = Math.floor(playerelement.duration / 60),
                percentageOfSong = ((playerelement.currentTime * 100) / playerelement.duration).toFixed(1);

                $scope.playbackTimeCurrent = currentMinutes + ':' + currentSeconds;
                $scope.playbackTimeTotal = totalMinutes + ':' + totalSeconds;
                $scope.playbackProgress = percentageOfSong;
                $scope.$apply();
            });
        }
    };
})
.directive('playbackProgress', function () {
    return {
        restrict: 'A',
        link: function ($scope, element) {
            element.bind('click', function (e) {
                var player = document.getElementById('player'),
                percent = (e.offsetX / this.clientWidth).toFixed(2) * 100;

                if (!isNaN(player.duration)) {
                    player.currentTime = (percent * player.duration) / 100;
                }
            });
        }
    };
});