using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// Helper Class to create an Object Matrix<string> that represents a Hexadecimal.
    /// </summary>
    public class HexaMatrixRepositoryHelper : MatrixRepositoryHelper<string>
    {
        /// <summary>
        /// Format the value using a Hexa format.
        /// </summary>
        /// <param name="value">value in integer form</param>
        /// <returns>Hexa formated.</returns>
        internal override string FormatValue(int value)
        {
            return value.ToString("X");
        }
    }
}