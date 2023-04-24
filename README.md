# Processo seletivo - QA

Bem vindo, candidato. 

Estamos felizes que você esteja participando do processo seletivo para a vaga de QA do Senai - Soluções Digitais.

A prova deverá utilizar as seguintes tecnologias: 
- Linguagem de programação orientada a objeto para web
- Banco de dados relacional
- GIT

Fica à sua escolha quais frameworks e servidor serão utilizados, desde que seja uma aplicação web. 

Na etapa da entrevista deverá ser apresentado a aplicação em funcionamento.

## Instruções para a execução da prova

A prova deve ser uma aplicação web. Você pode escolher a tecnologia que achar conveniente (PHP, JAVA, etc...).

O Banco utilizado na prova deve ser PostgrSQL.

Esse repositório possui apenas esse Readme com as instruções da prova. No entanto, **todo desenvolvimento deve ser commitado nesse repositório** até a data citada no email, enviado por nossa equipe.

Commite nesse repositório o script utilizado na criação do banco de dados (se aplicável).

Por fim, altere esse arquivo com as instruções de como poderemos testar o seu código (quais libs usar, qual servidor, etc) abaixo.

## Será avaliado
- Qualidade do código quanto a:
  - Facilidade no entedimento
  - Complexidade ciclomática
  - Divisão de resposabilidade das classes
  - Reutilização de código
- Qualidade quanto a interface:
  - Fácil usabilidade
  - Acessibilidade
  - Feedback ao usuário
- Qualidade quanto aos requisitos:
  - Desenvolvimento e funcionamento dos requisitos propostos.

## Informações extras

- Descreva ao final deste documento (Readme.md) o detalhamento de funcionalidades implementadas, sejam elas já descritas na modelagem e / ou extras.
- Detalhar também as funcionalidades que não conseguiu implementar e o motivo.
- Caso tenha adicionado novas libs ou frameworks, descreva quais foram e porque dessa agregação.

## Requisitos
- dotnet 6.0
- PostgrSQL

## Como executar
Entre na pasta `TarefasFIESC` e execute o comando 
```
$ dotnet run
```
Para a aplicação funcionar corretamente, é necessário está com o banco de dados rodando na porta 5432, com o usuário `postgres` e senha `psql1234`. Caso queira alterar essas configurações, basta alterar o arquivo `appsettings.json` na pasta `TarefasFIESC`.
Para facilitar a criação do banco de dados, com o docker compose instalado, basta executar o comando na pasta `TarefasFIESC`:
```bash
$ docker-compose up -d
```
O comando acima irá criar um container com o banco de dados rodando na porta 5432, com o usuário `postgres` e senha `psql1234`.

# Informações adicionais
- A aplicação foi desenvolvida utilizando o Entity Framework Core para criar as migrations e o banco de dados da .
- A aplicação foi desenvolvida utilizando o Razor com ASP.NET Core
- A aplicação foi desenvolvida utilizando o Docker para rodar o banco de dados
- A aplicação faz autenticação por meio de tokens armazenados em sessões para acessar as telas internas
- O tipo de token utilizado foi o JWT com a biblioteca `Microsoft.AspNetCore.Authentication.JwtBearer` 
- A aplicação possui paginação onde cada página lista até 10 resultados por página, além de conseguir ordenar as colunas da tabela e realizar buscas por elementos da tabela.


# Requisitos não funcionais
| # | Descrição | Comentários |
|---|-----------|-------------|
| RNF1 | A estrutura do banco de dados deve ser criada através de migrations.| Foi utilizado o Entity Framework Core para criar as migrations.
| RNF2 | A linguagem de programação para uso é livre, desde que a mesma suporte o paradigma orientado a objetos. | A linguagem utilizada foi C#.
| RNF3 | Pode ser utilizado ou não frameworks. | A aplicação utilizou vários frameworks, como o Entity Framework Core, Razor Pages, ASP.NET Core, entre outros.
| RNF4 | Deve ser um monolito, a aplicação não deve ser separada em back e front. | A aplicação foi desenvolvida como um monolito, utilizando o Razor Pages para a parte de front-end.
RNF5 | Para o desenvolvimento do sistema deverá ser utilizado o banco de dados PostgreSQL. | O banco de dados utilizado foi o PostgreSQL em um container Docker.

