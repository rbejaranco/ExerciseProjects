using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// Helper Class to create an Object Matrix<string> that represents a Binary.
    /// </summary>
    public class BinaryMatrixRepositoryHelper : MatrixRepositoryHelper<string>
    {
        /// <summary>
        /// Format the value using a Binary format.
        /// </summary>
        /// <param name="value">value in integer form</param>
        /// <returns>Binary formated.</returns>
        internal override string FormatValue(int value)
        {
            return Convert.ToString(value, 2);
        }
    }
}