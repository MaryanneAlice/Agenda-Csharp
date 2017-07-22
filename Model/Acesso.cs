using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Acesso : IId
    {
        private int id;
        private int idUsuario;
        private DateTime data;

        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
