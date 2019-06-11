﻿using System;
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

        [TestMethod]
        public void LogBackEnd_Update_First_Item_Should_Pass()
        {
            // Delete the first item from the list, and then check the list to verify it is gone

            // Arange
            var myData = LogBackend.Instance.Index();

            // Get the first item from the list
            var oldItem = myData.LogList.First();
            var oldPhoneID = oldItem.PhoneID;

            // Change the ID
            oldItem.PhoneID = "UpdatedPhone";

            // Act
            var result = LogBackend.Instance.Update(oldItem);
            var newItem = LogBackend.Instance.Read(oldItem.ID);

            // Assert
            Assert.AreNotEqual(oldPhoneID, newItem.PhoneID);
        }

    }
}
