using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserOperations
    {
        void registerUser(User user);

        bool checkUserRegister(String email);

        bool checkUserRegister(String email, int numconf);

        void confrimUser(String email);

        bool checkConfirmed(String email);

        bool checkLogin(String email, String password);
    }
}
