Crawler de Procuradores com Selenium e C#
Este projeto é um console application criado em C# utilizando o Selenium para realizar um web crawler no site ProxyScrape - Lista de Procuradores Gratuitos. Os dados coletados são enviados via POST para uma Web API, que é outro projeto separado, ambos desenvolvidos utilizando .NET 8.

Tecnologias Utilizadas
.NET 8
Selenium WebDriver
C#
HttpClient
JSON
ASP.NET Core Web API

Estrutura do Projeto

Crawler: Um projeto console que realiza o web scraping no site especificado, coletando informações dos procuradores gratuitos e enviando os dados para a Web API.

Api: Um projeto ASP.NET Core Web API que recebe os dados enviados pelo CrawleR e os processa de acordo com a lógica implementada.

Funcionalidades
Crawler

Acessa o site da ProxyScrape usando o Selenium WebDriver.
Extrai os dados dos procuradores gratuitos disponíveis na página.
Envia os dados extraídos para a API RESTful via HTTP POST.
ProcuradoresApi

Recebe os dados via POST.
Processa e armazena os dados em um banco de dados.

Como Executar
Pré-requisitos
.NET 8 SDK instalado
Navegador suportado pelo Selenium WebDriver (por exemplo, Chrome)
ChromeDriver configurado se usar o Chrome
Executando o Crawler
Clone este repositório.
Navegue até a pasta Crawler no terminal.
Execute o comando dotnet run para iniciar o projeto.
O console iniciará o Selenium WebDriver, acessará a página da ProxyScrape, coletará os dados e os enviará para a API.
Executando a Api
Navegue até a pasta Api no terminal.
Execute o comando dotnet run para iniciar a API.
A API estará disponível para receber dados na rota configurada.
Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou fazer um fork do projeto e enviar pull requests.

Licença
Este projeto está licenciado sob a MIT License - veja o arquivo LICENSE para mais detalhes.