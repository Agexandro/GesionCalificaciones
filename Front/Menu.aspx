<%@ Page Language="C#" %>
<% if(Session["_idu"]=="" | Session["_idu"]==null){
Response.Redirect("Default.aspx");
}
%>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Menu</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">

</head>
<body>
	<form id="form1" runat="server">
        <nav class="navbar navbar-dark bg-dark">
            <a class="navbar-brand" href="GMaterias.aspx">Gesitionar mis materias</a>
        </nav>            
	</form>
</body>
</html>
