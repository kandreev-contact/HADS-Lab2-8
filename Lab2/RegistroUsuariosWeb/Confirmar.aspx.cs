using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb
{
    public partial class Confirmar : System.Web.UI.Page
    {
        private BusinessLogicLayer.BusinessLogic bll;

        /*
                get data from url check if user is registered and check if the numconf is the same
                if TRUE:
                    modify confirmation field to true
                FALSE:
                    show error massage
             */
        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();

            String param1, param2;
            param1 = Request.QueryString["email"];
            param2 = Request.QueryString["numconf"];

            if (checkURLParamNULL(param1, param2))
            {
                headerConfirmation.InnerText = "No se ha podido confirmar tu email!";
            }
            else
            {
                String emailURL = param1;
                int numconfURL = int.Parse(param2);

                if (bll.confirmUser(emailURL, numconfURL))
                {
                    headerConfirmation.InnerText = "Has confirmado tu e-mail!";
                }
                else
                {
                    headerConfirmation.InnerText = "No se ha podido confirmar tu email!";
                }
            }

        }

        private bool checkURLParamNULL(String param1, String param2)
        {
            return (param1 == null || param2 == null);
        }

    }
}