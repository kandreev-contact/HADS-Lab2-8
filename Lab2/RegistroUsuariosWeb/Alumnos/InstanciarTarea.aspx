<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="RegistroUsuariosWeb.Alumnos.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instanciar Tareas</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/alumnoIStyle.css" />
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
                    <h1>Insertar Tareas</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%>                    <%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuAlumno">
                        <tr>
                            <td>
                                <p>Usuario: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="usuarioTB" runat="server" Enabled="False"></asp:TextBox></td>
                            <td rowspan="6">
                                <asp:GridView ID="tareasIGV" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" style="color:white;" bgcolor="#990000"><tr><td>Mis tareas</td></tr></table>' CaptionAlign="Top" CellPadding="4">
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
                        <tr>
                            <td>
                                <p>Tarea: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="tareaTB" runat="server" Enabled="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Horas Est: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="horasETB" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Horas Reales: </p>
                            </td>
                            <td>
                                <asp:TextBox ID="horasRTB" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button class="functionsButtons" ID="instanciarTareaButton" runat="server" Text="Instanciar Tarea" OnClick="instanciarTareaButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="feedbackTareaL" runat="server" Text="La Tarea se ha instanciado!"></asp:Label>
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
