using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAlumno
    {
        private int _Idalumno;
        private string _Nombre;
        private string _Apellidos;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Tipo_Documento;
        private string _Direccion;
        private int _Telefono;
        private string _Email;
        private byte[] _Imagen;
    }
}
