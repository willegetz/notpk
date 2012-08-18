using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1
{
	public static class TrapBasicsTable10a
	{
		private static List<string> objectTrapped = new List<string>();
		private static List<string> eitherMagicOrMechanical = new List<string>();

		private static void LoadTrappedObjects()
		{
			//objectTrapped.Add("The air itself");
			//objectTrapped.Add("The alcove");
			//objectTrapped.Add("The altar");
			//objectTrapped.Add("The aquarium");
			//objectTrapped.Add("The arch");
			//objectTrapped.Add("The armoire");
			//objectTrapped.Add("The armor");
			//objectTrapped.Add("The balcony");
			//objectTrapped.Add("The barrel");
			//objectTrapped.Add("The basin");
			//objectTrapped.Add("The bathtub");
			//objectTrapped.Add("The bed");
			//objectTrapped.Add("The bell");
			//objectTrapped.Add("The bookcase");
			//objectTrapped.Add("The brazier");
			//objectTrapped.Add("The bridge");
			//objectTrapped.Add("The button/switch");
			//objectTrapped.Add("The cabinet");
			//objectTrapped.Add("The cage");
			//objectTrapped.Add("The caldron");
			//objectTrapped.Add("The candelabra");
			//objectTrapped.Add("The cask");
			//objectTrapped.Add("The catwalk");
			//objectTrapped.Add("The ceiling");
			//objectTrapped.Add("The ceiling fan");
			//objectTrapped.Add("The chair");
			//objectTrapped.Add("The chandelier");
			//objectTrapped.Add("The chest");
			//objectTrapped.Add("The chute");
			//objectTrapped.Add("The column");
			//objectTrapped.Add("The crate");
			//objectTrapped.Add("The crystal ball");
			//objectTrapped.Add("The dais");
			//objectTrapped.Add("The desk");
			//objectTrapped.Add("The divan");
			//objectTrapped.Add("The door");
			//objectTrapped.Add("The concealed door");
			//objectTrapped.Add("The secret door");
			//objectTrapped.Add("The drum");
			//objectTrapped.Add("The elevator");
			//objectTrapped.Add("The escalator");
			//objectTrapped.Add("The fireplace");
			//objectTrapped.Add("The floor");
			//objectTrapped.Add("The forcefield");
			//objectTrapped.Add("The fountain");
			//objectTrapped.Add("The fresco");
			//objectTrapped.Add("The furnace");
			//objectTrapped.Add("The glass case");
			//objectTrapped.Add("The harp");
			//objectTrapped.Add("The holy/unholy font");
			//objectTrapped.Add("The hook");
			//objectTrapped.Add("The hourglass");
			//objectTrapped.Add("The idol");
			//objectTrapped.Add("The illusion");
			//objectTrapped.Add("The interdimensional portal");
			//objectTrapped.Add("The iron maiden");
			//objectTrapped.Add("The jar");
			//objectTrapped.Add("The lamp");
			//objectTrapped.Add("The ladder");
			//objectTrapped.Add("The lectern");
			//objectTrapped.Add("The lever");
			//objectTrapped.Add("The magic circle");
			//objectTrapped.Add("The manacles");
			//objectTrapped.Add("The mirror");
			//objectTrapped.Add("The mosaic");
			//objectTrapped.Add("The organ");
			//objectTrapped.Add("The painting");
			//objectTrapped.Add("The passage");
			//objectTrapped.Add("The pedestal");
			//objectTrapped.Add("The pendulum");
			//objectTrapped.Add("The pews");
			//objectTrapped.Add("The pillar");
			//objectTrapped.Add("The pit");
			//objectTrapped.Add("The pool");
			//objectTrapped.Add("The portcullis");
			//objectTrapped.Add("The railing");
			//objectTrapped.Add("The room");
			//objectTrapped.Add("The Rug");
			//objectTrapped.Add("The inset shelf");
			//objectTrapped.Add("The slide");
			//objectTrapped.Add("The sliding walkway");
			//objectTrapped.Add("The stairway");
			//objectTrapped.Add("The statue");
			//objectTrapped.Add("The stuffed animal/head");
			//objectTrapped.Add("The table");
			//objectTrapped.Add("The tapestry");
			//objectTrapped.Add("The telescope");
			//objectTrapped.Add("The throne");
			//objectTrapped.Add("The trophy");
			//objectTrapped.Add("The trunk");
			//objectTrapped.Add("The tunnel mouth");
			//objectTrapped.Add("The urn");
			//objectTrapped.Add("The vase");
			//objectTrapped.Add("The vegetation");
			//objectTrapped.Add("The waterclock");
			//objectTrapped.Add("The wall");
			//objectTrapped.Add("The weapon");
			//objectTrapped.Add("The well");
			//objectTrapped.Add("The wheel");
			//objectTrapped.Add("The window");
	   }

		private static void LoadMagicOrMechanicalList()
		{
			eitherMagicOrMechanical.Add("Elevator");
			eitherMagicOrMechanical.Add("Escalator");
			eitherMagicOrMechanical.Add("Sliding walkway");
			eitherMagicOrMechanical.Add("Telescope");
		}

		public static List<string> GetObjectTrappedList()
		{
			LoadTrappedObjects();
			return objectTrapped;
		}

		public static List<string> GetMagicalOrMechanicalList()
		{
			LoadMagicOrMechanicalList();
			return eitherMagicOrMechanical;
		}
	}
}
