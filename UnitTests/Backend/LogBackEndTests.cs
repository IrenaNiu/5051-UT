using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW1c.Backend;
using HW1c.Models;
using System.Linq;

namespace UnitTests.Backend
{
    [TestClass]
    public class LogBackendTests
    {
        [TestMethod]
        public void LogBackEnd_Index_Default_Should_Pass()
        {
            // Should load the dataset with 4 rows

            // Arange            
            var myViewModel = new LogViewModel();

            // Act
            myViewModel = LogBackend.Instance.Index();
            var result = myViewModel.LogList;

            // Assert
            Assert.AreEqual(4, result.Count);
        }



    }
}
