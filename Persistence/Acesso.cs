using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Acesso
    {

        private string arquivo = "c:\\Users\\marya\\Desktop\\acessos.json";

        public List<Model.Acesso> Selecionar()
        {
            return ArquivoJson<Model.Acesso>.Selecionar(arquivo);
        }
        public void Inserir(Model.Acesso a)
        {
            ArquivoJson<Model.Acesso>.Inserir(arquivo, a);
        }
        public void Atualizar(Model.Acesso a)
        {
            ArquivoJson<Model.Acesso>.Atualizar(arquivo, a);
        }
        public void Deletar(Model.Acesso a)
        {
            ArquivoJson<Model.Acesso>.Deletar(arquivo, a);
        }

    }
}
