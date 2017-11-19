using System;
using System.Xml.Serialization;

namespace RssService.Rss
{
    /// <summary>
    /// RssEnclosure
    /// </summary>
    [Serializable]
    public class RssEnclosure
    {
        private string _length;
        private string _type;
        private string _url;

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [XmlAttribute("length")]
        public string Length
        {
            get
            { 
                return _length; 
            }

            set
            {
                _length = value; 
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlAttribute("type")]
        public string Type
        {
            get
            { 
                return _type; 
            }

            set
            { 
                _type = value; 
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [XmlAttribute("url")]
        public string Url
        {
            get
            { 
                return _url; 
            }

            set
            {
                _url = value;
            }
        }
    }
}
