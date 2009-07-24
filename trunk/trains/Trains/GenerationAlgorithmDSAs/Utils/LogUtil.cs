using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PeriodicTimetableGeneration
{

    /// <summary>
    /// Implements utility method for logs.
    /// </summary>
	public static class LogUtil
	{


        /// <summary>
        /// Prints the discrete set matrix to file.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="fileName">Name of the file.</param>
		public static void printDiscreteSetMatrixToFile(Set[,] matrix, String fileName)
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

        /// <summary>
        /// Prints the constraints to file.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="fileName">Name of the file.</param>
		public static void printConstraintsToFile(List<Constraint> constraints, String fileName)
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
