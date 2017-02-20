using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioParamentrosXml.repositorio();
            string[] arquivos = Directory.GetFiles("C:\\Desenvolvimento", "*.0001", SearchOption.AllDirectories);
            Console.WriteLine(" LENDO ARQUIVOS ");
            int count = 0;
            string nome;
            string LocalizaPalavraAcei;
            string numeroProtocolo;

            foreach (var item in arquivos)
            {                           
                StringBuilder NovoNomeArquivo = new StringBuilder();
                 nome = item.Substring(19,19).ToString();
                LocalizaPalavraAcei = nome.Substring(0,4); // Localiza o Numero de protocolo
                numeroProtocolo = nome.ToString().Substring(4,6); // Ler o numero de protocolo
                if(LocalizaPalavraAcei.Equals("ACEI"))
                {
                    return;
                }
                else
                {                  

                    NovoNomeArquivo.Append("C:\\Desenvolvimento\\");                    
                    NovoNomeArquivo.Append("ACEI0000");
                    NovoNomeArquivo.Append(numeroProtocolo);
                    NovoNomeArquivo.Append(".0001");
                    Console.WriteLine("Nome do Arquivo Antigo : {0}", item);                   

                    try
                    {
                        
                        File.Move(item.ToString(), NovoNomeArquivo.ToString());
                        Console.WriteLine("Nome do Arquivo Novo : {0}", NovoNomeArquivo.ToString());
                        count++;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Não foi possível alterar o arquivo");
                        Console.WriteLine("Arquivo pode estar aberto. {0}", e.Message);
                    }
                    
                    
                }
                
            }
            Console.WriteLine("Nome dos Arquivos Alterados.");
            Console.WriteLine("Quantidade Alterado : {0}", count);
            Console.ReadLine();

        }
    }
}
