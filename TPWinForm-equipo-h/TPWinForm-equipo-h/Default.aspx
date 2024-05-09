<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_equipo_h.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Articulos del carrito</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            TPWinForm_equipo_h.ImagenNegocio imagen =new TPWinForm_equipo_h.ImagenNegocio();
            foreach (TPWinForm_equipo_h.Articulo articulo in articuloList)
            {
        %>
        <div class="col">
            <div class="card">
                <img src="<%: imagen.listarUna(articulo.id) %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.nombre %></h5>
                    <p class="card-text"><%: articulo.descripcion %></p>
                </div>
            </div>
        </div>
        <% }  %>
    </div>
</asp:Content>
