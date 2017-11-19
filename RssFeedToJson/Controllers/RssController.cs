using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Web.Http;
using RssService;


namespace RssFeedToJson.Controllers
{
    public class RssController : ApiController
    {
        IRssService _service;
        public string RssUrl { get; set; }

        public RssController() : this(new RssFeedService())
        {
        }

        public RssController(IRssService service)
        {
            _service = service;
            RssUrl = "http://www.economist.com/sections/obituary/rss.xml";
        }
        
        [HttpGet]
        public IEnumerable<SyndicationItem> GetRssFeed()
        {
            try
            {
                var request = new OperationRequest()
                {
                    RssFeedUrl = RssUrl
                };
                OperationResult or = _service.Fetch(request);
                SyndicationFeed result = or.Result;
                return result.Items;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public SyndicationItem GetRssFeedById(OperationRequest request)
        {
            try
            {
                OperationResult or = _service.FetchById(request);
                SyndicationItem result = or.ItemResult;
                return result;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
