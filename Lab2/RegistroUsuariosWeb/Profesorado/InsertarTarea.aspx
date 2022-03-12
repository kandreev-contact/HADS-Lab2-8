<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insertar Tareas</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/profesorIStyle.css" />
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
                                <asp:Button class="functionsButtons" ID="estadisticaButton" runat="server" Text="Estadisticas" disabled="true" /></td>
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
                    <h1>Insertar Tareas</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%>                    <%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuProf">
                        <tr>
                            <td>
                                <p>Codigo: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="codigoTB" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Descripcion: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="descripcionTA" runat="server" TextMode="MultiLine" Style="min-width: 180px; max-width: 180px; max-height: 50px; min-height: 50px;"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Asignatura: </p>
                            </td>
                            <td>
                                <asp:DropDownList ID="asignaturaDDL" runat="server" Style="width: 180px;" DataSourceID="AsignaturaDS" DataTextField="codigoAsig" DataValueField="codigoAsig"></asp:DropDownList>
                                <asp:SqlDataSource ID="AsignaturaDS" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT GrupoClase.codigoAsig FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE (ProfesorGrupo.email = @email)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="email" SessionField="email" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Horas Estimadas: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="hestimadasTB" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Tipo Tarea: </p>
                            </td>
                            <td>
                                <asp:DropDownList ID="typeSubjectDDl" runat="server" Style="width: 180px;">
                                    <asp:ListItem Text="Laboratorio" Value="Laboratorio"></asp:ListItem>
                                    <asp:ListItem Text="Examen" Value="Examen"></asp:ListItem>
                                    <asp:ListItem Text="Ejercicio" Value="Ejercicio"></asp:ListItem>
                                    <asp:ListItem Text="Trabajo" Value="Trabajo"></asp:ListItem>
                                    <asp:ListItem Text="Filtro" Value="Filtro"></asp:ListItem>
                                    <asp:ListItem Text="Practica" Value="Practica"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="feedbackTareaL" runat="server" Text="La Tarea se ha creado!"></asp:Label>
                            </td>
                            <td>
                                <asp:Button class="functionsButtons" ID="addTareaButton" runat="server" Text="Añadir Tarea" OnClick="insertarTareaButton_Click" />

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
