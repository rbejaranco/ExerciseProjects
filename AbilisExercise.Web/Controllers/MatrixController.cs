using AbilisExercise.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AbilisExercise.Web.Controllers
{

    /// <summary>
    /// Controller exposing JSON Methods to get Matrix<T>
    /// </summary>
    public class MatrixController : Controller
    {
        /// <summary>
        /// Get Index page.
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get a Matrix<T> based on parametres and represented using JSON.
        /// </summary>
        /// <param name="matrixSize">Matrix size. Value Between 3 and 15.</param>
        /// <param name="matrixBase">Matrix Format queried. matrix_int, matrix_bin, matrix_hexa </param>
        /// <returns></returns>
        public ActionResult GetMatrix(int matrixSize, string matrixBase)
        {
            //Validations.
            if (matrixSize >= 3 && matrixSize <= 15)
            {
                //Get the matrix based on action's parameters. 
                //To do >> improve Exception's management here.
                var _matrix = MatrixRepository.GetMatrix(matrixBase, matrixSize);
                //return Matrix formated in JSON.
                return Json(_matrix, JsonRequestBehavior.AllowGet);
            }
            else
                //Exception if matrixSize's validation's failed.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            

        }
    }
}