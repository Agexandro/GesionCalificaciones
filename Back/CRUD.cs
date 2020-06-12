using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Back
{
    public class CRUD
    {

        MySqlConnection connection;
        public void Connection()
        {
            connection = new MySqlConnection("Server=127.0.0.1; Database=materias; Uid=admin; pwd='root';");
            connection.Open();
        }

        public void RegistrarUsuario(string usr, string pass)
        {
                Connection();
                MySqlCommand command = new MySqlCommand(string.Format("insert into usuario(usuario, contrasena) values('{0}', sha1('{1}'))"
                , usr, pass), connection);
                command.ExecuteNonQuery();
                connection.Close();
        }



        public genericObject VerificarUsuario(string usr, string pass)
        {
            genericObject usuario = null;
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("SELECT*from usuario where usuario = '{0}' and contrasena = sha1('{1}')"
            , usr, pass), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                usuario = new genericObject(reader.GetString(0), reader.GetString(1));
            }
            connection.Close();
            return usuario;
        }

        public string EncontrarUsuario(string usr)
        {
            string _idu = "";
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("SELECT*from usuario where usuario = '{0}'"
            , usr), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                _idu = reader.GetString(0);
            }
            connection.Close();
            return _idu;
        }


        public void RegistrarMateria(string idu, string subject)
        {
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("insert into materia(_idu, materia) values('{0}', '{1}')"
            , idu, subject), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public string EncontrarMaterias(string idu, string subject)
        {
            Connection();
            string result = "";
            MySqlCommand command = new MySqlCommand(string.Format("SELECT materia from materia where _idu = '{0}' and materia = '{1}'"
            , idu, subject), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetString(0);
            }
            connection.Close();
            return result;
        }

        public void EliminarMateria(string idm)
        {
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("delete from materia where _idm = '{0}'"
            , idm), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<genericObject> ListaMaterias(int idu)
        {
            List<genericObject> dataList = new List<genericObject>();
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("select _idm, materia from materia where _idu ='{0}'"
            , idu), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataList.Add(new genericObject(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            return dataList;
        }


        public void RegistrarCalificacion(string idm, string unidad, string calificacion)
        {
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("insert into calificacion(_idm,unidad,calificacion) values('{0}','{1}','{2}')"
            , idm, unidad, calificacion), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string EncontrarCalificacion(string idm, string unidad )
        {
            Connection();
            string result = "";
            MySqlCommand command = new MySqlCommand(string.Format("select*from calificacion where _idm ='{0}' and unidad ='{1}'"
            , idm, unidad), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetString(0);
            }
            connection.Close();
            return result;
        }

        public List<genericObject> ListaCalificaciones(string idm)
        {
            List<genericObject> dataList = new List<genericObject>();
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("select unidad,calificacion from calificacion where _idm ='{0}' order by unidad asc"
            , idm), connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataList.Add(new genericObject(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            return dataList;
        }

        public void EliminarCalificacion(string idm, string unidad)
        {
            Connection();
            MySqlCommand command = new MySqlCommand(string.Format("delete from calificacion where _idm = '{0}' and unidad = '{1}'"
            , idm,unidad), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


    }

}
//kleon0313@gmail.com root1