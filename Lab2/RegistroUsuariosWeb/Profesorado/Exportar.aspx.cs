using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace RegistroUsuariosWeb.Profesorado
{
    public partial class Exportar : System.Web.UI.Page
    {
        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BusinessLogicLayer.BusinessLogic();
            bool firstTime = !Page.IsPostBack;

            if (firstTime)
            {
                String email = Session["email"].ToString();

                // Cargar las asignaturas
                DataSet ds1 = bll.getSubjectsProfe(email);
                asignaturasDDL.DataTextField = ds1.Tables[0].Columns[0].ToString();
                asignaturasDDL.DataValueField = ds1.Tables[0].Columns[0].ToString();
                asignaturasDDL.DataSource = ds1.Tables[0];
                asignaturasDDL.DataBind();

                /*SOLO UN ACCESO A LA BD */
                // Cargar las tareas en el grid view 
                DataTable dt = bll.getTareasGenericasAsig();
                DataView dv = new DataView(dt);

                updateGrid(dv);

                Session["view"] = dv;
            }
            else
            {
                feedbackImport.Text = "";

                // Hacer un filtro de la GridView , tenemos Session table
                // Filtramos solo las asugnatura seleccionada el row/column de asig
                DataView dv = (DataView)Session["view"];
                updateGrid(dv);
            }
        }

        private void updateGrid(DataView dv)
        {
            //MessageBox.Show(dv.ToString());
            string subject = asignaturasDDL.SelectedValue;
            dv.RowFilter = $"codAsig = '{subject}'";
            DataTable dt = dv.ToTable();
            dt.Columns.Remove("codAsig");
            tareasProfeGV.DataSource = dt;
            tareasProfeGV.DataBind();
        }

        protected void exportarXMLButton_Click(object sender, EventArgs e)
        {
            // Export xml file
            try
            {
                string subject = asignaturasDDL.SelectedValue;
                DataView dv = (DataView)Session["view"];
                DataTable dt = dv.ToTable();
                dt.TableName = "tarea";

                // convertirlo a atributo
                dt.Columns["codigo"].ColumnMapping = MappingType.Attribute;

                if (File.Exists(Server.MapPath($"~/App_Data/{subject}.xml")))
                {
                    feedbackImport.Text = $"El fichero {subject}.xml ya existe!".ToUpper();
                }
                else
                {
                    dt.WriteXml(Server.MapPath($"~/App_Data/{subject}.xml"));
                    feedbackImport.Text = $"Las tareas se han exportado en un fichero {subject}.xml!".ToUpper();
                }

            }
            catch (Exception ex)
            {
                //throw new Exception("Error en exportar! " + ex.ToString());
                feedbackImport.Text = "Las tareas no se han exportado!".ToUpper();
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
            Response.Redirect("./Profesor.aspx");
        }


    }
}