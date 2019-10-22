using Domain.ReadersFactory;
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
		public static string ToZerosOnesSequence(char c, Bitmap bitmap)
		{
			int R = Color.Black.R;
			int V = Color.Black.G;
			int A = Color.Black.B;

			StringBuilder sb = new StringBuilder();
			sb.Append(c.ToString() + ",");

			for (int i = bitmap.Width - 1; i >= 0; i--)
			{
				for (int j = bitmap.Height - 1; j >= 0; j--)
				{
					Color color = bitmap.GetPixel(i, j);

					if ((((R == color.R) && (color.G == V) && (A == color.B))))
					{
						sb.Append("1,");
					}
					else sb.Append("0,");
				}

			}

			sb.Remove(sb.Length - 1, 1); //Remove last ,					
			return sb.ToString();
		}

		public static void Generate() {

			var hsk1 = ReaderFactory.GetHSKReader(1);
			ArrayList words = hsk1.AllWords();

			ArrayList chars = new ArrayList();
			foreach (Word w in words)
			{

				foreach (Char c in w.Character)
				{
					if (!chars.Contains(c))
					{
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new Size(32, 32), 28);
						Projection.Bitmap.Save(@"C:\Users\dlorente\Desktop\RecogZi\Bitmaps\" + c.ToString() + ".bmp");
						var sequence = ToZerosOnesSequence(c, Projection.Bitmap);
						
						string path = @"C:\Users\dlorente\Desktop\RecogZi\dataset.csv";
						FileWriter.AddLine(sequence,path);
					}
				}
			}
		}
	}
}
