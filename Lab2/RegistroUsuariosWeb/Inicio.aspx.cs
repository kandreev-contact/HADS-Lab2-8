using EntityLayer;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Windows;

namespace RegistroUsuariosWeb
{
    public partial class Inicio1 : System.Web.UI.Page
    {
        private BusinessLogicLayer.BusinessLogic bll;
        // Check if in database and confirmed
        // true -> goto corresponding page
        // false -> show error message

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();
            divSend.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String email = EmailTB.Text;
            String password = PasswordTB.Text;

            if (bll.checkConfirmed(email))
            {
                // login 
                if (bll.login(email, password))
                {
                    User user = bll.getUser(email, password);
                    // Add session email and name
                    Session.Add("email", user.getEmail());
                    Session.Add("name", user.getName());
                    Session.Add("role", user.getRole());

                    // Set cookie 
                    FormsAuthentication.SetAuthCookie(user.getRole(), false);

                    if (user.getRole().Equals("Alumno"))
                    {
                        // Set role
                        //Roles.AddUserToRole(user.getEmail(), user.getRole());

                        Application.Lock();
                        Application["Alumnos"] = (int)Application["Alumnos"] + 1;
                        List<string> alumnos = (List<string>)Application["AlumnosEmails"];
                        alumnos.Add((string)Session["email"]);
                        Application["AlumnosEmails"] = alumnos;
                        Application.UnLock();


                        Response.Redirect("~/Alumnos/Estudiante.aspx");
                    }
                    else if (user.getRole().Equals("Profesor"))
                    {
                        // Set role
                        //Roles.AddUserToRole(user.getEmail(), user.getRole());

                        String cordinador = "vadillo@ehu.es";
                        if (user.getEmail().Equals(cordinador) || user.getEmail().Equals("admin@ehu.es"))
                        {
                            FormsAuthentication.SetAuthCookie(user.getRole() + "V", false);
                        }

                        Application.Lock();
                        Application["Profesores"] = (int)Application["Profesores"] + 1;
                        List<string> profesores = (List<string>)Application["ProfesoresEmails"];
                        profesores.Add((string)Session["email"]);
                        Application["ProfesoresEmails"] = profesores;
                        Application.UnLock();

                        Response.Redirect("~/Profesorado/Profesor.aspx");
                    }
                    divSend.Visible = false;
                }
                else
                {
                    divSend.Visible = true;
                }

            }
            else
            {
                divSend.Visible = true;
            }
        }

        protected void RegistroLB_Click(object sender, EventArgs e)
        {

        }

        protected void CambiarPassLB_Click(object sender, EventArgs e)
        {

        }
    }
}