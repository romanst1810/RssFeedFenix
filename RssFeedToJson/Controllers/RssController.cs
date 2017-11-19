using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RssService;
using RssService.Rss;

namespace RssFeedToJson.Controllers
{
    public class RssController : ApiController
    {
        IRssService _service;

        public RssController() : this(new RssFeedService())
        {
        }

        public RssController(IRssService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public List<RssItem> GetRssFeed(OperationRequest request)
        {
            try
            {
                var result = _service.Fetch(request);
                return result.Result.Channel.Items;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
