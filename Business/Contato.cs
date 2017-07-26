using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business
{
    public class Contato : Model.Usuario
    {
        private Persistence.Contato p = new Persistence.Contato();
              
        public List<Model.Contato> Selecionar()
        {
            return p.Selecionar();
        }

        public void Inserir(Model.Contato c)
        {
            // Valida o novo usuario
            if (c == null)
                throw new ArgumentNullException("Dados nao informados!");            
            p.Inserir(c);
        }

        public void Atualizar(Model.Contato c)
        {
            p.Atualizar(c);
        }

        public void Deletar(Model.Contato c)
        {
            p.Deletar(c);
        }
    }
}
