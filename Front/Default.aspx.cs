using System;
using Back;
using MySql.Data.MySqlClient;


namespace Front
{
    partial class Default : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        private bool validar()
        {
            bool condition = false;
            if (usr.Text == "" && pass.Text == "")
            {
                Response.Redirect("Default.aspx?&error=empty&usuario=null&contraseña=null");
            }
            else
            {
                if (usr.Text == "")
                {
                    Response.Redirect("Default.aspx?&error=emptyu&usuario=null");
                }
                else
                {
                    if (pass.Text == "")
                    {
                        Response.Redirect("Default.aspx?&error=emptyp&usuario=" + usr.Text);
                    }
                    else
                    {
                        condition = true;
                    }
                }
            }
            return condition;
        }

        private void ingresar()
        {
            try
            {
                genericObject genericUsr = crud.VerificarUsuario(usr.Text, pass.Text);
                if (genericUsr == null)
                {
                    Response.Redirect("Default.aspx?&error=nouser");
                }
                else
                {
                    Session["_idu"] = genericUsr.id;
                    Session["usuario"] = genericUsr.value;
                    Response.Redirect("Menu.aspx");
                }
            }
            catch (MySqlException)
            {
                Response.Redirect("Default.aspx?&error=sqlError");
            }

        }

        protected void Registrar(object o, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    if (crud.EncontrarUsuario(usr.Text) == "")
                    {
                        crud.RegistrarUsuario(usr.Text, pass.Text);
                        ingresar();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx?&error=exists");
                    }
                }
                catch (MySqlException)
                {
                    Response.Redirect("Default.aspx?&error=sqlError");
                }
            }
            }

        protected void Ingresar(Object o, EventArgs a)
        {
            if (validar())
            {
                ingresar();
            }
        }
    }
    }
