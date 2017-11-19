using System;
using System.Xml.Serialization;

namespace RssService.Rss
{
    /// <summary>
    /// RssSource
    /// </summary>
    [Serializable]
    public class RssSource
    {
        private string _url;
        private string _text;

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

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [XmlText()]
        public string Text
        {
            get 
            { 
                return _text; 
            }

            set 
            { 
                _text = value; 
            }
        }
    }
}
