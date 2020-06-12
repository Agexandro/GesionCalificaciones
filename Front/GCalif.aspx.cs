using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Back;
using MySql.Data.MySqlClient;

namespace Front
{

    public partial class GCalif : System.Web.UI.Page
    {

        static CRUD crud = new CRUD();
        protected void Page_Load(Object o, EventArgs a)
        {
            if (Session["_idu"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                List<genericObject> dataSource = crud.ListaCalificaciones(Convert.ToString(Request.QueryString["idm"]));
                grid.AutoGenerateColumns = false;
                grid.DataSource = dataSource;
                grid.DataBind();
            }
        }

        protected void Logout(Object o, EventArgs a)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void InsertarCalificacion(object o, EventArgs e)
        {
            string _unidad = unidad.Text.Trim();
            string _cali = cali.Text.Trim();
            string idm = Request.QueryString["idm"];
            string materia = Request.QueryString["materia"];


            if (_unidad == "" && _cali == "")
            {
                Response.Redirect("GCalif.aspx?&idm=" + idm +"&materia="+materia+"&status=empty");
            }
            else
            {
                if (_unidad == "")
                {
                    Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + materia + "&status=emptyu");
                }
                else
                {
                    if (_cali == "")
                    {
                        Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + materia + "&status=emptyc");
                    }
                    else
                    {
                        try
                        {
                            if (crud.EncontrarCalificacion(idm, _unidad) != "")
                            {
                                Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + materia + "&status=exists");
                            }
                            else
                            {
                                crud.RegistrarCalificacion(idm, _unidad, _cali);
                                Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + materia + "&status=success");

                            }
                        }
                        catch (MySqlException)
                        {
                            Response.Redirect("GCalif.aspx?&idm=" + idm + "&materia=" + materia + "&status=error");
                        }
                    }
                }
            }

        }

        protected void Unidades_row(Object o, GridViewCommandEventArgs a)
        {
            string _unidad = grid.Rows[int.Parse(a.CommandArgument.ToString())].Cells[0].Text;
            string calificacion = grid.Rows[int.Parse(a.CommandArgument.ToString())].Cells[1].Text;
            string idm = Request.QueryString["idm"];
            string materia = Request.QueryString["materia"];


            try
            {
                crud.EliminarCalificacion(idm,_unidad);
                Response.Redirect("GCalif.aspx?&idm=" + idm+"&materia=" + materia+"&status=deleted");
            }
            catch (MySqlException)
            {
                Response.Redirect("GCalif.aspx?&idc=" + idm+"&materia=" + materia+"&status=noDeleted");
            }
        }
    }
}