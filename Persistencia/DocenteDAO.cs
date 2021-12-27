using socrateWSSOAP.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace socrateWSSOAP.Persistencia
{
    public class DocenteDAO
    {
        private String CadenaConexion = "Data source =(local); Initial Catalog = socrates; Integrated Security=SSPI;";

        public Docente Crear(Docente docenteACrear)
        {
            Docente docenteCreado;
            string sql = "INSERT INTO docente VALUES(@codigodocente,@nombredocente,@apellidodocente,@dnidocente,@correodocente)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigodocente", docenteACrear.Codigodocente));
                    comando.Parameters.Add(new SqlParameter("@nombredocente", docenteACrear.Nombredocente));
                    comando.Parameters.Add(new SqlParameter("@apellidodocente", docenteACrear.Apellidodocente));
                    comando.Parameters.Add(new SqlParameter("@dnidocente", docenteACrear.Dnidocente));
                    comando.Parameters.Add(new SqlParameter("@correodocente", docenteACrear.Correodocente));
                    comando.ExecuteNonQuery();
                }
                docenteCreado = Obtener(docenteACrear.Codigodocente);
                return docenteCreado;
            }
        }

        public Docente Obtener(int codigo)
        {
            Docente docenteEncontrado = null;
            string sql = "SELECT * FROM docente WHERE codigodocente=@codigodocente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigodocente", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            docenteEncontrado = new Docente()
                            {
                                Codigodocente = (int)resultado["codigodocente"],
                                Nombredocente = (string)resultado["nombredocente"],
                                Apellidodocente = (string)resultado["apellidodocente"],
                                Dnidocente = (string)resultado["dnidocente"],
                                Correodocente = (string)resultado["correodocente"]
                            };
                        }
                    }
                }
                return docenteEncontrado;
            }
        }

        public Docente Modificar(Docente docenteAModificar)
        {
            Docente DocenteModificado;
            string sql = "UPDATE docente SET nombredocente=@nombredocente," +
                "apellidodocente=@apellidodocente,dnidocente=@dnidocente,correodocente=@correodocente " +
                "WHERE codigodocente=@codigodocente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigodocente", docenteAModificar.Codigodocente));
                    comando.Parameters.Add(new SqlParameter("@nombredocente", docenteAModificar.Nombredocente));
                    comando.Parameters.Add(new SqlParameter("@apellidodocente", docenteAModificar.Apellidodocente));
                    comando.Parameters.Add(new SqlParameter("@dnidocente", docenteAModificar.Dnidocente));
                    comando.Parameters.Add(new SqlParameter("@correodocente", docenteAModificar.Correodocente));
                    comando.ExecuteNonQuery();
                }
                DocenteModificado = Obtener(docenteAModificar.Codigodocente);
                return DocenteModificado;
            }
        }

        public void Eliminar(int codigo)
        {
            string sql = "DELETE FROM docente WHERE codigodocente=@codigodocente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigodocente", codigo));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Docente> Listar()
        {
            List<Docente> docentesEncontrados = new List<Docente>();
            Docente docenteEncontrado;
            string sql = "SELECT * FROM docente";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            docenteEncontrado = new Docente()
                            {
                                Codigodocente = (int)resultado["codigodocente"],
                                Nombredocente = (string)resultado["nombredocente"],
                                Apellidodocente = (string)resultado["apellidodocente"],
                                Dnidocente = (string)resultado["dnidocente"],
                                Correodocente = (string)resultado["correodocente"]
                            };
                            docentesEncontrados.Add(docenteEncontrado);
                        }
                    }
                }
            }
            return docentesEncontrados;
        }
    }
}