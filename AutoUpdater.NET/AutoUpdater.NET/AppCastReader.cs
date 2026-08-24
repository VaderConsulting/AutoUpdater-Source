using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace AutoUpdaterDotNET
{
    internal static class AppCastReader
    {
        public static IReadOnlyList<UpdateInfo> Read(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var document = new XmlDocument();
            document.Load(stream);
            return Read(document);
        }

        public static IReadOnlyList<UpdateInfo> Read(XmlDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            var updates = new List<UpdateInfo>();
            XmlNodeList items = document.SelectNodes("/item | /*/item");

            if (items == null)
                return updates;

            foreach (XmlNode item in items)
            {
                UpdateInfo update = ReadItem(item);
                if (update != null)
                    updates.Add(update);
            }

            return updates;
        }

        public static UpdateInfo SelectLatestNewerThan(IEnumerable<UpdateInfo> updates, Version installedVersion)
        {
            if (updates == null)
                throw new ArgumentNullException(nameof(updates));

            if (installedVersion == null)
                throw new ArgumentNullException(nameof(installedVersion));

            UpdateInfo selected = null;

            foreach (UpdateInfo update in updates)
            {
                if (update.Version <= installedVersion)
                    continue;

                if (selected == null || update.Version > selected.Version)
                    selected = update;
            }

            return selected;
        }

        private static UpdateInfo ReadItem(XmlNode item)
        {
            XmlNode versionNode = item.SelectSingleNode("version");
            if (versionNode == null)
                return null;

            Version version;
            if (!Version.TryParse(versionNode.InnerText, out version))
                return null;

            XmlNode titleNode = item.SelectSingleNode("title");
            XmlNode changeLogNode = item.SelectSingleNode("changelog");
            XmlNode urlNode = item.SelectSingleNode("url");
            XmlNode sha512Node = item.SelectSingleNode("sha512");
            XmlNode sha256Node = item.SelectSingleNode("sha256");

            return new UpdateInfo(
                version,
                titleNode != null ? titleNode.InnerText : "",
                changeLogNode != null ? changeLogNode.InnerText : "",
                urlNode != null ? urlNode.InnerText : "",
                sha512Node != null ? sha512Node.InnerText : "",
                sha256Node != null ? sha256Node.InnerText : "");
        }
    }
}
