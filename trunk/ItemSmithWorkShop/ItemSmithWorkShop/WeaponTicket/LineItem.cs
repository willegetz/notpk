using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponTicket
{
	class LineItem
	{
		public virtual string WeaponHeadName()
		{
			return string.Empty;
		}

		public virtual string Category()
		{
			return string.Empty;
		}

		public virtual string ProficiencyRequirement()
		{
			return string.Empty;
		}

		public virtual string Damage()
		{
			return string.Empty;
		}
	}
}
