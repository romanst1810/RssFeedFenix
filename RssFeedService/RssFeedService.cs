using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace RssService
{
    public class OperationRequest
    {
        public string ItemId { get; set; }
        public string RssFeedUrl { get; set; }
    }
    public class OperationResult
    {
        public string ItemId { get; set; }
        public SyndicationFeed Result { get; set; }
        public SyndicationItem ItemResult { get; set; }
    }

    public interface IRssService
    {
        OperationResult Fetch(OperationRequest context);
        OperationResult FetchById(OperationRequest context);
    }
   
    public class RssFeedService : IRssService
    {
        public OperationResult Fetch(OperationRequest context)
        {
            if (context == null)
                throw new ArgumentException();
            SyndicationFeed sf = GetRssFeed(context);
            OperationResult opRes = GetOperationResult(sf);
            return opRes;
        }
        public OperationResult FetchById(OperationRequest context)
        {
            if (context == null)
                throw new ArgumentException();
            SyndicationItem siItem = GetRssFeedById(context);
            OperationResult opRes = GetOperationResultByItem(siItem);
            return opRes;
        }

        private SyndicationFeed GetRssFeed(OperationRequest context)
        {
            var r = XmlReader.Create(context.RssFeedUrl);
            SyndicationFeed sf = SyndicationFeed.Load(r);
            r.Close();
            return sf;
        }
        
        private OperationResult GetOperationResult(SyndicationFeed sf)
        {
            var opRes = new OperationResult()
            {
                Result = sf
            };
            return opRes;
        }

        private SyndicationItem GetRssFeedById(OperationRequest context)
        {
            var syndicationItem = new SyndicationItem();
            var r = XmlReader.Create(context.RssFeedUrl);
            SyndicationFeed sf = SyndicationFeed.Load(r);
            r.Close();
            foreach (var item in sf.Items)
            {
                if (item.Id == context.ItemId)
                {
                    syndicationItem = item;
                }
            }
            return syndicationItem;
        }
        private OperationResult GetOperationResultByItem(SyndicationItem sItem)
        {
            var opRes = new OperationResult()
            {
               ItemResult = sItem,
               ItemId = sItem.Id
            };
            return opRes;
        }
    }
}
