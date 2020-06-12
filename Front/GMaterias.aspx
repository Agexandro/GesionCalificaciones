<%@ Page Language="C#" Inherits="Front.GMaterias" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8"/>
	<title>GMaterias</title>
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
        
        <div class="row">
                <div class="col-md-8">
                <asp:GridView runat="server" id="grid" CssClass="display" OnRowCommand="Calificaciones_row" DataKeyNames="id" >
                <Columns>
                <asp:BoundField DataField="id"  HeaderText="Clave"/>
                <asp:BoundField DataField="value" HeaderText="Materia"/>
                <asp:ButtonField CommandName="cnGestionar" ButtonType="Button" Text="Gestionar Calificaciones"/>
                <asp:ButtonField CommandName="cnDelete" ButtonType="Button" Text="Eliminar"/>
                </Columns>
                </asp:GridView>
                <% if(Request.QueryString.Get("status") == "deleted"){%>
                <%= "<div class='success'>La materia ha sido eliminada</div>" %>
                <%}%>
                <% if(Request.QueryString.Get("status") == "noDeleted"){%>
                <%= "<div class='error'>La materia no se pudo eliminar</div>" %>
                <%}%>
                    </div>
                <div class="col-md">
                    <div class="card">
                        <div class="card-body" >
                            <asp:TextBox id="materia" class="form-control" placeholder="Materia" runat="server" autofocus></asp:TextBox>
                            <% if(Request.QueryString.Get("status") == "empty"){%>
                            <%= "<div class='error'>Campo vacio</div>" %>
                            <%}%>
                            <% if(Request.QueryString.Get("status") == "exists"){%>
                            <%= "<div class='error'>La materia ya existe</div>" %>
                            <%}%>
                            <% if(Request.QueryString.Get("status") == "success"){%>
                            <%= "<div class='success'>La materia ha sido agragada</div>" %>
                            <%}%>
                            <br>
                            <asp:Button class="btn btn-block btn-primary" onclick="InsertarMateria" runat="server" Text="Agregar"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
   </form>
            
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
        <script>
         $("#grid").prepend("<thead><tr><td>Clave</td><td>Materia</td><td></td><td></td></tr></thead>").dataTable();
        </script>
</body>
</html>
