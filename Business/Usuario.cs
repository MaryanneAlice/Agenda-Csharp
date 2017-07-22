using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Usuario
    {
        private Persistence.Usuario p = new Persistence.Usuario();

        public List<Model.Usuario> Selecionar()
        {
            return p.Selecionar();
        }

        public void Inserir(Model.Usuario u)
        {
            // Valida o novo usuario
              if (u == null)
                throw new ArgumentNullException("Dados nao informados!");
              if (p.Selecionar().Where(r => r.Id == u.Id).Count() > 0)
                throw new InvalidOperationException("Usuario já cadastrado");          
            p.Inserir(u);
        }

        public void Atualizar(Model.Usuario u)
        {
            p.Atualizar(u);
        }

        public void Deletar(Model.Usuario u)
        {
            p.Deletar(u);
        }

    }
}
