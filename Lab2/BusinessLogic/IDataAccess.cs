using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IDataAccess
    {
        bool registerUser(String email, String password, String name, String surname, String role, int numConfirmation);

        bool confirmUser(String email, int id);

        bool checkConfirmed(String email);

        bool login(String email, String password);

        bool checkUserRegistered(String email);

        void changeUserCodePass(String email, int codpass);

        void changeUserPassword(String email, String newPassword);

        bool checkUserCodePass(String email, int codpass);

        bool checkUserPassword(String email, String newPassword);

        User getUser(String email, String password);

        bool registerTarea(TareaGenerica tg);

        DataSet getSubjects(String alumno);
        DataSet getTareasGenericas(string alumno);

        DataTable getTareasGenericas(String alumno, String codAsig);

        (DataTable, SqlDataAdapter) getTareasEstudiante(String email);

        bool updateTareasEstudiante(string email, string codTarea, string he, int hrc);

    }
}
