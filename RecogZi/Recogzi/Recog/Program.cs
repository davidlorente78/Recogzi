﻿using Recogzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recog
{
	class Program
	{
		static void Main(string[] args)
		{
			int level = 2;
			DatasetGenerator.GenerateDataSet(level);
		}
	}
}
