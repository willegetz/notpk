using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponUtilities
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

		private static Dictionary<string, Dictionary<string, string>> NewDamage;
		private static Dictionary<string, double> ScaleMultiplier;
		
		public string AlteredDamage { get; set; }
		public double AlteredMultiplier { get; set; }

		public WeaponSizing()
		{
			ScaleMultiplier = new Dictionary<string, double>
			{
				{ fine, 0.0625 }, { diminutive, 0.125 }, { tiny, 0.25 }, { small, 0.5 }, { medium, 1 }, { large, 2 }, { huge, 4 }, { gargantuan, 8 }, { colossal, 16 },
			};

			Dictionary<string, string> damage1D2 = new Dictionary<string, string>
			{
				{ fine, "No Meaningful Damage" }, { diminutive, "No Meaningful Damage" }, { tiny, "No Meaningful Damage" },
				{ small, "1" }, { medium, "1d2" }, { large, "1d3" }, { huge, "1d4" }, { gargantuan, "1d6" }, { colossal, "1d8" },
			};
			Dictionary<string, string> damage1D3 = new Dictionary<string, string>
			{
				{ fine, "No Meaningful Damage" }, { diminutive, "No Meaningful Damage" }, { tiny, "1" },
				{ small, "1d2" }, { medium, "1d3" }, { large, "1d4" }, { huge, "1d6" }, { gargantuan, "1d8" }, { colossal, "2d6" },
			}; 
			Dictionary<string, string> damage1D4 = new Dictionary<string, string>
			{
				{ fine, "No Meaningful Damage" }, { diminutive, "1" }, { tiny, "1d2" },
				{ small, "1d3" }, { medium, "1d4" }, { large, "1d6" }, { huge, "1d8" }, { gargantuan, "2d6" }, { colossal, "3d6" },
			};
			Dictionary<string, string> damage1D6 = new Dictionary<string, string>
			{
				{ fine, "1" }, { diminutive, "1d2" }, { tiny, "1d3" },
				{ small, "1d4" }, { medium, "1d6" }, { large, "1d8" }, { huge, "2d6" }, { gargantuan, "3d6" }, { colossal, "4d6" },
			};
			Dictionary<string, string> damage2D4 = new Dictionary<string, string>
			{
				{ fine, "1d2" }, { diminutive, "1d3" }, { tiny, "1d4" },
				{ small, "1d6" }, { medium, "2d4" }, { large, "2d6" }, { huge, "3d6" }, { gargantuan, "4d6" }, { colossal, "6d6" },
			};
			Dictionary<string, string> damage1D8 = new Dictionary<string, string>
			{
				{ fine, "1d2" }, { diminutive, "1d3" }, { tiny, "1d4" },
				{ small, "1d6" }, { medium, "1d8" }, { large, "2d6" }, { huge, "3d6" }, { gargantuan, "4d6" }, { colossal, "6d6" },
			};
			Dictionary<string, string> damage1D10 = new Dictionary<string, string>
			{
				{ fine, "1d3" }, { diminutive, "1d4" }, { tiny, "1d6" },
				{ small, "1d8" }, { medium, "1d10" }, { large, "2d8" }, { huge, "3d8" }, { gargantuan, "4d8" }, { colossal, "6d8" },
			};
			Dictionary<string, string> damage1D12 = new Dictionary<string, string>
			{
				{ fine, "1d4" }, { diminutive, "1d6" }, { tiny, "1d8" },
				{ small, "1d10" }, { medium, "1d12" }, { large, "3d6" }, { huge, "4d6" }, { gargantuan, "6d6" }, { colossal, "8d6" },
			};
			Dictionary<string, string> damage2D6 = new Dictionary<string, string>
			{
				{ fine, "1d4" }, { diminutive, "1d6" }, { tiny, "1d8" },
				{ small, "1d10" }, { medium, "2d6" }, { large, "3d6" }, { huge, "4d6" }, { gargantuan, "6d6" }, { colossal, "8d6" },
			};

			NewDamage = new Dictionary<string, Dictionary<string, string>>
			{
				{ "1d2", damage1D2 }, { "1d3", damage1D3 }, { "1d4", damage1D4 }, { "1d6", damage1D6 },
				{ "2d4", damage2D4 }, { "1d8", damage1D8 }, { "1d10", damage1D10 }, { "1d12", damage1D12 },
				{ "2d6", damage2D6 },
			};
		}

		public void SetSizingValues(string damage, string size)
		{
			if (NewDamage.ContainsKey(damage))
			{
				GetNewSizingData(damage, size);
			}
			else if (string.IsNullOrEmpty(damage))
			{
				GetNullSizingData();
			}
			else
			{
				GetOutOfRangeSizingData(damage, size);
			}
		}

		public void GetNewSizingData(string damage, string size)
		{
			AlteredDamage = NewDamage[damage][size];
			AlteredMultiplier = ScaleMultiplier[size];
		}

		public void GetNullSizingData()
		{
			AlteredDamage = "";
			AlteredMultiplier = 0;
		}

		public void GetOutOfRangeSizingData(string damage, string size)
		{
			int stringIndex;
			var multiHeadString = new StringBuilder();
			string[] multiHeadedWeapon = damage.Split('/');

			foreach (var item in multiHeadedWeapon)
			{
				string index = item.ToString();
				multiHeadString.Append(NewDamage[index][size] + "/");
			}

			stringIndex = multiHeadString.Length - 1;
			multiHeadString.Remove(stringIndex, 1);
			AlteredDamage = multiHeadString.ToString();
			AlteredMultiplier = ScaleMultiplier[size];
		}

		internal void SetSizingValues(WeaponData data, string size)
		{
			SetSizingValues(data.WeaponDamage, size);

			data.WeaponDamage = AlteredDamage;

			if (size == "Small")
			{
				data.BasePrice = data.BasePrice;
			}
			else
			{
				data.BasePrice = data.BasePrice * AlteredMultiplier;
			}
			
			if ((data.WeaponHardness * AlteredMultiplier) <= 1)
			{
				data.WeaponHardness = Math.Ceiling(data.WeaponHardness * AlteredMultiplier);
			}
			else
			{
				data.WeaponHardness = data.WeaponHardness * AlteredMultiplier;
			}

			if ((data.WeaponHitPoints * AlteredMultiplier) <= 1)
			{
				data.WeaponHitPoints = Math.Ceiling(data.WeaponHitPoints * AlteredMultiplier);
			}
			else
			{
				data.WeaponHitPoints = data.WeaponHitPoints * AlteredMultiplier;
			}
		}
	}
}