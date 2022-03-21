using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Xml;

namespace RegistroUsuariosWeb.Profesorado
{
    public partial class ImportarXMLDocument : System.Web.UI.Page
    {
        BusinessLogicLayer.BusinessLogic bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Code mostrar
            bool firstTime = !Page.IsPostBack;
            bll = new BusinessLogicLayer.BusinessLogic();

            if (firstTime)
            {
                SqlDataAdapter adapter;
                DataTable dt;
                (dt, adapter) = bll.getTareasGenericas();


                Session["table"] = dt;
                Session["adapter"] = adapter;
            }
            else
            {
                DataTable dt = (DataTable)Session["table"];
                SqlDataAdapter adapter = (SqlDataAdapter)Session["adapter"];
                String subject = asignaturasDDL.SelectedValue;

                importedTable.DocumentSource = Server.MapPath("~/App_Data/" + subject + ".xml");
                importedTable.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl");
            }

        }

        protected void importarXMLDButton_Click(object sender, EventArgs e)
        {
            String subject = asignaturasDDL.SelectedValue;
            String xmlPath = Server.MapPath("~/App_Data/" + subject + ".xml");
            bool hasErrors = false;

            // Code importar uso de XMLDocument class
            XmlDocument xmlD = new XmlDocument();
            xmlD.Load(xmlPath);

            XmlNodeList codTareasXml = xmlD.GetElementsByTagName("tarea"); // get a list with all tareas


            // Obtain DataTable
            DataTable dt = (DataTable)Session["table"];

            foreach (XmlNode tarea in codTareasXml)
            {
                //MessageBox.Show(tarea.Attributes.GetNamedItem("codigo").Value);
                foreach (DataRow row in dt.Rows)
                {
                    // Check if there is the same id
                    if (row["codigo"].Equals(tarea.Attributes.GetNamedItem("codigo").Value))
                    {
                        hasErrors = true;
                        break;
                    }
                }
            }

            if (hasErrors)
            {
                feedbackImport.Text = "Las tareas no se han podido insertar!".ToUpper();

                return;
            }
            else
            {
                // update datatable
                foreach (XmlNode tarea in codTareasXml)
                {
                    XmlElement tareaElem = (XmlElement)tarea;

                    DataRow dr = dt.NewRow();
                    dr["codigo"] = tarea.Attributes.GetNamedItem("codigo").Value;
                    dr["descripcion"] = tareaElem["descripcion"].InnerText;
                    dr["codAsig"] = asignaturasDDL.SelectedValue;
                    dr["hEstimadas"] = tareaElem["hestimadas"].InnerText;
                    dr["explotacion"] = tareaElem["explotacion"].InnerText;
                    dr["tipoTarea"] = tareaElem["tipotarea"].InnerText;

                    dt.Rows.Add(dr);
                }


                // Update DB
                SqlDataAdapter adapter = (SqlDataAdapter)Session["adapter"];
                adapter.Update(dt);
                dt.AcceptChanges();

                feedbackImport.Text = "Las tareas se han insertado en la BD!".ToUpper();
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