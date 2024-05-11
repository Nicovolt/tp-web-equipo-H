<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_equipo_h.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        
        .card img{
            height: 250px;
            width: 300px;
            margin: 0 auto;            
        }
        .card-title, h1{
            text-align:center;
        }
       
    </style>
    <h1>Catalago de Productos</h1>



        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%
                Negocio.ImagenDB imagen = new Negocio.ImagenDB();
                foreach (Dominio.Articulo articulo in articuloList)
                {
                    string img = imagen.listarUna(articulo.id);

            %>
            <div class="col">
                <div class="card">
                    <img src="<%: img%> " class="card-img-top" alt="">
                    <div class="card-body">
                        <h5 class="card-title"><%:articulo.nombre %></h5>
                        <p class="card-text">Descripcio: <%:articulo.descripcion %></p>
                        <p class="card-text">Precio: <%:articulo.precio %></p>
                        <asp:Button Text="Ver detalle" CssClass="btn btn-primary btn-lg" runat="server" />
                        <asp:Button Text="Agregar al carrito" CssClass="btn btn-primary btn-lg" runat="server" />
                    </div>
                </div>
            </div>
            <% }  %>
        </div>
    
</asp:Content>
