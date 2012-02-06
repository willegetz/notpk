using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class SizeDictionary
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

		const string d0 = "No Meaningful Damage";
		const string d1 = "1";
		private const string d2 = "1d2";
		private const string d3 = "1d3";
		private const string d4 = "1d4";
		private const string d6 = "1d6";
		private const string d2d4 = "2d4";
		private const string d8 = "1d8";
		private const string d10 = "1d10";
		private const string d12 = "1d12";
		private const string d2d6 = "2d6";

		private static Dictionary<string, double> sizeModifier;

		private Dictionary<string, string> sizedDamage;
		private static Dictionary<string, string> fineDamage;
		private static Dictionary<string, string> diminutiveDamage;
		private static Dictionary<string, string> tinyDamage;
		private static Dictionary<string, string> smallDamage;


		static SizeDictionary()
		{
			LoadSizeDictionaries();
		}

		private static void LoadSizeDictionaries()
		{
			sizeModifier = new Dictionary<string, double>()
			{
				{ fine, 0.0625 }, { diminutive, 0.125 }, { tiny, 0.25 }, { small, 0.5 }, { medium, 1 }, { large, 2 }, { huge, 4 }, { gargantuan, 8 }, { colossal, 16 },
			};

			fineDamage = new Dictionary<string, string>()
			{
				{d2, d0}, {d3, d0}, {d4, d0}, {d6, d1}, {d2d4, d2}, {d8, d2}, {d10, d3}, {d12, d4}, {d2d6, d4}
			};

			diminutiveDamage = new Dictionary<string, string>()
			{
				{d2, d0}, {d3, d0}, {d4, d1}, {d6, d2}, {d2d4, d3}, {d8, d3}, {d10, d4}, {d12, d6}, {d2d6, d6}
			};

			tinyDamage = new Dictionary<string, string>()
			{
				{d2, d0}, {d3, d1}, {d4, d2}, {d6, d3}, {d2d4, d4}, {d8, d4}, {d10, d6}, {d12, d8}, {d2d6, d8}
			};

			smallDamage = new Dictionary<string, string>()
			{
				{d2, d1}, {d3, d2}, {d4, d3}, {d6, d4}, {d2d4, d6}, {d8, d6}, {d10, d8}, {d12, d10}, {d2d6, d10}
			};
		}
	}
}
