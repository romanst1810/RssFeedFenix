using System;
using System.Collections.Generic;
using System.Linq;
using RssService.Rss;

namespace RssService
{
    // All Classes , Interfaces in One Class For Understanding.
    public class OperationInfo
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public interface IRssService
    {
        IEnumerable<OperationInfo> GetOperations();
        OperationResult Fetch(OperationRequest context);
    }

    public class OperationRequest
    {
        public string OperationId { get; set; }
        public string RssFeedUrl { get; set; }
        public string RssFeedXml { get; set; }

        public OperationRequest()
        {
            RssFeedUrl = "http://www.economist.com/sections/obituary/rss.xml";
            RssFeedXml = string.Empty;
        }
    }

    public class OperationResult
    {
        public string OperationId { get; set; }
        public RssDocument Result { get; set; }
    }

    public interface IOperation<TIn, TOut>
    {
        bool CanExecute(TIn context);
        TOut Execute(TIn context);
    }

    public interface IRssOperation : IOperation<OperationRequest, RssDocument>
    {
        string Code { get; }
    }

    //public interface IRssOpertionFactory
    //{
    //    IRssOperation Create(string operationId);
    //}

    public class RssFeedService : IRssService
    {
        private IEnumerable<IRssOperation> Operations;
       // private IRssOpertionFactory Factory;

        public RssFeedService()
        {
            Operations = new IRssOperation[] { new LoadFromUrlOperation() , new LoadFromXmlOperation() };
        }

        public RssFeedService(IEnumerable<IRssOperation> operation)
        {
            this.Operations = operation;
        }

        public IEnumerable<OperationInfo> GetOperations()
        {
            return Operations.Select(x => new OperationInfo()
            {
                Id = x.Code
            }).ToArray();
        }

        public OperationResult Fetch(OperationRequest context)
        {
            var operation = Operations.FirstOrDefault(x => x.CanExecute(context));
            if (operation == null)
            {
                throw new NotSupportedException();
            }
            var result = new OperationResult()
            {
                OperationId = operation.Code,
                Result = operation.Execute(context)
            };
            return result;
        }
    }

    public abstract class OperationBase : IRssOperation
    {
        protected OperationBase(string opertion)
        {
            Code = opertion;
        }
        public bool CanExecute(OperationRequest context)
        {
            return context != null && context.OperationId == Code;
        }
        public abstract RssDocument Execute(OperationRequest context);
        public string Code { get; private set; }
    }

    public class LoadFromUrlOperation : OperationBase
    {
        public LoadFromUrlOperation() : base("LoadFromUrl")
        {
        }
        public override RssDocument Execute(OperationRequest context)
        {
            if (context == null)
                throw new ArgumentException();
            var xml = RssDocument.Load(context.RssFeedUrl);
            return xml;
        }
    }

    public class LoadFromXmlOperation : OperationBase
    {
        public LoadFromXmlOperation() : base("LoadFromXml")
        {
        }

        public override RssDocument Execute(OperationRequest context)
        {
            if (context == null)
                throw new ArgumentException();
            var xml = RssDocument.LoadFromXml(context.RssFeedUrl);
            return xml;
        }
    }
}
