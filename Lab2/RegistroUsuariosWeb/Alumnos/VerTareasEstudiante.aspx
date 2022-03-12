<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="RegistroUsuariosWeb.Alumnos.VerTareasEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ver Tareas</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/alumnoStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="headerLeft">
                    <table id="FunctionsAlumno">
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="tareasButton" runat="server" Text="Ver Tareas" OnClick="tareasButton_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button class="functionsButtons" ID="cerrarSesionButton" runat="server" Text="Cerrar Sesion" OnClick="cerrarSesionButton_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div class="header">
                    <h1>Ver Tareas</h1>
                </div>

                <div class="loginBox">
                    <table id="menuAlumno">
                        <tr>
                            <td>
                                <p>Seleccionar Asignatura: </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="asignaturaDDL" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="tareasEstudianteGV" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="tareasEstudianteGV_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
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
