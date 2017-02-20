using System.Xml;
using Teste.Model;
namespace Teste
{
    public class RepositorioParamentrosXml
    {
        public static void repositorio()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\brendon\Documents\Visual Studio 2015\Projects\RenomearArquivos\RenomearArquivos\Teste\Config.xml");
            ParamentrosXml paramentrosXml = new ParamentrosXml();
           
            foreach (var item in xml)
            {
                paramentrosXml.CaminhoDoArquivo = item.GetElementById("CaminhoDoArquivo").ToString();
            }
        }
        

    }
}
