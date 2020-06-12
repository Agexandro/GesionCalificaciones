using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Back;
using MySql.Data.MySqlClient;

namespace Front
{

    public partial class GMaterias : System.Web.UI.Page
    {

        static CRUD crud = new CRUD();
        protected void Page_Load(Object o, EventArgs e)
        {
            if (Session["_idu"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                List<genericObject> dataSource = crud.ListaMaterias(Convert.ToInt32(Session["_idu"]));
                grid.AutoGenerateColumns = false;
                grid.DataSource = dataSource;
                grid.DataBind();
            }

        }

        protected void Calificaciones_row(Object o,GridViewCommandEventArgs a)
        {
            string idm = grid.Rows[int.Parse(a.CommandArgument.ToString())].Cells[0].Text;
            string nombreMateria= grid.Rows[int.Parse(a.CommandArgument.ToString())].Cells[1].Text;

            if (a.CommandName.Equals("cnDelete"))
            {
                try
                {
                    crud.EliminarMateria(idm);
                    Response.Redirect("GMaterias.aspx?&status=deleted");
                }
                catch (MySqlException)
                {
                    Response.Redirect("GMaterias.aspx?&status=noDeleted");
                }

            }
            else
            {
                Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + nombreMateria);
            }
        }



        protected void Logout(Object o, EventArgs a)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        public void InsertarMateria(object o, EventArgs a)
        {
            string _materia = materia.Text.Trim()+"";
            if (_materia != "")
            {
                try
                {
                    if (crud.EncontrarMaterias(Convert.ToString(HttpContext.Current.Session["_idu"]), _materia).Equals(_materia, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Response.Redirect("GMaterias.aspx?&status=exists");
                    }
                    else
                    {
                        crud.RegistrarMateria(Convert.ToString(HttpContext.Current.Session["_idu"]), _materia);
                        Response.Redirect("GMaterias.aspx?&status=success");
                    }
                }
                catch (MySqlException)
                {
                    Response.Redirect("GMaterias.aspx?&status=sqlError");
                }
            }
            else
            {
                Response.Redirect("GMaterias.aspx?&status=empty");
            }
        }


    }
}
