using System.Xml;
using Teste.Model;
namespace Teste
{
    public class RepositorioParamentrosXml
    {
        public static void repositorio()
        {
            ParamentrosXml paramentrosXml = new ParamentrosXml();
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\brendon\Source\Repositorio\RenomearArquivo\Teste\Config.xml");

            XmlNode xmlConfiguracao = xml.SelectSingleNode("Configuracao");
            XmlNode xmlCaminhoDoArquivo = xmlConfiguracao.SelectSingleNode("CaminhoDoArquivo");
            XmlNode xmlQuantidadeDigitosProtocolos = xmlConfiguracao.SelectSingleNode("QuantidadeDigitosProtocolo");
            XmlNode xmlPastaTemp = xmlConfiguracao.SelectSingleNode("PastaTemp");

            paramentrosXml.CaminhoDoArquivo = xmlCaminhoDoArquivo.InnerText;
            paramentrosXml.QuantidadeDigitosProtocolo = int.Parse(xmlQuantidadeDigitosProtocolos.InnerText);
            paramentrosXml.CaminhoPastaTemp = xmlPastaTemp.InnerText;

        }


    }
}
