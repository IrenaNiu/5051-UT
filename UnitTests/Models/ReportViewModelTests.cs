﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW1c.Models;
using System.Collections.Generic;

namespace UnitTests.Models
{
    [TestClass]
    public class ReportViewModelTests
    {
        [TestMethod]
        public void ReportViewModel_Instantiate_Default_Should_Pass()
        {
            // Arange

            // Act
            var result = new ReportViewModel();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReportViewModel_NumberOfUsers_Get_Default_Should_Pass()
        {
            // Arrange 
            var myTest = new ReportViewModel();

            // Act 
            var result = myTest.NumberOfUsers;

            // Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReportViewModel_NumberOfUsers_Set_Default_Should_Pass()
        {
            // Arrange 
            var myTest = new ReportViewModel();
            int myNumber = 5;

            // Act 
            myTest.NumberOfUsers = myNumber;
            var result = myTest.NumberOfUsers;

            // Assert 
            Assert.AreEqual(5, result);
        }

    }
}
