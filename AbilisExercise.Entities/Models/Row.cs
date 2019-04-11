using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Entities.Models
{
    /// <summary>
    /// Row<T> This class represents the elements(Cell)in each column in the Row. DTO.
    /// </summary>
    /// <typeparam name="T">This type represent the generic type T of elements in the matrix.</typeparam>
    public class Row<T>
    {
        /// <summary>
        /// Collection of elements Cell in a Row.
        /// </summary>
        public ICollection<Cell<T>> Columns { get; set; }
    }
}