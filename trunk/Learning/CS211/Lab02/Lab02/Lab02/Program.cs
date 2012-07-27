using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab02
{
	class Program
	{
		static void Main(string[] args)
		{
			var V = new List<string>();

			BuildBeginningVector(V);

			var fileStream = new FileStream(@"C:\Users\William\Documents\Visual Studio 2010\NoTPK\trunk\Learning\CS211\Lab02\Lab02\Files\data.txt", FileMode.Open, FileAccess.Read);
			using (var file = new StreamReader(fileStream))
			{
				PerformTransaction(V, file);
				
			}

		}
		private static void BuildBeginningVector(List<string> V)
		{
			V.Add("In");
			V.Add("a");
			V.Add("hole");
			V.Add("in");
			V.Add("the");
			V.Add("ground");
			V.Add("there");
			V.Add("lived");
			V.Add("a");
			V.Add("hobbit.");
		}

		private static void PerformTransaction(List<string> v, StreamReader file)
		{
			string [] operationArray = new string [v.Count];

			while (!file.EndOfStream)
			{
				operationArray = file.ReadLine().ToString().Split('\t');
				ExecuteTransaction(v, operationArray);
			}
			var blah = operationArray.Length;
		}

		private static void ExecuteTransaction(List<string> v, string[] operationArray)
		{
			switch (operationArray[0])
			{
				case "Insert":
					PerformInsert(v, operationArray);
					break;
				case "Delete":
					PerformDelete(v, operationArray);
					break;
				case "Print":
					PerformPrint(v);
					break;
				default:
					break;
			}
		}
		private static void PerformInsert(List<string> v, string[] operationArray)
		{
			int insertIndex = int.Parse(operationArray[2]);
			if (insertIndex <= v.Count)
			{
				v.Insert(insertIndex, operationArray[1]);
			}
			else
			{
				v.Add(string.Format("Cannot insert: '{0}' at Index '{1}'\r\nThe list is '{2}' long", operationArray[1], insertIndex, v.Count));
			}
		}

		private static void PerformDelete(List<string> v, string[] operationArray)
		{
			int deleteIndex = int.Parse(operationArray[2]);
			if (deleteIndex <= v.Count)
			{
				v.RemoveAt(deleteIndex);
			}
			else
			{
				v.Add(string.Format("Cannot delete at Index '{0}'\r\nThe list is '{2}' long", deleteIndex, v.Count));
			}
		}

		private static void PerformPrint(List<string> v)
		{
			var sb = new StringBuilder();
			foreach (var item in v)
			{
				sb.Append(item + " ");
			}
			Console.WriteLine(sb.ToString());
			Console.ReadKey();
		}
	}
}
