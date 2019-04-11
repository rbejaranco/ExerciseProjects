using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Entities.Models
{
    /// <summary>
    /// Cell<T> This class represents on cell in a Table. DTO.
    /// </summary>
    /// <typeparam name="T">This type represent the generic type T of elements in the matrix.</typeparam>
    public class Cell<T>
    {
        /// <summary>
        /// Value is the generic value contained in a Cell. 
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// TypeOfCell represents the typeOfCell in a Row. Header = 1, Corner=2, Prime=3, Normal=3 
        /// </summary>
        public int TypeOfCell { get; set; }
    }
}