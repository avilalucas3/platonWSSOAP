using socrateWSSOAP.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace socrateWSSOAP.Persistencia
{
    public class AlumnoDAO
    {
        private String CadenaConexion = "Data source =(local); Initial Catalog = socrates; Integrated Security=SSPI;";

        public Alumno Crear(Alumno alumnoACrear)
        {
            Alumno alumnoCreado;
            string sql = "INSERT INTO alumno VALUES(@codigoalumno,@nombrealumno,@apellidoalumno,@dnialumno,@correoalumno)";
            using(SqlConnection conexion= new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using(SqlCommand comando =new SqlCommand(sql,conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoalumno",alumnoACrear.Codigoalumno));
                    comando.Parameters.Add(new SqlParameter("@nombrealumno", alumnoACrear.Nombrealumno));
                    comando.Parameters.Add(new SqlParameter("@apellidoalumno", alumnoACrear.Apellidoalumno));
                    comando.Parameters.Add(new SqlParameter("@dnialumno", alumnoACrear.Dnialumno));
                    comando.Parameters.Add(new SqlParameter("@correoalumno", alumnoACrear.Correoalumno));
                    comando.ExecuteNonQuery();
                }
                alumnoCreado = Obtener(alumnoACrear.Codigoalumno);
                return alumnoCreado;
            }
        }
  

        public Alumno Obtener(string codigo)
        {
            Alumno alumnoEncontrado = null;
            string sql = "SELECT * FROM alumno WHERE codigoalumno=@codigoalumno";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoalumno", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            alumnoEncontrado = new Alumno()
                            {
                                Codigoalumno = (string)resultado["codigoalumno"],
                                Nombrealumno = (string)resultado["nombrealumno"],
                                Apellidoalumno = (string)resultado["apellidoalumno"],
                                Dnialumno = (string)resultado["dnialumno"],
                                Correoalumno = (string)resultado["correoalumno"]
                            };
                        }
                    }
                }
                return alumnoEncontrado;
            }
        
        }

        public Alumno Modificar(Alumno AlumnoAModificar)
        {
            Alumno AlumnoModificado;
            string sql = "UPDATE alumno SET nombrealumno=@nombrealumno," + 
                "apellidoalumno=@apellidoalumno,dnialumno=@dnialumno,correoalumno=@correoalumno " + 
                "WHERE codigoalumno=@codigoalumno";
            using(SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using(SqlCommand comando = new SqlCommand(sql,conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoalumno", AlumnoAModificar.Codigoalumno));
                    comando.Parameters.Add(new SqlParameter("@nombrealumno", AlumnoAModificar.Nombrealumno));
                    comando.Parameters.Add(new SqlParameter("@apellidoalumno", AlumnoAModificar.Apellidoalumno));
                    comando.Parameters.Add(new SqlParameter("@dnialumno", AlumnoAModificar.Dnialumno));
                    comando.Parameters.Add(new SqlParameter("@correoalumno", AlumnoAModificar.Correoalumno));
                    comando.ExecuteNonQuery();
                }
                AlumnoModificado = Obtener(AlumnoAModificar.Codigoalumno);
                return AlumnoModificado;
            }
        }

        public void Eliminar(string codigo)
        {
            string sql = "DELETE FROM alumno WHERE codigoalumno=@codigoalumno";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using(SqlCommand comando = new SqlCommand(sql,conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoalumno", codigo));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Alumno> Listar()
        {
            List<Alumno> alumnosEncontrados = new List<Alumno>();
            Alumno alumnoEncontrado;
            string sql = "SELECT * FROM alumno";
            using(SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using(SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while(resultado.Read())
                        {
                            alumnoEncontrado = new Alumno()
                            {
                                Codigoalumno = (string)resultado["codigoalumno"],
                                Nombrealumno = (string)resultado["nombrealumno"],
                                Apellidoalumno = (string)resultado["apellidoalumno"],
                                Dnialumno = (string)resultado["dnialumno"],
                                Correoalumno = (string)resultado["correoalumno"]
                            };
                            alumnosEncontrados.Add(alumnoEncontrado);
                        }
                    }
                }
            }
            return alumnosEncontrados;
        }
    }
}