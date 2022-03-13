using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace RegistroUsuariosWeb.Alumnos
{
    public partial class VerTareasEstudiante : System.Web.UI.Page
    {
        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e) // Tiene que corregirse limpiar
        {
            bll = new BusinessLogicLayer.BusinessLogic();
            if (!Page.IsPostBack)
            {
                if (!(Session["email"] is null))
                {
                    String email = Session["email"].ToString();

                    DataSet ds = bll.getSubjects(email);
                    asignaturaDDL.DataTextField = ds.Tables[0].Columns[0].ToString();
                    asignaturaDDL.DataValueField = ds.Tables[0].Columns[0].ToString();
                    asignaturaDDL.DataSource = ds.Tables[0];
                    asignaturaDDL.DataBind();


                    gridView();
                }
            }
            else
            {
                if (!(Session["email"] is null))
                {
                    gridView();
                }
            }
        }

        protected void tareasButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Estudiante.aspx");
        }

        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("../Inicio.aspx"); // Msg to confirm exit
        }

        protected void tareasEstudianteGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pasar email(Session), he, codTarea, indexGV
            // Coger las hEstimadas
            string he = tareasEstudianteGV.SelectedRow.Cells[3].Text;
            string ct = tareasEstudianteGV.SelectedRow.Cells[1].Text;
            string index = tareasEstudianteGV.SelectedRow.RowIndex.ToString();

            //MessageBox.Show("he " + he + " codTarea " + ct + " index " + index);

            Response.Redirect($"./InstanciarTarea.aspx?codTarea={ct}&he={he}&indexGV={index}");
        }

        private void gridView()
        {
            String email = Session["email"].ToString();
            DataTable dt = bll.getTareasGenericas(email, asignaturaDDL.SelectedValue);
            tareasEstudianteGV.DataSource = dt;
            tareasEstudianteGV.DataBind();
        }
    }
}