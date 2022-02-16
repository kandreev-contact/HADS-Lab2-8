using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb
{
    public partial class CambiarPass : System.Web.UI.Page
    {
        private BusinessLogicLayer.BusinessLogic bll;
        private String emailURL;

        // Comprobar que el usuario esta registrado, comprobar su codpass, comprobar el password y
        // cambia el cod pass despues del cambio para que no haga el usuarios muchos cambios de password
        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();

            String param;
            param = Request.QueryString["email"];
            infoDiv.Visible = true;

            if (checkURLParamNULL(param))
            {
                textDivInfo.InnerText = "Se ha producido algun error!";
                CambiarPassButton.Enabled = false;
            }
            else
            {
                this.emailURL = param;
                if (bll.checkUserRegistered(emailURL))
                {
                    // user is registered
                }
                else
                {
                    textDivInfo.InnerText = "Se ha producido algun error!";
                    CambiarPassButton.Enabled = false;
                }
            }
        }
        protected void CambiarPassButton_Click(object sender, EventArgs e)
        {
            String password1, password2, code;
            password1 = PasswordTBC.Text;
            password2 = PasswordTBCC.Text;
            code = CodeTBC.Text;
            int codPass = int.Parse(code);

            bool v1 = passwordRepeatValidation(password1, password2);

            PasswordsEValidators.IsValid = v1;

            if (v1)
            {
                if (bll.checkUserCodePass(this.emailURL, codPass))
                {
                    if (bll.checkUserPassword(this.emailURL, newPassword: password1))
                    {
                        PassSameOldNewValidator.IsValid = false;
                        infoDiv.Visible = false;
                    }
                    else
                    {
                        PassSameOldNewValidator.IsValid = true;
                        bll.changeUserPassword(emailURL, password1);
                        bll.changeUserCodePass(emailURL, 0);
                        textDivInfo.InnerText = "Has cambiado correctamente tu password! Vuelve al Inicio!";
                        infoDiv.Visible = true;
                    }

                }
                else
                {
                    textDivInfo.InnerText = "Error de codigo!";
                    infoDiv.Visible = true;
                }
            }
            else
            {
                infoDiv.Visible = false;
            }

        }

        private bool passwordRepeatValidation(String pass1, String pass2)
        {
            if (pass1.Equals(pass2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkURLParamNULL(String param1)
        {
            return (param1 == null);
        }
    }
}