<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="TPWinForm_equipo_h.CarritoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>Tus COMPRAS</h1>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th class="d-none">Id</th>
                <th>Codigo</th>
                <th>Nombre</th>
                <th>Descripción</th>
                <th>Marca</th>
                <th>Categoría</th>
                <th>Precio</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repeaterCarrito" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"<%# Eval("id") %></td>
                        <td><%# Eval("codigo") %></td>
                        <td><%# Eval("nombre") %></td>
                        <td><%# Eval("descripcion") %></td>
                        <td><%# Eval("marca") %></td>
                        <td><%# Eval("categoria") %></td>
                        <td><%# Eval("precio") %></td>
                        </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td>Total</td>
                <td>
                    <asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
                <td>
                    <!-- comento este boton ya que da error en la pagina de carrito -->
                  
            </tr>
        </tfoot>
    </table>


</asp:Content>
