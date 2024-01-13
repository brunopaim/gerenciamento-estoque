# Sistema de Gerenciamento de Estoque

Este é um pequeno sistema de gerenciamento de estoque desenvolvido para facilitar o cadastro de produtos, controle de entradas de mercadorias e organização eficiente no estoque usando um formato de matriz. A seguir, são fornecidas instruções para configurar e utilizar o sistema.

## Configuração

### Banco de Dados (MySQL)

1. Configure a string de conexão no arquivo `appsettings.Development.json` com as informações do seu banco de dados MySQL:

   ```json
   "ConnectionStrings": {
       "Default": "Server=localhost;Database=seu_banco_de_dados;User=root;Password=sua_senha;"
   }
   ```

2. Execute os seguintes comandos no terminal para aplicar as migrações:

   ```bash
   dotnet restore
   dotnet ef database update
   ```

### Frontend (ReactJS)

1. Navegue até o diretório `ClientApp` no terminal:

   ```bash
   cd ClientApp
   ```

2. Execute o comando para instalar as dependências do frontend:

   ```bash
   npm install
   ```

## Executando o Sistema

1. No diretório raiz do projeto, execute o seguinte comando para iniciar o backend:

   ```bash
   dotnet run
   ```

   O backend estará disponível em [https://localhost:7025/](https://localhost:7025/).

2. Para visualizar e testar as rotas, acesse o Swagger pelo seguinte link:

   [https://localhost:7025/swagger/index.html](https://localhost:7025/swagger/index.html)

   O código redireciona automaticamente para [https://localhost:44448/](https://localhost:44448/) ao acessar a rota do BackEnd.

Agora, o sistema está configurado e pronto para uso. Certifique-se de ajustar as configurações conforme necessário e siga as instruções para uma experiência eficiente de gerenciamento de estoque.

## Requisitos do Sistema

Antes de iniciar a instalação e execução do sistema, certifique-se de que o seu ambiente atende aos seguintes requisitos:

- **[.NET 6](https://dotnet.microsoft.com/download)**: Certifique-se de ter o SDK do .NET 6 instalado na sua máquina.

- **[Node.js](https://nodejs.org/)**: O frontend é construído usando ReactJS, portanto, é necessário ter o Node.js instalado para gerenciar as dependências.

- **[MySQL](https://www.mysql.com/)**: O sistema utiliza um banco de dados MySQL. Certifique-se de ter um servidor MySQL instalado e configurado.

- **[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)**: O Entity Framework Core é usado para mapear objetos .NET para o banco de dados MySQL. Certifique-se de que o Entity Framework Core está instalado.

Inclua informações adicionais específicas, se necessário, para garantir que os usuários possam configurar e executar o sistema sem problemas. Isso ajuda a reduzir possíveis problemas de configuração e facilita a entrada dos usuários no uso do seu aplicativo.
