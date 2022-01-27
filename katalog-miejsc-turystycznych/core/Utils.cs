using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    internal class Utils
    {
        internal static double computeMean(List<Double> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach (var val in values)
            {
                sum += val;
            }
            return sum / values.Count;
        }
    }
}
