using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using RenomearArquivos.Model;
namespace RenomearArquivos
{
   public class _Conversor
    {
        public void Converter(string caminho)
        {
            _Configuration dadosConfi = new _Configuration();
            int count = 0;
            string nome;
            string LocalizaPalavraAcei;
            string numeroProtocolo, msg;
            int numeroProtocoloConfi, tamanhoDoArquivo;

            try
            {
                string[] arquivos = Directory.GetFiles(caminho, "*.0001", SearchOption.TopDirectoryOnly);
                foreach (var item in arquivos)
                {
                    StringBuilder NovoNomeArquivo = new StringBuilder();
                    tamanhoDoArquivo = item.Length -30;
                    nome = item.Substring(tamanhoDoArquivo, 30).ToString();
                    LocalizaPalavraAcei = nome.Substring(0, 4); // Localiza o Numero de protocolo
                    if (LocalizaPalavraAcei.Equals("ACEI"))
                    {
                        msg = "Arquivos já convertidos para formato tif";
                        return;
                    }
                    else
                    {
                        numeroProtocoloConfi = int.Parse(ConfigurationManager.AppSettings["QuantidadeDigitosProtocolo"]);
                        numeroProtocolo = nome.Substring(4, numeroProtocoloConfi); // Ler o numero de protocolo
                        NovoNomeArquivo.Append(caminho);
                        NovoNomeArquivo.Append("\\");
                        NovoNomeArquivo.Append("ACEI0000");
                        NovoNomeArquivo.Append(numeroProtocolo);
                        NovoNomeArquivo.Append(".0001");
                        
                        try
                        {
                            File.Move(item.ToString(), NovoNomeArquivo.ToString());
                            count++;                            
                        }
                        catch (Exception e)
                        {
                            dadosConfi.mensagemError = e.Message;
                            
                        }

                        
                    }
                    
                } //Foreach
                
               

            }
            catch (Exception e)
            {
                dadosConfi.mensagemError = e.Message;
            }
            
            dadosConfi.Contador = count;
        }
    }
}