# Requisitos funcionais

## RF1 - Autenticação
| # | Descrição | Comentários | Concluído |
|---|-----------|-------------|-----------|
1 | O acesso ao sistema deverá se dar através de login e senha, sendo que o usuário não poderá acessar as telas internas se não informar os dados corretos. | O sistema utiliza autenticação por meio de utilização de tokens armazenados em sessões para acessar as telas internas, sendo que o usuário não poderá acessar as telas internas se não informar os dados corretos.  | Sim |

## RF2 - Tela de listagem de tarefas
| # | Descrição | Comentários | Concluído |
|---|-----------|-------------|-----------|
| 1 | Deverá possuir um link que direcione o usuário para a tela de cadastro de tarefa (RF3). | O sistema possui um link que direciona o usuário para a tela de cadastro de tarefa. | Sim |
| 2 | Deverá listar em uma tabela todas as tarefas que não estejam concluídas, as colunas devem ser: Número da tarefa (id); Título da tarefa;Tipo da tarefa; Prioridade da tarefa; Data de abertura; Responsável pela Tarefa | O sistema lista em uma tabela todas as tarefas que não estejam concluídaS com as colunas requisitadas. | Sim |
| 3 | Deverá ter uma paginação onde cada página deverá listar até 10 resultados por página. | O sistema possui paginação onde cada página lista até 10 resultados por página, além de conseguir ordenar as colunas da tabela e realizar buscas por elementos da tabela. | Sim |
| 4 | Na coluna id, da tabela de listagem de tarefas, deverá conter um link que direcione o usuário para a página de visualização (RF4) deste registro. | Ao clicar no id da tarefa, o usuário é direcionado para a página de visualização da tarefa. | Sim |
| 5 | Quando for inserido um novo registro, deverá ser mostrada uma mensagem de sucesso informando que a tarefa com o id XXXX foi inserida com sucesso. | Quando é inserido um novo registro, é mostrada uma mensagem de sucesso informando o id da tarefa | Sim |
| 6 | Na tabela de listagem de tarefas, os registros que estiverem sob a responsabilidade do usuário logado deverão aparecer com a cor alaranjada. | Os registros que estiverem sob a responsabilidade do usuário logado aparecem com a cor amarelada (cor escolhida pois fica mais agradável aos olhos) . | Sim |

## RF3 - Tela de cadastro de tarefas
| # | Descrição | Comentários | Concluído |
|---|-----------|-------------|-----------|
| 1 | O formulário de cadastro de tarefas deverá exibir os campos abaixo, sendo que todos eles são obrigatórios: Título; Tipo; Prioridade; Descrição | O formulário de cadastro de tarefas exibe os campos requisitados | Sim |
| 2 | O campo Prioridade será uma caixa de lista suspensa (combo) com os seguintes valores disponíveis para seleção: Alta; Média; Baixa Sem prioridade | O campo Prioridade é uma caixa de lista suspensa (combo) com os valores requisitados | Sim |
| 3 | O campo Tipo será uma caixa de lista suspensa (combo) com os seguintes valores disponíveis para seleção: Incidente; Solicitação de serviço; Melhoria; Projeto | O campo Tipo é uma caixa de lista suspensa (combo) com os valores requisitados | Sim |
| 4 | O campo Descrição será do tipo Rich Text e poderá conter formatação em HTML. | O campo Descrição é do tipo Rich Text não sendo possível inserir formatação em HTML. | Não |
| 5 | O botão Salvar deverá salvar os dados preenchidos nos campos do formulário sendo que a data de abertura deve considerar a data atual e o responsável deverá ser o usuário responsável pelo cadastro do registro. | O botão Salvar salva os dados preenchidos nos campos do formulário sendo que a data de abertura é a data atual e o responsável é o usuário logado. | Sim |
| 6 | O botão Cancelar deverá retornar o usuário para a página de listagem (RF2) sem fazer qualquer alteração no banco de dados. | O botão Cancelar retorna o usuário para a página de listagem sem fazer qualquer alteração no banco de dados. | Sim |
| 7 | Após salvar os registros no banco de dados, o usuário deverá ser redirecionado para a tela de listagem (RF2) com a mensagem de registro inserido com sucesso. | Após salvar os registros no banco de dados, o usuário é redirecionado para a tela de listagem com a mensagem de registro inserido com sucesso. | Sim |

