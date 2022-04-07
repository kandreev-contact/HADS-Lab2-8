<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrada Profesor</title>
    <link rel="stylesheet" type="text/css" href="../css/CommonStyle.css" />
    <link rel="stylesheet" type="text/css" href="../css/profesorStyle.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="headerLeft">
                <table id="FunctionsProf">
                    <tr>
                        <td>
                            <asp:Button class="functionsButtons" ID="tareasButton" runat="server" Text="Tareas" OnClick="tareasButton_Click" /></td>
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
                <h1>Entrada Profesor</h1>
            </div>

            <div class="loginBox">
                <h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>
                <p id="HelloMsg" runat="server">Bienvenido de nuevo</p>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ViewStateMode="Enabled" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="alumnosOnline" runat="server" Text=""></asp:Label>
                        <asp:Label ID="profesoresOnline" runat="server" Text=""></asp:Label>
                        <asp:Label ID="usuariosOnline" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:ListBox ID="alumnosLB" runat="server" Width="160px"></asp:ListBox>
                        <asp:ListBox ID="profesoresLB" runat="server" Width="162px"></asp:ListBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                </asp:Timer>

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
    </form>
</body>
</html>
