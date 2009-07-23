using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{

	public static class LogUtil
	{

		public static void printToFile(Set[,] matrix, String fileName)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			// loop over all rows
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				// loop over all columns
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					String str = String.Format("[{0}, {1}]: ", i.ToString().PadLeft(2, ' '), j.ToString().PadLeft(2, ' '));
					str += matrix[i, j].ToString();
					sw.WriteLine(str);
				}
			}

			sw.Close();
			fs.Close();
		}

		public static void printToFileConstraints(List<Constraint> constraints, String fileName)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			sw.WriteLine("{0} ", constraints.Count);

			foreach (Constraint constraint in constraints)
			{
				sw.Write("{0}->{1}: ", constraint.TrainLineNumber1, constraint.TrainLineNumber2);
				sw.WriteLine(constraint.DiscreteSet.ToString());
			}

			sw.Close();
			fs.Close();
		}

	}

}
