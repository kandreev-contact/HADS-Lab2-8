using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserDAO
    {
        void registerUser(User user);

        bool checkExistingUser(String email);

        bool checkUserToConfirm(String email, int numconf);

        void confrimUser(String email);

        bool checkConfirmed(String email);

        bool checkLogin(String email, String password);

        void setUserPassCodeChanged(String email, int codPass);

        bool checkUserCodePass(String email, int codPass);

        void changeUserPassword(String email, String newPassword);

        bool checkUserPassword(String email, String newPassword);
    }
}
