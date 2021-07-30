using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DCurso
    {
        private int _Idcurso;
        private string _Nombre;
        private string _Turno;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idcurso { get => _Idcurso; set => _Idcurso = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Turno { get => _Turno; set => _Turno = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //contructor vacio
        public DCurso()
        {

        }

        //contructor con parametros
        public DCurso(int idcurso, string nombre, string turno, string descripcion, string textobuscar)
        {
            this.Idcurso = idcurso;
            this.Nombre = nombre;
            this.Turno = turno;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DCurso Curso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                //Establecer la cadena
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //estaclecer comandos para la sentencias   sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_curso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcurso = new SqlParameter();
                ParIdcurso.ParameterName = "@idcurso";
                ParIdcurso.SqlDbType = SqlDbType.Int;
                ParIdcurso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcurso);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Curso.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = 10;
                ParTurno.Value = Curso.Turno;
                SqlCmd.Parameters.Add(ParTurno);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Curso.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            //para limpiar todo lo acontecido, se ejecutará si o si
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;

        }

        public string Editar(DCurso Curso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                //Establecer la cadena
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //estaclecer comandos para la sentencias   sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_curso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcurso = new SqlParameter();
                ParIdcurso.ParameterName = "@idcurso";
                ParIdcurso.SqlDbType = SqlDbType.Int;
                ParIdcurso.Value = Curso.Idcurso;
                SqlCmd.Parameters.Add(ParIdcurso);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Curso.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParTurno = new SqlParameter();
                ParTurno.ParameterName = "@turno";
                ParTurno.SqlDbType = SqlDbType.VarChar;
                ParTurno.Size = 15;
                ParTurno.Value = Curso.Turno;
                SqlCmd.Parameters.Add(ParTurno);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Curso.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizó el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            //para limpiar todo lo acontecido, se ejecutará si o si
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(DCurso Curso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo 
                //Establecer la cadena
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //estaclecer comandos para la sentencias   sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_curso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcurso = new SqlParameter();
                ParIdcurso.ParameterName = "@idcurso";
                ParIdcurso.SqlDbType = SqlDbType.Int;
                ParIdcurso.Value = Curso.Idcurso;
                SqlCmd.Parameters.Add(ParIdcurso);

               

                //ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";

            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            //para limpiar todo lo acontecido, se ejecutará si o si
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        //Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("CURSO");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_curso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch(Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //Metodo Buscar Nombre
        public DataTable BuscarNombre(DCurso Curso)
        {
            DataTable DtResultado = new DataTable("CURSO");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_curso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Curso.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }



    }
}
