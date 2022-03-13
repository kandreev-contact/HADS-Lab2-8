<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasEstudiante.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.EstadisticasEstudiante" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estadisticas Alumnos</title>
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
                                <asp:Button class="functionsButtons" ID="xmldocButton" runat="server" Text="Importar v. XMLDocument" disabled="true" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="exportarButton" runat="server" Text="Exportar" disabled="true" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="cerrarSesionButton" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesionButton_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div class="header">
                    <h1>Estadisitcas Tareas-Alumnos</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%><%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuProf">
                        <tr>
                            <td>
                                <p>Alumno: </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="alumnosDDL" runat="server" DataSourceID="HADSAlumnos" DataTextField="email" DataValueField="email" AutoPostBack="True"></asp:DropDownList>
                                <asp:SqlDataSource ID="HADSAlumnos" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT DISTINCT Usuario.email FROM Usuario INNER JOIN EstudianteGrupo ON Usuario.email = EstudianteGrupo.email"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Chart runat="server" ID="chartHoras" DataSourceID="HADSHorasInvertidas">
                                    <Series>
                                        <asp:Series Name="Horas" XValueMember="codTarea" YValueMembers="hReales"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:SqlDataSource ID="HADSHorasInvertidas" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT DISTINCT [hEstimadas], [hReales], [codTarea] FROM [EstudianteTarea] WHERE ([email] = @email)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="alumnosDDL" Name="email" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
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
