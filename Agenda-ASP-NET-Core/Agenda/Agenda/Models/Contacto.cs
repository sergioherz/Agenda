using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Agenda.Models
{
    public class Contacto
    {
        public static string cadenaConexion { get; set;}

        public string nombre { get; set; }
        public string email { get; set; }
        public string apellido { get; set; }
        public string telCel { get; set; }
        

        public bool Guardar(){

            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "insert into Contactos values(?,?,?,?)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", this.nombre);
            comando.Parameters.AddWithValue("@apellido", this.apellido);
            comando.Parameters.AddWithValue("@email", this.email);
            comando.Parameters.AddWithValue("@telCel", this.telCel);
            

            int filas = comando.ExecuteNonQuery();
            conexion.Close();

            return (filas>0);
        }

        public List<Contacto> Consultar(){
            List<Contacto> contactos = new List<Contacto>();

            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "select * from Contactos";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Contacto c = new Contacto();
                c.nombre = lector["nombre"].ToString();
                c.email = lector["email"].ToString();
                c.apellido = lector["apellido"].ToString();
                c.telCel = lector["telCel"].ToString();
               
                contactos.Add(c);
            }

            lector.Close();

            conexion.Close();

            return contactos;
        }

        public bool Eliminar(){
            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "delete from Contactos where email = ?";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@email", this.email);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            return (filas > 0);
        }

        public bool Buscar(){
            bool encontrado = false;
            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "select * from Contactos";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                this.nombre = lector["nombre"].ToString();
                this.email = lector["email"].ToString();
                this.apellido = lector["apellido"].ToString();
                this.telCel = lector["telCel"].ToString();
                

            }

            lector.Close();

            conexion.Close();

            return encontrado;
        }

        public bool Editar()
        {

            MySqlConnection conexion = new MySqlConnection(Contacto.cadenaConexion);
            conexion.Open();
            string sql = "update Contactos set nombre=?,apellido=?,telCel=? where Contactos.email=?";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", this.nombre);
            comando.Parameters.AddWithValue("@apellido", this.apellido);
            comando.Parameters.AddWithValue("@telCel", this.telCel);
            comando.Parameters.AddWithValue("@email", this.email);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();

            return (filas > 0);
        }
        public Contacto()
        {
        }

        public Contacto(string email){
            this.email = email;
           

        }
    }
}
