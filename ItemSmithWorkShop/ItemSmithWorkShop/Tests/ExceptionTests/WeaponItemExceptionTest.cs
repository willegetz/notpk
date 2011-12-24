﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;
using MagicWeaponUtilities;

namespace ItemSmithWorkShop.Tests.ExceptionTests
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

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestExtraordinaryNameEmptyThrowsError()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItemSmith.OrderSpecialComponent(weapon, string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void TestExtraordinaryComponentNotInListThrowsException()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItemSmith.OrderSpecialComponent(weapon, "Shiny Thing");
		}
	}
	// Include cs test files, not approvals.
}
