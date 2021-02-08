using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUserZeroCode.Logica
{
    class lUsers
    {
        private int Id_Usuarios;
        private string Usuarios;
        private string Password;
        private byte[] Icono;
        private string Estado;

        public int idusarios{ get { return Id_Usuarios; } set { Id_Usuarios = value; } }
        public string usuarios { get { return Usuarios; } set { Usuarios = value; } }
        public string pass { get { return Password; } set { Password = value; } }
        public byte[] icono { get { return Icono; } set { Icono = value; } }
        public string estado { get { return Estado; } set { Estado = value; } }

        public lUsers() { }
        public lUsers(int Id_Usuarios, string Usuarios, string Password, byte[] Icono, string Estado) {
            idusarios = Id_Usuarios;
            usuarios = Usuarios;
            pass = Password;
            icono = Icono;
            estado = Estado;
        }

    }
}
