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
    public class RepoPersonasAzure : IRepoPersonasDepartamentos
    {
        #region CRUDPersona
        public int createPersona(Persona newPersona)
        {
            int filasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Persona oPersona = new Persona();

            miConexion.ConnectionString = Connection.getConnectionString();

            try

            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = $"INSERT INTO Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) VALUES" +
                    $"('{newPersona.nombre}'," +
                    $" '{newPersona.apellidos}'," +
                    $" '{newPersona.telefono}')," +
                    $" '{newPersona.direccion}'," +
                    $" '{newPersona.foto}'," +
                    $" '{newPersona.fecha}'," +
                    $" '{newPersona.idDepartamento}'";

                miComando.Connection = miConexion;

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException exSql)

            {
                throw exSql;
            }
            return filasAfectadas;
        }
        public Persona getPersonaById(int id)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Persona oPersona = new Persona();

            miConexion.ConnectionString = Connection.getConnectionString();

            try

            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)


                miComando.CommandText = $"SELECT * FROM Personas where ID = {id}";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.Read())

                {
                    oPersona.id = (int)miLector["ID"];

                    oPersona.nombre = (string)miLector["Nombre"];

                    oPersona.apellido = (string)miLector["Apellidos"];

                    //Si sospechamos que el campo puede ser Null en la BBDD

                    if (miLector["FechaNacimiento"] != System.DBNull.Value)
                    {
                        oPersona.fecha = (DateTime)miLector["FechaNacimiento"];
                    }

                    oPersona.direccion = (string)miLector["Direccion"];

                    oPersona.telefono = (string)miLector["Telefono"];

                }
                else
                {
                    oPersona = null;
                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {
                throw exSql;
            }
            return oPersona;
        }
        public int updatePersona(int id, Persona ePersona)
        {
            int filasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            miConexion.ConnectionString = Connection.getConnectionString();

            try

            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = $"UPDATE Personas SET " +
                    $"Nombre = {ePersona.nombre}, " +
                    $"Apellidos = {ePersona.apellidos}, " +
                    $"Telefono = {ePersona.telefono}, " +
                    $"Direccion = {ePersona.direccion}, " +
                    $"Foto = {ePersona.foto}, " +
                    $"FechaNacimiento = {ePersona.fecha}, " +
                    $"IDDepartamento = {ePersona.idDepartamento}";


                miComando.Connection = miConexion;

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException exSql)

            {
                throw exSql;
            }

            return filasAfectadas;
        }
        public int deletePersona(int id)
        {
            int filasAfectadas;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Persona oPersona = new Persona();

            miConexion.ConnectionString = Connection.getConnectionString();

            try

            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = $"DELETE FROM Personas where ID = {id}";

                miComando.Connection = miConexion;

                filasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException exSql)

            {
                throw exSql;
            }
            return filasAfectadas;
        }
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

                        oPersona.id = (int)miLector["ID"];

                        oPersona.nombre = (string)miLector["Nombre"];

                        oPersona.apellidos = (string)miLector["Apellidos"];

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fecha = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.direccion = (string)miLector["Direccion"];

                        oPersona.telefono = (string)miLector["Telefono"];

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
        #endregion

        #region CRUDDepartamento
        public Departamento[] getDepartamentos()
        {
            Departamento oDepartamento;

            List<Departamento> lista = new List<Departamento>();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

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

                        oDepartamento = new Departamento();

                        oDepartamento.id = (int)miLector["ID"];

                        oDepartamento.nombre = (string)miLector["Nombre"];

                        lista.Add(oDepartamento);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

           return lista.ToArray();
        }

        public int createDepartamento(Departamento newDepartamento)
        {
            throw new NotImplementedException();
        }

        public Departamento getDepartamentoById(int id)
        {
            throw new NotImplementedException();
        }

        public int updateDepartamento(int id, Departamento eDepartamento)
        {
            throw new NotImplementedException();
        }

        public int deleteDepartamento(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

