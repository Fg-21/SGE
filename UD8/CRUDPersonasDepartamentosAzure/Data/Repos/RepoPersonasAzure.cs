using Data.DB;
using Domain.Entities;
using Domain.Repos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class RepoPersonasAzure : IGetListaPersonas
    {
        public Persona[] getListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<Persona> listadoPersonas = new List<Persona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Persona oPersona;

            miConexion.ConnectionString = Connection.getConnectionString();

            try

            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)


                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new Persona();

                        oPersona.id = (int)miLector["IDPersona"];

                        oPersona.nombre = (string)miLector["nombre"];

                        oPersona.apellido = (string)miLector["apellidos"];

                    //Si sospechamos que el campo puede ser Null en la BBDD

                    if (miLector["fechaNac"] != System.DBNull.Value)
                        {
                            oPersona.fecha = (DateTime)miLector["fechaNac"];
                        }

                        oPersona.direccion = (string)miLector["direccion"];

                        oPersona.telefono = (string)miLector["telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

            return listadoPersonas.ToArray();

        }
    }
}

