#region Using library
using System.Collections.Generic;
using System.IO;
using System.Xml;
using desktop_admin.Models; 
#endregion

namespace desktop_admin.Helpers
{
    class VersioningHelper
    {
        #region version_get
        public static List<VersioningModel> version_get()
        {
            List<VersioningModel> versioningModel_list = new List<VersioningModel>();
            VersioningModel versioningModel;

            string subFolderName = "VersionDetail";
            string fileName = "version-detail.txt";

            //------------------------------------------
            string path = string.Format("{0}\\{1}\\{2}", Directory.GetCurrentDirectory(), subFolderName, fileName);

            //------------------------------------------
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode nodeList = doc.SelectSingleNode("list");
                XmlNodeList nodeVersion = nodeList.SelectNodes("version");

                foreach (XmlNode version in nodeVersion)
                {
                    versioningModel = new VersioningModel();

                    foreach (XmlNode node in version)
                    {
                        switch (node.Name)
                        {
                            case "number":
                                versioningModel.version_number = node.InnerText;
                                break;

                            case "date":
                                versioningModel.version_date = node.InnerText;
                                break;

                            case "description":
                                if (node.HasChildNodes)
                                {
                                    versioningModel.version_description = new List<string>();

                                    for (int i = 0; i < node.ChildNodes.Count; i++)
                                    {
                                        versioningModel.version_description.Add(node.ChildNodes[i].InnerText);
                                    }
                                }
                                break;
                        }
                    }

                    versioningModel_list.Add(versioningModel);
                }
            }

            return versioningModel_list;
        } 
        #endregion
    }
}
