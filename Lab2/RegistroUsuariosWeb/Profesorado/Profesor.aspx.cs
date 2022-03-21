using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;


namespace RegistroUsuariosWeb.Profesorado
{
    public partial class Profesor : System.Web.UI.Page
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

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("../Inicio.aspx"); // Msg to confirm exit

        }

        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./GestionarTareas.aspx");
        }

        protected void estadisticaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./EstadisticasEstudiante.aspx");
        }

        protected void xmldocButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ImportarXMLDocument.aspx");
        }

        protected void exportarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Exportar.aspx");
        }


    }
}