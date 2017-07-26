using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Acessos
    {

        private Persistence.Acesso p = new Persistence.Acesso();

        public List<Model.Acesso> Selecionar()
        {
            return p.Selecionar();
        }

        public void Inserir(Model.Acesso a)
        {

            p.Inserir(a);
    
        }

        public void Atualizar(Model.Acesso a)
        {
            p.Atualizar(a);
        }

        public void Deletar(Model.Acesso a)
        {
            p.Deletar(a);
        }
    }
}
