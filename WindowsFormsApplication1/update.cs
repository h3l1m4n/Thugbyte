using System;
using System.Diagnostics;
using System.Xml;

namespace WindowsFormsApplication1
{
    class update
    {
        public string Vernum { get; private set; }
        public string Url { get; set; }
        public string Change { get; set; }
        public string AppVersion { get; set; }

        public update(string vernum)
        {
            this.Vernum = vernum;
            GatherInfo();
        }

        private void GatherInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"INSERT YOUR XML PATH HERE");
            if (xmlDoc.DocumentElement == null) return;
            var nodeList = xmlDoc.DocumentElement.SelectNodes("/);

            if (nodeList != null)
                foreach (XmlNode node in nodeList)
                {
                    var selectSingleNode = node.SelectSingleNode("AppVersion");
                    if (selectSingleNode != null)
                        AppVersion = selectSingleNode.InnerText;
                    var singleNode = node.SelectSingleNode("Url");
                    if (singleNode != null) Url = singleNode.InnerText;
                    var xmlNode = node.SelectSingleNode("Change");
                    if (xmlNode != null) Change = xmlNode.InnerText;
                }
        }

        public bool CheckForNewVersion()
        {

            var oldVersion = new Version(Vernum);
             var newVersion = new Version(AppVersion);
                var result = oldVersion.CompareTo(newVersion);
                if (result > 0)
                    return false;
                if (result == 0)
                    return false;

            return true;
        }



        public void StartUpdater()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ThugUpdater.exe";
            startInfo.Arguments = Url;
            Process.Start(startInfo);
        }

    }
}
