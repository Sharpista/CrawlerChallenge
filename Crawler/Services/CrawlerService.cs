using Crawler.Configurations.Extensions;
using Crawler.Model;
using Crawler.Services.Base;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;
using System.Text.Json;
using System.Xml.Linq;

namespace Crawler.Services
{
    public class CrawlerService : ICrawlerService
    {
        private readonly IHttpClientService? _httpClientService;
        private readonly ILogger<CrawlerService> _logger;
        private readonly SettingsOptions _settingsOptions;

        public CrawlerService(IHttpClientService? httpClientService, 
                              ILogger<CrawlerService> logger,
                              IOptions<SettingsOptions> options)
        {
            _settingsOptions = options.Value;
            _httpClientService = httpClientService;
            _logger = logger;
        }

        public async Task<string> CrawlerServidoresProxy(CancellationToken cancellationToken)
        {
           
            var response =  await _httpClientService!.CrawlerServidoresProxy(_settingsOptions!.SevidorProxy!.Url!, cancellationToken);
            var document = new HtmlDocument();
            document.LoadHtml(response);

            // Verifica se a estrutura é a esperada
            var tableNode = document.DocumentNode.SelectSingleNode("//table");
            if (tableNode != null)
            {
                var tbodyNode = tableNode.SelectSingleNode(".//tbody");
                if (tbodyNode != null)
                {
                    var trNodes = tbodyNode.SelectNodes(".//tr");

                    if (trNodes != null)
                    {
                        foreach (var tr in trNodes)
                        {
                            var tdNodes = tr.SelectNodes(".//td");

                            if (tdNodes != null && tdNodes.Count >= 2)
                            {
                                string ip = tdNodes[0].InnerText.Trim();
                                string port = tdNodes[1].InnerText.Trim();

                                if (!string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(port))
                                {
                                    Console.WriteLine($"Proxy: {ip}:{port}");
                                }
                                else
                                {
                                    Console.WriteLine("Células vazias encontradas.");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum <tr> encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum <tbody> encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma tabela encontrada.");
            }

            return "";
        }

        public string CrawlerServidoresProxySelenium(CancellationToken cancellationToken)
        {
         
            var servidoresRequestList = new List<ServidorProxyRequest>();
            using  var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_settingsOptions!.SevidorProxy!.Url!);

            var driverAwait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

            var jsonExtraido = ExtrairDados(driver);
            
            var proxies = ParseJson(jsonExtraido);
            
            foreach (var proxy in proxies!.Data!.Where(x => x.IpData is not null))
            {
                var servidor = new ServidorProxyRequest(proxy.Protocol, 
                                                        proxy.Ip, 
                                                        proxy.Port, 
                                                        proxy.IpData!.CountryCode,
                                                        proxy.Ssl,
                                                        proxy.IpData.Country,
                                                        proxy.Anonymity, 
                                                        proxy.AverageTimeout, 
                                                        proxy.IpDataLastUpdate);

                servidoresRequestList.Add(servidor);
            }
            
            //Só estou realizando o envio de 10 objetos apenas, caso queira enviar todos remover o take(10)
            return JsonSerializer.Serialize(servidoresRequestList.Take(10));
        }


        private string  ExtrairDados(IWebDriver webDriver)
        {
          
            var servidorList = new List<ServidorProxyRequest>();
            var buttonIpport = webDriver.FindElement(By.XPath("//button[small[text()='ip:port']]"));
            var buttonJson = webDriver.FindElement(By.XPath("//button[small[text()='json']]"));

            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", buttonIpport);
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", buttonJson);

            var input = webDriver.FindElement(By.XPath("//div/input"));

            var valorInput = input.GetAttribute("value");

            webDriver.Navigate().GoToUrl(valorInput);

            var hiddenDiv = webDriver.FindElement(By.XPath("//pre"));

            return hiddenDiv.Text;
           
        }

        private ApiResult<List<ServidorProxy>> ParseJson(string json) => JsonSerializer.Deserialize<ApiResult<List<ServidorProxy>>>(json)!;
    }
}
