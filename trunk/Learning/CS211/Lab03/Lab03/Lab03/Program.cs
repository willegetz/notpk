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
			var fileStream = new FileStream(@"C:\Documents and Settings\wgetz\Learning\CS211\Lab03\Lab03\Files\data.txt", FileMode.Open, FileAccess.Read);
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
			// Apparently, readline will consume the first line of the file.
			// Subsequent readlines after the first will take the next line after, etc.
			// This continues whilst the stream is open.
			// var blah = file.ReadLine();
//			var blah1 = file.ReadToEnd().Split('\r');

//			var name = file.ReadLine().Split(' ');
//			var age = file.ReadLine();
//			var sex = file.ReadLine();
//			var ssn = file.ReadLine().Split('-');
//			var studentNumber = file.ReadLine();
//			var course1 = file.ReadLine().Split(' ');
//			var course2 = file.ReadLine().Split(' ');
//			var course3 = file.ReadLine().Split(' ');

			var stuffs = file.ReadToEnd().Split(',');

			var studentProfile = new StudentProfile();
			string[] blah;
			foreach (var stuff in stuffs)
			{
				blah = stuff.ToString().Split("\r\n");
			}
		}
	}
}
