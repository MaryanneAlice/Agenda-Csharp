using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business
{
    public class Contato
    {
        private Persistence.Contato p = new Persistence.Contato();


        public List<Model.Contato> Selecionar(string nomeUser)
        {
            return p.Selecionar(nomeUser);
        }

        public void Inserir(Model.Contato c, string nomeUser)
        {
            // Valida o novo usuario
            if (c == null)
                throw new ArgumentNullException("Dados nao informados!");            
            p.Inserir(c, nomeUser);
        }

        public void Atualizar(Model.Contato c, string nomeUser)
        {
            p.Atualizar(c, nomeUser);
        }

        public void Deletar(Model.Contato c, string nomeUser)
        {
            p.Deletar(c, nomeUser);
        }
    }
}
