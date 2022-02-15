using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IBLGeneral : IMailing, IDataAccess
    {

        int generateNumConfirmation();

        int generateNumPass();

    }
}
