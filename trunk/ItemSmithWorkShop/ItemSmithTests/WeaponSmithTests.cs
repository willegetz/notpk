using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests.Reporters;
using ItemSmithWeaponSmith;
using ApprovalTests;

namespace ItemSmithTests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithTests
	{
		[TestMethod]
		public void TestDisplayDagger()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestProperNameDagger()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("One-eyed Bart's Shiv");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDmChangesPrice()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Expensive Dagger");
			dagger.WeaponCost(10);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestWeaponIsMasterWork()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			dagger.IsMasterworkQualifier(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSteelProperty()
		{
			SteelMaterial steel = new SteelMaterial();

			Approvals.Approve(steel);
		}

		[TestMethod]
		public void TestAdamantineProperty()
		{
			ItemSmithWeaponSmith.AdamantineMaterial adamantine = new ItemSmithWeaponSmith.AdamantineMaterial();

			Approvals.Approve(adamantine);
		}

		[TestMethod]
		public void TestDagger()
		{
			Dagger dagger = new Dagger();

			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSteelPropertyOnDagger()
		{
			Dagger dagger = new Dagger();
			MaterialComponent steel = new SteelMaterial();

			dagger.WeaponName("Dagger");
			dagger.WeaponMaterial(steel);
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAdamantinePropertyOnDagger()
		{
			Dagger dagger = new Dagger();
			MaterialComponent adamantine = new AdamantineMaterial();

			dagger.WeaponName("Dagger");
			dagger.WeaponMaterial(adamantine);
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMaterialPassedIntoConstructor()
		{
			MaterialComponent steel = new SteelMaterial();
			Dagger dagger = new Dagger(steel);
		}

		// Requires a Wooden Item.
		// Much more work needs to be done before this can happen.
		[Ignore]
		[TestMethod]
		public void TestDarkwoodPropertyOnWeapon()
		{

		}
	}
}
