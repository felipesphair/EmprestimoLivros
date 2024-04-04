# Emprestimos de Livros

Este projeto é uma aplicação desenvolvida com o objetivo de implementar um sistema de gerenciamento de empréstimos de livros de forma digital, utilizando as práticas do CRUD (Create, Read, Update, Delete). Construído com C# no framework ASP .NET Core MVC, o projeto oferece uma arquitetura robusta e escalável para o desenvolvimento de aplicações web.

Uma das principais vantagens de utilizar o padrão MVC (Model-View-Controller) neste projeto é a separação clara de responsabilidades entre os componentes da aplicação:

1. Model (Modelo): Responsável pela lógica de negócios e interação com o banco de dados. Aqui, são definidos os modelos de dados que representam as entidades do sistema, como Empréstimo, Livro e Usuário. Utilizando o Entity Framework Core, é possível mapear esses modelos para o banco de dados de forma simplificada, facilitando a persistência e manipulação dos dados.

2. View (Visão): Camada responsável pela apresentação dos dados ao usuário. No ASP .NET Core MVC, as views são criadas utilizando as linguagens Razor e HTML, permitindo a construção de interfaces de usuário dinâmicas e interativas. Neste projeto, as views são utilizadas para exibir formulários de cadastro, listagens de empréstimos e detalhes dos livros.

3. Controller (Controlador): Responsável por intermediar as requisições do usuário e coordenar as ações necessárias para atender essas requisições. Os controladores recebem as solicitações HTTP, interagem com os modelos de dados e renderizam as views apropriadas. Com o ASP .NET Core MVC, é possível criar rotas e definir comportamentos específicos para cada ação da aplicação.

Além disso, o projeto oferece a funcionalidade adicional de exportar todos os dados para o Excel, fornecendo aos usuários uma maneira conveniente de visualizar e analisar os registros de empréstimos de forma tabular e compatível com outras ferramentas de planilhas.

No geral, ao adotar o padrão MVC e utilizar tecnologias modernas como ASP .NET Core MVC, Entity Framework Core e SQL Server, o projeto garante uma estrutura organizada, manutenível e eficiente para o desenvolvimento de aplicações web, promovendo a escalabilidade, a reutilização de código e uma experiência de usuário mais consistente e satisfatória.


# Como Rodar:

1. SDK do .NET 6.0: Certifique-se de ter o SDK do .NET 6.0 instalado em sua máquina. Você pode baixá-lo e instalá-lo a partir do site oficial da Microsoft: <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/6.0">Download do .NET SDK</a>.

2. Servidor SQL Server: Você precisará de um servidor SQL Server em execução ou pode usar um servidor local para persistência de dados. Certifique-se de ter acesso a um servidor SQL Server e as credenciais necessárias para se conectar a ele.

3. No Visual Studio clique na opção de clonar um repositório na tela de início e adicione o link do meu repositório: https://github.com/felipesphair/EmprestimoLivros.git
   ![image](https://github.com/felipesphair/EmprestimoLivros/assets/107360437/4fd619ff-a20f-4fa8-a172-e32ae15d5d1a)

4. Abra um cmd e vá até a raiz do projeto \EmprestimoLivros e digite o seguinte comando para baixar as dependecias do projeto: dotnet restore.

5. Configure o SQL SERVER no arquivo appsettings.json mudando o server:
   ![image](https://github.com/felipesphair/EmprestimoLivros/assets/107360437/f0fe3028-e233-482e-b702-8915281c70ea)

6. Abra o console de gerenciador de pacotes nugget:
   ![image](https://github.com/felipesphair/EmprestimoLivros/assets/107360437/c759b4f0-651a-4f23-9ce8-aedd7c26d742)

7. Digite o seguinte comando para rodar as migrations e criar o banco de dados: Update-Database.

8. Aperte F5 para rodar o projeto.

# Telas:


