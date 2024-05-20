<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="TPWinForm_equipo_h.CarritoCompras" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
         .titulo-catalogo {
              text-align: center;
              font-size: 2rem; /* Tamaño de fuente */
              color:#000000; /* Color del texto */
               margin-top: 15px;
              margin-bottom: 15px; /* Espacio inferior */
              text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.2); /* Sombra de texto */

         }
    </style>


                            
        <h1 class="titulo-catalogo">Carrito de compras</h1>
 
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
                <th>Eliminar</th>
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
                        <td><asp:Button ID="btnEliminar" runat="server" Text="X" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("id") %>' CommandName="idArticulo"/></td>
                        
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
