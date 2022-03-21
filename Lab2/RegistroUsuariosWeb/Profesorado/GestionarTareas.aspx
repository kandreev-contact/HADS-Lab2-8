<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTareas.aspx.cs" Inherits="RegistroUsuariosWeb.Profesorado.GestionarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestionar Tareas</title>
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
                    <h1>Gestionar Tareas</h1>
                </div>

                <div class="loginBox">
                    <%--<h1 id="headerConfirmation" runat="server">Gestion Web de Tareas-Dedicacion</h1>--%>                    <%--<p id="HelloMsg" runat="server">Bienvenido de nuevo</p>--%>
                    <table id="menuProf">
                        <tr>
                            <td>
                                <p>Seleccionar Asignatura: </p>
                            </td>
                            <td>
                                <asp:Button class="functionsButtons" ID="insertarTareasButton" runat="server" Text="Insertar Tareas" OnClick="insertarTareasButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="asignaturasDDL" runat="server" DataSourceID="HADSSQLDataSource" DataTextField="codigoAsig" DataValueField="codigoAsig" AutoPostBack="True"></asp:DropDownList>

                                <asp:SqlDataSource ID="HADSSQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" SelectCommand="SELECT GrupoClase.codigoAsig FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE (ProfesorGrupo.email = @email)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="email" SessionField="email" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:GridView ID="TareasGenericasAsig" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="codigo" DataSourceID="UpdateSQLTG" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                                        <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                                        <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                                        <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                                        <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
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
                                <asp:SqlDataSource ID="UpdateSQLTG" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS22-12ConnectionString %>" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @hEstimadas, @explotacion, @tipoTarea)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [codigo], [descripcion], [hEstimadas], [explotacion], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))">
                                    <DeleteParameters>
                                        <asp:Parameter Name="original_codigo" Type="String" />
                                        <asp:Parameter Name="original_descripcion" Type="String" />
                                        <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                                        <asp:Parameter Name="original_explotacion" Type="Boolean" />
                                        <asp:Parameter Name="original_tipoTarea" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="codigo" Type="String" />
                                        <asp:Parameter Name="descripcion" Type="String" />
                                        <asp:Parameter Name="hEstimadas" Type="Int32" />
                                        <asp:Parameter Name="explotacion" Type="Boolean" />
                                        <asp:Parameter Name="tipoTarea" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="asignaturasDDL" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="descripcion" Type="String" />
                                        <asp:Parameter Name="hEstimadas" Type="Int32" />
                                        <asp:Parameter Name="explotacion" Type="Boolean" />
                                        <asp:Parameter Name="tipoTarea" Type="String" />
                                        <asp:Parameter Name="original_codigo" Type="String" />
                                        <asp:Parameter Name="original_descripcion" Type="String" />
                                        <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                                        <asp:Parameter Name="original_explotacion" Type="Boolean" />
                                        <asp:Parameter Name="original_tipoTarea" Type="String" />
                                    </UpdateParameters>
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
