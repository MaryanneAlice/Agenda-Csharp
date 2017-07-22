using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario : IId
    {
        private int id;
        private string senha;
        private string login;
        private bool admin;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public bool Admin { get => admin; set => admin = value; }

    }
}
