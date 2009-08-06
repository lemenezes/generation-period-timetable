using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTimetableGeneration
{
    public static class NewtonFormula
    {
        const double KAPPA = 0.001;

        public static int generatePassengers(TrainConnection connection)
        {
            return evaluateNewtonFormula(connection.FromStation.Inhabitation,
                connection.ToStation.Inhabitation, connection.Time);
        }

        public static  int generatePassengers(TrainStation from, TrainStation to, Time time)
        {
            return evaluateNewtonFormula(from.Inhabitation, to.Inhabitation , time);
        }

        public static int evaluateNewtonFormula(int from, int to, Time time)
        {
            double result;
            double midResult = KAPPA * from * to;

            result = (double) midResult / ( (long) time.ToMinutes() * (long) time.ToMinutes());

            return (int) result;
        }
    }
}
