using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace RefactorMe.Tests
{
    [TestClass]
    public class UnitTest_ProductDataConsolidator
    {
        [TestMethod]
        public void DataCount()
        {
            var items = ProductDataConsolidator.Get().ToList();
            Assert.IsTrue(items.Count() == 8);
            var itemsInEuros = ProductDataConsolidator.GetInEuros().ToList();
            Assert.IsTrue(itemsInEuros.Count() == 8);
            var itemsInUSDollars = ProductDataConsolidator.GetInUSDollars().ToList();
            Assert.IsTrue(itemsInUSDollars.Count() == 8);
        }

        [TestMethod]
        public void DataInEuros() 
        {
            var isTestPassed = true;
            var items = ProductDataConsolidator.Get().ToList();
            var itemsInEuros = ProductDataConsolidator.GetInEuros().ToList();
            foreach (var item in items) 
            {
                if ((item.Price * 0.67) != itemsInEuros.FirstOrDefault(x => x.Name == item.Name).Price)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void DataInUSDollars()
        {
            var isTestPassed = true;
            var items = ProductDataConsolidator.Get().ToList();
            var itemsInUSDollars = ProductDataConsolidator.GetInUSDollars().ToList();
            foreach (var item in items)
            {
                if ((item.Price * 0.76) != itemsInUSDollars.FirstOrDefault(x => x.Name == item.Name).Price)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
    }
}
