using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Data.SqlClient;

using BusinessLogicLayer;

namespace RegistroUsuariosWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        private BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            divSend.Visible = false;
            bll = new BusinessLogicLayer.BusinessLogic();
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            String password = PasswordTBR.Text;
            String password2 = PasswordTBRR.Text;

            bool v1 = passwordLengthValidation(password);
            bool v2 = passwordRepeatValidation(password, password2);
            bool v3 = RadioRFieldValidator.IsValid;

            PassLengthValidator.IsValid = v1;
            PasswordsEValidators.IsValid = v2;

            if (v2 && v3)
            {
                int id = bll.generateNumConfirmation();
                String email = EmailTBR.Text;
                String name = NameTB.Text;
                String surname = SurnameTB.Text;
                String role = RoleSelectRBL.SelectedValue;

                if (bll.registerUser(email, password, name, surname, role, id))
                {
                    bll.sendEmailRegister(email, id);
                    textDivError.InnerText = "Se ha enviado a tu email!";
                    divSend.Visible = true;
                }
                else
                {
                    textDivError.InnerText = "Ya existe usuario con este email!";
                    divSend.Visible = true;
                }
            }
            else
            {
                divSend.Visible = false;
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

        private bool passwordLengthValidation(String pass)
        {
            if (pass.Length >= 6)
                return true;
            else
                return false;
        }

    }
}