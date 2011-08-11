using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests.Reporters;
using ApprovalTests;

namespace TestProject1
{
    [UseReporter(typeof(DiffReporter))]
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestItemName()
        {
            // Start a new item view
            Item item = new Item();
            // Get an item name
            item.ItemName = "Dagger";

            Approvals.Approve(item);
        }

        [TestMethod]
        public void TestDisplayItemStatistics()
        {
            Item item = new Item();
            // Given the item name
            // Display the item's Statistics
        	string itemName = "Dagger";
        	string itemCost = "2 cp";
        	string itemBaseDamage = "1d4";
        	string itemThreatRange = "20";
        	string itemDamageType = "Piercing or Slashing";
            item.GetItemStatistics(itemName, itemCost, itemBaseDamage, itemDamageType, itemThreatRange);

            Approvals.Approve(item);
        }
    }
}
