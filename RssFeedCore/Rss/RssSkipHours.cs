using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RssService.Rss
{
    /// <summary>
    /// RssSkipHours
    /// </summary>
    [Serializable]
    public class RssSkipHours
    {
        private List<string> _hours;

        /// <summary>
        /// Gets or sets the hours.
        /// </summary>
        /// <value>The hours.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [XmlElement("hour")]
        public List<string> Hours
        {
            get 
            { 
                return _hours; 
            }

            set 
            { 
                _hours = value; 
            }
        }
    }
}
