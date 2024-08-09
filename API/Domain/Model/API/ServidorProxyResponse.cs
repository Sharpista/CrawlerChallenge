using API.Domain.Model.Entities;

namespace API.Domain.Model.API
{
    public class ServidorProxyResponse
    {
        public ServidorProxyResponse(string? protocolo, string? ip, int? porta,
                                    string? code, bool? https, string? country,
                                    string? anonimato, double? latencia, double? ultimaVerificacao)
        {
            Protocolo = protocolo;
            Ip = ip;
            Porta = porta;
            Code = code;
            Https = https;
            Country = country;
            Anonimato = anonimato;
            Latencia = latencia;
            UltimaVerificacao = ultimaVerificacao;
        }

        public string? Protocolo { get; private set; }
        public string? Ip { get; private set; }
        public int? Porta { get; private set; }
        public string? Code { get; private set; }
        public bool? Https { get; private set; }
        public string? Country { get; private set; }
        public string? Anonimato { get; private set; }
        public double? Latencia { get; private set; }
        public double? UltimaVerificacao { get; private set; }


        public ServidorProxy MapToDomain()
        {
            return new ServidorProxy(Protocolo, Ip, Porta, Code, Https, Country, Anonimato, Latencia, UltimaVerificacao);
        }
    }
}
