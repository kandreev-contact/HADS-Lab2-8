using System;
using System.Collections.Generic;


namespace RegistroUsuariosWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Alumnos"] = 0;
            Application["Profesores"] = 0;
            Application["AlumnosEmails"] = new List<string>();
            Application["ProfesoresEmails"] = new List<string>();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["role"].Equals("Alumno"))
            {
                Application.Lock();
                Application["Alumnos"] = (int)Application["Alumnos"] - 1;
                List<string> alumnos = (List<string>)Application["AlumnosEmails"];
                alumnos.Remove((string)Session["email"]);
                Application["AlumnosEmails"] = alumnos;
                Application.UnLock();
            }
            else if (Session["role"].Equals("Profesor"))
            {
                Application.Lock();
                Application["Profesores"] = (int)Application["Profesores"] - 1;
                List<string> profesores = (List<string>)Application["ProfesoresEmails"];
                profesores.Remove((string)Session["email"]);
                Application["ProfesoresEmails"] = profesores;
                Application.UnLock();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}