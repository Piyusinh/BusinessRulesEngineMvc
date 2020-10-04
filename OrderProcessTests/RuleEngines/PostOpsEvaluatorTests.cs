using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcess.RuleEngines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcess.Intefaces;
using OrderProcess.Models;

namespace OrderProcess.RuleEngines.Tests
{
    [TestClass()]
    public class PostOpsEvaluatorTests
    {
        [TestMethod()]
        public void PostOpsEvaluatorTest()
        {
            List<IPostprocessingRule> postprocessingRules = new List<IPostprocessingRule> {new BookProductRules()};
            PostOpsEvaluator postOpsEvaluator=new PostOpsEvaluator(postprocessingRules); 
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).Count == 2);
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).FirstOrDefault() == "Created duplicate packing slip for royalty department");
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).Last() == "Generated commission payment for agent");
        }
        [TestMethod()]
        public void PostOpsEvaluatorWithExtendedNewRuleTest()
        {
            List<IPostprocessingRule> postprocessingRules = new List<IPostprocessingRule> { new BookProductRules(),new NewBookProductRules()};
            PostOpsEvaluator postOpsEvaluator = new PostOpsEvaluator(postprocessingRules);
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).Count == 3);
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).FirstOrDefault() == "Created duplicate packing slip for royalty department");
            Assert.IsTrue(postOpsEvaluator.Execute(new Product("1")).Last() == "New Rule Applied");
        }
    }
    public class NewBookProductRules : IPostprocessingRule
    {
        public bool IsApplicable(Product product)
        {
            bool evl = false;
            try
            {
                if (product != null)
                {
                    if (product.ProductType == ProductType.Book)
                    {
                        evl = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return evl;
        }

        public string[] Execute()
        {
            return new string[] { "New Rule Applied"};
        }
    }
}