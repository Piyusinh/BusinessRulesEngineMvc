using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using OrderProcess.Controllers;
using OrderProcess.Intefaces;
using OrderProcess.Models;
using OrderProcess.RuleEngines;

namespace OrderProcess.ProcessingModule
{
    public class PostPaymentService : PostPaymentAnalyzerServiceBase, IPostPaymentService
    {
        public string StartPostPaymentAction(string id)
        {
            Product product=new Product(id);
            List<IPostprocessingRule> iPostprocessingRules = new List<IPostprocessingRule>()
            {
                new BookProductRules(),new MembershipProductRules(),new MembershipUpgradeProductRules(),new PhysicalProductRules(),new VideoRule()

            };
           return String.Join(",", new PostOpsEvaluator(iPostprocessingRules).Execute(product)); 
        }
    }

    public interface IPostPaymentService: IPostPaymentAnalyzerService
    {
        string StartPostPaymentAction(string id);
    }

    public interface IPostPaymentAnalyzerService
    {
        void Register(IBaseController controller);
    } 
    public abstract class PostPaymentAnalyzerServiceBase : IPostPaymentAnalyzerService
    {
        private IBaseController _controller;
        protected IBaseController Controller { get { return _controller; } }
        public void Register(IBaseController controller)
        {
            this._controller = controller;
        }
    }
}