## RF4 - Detalhes da tarefa
| # | Descrição | Comentários | Concluído |
|---|-----------|-------------|-----------|
| 1 | A tela de detalhes deverá conter as seguintes informações referente a tarefa: Número da tarefa; Título da tarefa; Responsável pela tarefa; Prioridade da tarefa; Tipo de tarefa; Data de criação; Descrição da tarefa; Situação da tarefa | A tela de detalhes contém as informações requisitadas | Sim |
| 2 | Deverá haver um botão que permita que outro usuário assuma a tarefa, sendo que somente o usuário logado poderá assumir a tarefa. O botão não deverá aparecer caso o usuário logado seja o responsável pela tarefa. | O botão que permite que outro usuário assuma a tarefa aparece somente se o usuário logado não for o responsável pela tarefa. | Sim |
| 3 | Deverá haver um botão que permita fechar a tarefa, este botão só estará disponível para o usuário responsável pela tarefa e enquanto a tarefa estiver concluída. Ao clicar no botão de finalizar tarefa o mesmo deverá solicitar uma nova providência explicando o que foi feito na tarefa e logo em seguida o status da tarefa deve ser alterado para Concluída. | O botão que permite fechar a tarefa aparece somente se o usuário logado for o responsável pela tarefa e enquanto a tarefa estiver aberta. Ao clicar no botão de finalizar tarefa o mesmo solicita uma nova providência explicando o que foi feito na tarefa e logo em seguida o status da tarefa é alterado para Concluída. | Sim |	
| 4 | O campo Descrição deverá estar disponível para Somente Leitura (read only) e deverá exibir a descrição da tarefa. | O campo Descrição está disponível para Somente Leitura (read only) e exibe a descrição da tarefa. | Sim |
| 5 | Deverá haver um campo do tipo Rich Text que aceite HTML para que seja digitado uma nova providência e só estará habilitado para digitação se o usuário logado for o responsável pela tarefa e a tarefa não esteja concluída. | Não foi possível implementar o campo do tipo Rich Text que aceite HTML para que seja digitado uma nova providência. | Não |	
| 6 | Deverá haver um botão de salvar que permita salvar o texto digitado no banco de dados e só estará habilitado para digitação se o usuário logado for o responsável pela tarefa e a tarefa não estiver concluída. A observação deverá salvar o usuário cadastrado, a data de cadastro e o texto digitado no campo observação. | O botão de salvar permite salvar o texto digitado no banco de dados. A observação salva o usuário cadastrado, a data de cadastro e o texto digitado no campo observação. | Sim |
| 7 | Deverá ser exibido na tela a lista de observações já cadastradas, ordenadas pela data de criação, da mais recente para a mais antiga. | A lista de observações é exibida na tela ordenadas pela data de criação, da mais recente para a mais antiga. | Sim |
| 8 | Deverá exibir o usuário responsável pelo cadastro da observação e a data e a hora em que a mesma foi cadastrada.| A observação e a data e a hora em que a mesma foi cadastrada são exibidos. | Sim |
| 9 | Será possível editar somente a última observação e somente se o usuário logado for o criador da providência e responsável pela tarefa. | Não foi possível implementar a edição da última observação. | Não |
| 10 | A edição não poderá ser realizada se a tarefa estiver concluída. | Não foi possível implementar a edição da última observação. | Não |