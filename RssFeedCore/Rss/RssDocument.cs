using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace RssService.Rss 
{
    /// <summary>
    /// RssDocument
    /// </summary>
    [Serializable()]
    [XmlRoot("rss")]
    public class RssDocument
    {
        private string _version;
        private RssChannel _channel;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        public string Version
        {
            get
            { 
                return _version; 
            }
            
            set
            {
                _version = value; 
            }
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>The channel.</value>
        [XmlElement("channel")]
        public RssChannel Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                _channel = value;
            }
        }

        /// <summary>
        /// Loads from XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>RssDocument</returns>
        public static RssDocument LoadFromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException("xml");
            }

            return DeserializeFromXmlUsingStringReader<RssDocument>(xml);
        }

        /// <summary>
        /// Loads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>RssDocument</returns>
        public static RssDocument Load(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url");
            }

            string rssXml = new WebClient().DownloadString(url);

            if (string.IsNullOrEmpty(rssXml))
            {
                throw new Exception("Invalid Url");
            }

            return LoadFromXml(rssXml);
        }

        /// <summary>
        /// Serializes to Xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return this.Serialize();
        }

        /// <summary>
        /// Serializes to JSON
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(this); //this is an instance of the strongly typed Rss Class
        }

        private static T DeserializeFromXmlUsingStringReader<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentException("xml");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader strngReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(strngReader);
            }
        }

        private string Serialize()
        {
            string xml = string.Empty;

            using (StringWriter output = new StringWriter(new StringBuilder(), System.Globalization.CultureInfo.InvariantCulture))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(RssDocument));
                xmlSerializer.Serialize(output, this);
                xml = output.ToString();
            }

            return xml;
        }
    }
}
