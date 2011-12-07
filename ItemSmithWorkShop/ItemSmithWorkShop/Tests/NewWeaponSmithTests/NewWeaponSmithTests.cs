using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using NewWeaponSmith;
using System.Text;
using Decorators;

namespace NewWeaponSmithTests
{
	[TestClass]
	public class NewWeaponSmithTests
	{
		[TestMethod]
		public void TestCreateDagger()
		{
			AdventureItem dagger = new AdventureWeapon("Dagger");
			var weaponDisplay = new StringBuilder();
			weaponDisplay.Append(string.Format("{0}: '{1}' gp", dagger.GetItemName(), dagger.GetCost()));
			Approvals.Approve(weaponDisplay.ToString());
		}

		[TestMethod]
		public void TestCreateMasterworkDagger()
		{
			AdventureItem dagger = new AdventureWeapon("Dagger");
			dagger = new Masterwork(dagger);

			var weaponDisplay = new StringBuilder();
			weaponDisplay.Append(string.Format("{0}: '{1}' gp", dagger.GetItemName(), dagger.GetCost()));
			Approvals.Approve(weaponDisplay.ToString());
		}
	}
}
