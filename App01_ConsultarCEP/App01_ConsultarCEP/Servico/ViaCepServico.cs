using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        public static string EndrecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEndercoUrl = string.Format(EndrecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEndercoUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep ==null)
            {
                return null;
            }

            return end;
        }
    }
}
