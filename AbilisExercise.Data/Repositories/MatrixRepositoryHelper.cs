using AbilisExercise.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// This class build a DTO of type Matrix<T>. 
    /// </summary>
    /// <typeparam name="T">This type represent the generic type T of elements in the matrix.</typeparam>
    public abstract class MatrixRepositoryHelper<T>
    {
        /// <summary>
        /// Build a DTO of Matrix<T>
        /// </summary>
        /// <param name="matrixSize">Size of the matrix</param>
        /// <returns>Matrix<T></returns>
        public Matrix<T> GetMatrix(int matrixSize)
        {
            Matrix<T> matrix = new Matrix<T>
            {
                //It includes the headers of the table so the table's size is matrixSize + 1
                Rows = new List<Row<T>>(matrixSize + 1)
            };
            for (int i = 0; i <= matrixSize; i++)
            {
                Row<T> _row = new Row<T>
                {
                    Columns = new List<Cell<T>>(matrixSize)
                };
                for (int j = 0; j <= matrixSize; j++)
                {
                    Cell<T> _column = new Cell<T>();
                    //Calculate the value and type of the cell in the table.
                    CalculateValue(i, j, _column);
                    _row.Columns.Add(_column);
                }
                matrix.Rows.Add(_row);
            }
            return matrix;
        }

        /// <summary>
        /// This actions allows the Helper to identify the value and type of cell based on the data.
        /// </summary>
        /// <param name="RowPosition"></param>
        /// <param name="ColumnPosition"></param>
        /// <param name="column"></param>
        internal void CalculateValue(int RowPosition, int ColumnPosition, Cell<T> column)
        {
            //If RowPosition is 0 then is a table's header.
            if (RowPosition == 0)
            {
                //If ColumnPosition is 0 then is the first Cell of the table ('X'). Value asigned is 0.
                if (ColumnPosition == 0)
                {
                    column.Value = FormatValue(0);
                    column.TypeOfCell = CellType.Corner;
                }
                //Marking the header.
                else
                {
                    column.Value = FormatValue(ColumnPosition);
                    column.TypeOfCell = CellType.Header;
                }
            }
            //If ColumnPosition is 0 then is a table's header.
            else if (ColumnPosition == 0)
            {
                column.Value = FormatValue(RowPosition);
                column.TypeOfCell = CellType.Header;
            }
            //Identify the Diagonal
            else if(RowPosition == ColumnPosition)
            {
                column.Value = FormatValue(RowPosition * ColumnPosition);
                column.TypeOfCell = CellType.Diagonal;
            }
            //Mark as a Prime Number.
            else if ( CellType.IsPrime(RowPosition * ColumnPosition) )
            {
                column.Value = FormatValue(RowPosition * ColumnPosition);
                column.TypeOfCell = CellType.Prime;
            }
            //Mark as a Regular Number
            else
            {
                column.Value = FormatValue(RowPosition * ColumnPosition);
                column.TypeOfCell = CellType.Normal;
            }
        }


        /// <summary>
        /// Format the value of T depending on the type of T used. It has to be implemented in the concrete class.
        /// </summary>
        /// <param name="value">value in integer form</param>
        /// <returns>T formated.</returns>
        internal abstract T FormatValue(int value);


    }
}