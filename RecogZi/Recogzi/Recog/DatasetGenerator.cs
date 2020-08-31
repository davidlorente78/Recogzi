using DomainServices;
using HSK;
using Recogzi.FileWriters;
using SubripServices;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Recogzi
{
    public class DatasetGenerator
	{
		public static string datasetPath = @"C:\Users\dlorente\Desktop\RecogZi\dataset.csv";
		public static string ToZerosOnesSequence(char c, Bitmap bitmap)
		{
			int R = Color.Black.R;
			int V = Color.Black.G;
			int A = Color.Black.B;
			int AA = Color.Black.A;

			StringBuilder sb = new StringBuilder();
			sb.Append(c.ToString() + ",");

			for (int i = bitmap.Width - 1; i >= 0; i--)
			{
				for (int j = bitmap.Height - 1; j >= 0; j--)
				{
					Color color = bitmap.GetPixel(i, j);

					if ((((R == color.R) && (color.G == V) && (A == color.B) && (color.A == AA))))
					{
						sb.Append("1,");
					}
					else sb.Append("0,");
				}

			}

			sb.Remove(sb.Length - 1, 1); //Remove last ,					
			return sb.ToString();
		}

		public static void GenerateDataSet(int level)
		{

			ArrayList all = new ArrayList();

			DictionaryService dictionaryService = new DictionaryService();

			for (int i = 1; i <= level; i++)
			{
				ArrayList words = dictionaryService.GetAllWords(i);
				all.AddRange(words);
			}

			ArrayList chars = new ArrayList();

			foreach (Word w in all)
			{
				foreach (Char c in w.Character)
				{
					if (!chars.Contains(c))
					{
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new Size(32, 32), 28, "DengXian", FontStyle.Regular);
						var sequence = ToZerosOnesSequence(c, Projection.Bitmap);
						FileWriter.AddLine(sequence, datasetPath);
					}
				}
			}

			foreach (Word w in all)
			{
				foreach (Char c in w.Character)
				{
					if (!chars.Contains(c))
					{
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new Size(32, 32), 28, "DengXian Light", FontStyle.Regular);
						var sequence = ToZerosOnesSequence(c, Projection.Bitmap);
						string path = @"C:\Users\dlorente\Desktop\RecogZi\dataset.csv";
						FileWriter.AddLine(sequence, path);
					}
				}
			}

			foreach (Word w in all)
			{
				foreach (Char c in w.Character)
				{
					if (!chars.Contains(c))
					{
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new Size(32, 32), 28, "DengXian", FontStyle.Italic);
						var sequence = ToZerosOnesSequence(c, Projection.Bitmap);
						FileWriter.AddLine(sequence, datasetPath);
					}
				}
			}

			foreach (Word w in all)
			{
				foreach (Char c in w.Character)
				{
					if (!chars.Contains(c))
					{
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new Size(32, 32), 28, "DengXian Light", FontStyle.Italic);
						var sequence = ToZerosOnesSequence(c, Projection.Bitmap);

						FileWriter.AddLine(sequence, datasetPath);
					}
				}
			}

		}



	}
}
