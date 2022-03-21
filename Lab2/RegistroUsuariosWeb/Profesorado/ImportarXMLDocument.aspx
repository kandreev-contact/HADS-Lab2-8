<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarXMLDocument.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.ImportarXMLDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Importar XML Document</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/profesorStyle.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="headerLeft">
                    <table id="FunctionsProf">
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="tareasButton" runat="server" Text="Gestion Tareas" OnClick="tareasButton_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="estadisticaButton" runat="server" Text="Estadisticas" OnClick="estadisticaButton_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="xmldocButton" runat="server" Text="Importar v. XMLDocument" OnClick="xmldocButton_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="exportarButton" runat="server" Text="Exportar" OnClick="exportarButton_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="importarDataSetButton" runat="server" Text="Importar Dataset" disabled="true" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="cerrarSesionButton" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesionButton_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div class="header">
                    <h1>Importar Tareas Genericas</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%><%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuProf">
                        <tr>
                            <td colspan="2">
                                <p>Seleccionar Asignatura a Importar: </p>
                            </td>
                            <td rowspan="4">
                                <asp:Xml ID="importedTable" runat="server"></asp:Xml></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="asignaturasDDL" runat="server" AutoPostBack="True" DataSourceID="HADSSubjectsDB" DataTextField="codigoAsig" DataValueField="codigoAsig"></asp:DropDownList>
                                <asp:SqlDataSource ID="HADSSubjectsDB" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT GrupoClase.codigoAsig FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE (ProfesorGrupo.email = @email)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="email" SessionField="email" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>


                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="importarXMLDButton" runat="server" Text="Importar (XMLD)" OnClick="importarXMLDButton_Click" /></td>
                            <td>
                                <asp:Button class="functionsButtons" ID="REFRESH" runat="server" Text="Refresh" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="feedbackImport" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </div>

                <div class="backgroundBody">
                    <img src="../imgs/upvb.jpeg" />
                </div>

                <div class="logo">
                    <img src="../imgs/logo.png" />
                </div>

                <div class="footer">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
