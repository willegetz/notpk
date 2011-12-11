using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;

namespace ItemSmithWorkShop.Tests.AdventureItemsTests
{
	[TestClass]
	public class WeaponItemExceptionTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestWeaponNameEmptyThrowsError()
		{
			WeaponItemSmith.OrderItem(string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void TestWeaponNotInListThrowsException()
		{
			WeaponItemSmith.OrderItem("Awesome Blade");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestMagicEnhancementLessThanOneThrowsError()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			new MagicWeaponItem(weapon, -1);
		}
	}
}
