using System;
using System.Xml.Serialization;

namespace RssService.Rss
{
    /// <summary>
    /// RssGuid
    /// </summary>
    [Serializable]
    public class RssGuid
    {
        private string _isPermaLink;
        private string _text;

        /// <summary>
        /// Gets or sets the is perma link.
        /// </summary>
        /// <value>The is perma link.</value>
        [XmlAttribute("isPermaLink")]
        public string IsPermaLink
        {
            get
            {
                return _isPermaLink; 
            }

            set
            {
                _isPermaLink = value; 
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
