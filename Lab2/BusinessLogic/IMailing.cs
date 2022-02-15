using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IMailing
    {
        void sendEmailRegister(String email, int id);

        void sendEmailChangePassword(String email);
    }
}
