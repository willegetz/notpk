﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class SpecialAbilityRequestTests
	{
		[TestMethod]
		public void TestRequestSpecialAbility()
		{
			var specialAbility = ItemTicket.GetSpecialAbilityTicket("Flaming");
			Approvals.Approve(specialAbility);
		}
	}
}
