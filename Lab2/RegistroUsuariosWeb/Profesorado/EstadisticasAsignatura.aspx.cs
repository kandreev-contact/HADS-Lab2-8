using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuariosWeb.Profesorado
{
    public partial class EstadisticasAsignatura : System.Web.UI.Page
    {
        private studentAvgHoursBySubjectService.StudentAvgService service;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new studentAvgHoursBySubjectService.StudentAvgService();
        }
        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Profesor.aspx");
        }

        protected void estadisticaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Profesor.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Inicio.aspx");
        }

        protected void xmldocButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ImportarXMLDocument.aspx");
        }

        protected void exportarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Exportar.aspx");
        }

        protected void alumnosDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int avrgHour = service.GetStudentAvrgHours(alumnosDDL.SelectedValue);
                horasM.Text = avrgHour.ToString();
            }
            catch (Exception ex)
            {
                horasM.Text = "-";
            }

        }
    }
}