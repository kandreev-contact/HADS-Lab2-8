using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb.Alumnos
{
    public partial class Estudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HelloMsg.InnerText = "Bienvenido de nuevo " + Session["name"].ToString();

            }
            catch (Exception)
            {
                HelloMsg.InnerText = "Entrada sin sesion... ";
            }
        }

        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./VerTareasEstudiante.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            Response.Redirect("../Inicio.aspx"); // Msg to confirm exit
        }
    }
}