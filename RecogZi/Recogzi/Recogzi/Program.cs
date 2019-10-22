using DALReaders;
using Domain.ReadersFactory;
using DomainHSK.FileWriters;
using HSK;
using SubripServices;
using System;
using System.Collections;

namespace Recogzi
{
	class Program
	{
		static void Main(string[] args)
		{


			//var Projection = ProjectionService.GenerateProjectionfromFontChar('安', new System.Drawing.Size(32, 32), 28);
			//Projection.Bitmap.Save(@"C:\Users\dlorente\Desktop\RecogZi\an.bmp");
			//var sequence = BitmapService.ToZerosOnesSequence('安',Projection.Bitmap);

			//FileWriter f = new FileWriter();
			//f.AddLine(sequence);
						

			var hsk1 = ReaderFactory.GetHSKReader(1);
			ArrayList words = hsk1.AllWords();

			ArrayList chars = new ArrayList();
			foreach (Word w in words) {

				foreach (Char c in w.Character) {
					if (!chars.Contains(c)) {
						chars.Add(c);

						var Projection = ProjectionService.GenerateProjectionfromFontChar(c, new System.Drawing.Size(32, 32), 28);
						Projection.Bitmap.Save(@"C:\Users\dlorente\Desktop\RecogZi\Bitmaps\" + c.ToString() + ".bmp");
						var sequence = BitmapService.ToZerosOnesSequence(c, Projection.Bitmap);

						FileWriter.AddLine(sequence);
						

					}

				}
   
			}

			int charsCount = chars.Count;



		}


	}
}
