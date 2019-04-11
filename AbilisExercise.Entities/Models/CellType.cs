using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// CellType Static class used to get the possibles values of a Cell Type in a Table.
    /// </summary>
    public static class CellType
    {
        public const int Header = 1;
        public const int Corner = 2;
        public const int Prime = 3;
        public const int Normal = 4;
        public const int Diagonal = 5;

        /// <summary>
        /// Indicates if a integer is prime
        /// </summary>
        /// <param name="number">number to identify</param>
        /// <returns>true if the number is prime or false if it isn't</returns>
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            //Get the limit.
            var max = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= max; ++i)
                if (number % i == 0)
                    return false;
            return true;
        }
    }
}