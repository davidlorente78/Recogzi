using System.IO;

namespace Recogzi.FileWriters
{
	public static class FileWriter
	{

		static string path = @"C:\Users\dlorente\Desktop\RecogZi\dataset.csv";

		public static void AddLine(string line)
		{
			if (!File.Exists(path))
			{
				using (StreamWriter tw = File.CreateText(path))
				{
					tw.WriteLine(line);
					tw.Close();
				}
			}
			else if (File.Exists(path))
			{
				using (StreamWriter tw = File.AppendText(path))
				{
					tw.WriteLine(line);
					tw.Close();
				}
			}
		}
	}
}
