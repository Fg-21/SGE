using Data.DB;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Data.Repos
{
    public class RepoPersonas : IRepoPersonas
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public RepoPersonas()
        {
            _connectionString = Connection.getConnectionString();
        }
        #endregion

        #region CRUD Methods
        public int createPersona(Persona newPersona)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = @"INSERT INTO Personas 
                                    (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) 
                                    VALUES (@Nombre, @Apellidos, @Telefono, @Direccion, @Foto, @FechaNacimiento, @IDDepartamento)",
                    Connection = miConexion
                };

                miComando.Parameters.AddWithValue("@Nombre", newPersona.nombre);
                miComando.Parameters.AddWithValue("@Apellidos", newPersona.apellidos);
                miComando.Parameters.AddWithValue("@Telefono", newPersona.telefono);
                miComando.Parameters.AddWithValue("@Direccion", newPersona.direccion);
                miComando.Parameters.AddWithValue("@Foto", newPersona.foto);
                miComando.Parameters.AddWithValue("@FechaNacimiento", newPersona.fecha);
                miComando.Parameters.AddWithValue("@IDDepartamento", newPersona.idDepartamento);

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

            return rowsAffected;
        }

        public Persona getPersonaById(int id)
        {
            Persona oPersona = null;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = "SELECT * FROM Personas WHERE ID=@ID",
                    Connection = miConexion
                };

                miComando.Parameters.AddWithValue("@ID", id);

                try
                {
                    miConexion.Open();
                    using (SqlDataReader miLector = miComando.ExecuteReader())
                    {
                        if (miLector.HasRows && miLector.Read())
                        {
                            oPersona = new Persona
                            {
                                id = (int)miLector["ID"],
                                nombre = (string)miLector["Nombre"],
                                apellidos = (string)miLector["Apellidos"],
                                telefono = (string)miLector["Telefono"],
                                direccion = (string)miLector["Direccion"],
                                foto = (string)miLector["Foto"],
                                fecha = miLector["FechaNacimiento"] != DBNull.Value ? (DateTime)miLector["FechaNacimiento"] : DateTime.MinValue,
                                idDepartamento = (int)miLector["IDDepartamento"]
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return oPersona;
        }

        public Persona[] getListaPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>();

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = "SELECT * FROM Personas",
                    Connection = miConexion
                };

                try
                {
                    miConexion.Open();
                    using (SqlDataReader miLector = miComando.ExecuteReader())
                    {
                        if (miLector.HasRows)
                        {
                            while (miLector.Read())
                            {
                                Persona oPersona = new Persona
                                {
                                    id = (int)miLector["ID"],
                                    nombre = (string)miLector["Nombre"],
                                    apellidos = (string)miLector["Apellidos"],
                                    telefono = (string)miLector["Telefono"],
                                    direccion = (string)miLector["Direccion"],
                                    foto = (string)miLector["Foto"],
                                    fecha = miLector["FechaNacimiento"] != DBNull.Value ? (DateTime)miLector["FechaNacimiento"] : DateTime.MinValue,
                                    idDepartamento = (int)miLector["IDDepartamento"]
                                };
                                listadoPersonas.Add(oPersona);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return listadoPersonas.ToArray();
        }

        public int updatePersona(int id, Persona ePersona)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = @"UPDATE Personas SET 
                                    Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, 
                                    Direccion=@Direccion, Foto=@Foto, FechaNacimiento=@FechaNacimiento, IDDepartamento=@IDDepartamento
                                    WHERE ID=@ID",
                    Connection = miConexion
                };

                miComando.Parameters.AddWithValue("@Nombre", ePersona.nombre);
                miComando.Parameters.AddWithValue("@Apellidos", ePersona.apellidos);
                miComando.Parameters.AddWithValue("@Telefono", ePersona.telefono);
                miComando.Parameters.AddWithValue("@Direccion", ePersona.direccion);
                miComando.Parameters.AddWithValue("@Foto", ePersona.foto);
                miComando.Parameters.AddWithValue("@FechaNacimiento", ePersona.fecha);
                miComando.Parameters.AddWithValue("@IDDepartamento", ePersona.idDepartamento);
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

            return rowsAffected;
        }

        public int deletePersona(int id)
        {
            int rowsAffected = 0;

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = "DELETE FROM Personas WHERE ID=@ID",
                    Connection = miConexion
                };

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

            return rowsAffected;
        }

        public List<Persona> getLISTAPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>();

            using (SqlConnection miConexion = new SqlConnection(_connectionString))
            {
                SqlCommand miComando = new SqlCommand
                {
                    CommandText = "SELECT * FROM Personas",
                    Connection = miConexion
                };

                try
                {
                    miConexion.Open();
                    using (SqlDataReader miLector = miComando.ExecuteReader())
                    {
                        if (miLector.HasRows)
                        {
                            while (miLector.Read())
                            {
                                Persona oPersona = new Persona
                                {
                                    id = (int)miLector["ID"],
                                    nombre = (string)miLector["Nombre"],
                                    apellidos = (string)miLector["Apellidos"],
                                    telefono = (string)miLector["Telefono"],
                                    direccion = (string)miLector["Direccion"],
                                    foto = (string)miLector["Foto"],
                                    fecha = miLector["FechaNacimiento"] != DBNull.Value ? (DateTime)miLector["FechaNacimiento"] : DateTime.MinValue,
                                    idDepartamento = (int)miLector["IDDepartamento"]
                                };
                                listadoPersonas.Add(oPersona);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return listadoPersonas;
        }
        #endregion
    }
}
