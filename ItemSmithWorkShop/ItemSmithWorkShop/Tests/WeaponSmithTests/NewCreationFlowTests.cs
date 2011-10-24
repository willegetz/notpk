using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop.Tests.WeaponSmithTests
{
	[TestClass]
	public class NewCreationFlowTests
	{
		[TestMethod]
		public void TestCreateWeaponClass()
		{
			var weaponData = TempWeaponDictionary.GetWeaponData("Dagger");

			var dagger = new CreateWeapon(weaponData);

			Approvals.Approve(dagger.DisplayWeapon1());
		}

		[TestMethod]
		public void TestCreateDoubleWeaponWithNewClass()
		{
			var weaponData1 = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var weaponData2 = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var weapon = new CreateWeapon(weaponData1, weaponData2);

			Approvals.Approve(weapon.DisplayWeapon());
		}
	}
}
