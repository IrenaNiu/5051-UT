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

        [TestMethod]
        public void LogBackEnd_Update_InValid_Bogus_Item_Should_Pass()
        {
            // Arange
            var myData = LogBackend.Instance.Index();
            var oldItem = myData.LogList.First();

            var newItem = new LogModel();
            newItem.ID = "bogus";

            // Act
            var result = LogBackend.Instance.Update(newItem);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void LogBackend_Delete_First_Item_Should_Pass()
        {
            // Delete the first item from the list, and then check the list to verify it is gone

            // Arange
            var myData = LogBackend.Instance.Index();

            // Get the first item from the list
            var oldItem = myData.LogList.First();

            // Act
            var result = LogBackend.Instance.Delete(oldItem.ID);
            var newItem = myData.LogList.First();

            // Assert
            Assert.AreNotEqual(oldItem.ID, newItem.ID);
        }

        [TestMethod]
        public void LogBackend_Delete_InValid_Bogus_Item_Should_Pass()
        {

            // Arange

            // Act
            var newItem = LogBackend.Instance.Delete("bogus");

            // Assert
            Assert.AreEqual(false, newItem);
        }


        [TestMethod]
        public void LogBackend_Read_Valid_Item_Should_Pass()
        {
            // Delete the first item from the list, and then check the list to verify it is gone

            // Arange
            var myData = LogBackend.Instance.Index();

            // Get the first item from the list
            var oldItem = myData.LogList.First();

            // Act
            var newItem = LogBackend.Instance.Read(oldItem.ID);

            // Check each item one by one to ensure it is correctly loaded

            // Assert
            Assert.AreEqual(oldItem.ID, newItem.ID);
            Assert.AreEqual(oldItem.PhoneID, newItem.PhoneID);
            Assert.AreEqual(oldItem.RecordedDateTime, newItem.RecordedDateTime);
            Assert.AreEqual(oldItem.Value, newItem.Value);
        }

        [TestMethod]
        public void LogBackend_Read_InValid_Bogus_Item_Should_Pass()
        {
            // Arange

            // Act
            var newItem = LogBackend.Instance.Read("bogus");

            // Assert
            Assert.AreEqual(null, newItem);
        }


    }
}
