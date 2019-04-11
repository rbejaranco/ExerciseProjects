using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// Helper Class to create an Object Matrix<int>
    /// </summary>
    public class IntMatrixRepositoryHelper : MatrixRepositoryHelper<int>
    {
        /// <summary>
        /// Format the value using a decimal format.
        /// </summary>
        /// <param name="value">value in integer form</param>
        /// <returns>decimal formated.</returns>
        internal override int FormatValue(int value)
        {
            return value;
        }
    }
}