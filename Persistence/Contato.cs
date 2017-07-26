using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Contato
    {

        public List<Model.Contato> Selecionar(string nomeUser)
        {
            string arquivo = "c:\\Users\\marya\\Desktop\\"+nomeUser+"contatos.json";
            return ArquivoJsonContato<Model.Contato>.Selecionar(arquivo);
        }

        public void Inserir(Model.Contato c, string nomeUser)
        {
            string arquivo = "c:\\Users\\marya\\Desktop\\"+nomeUser+"contatos.json";
            ArquivoJsonContato<Model.Contato>.Inserir(arquivo, c);
        }

        public void Atualizar(Model.Contato c, string nomeUser)
        {
            string arquivo = "c:\\Users\\marya\\Desktop\\"+nomeUser+"contatos.json";
            ArquivoJsonContato<Model.Contato>.Atualizar(arquivo, c);
        }

        public void Deletar(Model.Contato c, string nomeUser)
        {
            string arquivo = "c:\\Users\\marya\\Desktop\\" + nomeUser + "contatos.json";
            ArquivoJsonContato<Model.Contato>.Deletar(arquivo, c);
        }
        
        
    }
}
