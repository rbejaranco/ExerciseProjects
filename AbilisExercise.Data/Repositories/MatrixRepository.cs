using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisExercise.Data.Repositories
{
    /// <summary>
    /// MatrixRepository Represents a Factory of MatrixRepositoryHelper to build the diferents types of Matrix<T>
    /// </summary>
    public class MatrixRepository
    {

        /// <summary>
        /// This action allows to  build and object of type Matrix<T>.
        /// </summary>
        /// <param name="matrixBase">Type of matrix required. Integer (Matrix<int>), Binaries (Matrix<string>), Hexadecimal (Matrix<string>).</param>
        /// <param name="matrixSize"></param>
        /// <returns>Object of Type Matrix<T></returns>
        public static object GetMatrix(string matrixBase, int matrixSize)
        {
            //Get a Matrix of integers.
            if (matrixBase.Equals("matrix_int"))
            {
                MatrixRepositoryHelper<int> repo = new IntMatrixRepositoryHelper();
                return repo.GetMatrix(matrixSize);
            }
            //Get a Matrix of binaries.
            else if (matrixBase.Equals("matrix_bin"))
            {
                MatrixRepositoryHelper<string> repo = new BinaryMatrixRepositoryHelper();
                return repo.GetMatrix(matrixSize);
            }
            //Get a Matrix of Hexas.
            else if (matrixBase.Equals("matrix_hexa"))
            {
                MatrixRepositoryHelper<string> repo = new HexaMatrixRepositoryHelper();
                return repo.GetMatrix(matrixSize);
            }
            //Posibilities to include more Matrix<T>


            //If the Matrix base is not avaliable this actions throws an error. 
            throw new InvalidOperationException();
        }



    }
}