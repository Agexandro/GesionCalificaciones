<%@ Page Language="C#" Inherits="Front.GCalif" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8"/>
    <title>Gestionar Calificaciones</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">
        <style>
            body{padding: 5px; width:80%; margin:0 auto;}
            #head{text-align:right; margin:5px;}
            .error{
                color:red;
            }
            .success{
                color:green;
            }
        </style>
</head>
<body>

        <form id="form1" runat="server">
             <div id="head"><%= Session["usuario"]+"" %> <asp:Button runat="server" OnClick="Logout" CssClass="btn btn-danger" Text="Cerrar sesión"></asp:Button></div>
              <h3>
                <%= Request.QueryString["materia"] %>
                <a href="GMaterias.aspx" class="btn btn-dark">Regresar</a>
              </h3>
                <div class="row">                
                <div class="col-md-8">

                <asp:GridView runat="server" id="grid" CssClass="display" OnRowCommand="Unidades_row" DataKeyNames="id" >
                <Columns>
                <asp:BoundField DataField="id"  HeaderText="Unidad"/>
                <asp:BoundField DataField="value" HeaderText="Calificación"/>
                <asp:ButtonField CommandName="cnDelete" ButtonType="Button" Text="Eliminar"/>
                </Columns>
                </asp:GridView>
                <% if(Request.QueryString.Get("status") == "deleted"){%>
                <%= "<div class='success'>La unidad ha sido eliminada</div>" %>
                <%}%>
                <% if(Request.QueryString.Get("status") == "noDeleted"){%>
                <%= "<div class='error'>La unidad no se pudo eliminar</div>" %>
                <%}%>
                </div>
             <div class="col-md">
             <div class="card">
             <div class="card-body" >
                 <asp:TextBox runat="server" id="unidad" placeholder="Unidad" CssClass="form-control"></asp:TextBox>
                    <% if(Request.QueryString.Get("status") == "emptyu" | Request.QueryString.Get("status") == "empty"){%>
                    <%= "<div class='error'>Campo vacio</div>" %>
                    <%}%>
                <br>
                 <asp:TextBox runat="server" id="cali" placeholder="Calificación" CssClass="form-control"></asp:TextBox>
                    <% if(Request.QueryString.Get("status") == "emptyc" | Request.QueryString.Get("status") == "empty"){%>
                    <%= "<div class='error'>Campo vacio</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("status") == "error"){%>
                    <%= "<div class='error'>A ocurrido un error</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("status") == "success"){%>
                    <%= "<div class='success'>Calificación agregada</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("status") == "exists"){%>
                    <%= "<div class='error'>La unidad ya fue calificada</div>" %>
                    <%}%>
                <br>
                  <asp:Button runat="server" OnClick="InsertarCalificacion" CssClass="btn btn-primary btn-block" Text="Agregar"></asp:Button>
             </div>
             </div>
             </div>
             </div>
            
   </form>
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>

         <script>
         $("#grid").prepend("<thead><tr><td>Unidad</td><td>Calificación</td><td></td></tr></thead>").dataTable();
        </script>
</body>
</html>
