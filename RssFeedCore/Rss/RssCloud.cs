using System;
using System.Xml.Serialization;

namespace RssService.Rss
{
    /// <summary>
    /// RssCloud
    /// </summary>
    [Serializable]
    public class RssCloud
    {
        private string _domain;
        private string _path;
        private string _port;
        private string _protocol;
        private string _registerProcedure;

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        /// <value>The domain.</value>
        [XmlAttribute("domain")]
        public string Domain
        {
            get
            { 
                return _domain; 
            }

            set 
            { 
                _domain = value; 
            }
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [XmlAttribute("path")]
        public string Path
        {
            get 
            { 
                return _path; 
            }

            set 
            { 
                _path = value; 
            }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        [XmlAttribute("port")]
        public string Port
        {
            get 
            { 
                return _port; 
            }

            set 
            {
                _port = value; 
            }
        }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
        [XmlAttribute("protocol")]
        public string Protocol
        {
            get 
            { 
                return _protocol; 
            }

            set 
            { 
                _protocol = value; 
            }
        }

        /// <summary>
        /// Gets or sets the register procedure.
        /// </summary>
        /// <value>The register procedure.</value>
        [XmlAttribute("registerProcedure")]
        public string RegisterProcedure
        {
            get 
            { 
                return _registerProcedure; 
            }

            set 
            { 
                _registerProcedure = value; 
            }
        }
    }
}
