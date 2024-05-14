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

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
        }


       
    </style>

    <h1>Catalago de Productos</h1>

       <div class="container">
        <nav aria-label="...">
            <ul class="pagination pagination-lg">
                <li class="page-item active" aria-current="page">
                    <span class="page-link">1</span>
                </li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
            </ul>
        </nav>
    </div>


    </div>

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%
                Negocio.ImagenDB imagen = new Negocio.ImagenDB();
                foreach (Dominio.Articulo articulo in articuloList)
                {
                    string img = imagen.listarUna(articulo.id);
                    string imageUrl = string.IsNullOrEmpty(img) ? "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" : img;


                 %>
                    <div class="col">
                        <div class="card">
                            <img src="<%= imageUrl %>??"https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" class="card-img-top" alt="Imagen del artículo">
                            <div class="card-body">
                                <h5 class="card-title"><%:articulo.nombre %></h5>
                                <p class="card-text">Descripcio: <%:articulo.descripcion %></p>
                                <p class="card-text">Precio: <%:articulo.precio %></p>
                                <a href= "DetallesArticulo.aspx?id=<%=articulo.id %> " class="btn btn-primary"> Ver detalle </a>
                                <!--<asp:Button ID="btnVerDetalle" Text="Ver detalle" CssClass="btn btn-primary btn-lg" runat="server"  OnClick="btnVerDetalle_Click"/>-->
                                <asp:Button Text="Agregar al carrito" CssClass="btn btn-primary btn-lg" runat="server" />
                            </div>
                        </div>
                    </div>
            <% }  %>
        </div>

    
</asp:Content>
