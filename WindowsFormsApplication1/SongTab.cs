using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NAudio.Wave;

namespace WindowsFormsApplication1
{
    public partial class SongTab : UserControl
    {
        public int _currentindex;
        public List<song> _searchSongs;
        private readonly Form1 fr1;

        public SongTab(List<song> songs, Form1 frm1)
        {
            fr1 = frm1;
            _currentindex = 0;
            InitializeComponent();
            _searchSongs = songs;

            foreach (var song in songs)
            {
                var fixedlv = new ListViewItem(song.Artist);

                fixedlv.SubItems.Add(song.Songname);
                fixedlv.SubItems.Add(song.SecToMin());
                fixedlv.ToolTipText = song.GetSongInfo();
                lvSearch.Items.Add(fixedlv);
            }
        }

        private void lvSearch_DoubleClick(object sender, EventArgs e)
        {
            _currentindex = lvSearch.FocusedItem.Index;
            fr1.PlaySong(_searchSongs[lvSearch.FocusedItem.Index], this);
        }


        public void NextSong()
        {
            var rnd = new Random();

            if (fr1._queueList.Count > 0)
            {
                fr1.PlaySong(fr1._queueList[0], this);
                fr1._queueList.RemoveAt(0);
            }
            else
            {
                if (fr1.GetCbLoop() == false)
                    if (fr1.GetCbRandom())
                        _currentindex = rnd.Next(0, _searchSongs.Count);
                    else
                        _currentindex++;



                if (_searchSongs.Count > _currentindex)
                {
                    SetListViewSelected(_currentindex, lvSearch);
                    fr1.PlaySong(_searchSongs[_currentindex], this);
                }
            }
        }

        public song GetSelectedSong()
        {
            return _searchSongs[lvSearch.FocusedItem.Index];
        }

        private void SetListViewSelected(int value, ListView listb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (listb.InvokeRequired)
            {
                SetListViewSelectedCallBack d = SetListViewSelected;
                Invoke(d, value, listb);
            }
            else
            {
                listb.Items[value].Selected = true;
            }
        }

        private void ClearListview(ListView oldlv)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (oldlv.InvokeRequired)
            {
                ClearListviewCallback d = ClearListview;
                Invoke(d, oldlv);
            }
            else
            {
                oldlv.Items.Clear();
            }
        }

        private void ListViewAdd(ListView listv, List<song> sr)
        {
            if (listv.InvokeRequired)
            {
                SettListViewAddCallBack d = ListViewAdd;
                Invoke(d, listv, sr);
            }
            else
            {
                foreach (var song in sr)
                {
                    var fixedlv = new ListViewItem(song.Artist);

                    fixedlv.SubItems.Add(song.Songname);
                    fixedlv.SubItems.Add(song.SecToMin());
                    fixedlv.ToolTipText = song.GetSongInfo();
                    listv.Items.Add(fixedlv);
                }
            }
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var colIndex = Convert.ToInt32(e.Column.ToString());
            switch (colIndex)
            {
                case 0:
                    ClearListview(lvSearch);
                    _searchSongs.Sort();
                    ListViewAdd(lvSearch, _searchSongs);

                    break;
                case 1:
                    //Sort Song   
                    break;
                case 2:
                    //sort Duratation
                    break;
            }
        }

        private delegate void SettListViewAddCallBack(ListView listv, List<song> sr);

        private delegate void ClearListviewCallback(ListView oldlv);

        private delegate void SetListViewSelectedCallBack(int time, ListView listb);

        private void cmsDownload_Click(object sender, EventArgs e)
        {
            fr1.DownloadSong(GetSelectedSong());
        }

        private void cmsPlay_Click(object sender, EventArgs e)
        {
            fr1.PlaySong(GetSelectedSong(),this);
        }

        private void artistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr1.SetSearchBox(GetSelectedSong().Artist);
        }
        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            var listView = sender as ListView;
            if (e.Button != MouseButtons.Right) return;
            if (listView != null)
            {
                var item = listView.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
            }
            if (listView != null) cmsSearch.Show(listView, e.Location);
        }

        private void songToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr1.SetSearchBox(GetSelectedSong().Songname);
        }

        private void addToQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr1._queueList.Add(GetSelectedSong());
        }

        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copied to Clipboard \n " + GetSelectedSong().URL);
            Clipboard.SetText(GetSelectedSong().URL);
        }
    }
}