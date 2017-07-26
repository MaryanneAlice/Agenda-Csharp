using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Contato
    {

        private string arquivo = "c:\\Users\\marya\\Desktop\\contatos.json";


        public List<Model.Contato> Selecionar()
        {
            return ArquivoJson<Model.Contato>.Selecionar(arquivo);
        }

        public void Inserir(Model.Contato c)
        {
            ArquivoJson<Model.Contato>.Inserir(arquivo, c);
        }

        public void Atualizar(Model.Contato c)
        {
            ArquivoJson<Model.Contato>.Atualizar(arquivo, c);
        }

        public void Deletar(Model.Contato c)
        {
            ArquivoJson<Model.Contato>.Deletar(arquivo, c);
        }
    }
}
