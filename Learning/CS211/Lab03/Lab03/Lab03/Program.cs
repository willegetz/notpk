using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab03
{
	class Program
	{
		static void Main(string[] args)
		{
			List<StudentProfile> StCollection = new List<StudentProfile>();
			var fileStream = new FileStream(@"C:\Users\William\Documents\Visual Studio 2010\NoTPK\trunk\Learning\CS211\Lab03\Lab03\Files\data.txt", FileMode.Open, FileAccess.Read);
			using (var file = new StreamReader(fileStream))
			{
				while (!file.EndOfStream)
				{
					AddStudent(StCollection, file);
				}	
			}
		}

		private static void AddStudent(List<StudentProfile> stCollection, StreamReader file)
		{
			var studentProfile = new StudentProfile();
		}
	}
}
