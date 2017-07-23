using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Usuario
    {
        
        private string arquivo = "c:\\Users\\marya\\Desktop\\usuarios.json";

        public List<Model.Usuario> Selecionar()
        {
            return ArquivoJson<Model.Usuario>.Selecionar(arquivo);
        }
        public void Inserir(Model.Usuario u)
        {
            ArquivoJson<Model.Usuario>.Inserir(arquivo, u);
        }
        public void Atualizar(Model.Usuario v)
        {
            ArquivoJson<Model.Usuario>.Atualizar(arquivo, v);
        }
        public void Deletar(Model.Usuario u)
        {
            ArquivoJson<Model.Usuario>.Deletar(arquivo, u);
        }
    }
}
