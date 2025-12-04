using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DB;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Data.Repos
{
    public class RepoDepartamentos : IRepoDepartamentos
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public RepoDepartamentos()
        {
            _connectionString = Connection.getConnectionString();
        }
        #endregion

        #region CRUD Methods
        public int createDepartamento(Departamento newDepartamento)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", newDepartamento.nombre);

                    try
                    {
                        miConexion.Open();
                        rowsAffected = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return rowsAffected;
        }

        public Departamento getDepartamentoById(int id)
        {
            Departamento dpto = null;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Departamentos WHERE ID=@ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.HasRows && miLector.Read())
                            {
                                dpto = new Departamento
                                {
                                    id = (int)miLector["ID"],
                                    nombre = (string)miLector["Nombre"]
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dpto;
        }

        public Departamento[] getListaDepartamento()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Departamentos";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.HasRows)
                            {
                                while (miLector.Read())
                                {
                                    Departamento dpto = new Departamento
                                    {
                                        id = (int)miLector["ID"],
                                        nombre = (string)miLector["Nombre"]
                                    };
                                    lista.Add(dpto);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return lista.ToArray();
        }

        public int updateDepartamento(int id, Departamento eDepartamento)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Departamentos SET Nombre=@Nombre WHERE ID=@ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", eDepartamento.nombre);
                    miComando.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        miConexion.Open();
                        rowsAffected = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return rowsAffected;
        }

        public int deleteDepartamento(int id)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Departamentos WHERE ID=@ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        miConexion.Open();
                        rowsAffected = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return rowsAffected;
        }
        #endregion

        List<Departamento> getLISTADepartamento()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Departamentos";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.HasRows)
                            {
                                while (miLector.Read())
                                {
                                    Departamento dpto = new Departamento
                                    {
                                        id = (int)miLector["ID"],
                                        nombre = (string)miLector["Nombre"]
                                    };
                                    lista.Add(dpto);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return lista;
        }

        #region Extra Methods
        public int contarPersonasDepartamentos(int idDepartamento)
        {
            int contador = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT COUNT(*) FROM Personas WHERE IDDepartamento = @IDDepartamento";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@IDDepartamento", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        contador = (int)miComando.ExecuteScalar();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return contador;
        }

        List<Departamento> IRepoDepartamentos.getLISTADepartamento()
        {
            return getLISTADepartamento();
        }
        #endregion
    }
}

