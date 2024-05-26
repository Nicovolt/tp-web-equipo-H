 <%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_equipo_h.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto&display=swap">


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
        .titulo-catalogo {
            text-align: center;
            font-size: 2rem; /* Tamaño de fuente */
            color: #0000; /* Color del texto */
            margin-bottom: 30px; /* Espacio inferior */
            text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.2); /* Sombra de texto */
        }


       
    </style>
    
            <div class="center-container">

                <div class="search-bar">
                    <asp:TextBox ID="searchTextBox" runat="server" CssClass="search-input" placeholder="Buscar..." onkeydown="enter(event)"></asp:TextBox>
                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="search-button" OnClick="btnSearch_Click" type="button">
                     <i class="fas fa-search"></i>
                    </asp:LinkButton>
               </div>
                <script>
                    function enter(event) {
                        if (event.keyCode === 13 || event.which === 13) {
                            event.preventDefault();
                            document.getElementById('<%= btnSearch.ClientID %>').click();
                         }
                     }
                        

                </script>

            </div>
         <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Literal ID="Resultados" runat="server"></asp:Literal>
        </div>

        <h1 class="titulo-catalogo">Catálogo de Productos</h1>


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
                                <!--<asp:Button Text="Agregar al carrito" CssClass="btn btn-primary btn-lg" runat="server" />-->
                                <a href="CarritoCompras.aspx?id=<%=articulo.id %>" class="btn btn-danger" onclick="redireccionarCarrito()">Agregar al carrito</a>
                               <script>
                                   // Redirecciona a default.aspx de manera inperceptible llevando asi los datos de articulo id
                                   function redireccionarCarrito() {
                              
                                       setTimeout(function () {
                                           window.location.href = "Default.aspx";
                                       }, 7);
                                   }
                               </script>


                            </div>
                        </div>
                    </div>
            <% }  %>
        </div>

    
</asp:Content>
