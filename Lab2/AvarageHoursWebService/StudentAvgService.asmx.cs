using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AvarageHoursWebService
{
    /// <summary>
    /// Summary description for StudentAvgService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StudentAvgService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Dado un código de asignatura devolverá el
        //número medio de horas dedicadas por los
        //estudiantes a realizar las tareas de dicha asignatura.
        [WebMethod]
        public int GetStudentAvrgHours(string subjectId)
        {
            // 1. Obtener los estudiantes en la asignatura (SQL)
            BusinessLogicLayer.BusinessLogic bll = new BusinessLogicLayer.BusinessLogic();
            int avgH = bll.getSubjectAvgHoursStudent(subjectId);

            return avgH;
        }


    }
}
