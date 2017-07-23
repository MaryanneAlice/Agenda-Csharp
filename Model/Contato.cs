using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Contato : IId
    {
        private int id;
        public string nome;
        public string telefone;
        public string email;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        public Contato() { }

        public override string ToString()
        {
            return $"{Nome} - {Email} - {Telefone}";
        }
    }
}
