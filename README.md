# Avaliação Fullstack Backend
## Descrição do projeto:

Essa é uma API feita para a avaliação FullStack da Impar/I9. Feita em .Net Core 6.0
## Construído com:
- C#
- EntityFramework Core
- MediatR
#
## Rodando a API:
- Primeiramente, você precisara de um banco de dados SQL server. Recomendo o [SQL Server Express](https://www.microsoft.com/en-us/download/details.aspx?id=101064). 
- Após baixar e instalar o SQL Server Express, clone este repositório usando o `git clone`
- Abra o arquivo `appsetings.development.json` dentro da pasta `src/DesafioImpar.Presentation` e verifique se a string de conexão com o banco de dados está correta.
- Abra a solução no Visual Studio e compile usando o `DesafioImpar.Presentation` como projeto padrão
- Você pode também navegar até a pasta `src/DesafioImpar.Presentation`, abrir um terminal nesta pasta e rodar o comando: `dotnet run`
- O banco de dados necessário para a aplicação será criado automaticamente pela API.
- Você pode acessar no seu navegador a página do [Swagger](http://localhost:5001/swagger) para verificar o funcionamento
- __Caso ocorra algum erro, verifique a string de conexão com o banco de dados no arquivo `appsetings.development.json`__
