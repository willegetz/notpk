using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponSizing
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

		private List<string> SizeIndex { get; set; }
		private Dictionary<string, string[]> DamageScale { get; set; }
		private double[] SizeModification { get; set; }
		
		public string NewDamage { get; set; }
		public double Multiplier { get; set; }

		public WeaponSizing(string damage, string size)
		{
			SizeIndex = new List<string> { fine, diminutive, tiny, small, medium, large, huge, gargantuan, colossal };

			SizeModification = new[] { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 };

			string[] damage1D2 = new[] { "No Meaningful Damage", "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8" };
			string[] damage1D3 = new[] { "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6" };
			string[] damage1D4 = new[] { "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6" };
			string[] damage1D6 = new[] { "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6" };
			string[] damage2D4 = new[] { "1d2", "1d3", "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D8 = new[] { "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D10 = new[] { "1d3", "1d4", "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8" };
			string[] damage1D12 = new[] { "1d4", "1d6", "1d8", "1d10", "1d12", "3d6", "4d6", "6d6", "8d6" };
			string[] damage2D6 = new[] { "1d4", "1d6", "1d8", "1d10", "2d6", "3d6", "4d6", "6d6", "8d6" };

			DamageScale = new Dictionary<string, string[]>{
						 {"1d2", damage1D2}, {"1d3", damage1D3}, {"1d4", damage1D4}, {"1d6", damage1D6},
						 {"2d4", damage2D4}, {"1d8", damage1D8}, {"1d10", damage1D10}, {"1d12", damage1D12},
						 {"2d6", damage2D6},
			};

			if (DamageScale.ContainsKey(damage))
			{
				NewDamage = DamageScale[damage][SizeIndex.IndexOf(size)];
				Multiplier = SizeModification[SizeIndex.IndexOf(size)];
			}
			else
			{
				NewDamage = damage + " (No sizing info)";
				Multiplier = SizeModification[SizeIndex.IndexOf(size)];
			}

		}
	}
}