<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasAsignatura.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.EstadisticasAsignatura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estadisticas Asignatura</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/profesorEStyle.css" />
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
                    <h1>Estadisitcas Tareas-Asignaturas</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%><%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuProf">
                        <tr>
                            <td>
                                <p>Asignaturas: </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="alumnosDDL" runat="server" DataSourceID="HADSAsignaturas" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True" OnSelectedIndexChanged="alumnosDDL_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:SqlDataSource ID="HADSAsignaturas" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignatura]"></asp:SqlDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>Horas medias:
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="horasM" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
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
