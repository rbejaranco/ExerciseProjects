using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Entities.Models
{
    /// <summary>
    /// Matrix<T> This class represent the table of elements (T). DTO.
    /// </summary>
    /// <typeparam name="T">This type represent the generic type T of elements in the matrix.</typeparam>
    public class Matrix<T>
    {
        /// <summary>
        /// Collection of element T that represents a Row in the Table.
        /// </summary>
        public ICollection<Row<T>> Rows { get; set; }
    }
}