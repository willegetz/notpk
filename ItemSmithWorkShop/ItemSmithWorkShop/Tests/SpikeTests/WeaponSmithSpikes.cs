using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests.Reporters;
using ApprovalTests;

namespace ItemSmithWorkShop
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithSpikes
	{
		[Ignore]
		[TestMethod]
		public void TestWeaponHardnessHitPointsBySize()
		{
			Dictionary<string, double> hardnessHitPoints = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			double hardness = 10;
			double hitPoints = 20;

			hardnessHitPoints.Add("Fine", 0.0625);
			hardnessHitPoints.Add("Diminutive", 0.125);
			hardnessHitPoints.Add("Tiny", 0.25);
			hardnessHitPoints.Add("Small", 0.5);
			hardnessHitPoints.Add("Medium", 1);
			hardnessHitPoints.Add("Large", 2);
			hardnessHitPoints.Add("Huge", 4);
			hardnessHitPoints.Add("Gargantuan", 8);
			hardnessHitPoints.Add("Colossal", 16);

			foreach (var item in hardnessHitPoints)
			{
				sb.Append(String.Format("Original Hardness: {0}\tOriginal Hit Points: {1}\nWeapon Size: {2}\nNew Hardness: {3}\tNew Hit Points: {4}\n\n", hardness, hitPoints, item.Key, (hardness * item.Value), (hitPoints * item.Value)));
			}

			Approvals.Approve(sb);
		}

		[Ignore]
		[TestMethod]
		public void TestWeaponDamageBySize()
		{
			Dictionary<string, string> damage = new Dictionary<string, string>();

			damage.Add("Fine", "No Meaningful Damage");
			damage.Add("Diminutive", "1");
			damage.Add("Tiny", "1d2");
			damage.Add("Small", "1d3");
			damage.Add("Medium", "1d4");
			damage.Add("Large", "1d6");
			damage.Add("Huge", "1d8");
			damage.Add("Gargantuan", "2d6");
			damage.Add("Colossal", "3d6");

			List<KeyValuePair<string, string>> weaponDamage = new List<KeyValuePair<string, string>>();

			var sb = new StringBuilder();

			foreach (var item in damage)
			{
				weaponDamage.Add(item);
			}

			foreach (var item in weaponDamage)
			{
				sb.Append(String.Format("Index: {2}\tSize: {0}\tDamage: {1}\n", item.Key, item.Value, weaponDamage.IndexOf(item)));
			}

			Approvals.Approve(sb);
		}

		[Ignore]
		[TestMethod]
		public void TestDictionaryQuery()
		{
			string[] baseDamage = new[] { "1d2", "1d3", "1d4", "1d6", "2d4", "1d8", "1d10", "1d12", "2d6" };
			string[] sizeDesired = new[] { "Fine", "Diminutive", "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan", "Colossal" };

			ApprovalTests.Combinations.Approvals.ApproveAllCombinations(GetDamage, baseDamage, sizeDesired);
		}

		[Ignore]
		[TestMethod]
		public void TestWeightCalculationUsingHardnessHitPointModifiers()
		{
			//double[] weightModifiers = new[] { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 };

			double[] weaponWeights = new[] { 0.5, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15 };

			Dictionary<string, double> weightModifiers = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
			weightModifiers.Add("Fine", 0.0625);
			weightModifiers.Add("Diminutive", 0.125);
			weightModifiers.Add("Tiny", 0.25);
			weightModifiers.Add("Small", 0.5);
			weightModifiers.Add("Medium", 1);
			weightModifiers.Add("Large", 2);
			weightModifiers.Add("Huge", 4);
			weightModifiers.Add("Gargantuan", 8);
			weightModifiers.Add("Colossal", 16);

			var sb = new StringBuilder();

			foreach (var weight in weaponWeights)
			{
				foreach (var modifier in weightModifiers)
				{
					sb.Append(String.Format("Initial Weight for Medium Weapon: '{0}' pounds\t=>\t'<{1}>'\t'{2} pounds'\n", weight, modifier.Key, (weight * modifier.Value)));
				}
			}

			Approvals.Approve(sb);
		}

		public string GetDamage(string damage, string size)
		{
			const string fine = "Fine";
			const string diminutive = "Diminutive";
			const string tiny = "Tiny";
			const string small = "Small";
			const string medium = "Medium";
			const string large = "Large";
			const string huge = "Huge";
			const string gargantuan = "Gargantuan";
			const string colossal = "Colossal";

			Dictionary<string, int> sizing = new Dictionary<string, int>{
			{fine, 0}, {diminutive, 1}, {tiny, 2}, {small, 3}, {medium, 4}, {large, 5}, {huge, 6}, {gargantuan, 7}, {colossal, 8}};

			int sizingIndex = sizing[size];

			string[] damage1D2 = new[] { "No Meaningful Damage", "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8" };
			string[] damage1D3 = new[] { "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6" };
			string[] damage1D4 = new[] { "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6" };
			string[] damage1D6 = new[] { "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6" };
			string[] damage2D4 = new[] { "1d2", "1d3", "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D8 = new[] { "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D10 = new[] { "1d3", "1d4", "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8" };
			string[] damage1D12 = new[] { "1d4", "1d6", "1d8", "1d10", "1d12", "3d6", "4d6", "6d6", "8d6" };
			string[] damage2D6 = new[] { "1d4", "1d6", "1d8", "1d10", "2d6", "3d6", "4d6", "6d6", "8d6" };

			Dictionary<string, string[]> sizeModification = new Dictionary<string, string[]>{
						 {"1d2", damage1D2}, {"1d3", damage1D3}, {"1d4", damage1D4}, {"1d6", damage1D6},
						 {"2d4", damage2D4}, {"1d8", damage1D8}, {"1d10", damage1D10}, {"1d12", damage1D12},
						 {"2d6", damage2D6}
			};

			return sizeModification[damage][sizingIndex].ToString();
		}
	}

	public class Sizing
	{
		// Original Damage Value is Key to the Second Dictionary whose key is Size

		// Key is the Size
		// Keys { "Fine", "Diminutive", "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan", "Colossal" }

		// Weight Value is the original value multiplied by the adjustment modifier
		// { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 }

		// Hardness Value is the original value multiplied by the adjustment modifier
		// { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 }

		// Hit Point Value is the original value multiplied by the adjustment modifier
		// { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 }

		// Cost Value is the original value multiplied by the adjustment modifier
	}
}
