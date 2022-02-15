using System;
using System.Collections.Generic;
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

    }
}
