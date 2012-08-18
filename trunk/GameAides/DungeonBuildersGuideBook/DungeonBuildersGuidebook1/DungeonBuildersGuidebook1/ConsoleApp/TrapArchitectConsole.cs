using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1
{
	class TrapArchitectConsole
	{
		public static int Main()
		{
			var blah = new TrapArchitect();
			List<string> trappedObjects = new List<string>();
			trappedObjects = TrapBasicsTable10a.GetObjectTrappedList();

			List<string> trapTraits = new List<string>();
			trapTraits = TrapEffectsTable10b.EffectsOfTrap();

			int objectIndex = 0;
			int effectIndex = 0;

			Console.Title = "Trap Architect";
			Console.WindowHeight = Console.LargestWindowHeight;
			Console.WindowWidth = Console.LargestWindowWidth;


			Console.WriteLine("Please select an object to be trapped (Roll Percentile dice for randomization)");
			for (int trap = 1; (trap - 1) < trappedObjects.Count; trap++)
			{
				Console.WriteLine(trap.ToString() + " - {0}", trappedObjects[(trap - 1)]);
			}
			Console.WriteLine();
			Console.WriteLine("Your choice: ");
			objectIndex = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.WriteLine("Please select a trap effect (Roll Percentile dice for randomization)");
			for (int effect = 1; (effect - 1) < trapTraits.Count; effect++)
			{
				Console.WriteLine(effect.ToString() + " - {0}", trapTraits[effect - 1]);
			}
			Console.WriteLine("Your choice: ");
			effectIndex = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.WriteLine("Your trap is:");
			Console.WriteLine("{0} {1}", trappedObjects[objectIndex - 1], trapTraits[effectIndex - 1]);

			Console.ReadKey();
			return 0;
		}
	}
}
