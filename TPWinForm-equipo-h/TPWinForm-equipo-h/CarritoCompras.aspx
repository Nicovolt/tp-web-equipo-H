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

        </tbody>
        <tfoot>
            <tr>
                <td>Total</td>
                <td>
                    <asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
                <td>
                    <asp:Button ID="btnComprar" runat="server" Text="Comprar" OnClick="btnComprar_Click" /></td>
            </tr>
        </tfoot>
    </table>


</asp:Content>
