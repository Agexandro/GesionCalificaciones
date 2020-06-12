<%@ Page Language="C#" Inherits="Front.Default" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
	<title>Default</title>
    <meta charset="utf-8">
    <link href="css/estilo.css" rel="stylesheet"/>
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
</head>
<body>
	<form id="form1" runat="server">
            <div class="card">
                    <div class="card-body">
                        <div class="form-group">
                        <asp:TextBox runat="server" CssClass="form-control" ID="usr" ClientIDMode="Static" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <% if(Request.QueryString.Get("error") == "emptyu" | Request.QueryString.Get("error") == "empty"){%>
                    <%= "<div class='alert alert-danger'>Usuario vacio</div>" %>
                    <%}%>
                    <div class="form-group">
                        <asp:TextBox runat="server" CssClass="form-control" ID="pass" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <% if(Request.QueryString.Get("error") == "emptyp" | Request.QueryString.Get("error") == "empty"){%>
                    <%= "<div class='alert alert-danger'>Contraseña vacia</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("error") == "sqlError"){%>
                    <%= "<div class='alert alert-danger'>A ocurrido un error</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("error") == "nouser"){%>
                    <%= "<div class='alert alert-danger'>Usuario o contraseña incorrectos, intentalo de nuevo</div>" %>
                    <%}%>
                    <% if(Request.QueryString.Get("error") == "exists"){%>
                    <%= "<div class='alert alert-danger'>El usuario ya existe</div>" %>
                    <%}%>
                    <div class="row">
                        <div class="col-sm">
                            <asp:Button runat="server" OnClick="Ingresar" Text="Ingresar" CssClass="btn btn-primary btn-block"></asp:Button>
                        </div>
                        <div class="col-sm">
                            <asp:Button runat="server" OnClick="Registrar" Text="Registrar" CssClass="btn btn-success btn-block"></asp:Button>
                        </div>
                    </div>
                    </div>           
            </div>
	</form>
        <script>
            document.getElementById("pass").type="password";
        </script>
</body>
</html>
