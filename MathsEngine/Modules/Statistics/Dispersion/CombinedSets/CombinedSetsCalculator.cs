using System;
using System.Collections.Generic;

namespace MathsEngine.Modules.Statistics.Dispersion.CombinedSets
{
    public class CombinedSetsCalculator
    {
        private int _numFirstSetPoints;
        private double mean1, standardDeviation1, sigmaX1, sigmaXSq1;

        private int _numSecondSetPoints;
        private double mean2, standardDeviation2, sigmaX2, sigmaXSq2;

        public CombinedSetsCalculator(List<string> dataSet1, List<string> dataSet2)
        {
            if (dataSet1 == null || dataSet2 == null)
                throw new ArgumentException("The lists must not be empty");

            _numFirstSetPoints = Convert.ToInt16(dataSet1[0]);
            mean1 = Convert.ToDouble(dataSet1[1]);
            standardDeviation1 = Convert.ToDouble(dataSet1[2]);

            _numSecondSetPoints = Convert.ToInt16(dataSet2[0]);
            mean2 = Convert.ToDouble(dataSet2[1]);
            standardDeviation2 = Convert.ToDouble(dataSet2[2]);
        }

        public void Run()
        {

        }

        private void checkFirstDataSet(int numDataPoints, double mean, double standardDeviation)
        {

        }

        public void DisplayData()
        {

        }
    }
}