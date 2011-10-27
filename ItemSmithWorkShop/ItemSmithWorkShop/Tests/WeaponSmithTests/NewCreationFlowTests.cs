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

			var ticket = new WeaponTicket();
			ticket.AddLineItem(new WeaponHead("dagger"));
			ticket.AddLineItem(new AdamantineMaterial());
			ticket.AddLineItem(new ...?);

			public class LineItem
			{
			     public virtual string GetDice()
				 {
				 	return string.Empty;
				 }
			}

			Approvals.Approve(ticket);

			dagger.SizeAdjustment("Medium");
			dagger.ManipulatePrice(0);
			dagger.ProduceFinalWeapon();

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
