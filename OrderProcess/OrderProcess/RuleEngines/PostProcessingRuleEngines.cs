using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProcess.Intefaces;
using OrderProcess.Models;

namespace OrderProcess.RuleEngines
{
    public class PhysicalProductRules:IPostprocessingRule
    {
        public bool IsApplicable(Product product)
        {
            bool evl = false;
            try
            {
                if (product != null)
                {
                    if (product.ProductType == ProductType.Physical)
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
            return new string[]{"Generated packing slip for shipping","Generated commission payment for agent"};
        }
    }

    public class BookProductRules : IPostprocessingRule
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
            return new string[] { "Created duplicate packing slip for royalty department", "Generated commission payment for agent" };
        }
    }

    public class MembershipProductRules : IPostprocessingRule
    {
        public bool IsApplicable(Product product)
        {
            bool evl = false;
            try
            {
                if (product != null)
                {
                    if (product.ProductType == ProductType.Membership)
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
            return new string[] { "Activated the membership.", "email has sent to owner for activation." };
        }
    }

    public class MembershipUpgradeProductRules : IPostprocessingRule
    {
        public bool IsApplicable(Product product)
        {
            bool evl = false;
            try
            {
                if (product != null)
                {
                    if (product.ProductType == ProductType.MembershipUpgrade)
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
            return new string[] { "Upgraded the membership.", "email has sent to owner for Membership upgrade." };
        }
    }

    public class VideoRule : IPostprocessingRule
    {
        public bool IsApplicable(Product product)
        {
            bool evl = false;
            try
            {
                if (product != null)
                {
                    if (product.ProductType == ProductType.Video)
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
            return new string[] { "First Add video added with packing slip." };
        }
    }

    public class PostOpsEvaluator
    {
        public PostOpsEvaluator(IEnumerable<IPostprocessingRule> rules)
        {
            Rules = rules;
        }

        private IEnumerable<IPostprocessingRule> Rules { get; }

        public List<string> Execute(Product product)
        {
            List<string> res=new List<string>();
            foreach (IPostprocessingRule rule in Rules)
            {
                if (rule.IsApplicable(product))
                {
                    res.AddRange(rule.Execute());
                }
            }

            return res;
        }
    }
}