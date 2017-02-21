using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Teste.Model;
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ParamentrosXml paramentosXml = new ParamentrosXml();
            RepositorioParamentrosXml.repositorio();
            string CaminhoDasImagens = '@'+'"' +paramentosXml.CaminhoDoArquivo.ToString()+ '"';
            string CaminhoBackup = '@' + '"' + paramentosXml.CaminhoPastaTemp + '"';
            string[] arquivos = Directory.GetFiles(CaminhoDasImagens, "*.0001", SearchOption.AllDirectories);
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
                numeroProtocolo = item.Substring(13,paramentosXml.QuantidadeDigitosProtocolo).ToString(); // Ler o numero de protocolo

                if(LocalizaPalavraAcei.Equals("ACEI"))
                {
                    return;
                }
                else
                {      
                    NovoNomeArquivo.Append(@"D:\Teste\");                    
                    NovoNomeArquivo.Append("ACEI0000");
                    NovoNomeArquivo.Append(numeroProtocolo);
                    NovoNomeArquivo.Append(".0001");
                    Console.WriteLine("Nome do Arquivo Antigo : {0}", item);                  
                    try
                    {
                        // Verifica se o arquivo de backup está criado, se não
                        // Ele cria
                        if(File.Exists(paramentosXml.CaminhoPastaTemp))
                        {
                            File.Copy(CaminhoDasImagens, CaminhoBackup);
                        }
                        else
                        {
                            File.Create(CaminhoBackup);
                            File.Copy(CaminhoDasImagens, CaminhoBackup);
                        }
                        
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
