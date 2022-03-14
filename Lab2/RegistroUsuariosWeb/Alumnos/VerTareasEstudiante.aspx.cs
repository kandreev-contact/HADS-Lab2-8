using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();
            bool firstTime = Page.IsPostBack;

            if (!firstTime)
            {
                String email = Session["email"].ToString();

                // Cargar las asignaturas
                DataSet ds1 = bll.getSubjects(email);
                asignaturaDDL.DataTextField = ds1.Tables[0].Columns[0].ToString();
                asignaturaDDL.DataValueField = ds1.Tables[0].Columns[0].ToString();
                asignaturaDDL.DataSource = ds1.Tables[0];
                asignaturaDDL.DataBind();


                /* SOLO UN ACCESO A LA BD */
                // Cargar las tareas en el grid view 
                DataSet ds2 = bll.getTareasGenericas(email); // Cargar las tareas genericas del alumno
                DataTable dt = ds2.Tables[0];
                DataView dv = new DataView(dt);

                updateGrid(dv);

                Session["view"] = dv;
            }
            else
            {
                // Hacer un filtro de la GridView , tenemos Session table
                // Filtramos solo las asugnatura seleccionada el row/column de asig
                DataView dv = (DataView)Session["view"];
                updateGrid(dv);
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
            string he = tareasEstudianteGV.SelectedRow.Cells[3].Text;
            string ct = tareasEstudianteGV.SelectedRow.Cells[1].Text;
            string index = tareasEstudianteGV.SelectedRow.RowIndex.ToString(); // Para el uso en la tabla metodos (Update & AcceptChanges)

            Response.Redirect($"./InstanciarTarea.aspx?codTarea={ct}&he={he}&indexGV={index}");
        }

        private void updateGrid(DataView dv)
        {
            string subject = asignaturaDDL.SelectedValue;
            dv.RowFilter = $"codAsig = '{subject}'";
            DataTable dt = dv.ToTable();
            dt.Columns.Remove("codAsig");
            tareasEstudianteGV.DataSource = dt;
            tareasEstudianteGV.DataBind();
        }

    }
}