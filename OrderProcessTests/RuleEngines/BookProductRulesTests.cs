using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcess.RuleEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcess.Models;

namespace OrderProcess.RuleEngines.Tests
{
    [TestClass()]
    public class BookProductRulesTests
    {
        [TestMethod()]
        public void IsApplicableTest()
        {
            Product p=new Product("1");
            Assert.Equals(p.ProductType,ProductType.Book);
            BookProductRules bookProductRules =new BookProductRules();
            Assert.IsTrue(bookProductRules.IsApplicable(p));
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Product p = new Product("1"); 
            BookProductRules bookProductRules = new BookProductRules();
            Assert.IsTrue(bookProductRules.Execute().Length==2);
            Assert.IsTrue(bookProductRules.Execute().FirstOrDefault() == "Created duplicate packing slip for royalty department");
            Assert.IsTrue(bookProductRules.Execute().Last() == "Generated commission payment for agent");
        }
    }
}