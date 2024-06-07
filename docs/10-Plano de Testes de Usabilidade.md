# Plano de Testes de Usabilidade

Testes de usabilidade posuem relação com a experiência do usuário em utilizar a aplicação, visando verificar o seu funcionamento por meio da observação. Com esta técnica é possível controlar se a aplicação atende aos requisitos e solicitações realizadas, certificando a qualidade da interface.

Através da observação dos testes realizados é possível identificar diferentes comportamentos e reações dos participantes diante das diferentes telas navegadas da aplicação interativa.   
Mediante dados coletados e métricas é feito uma análise dos resultados com o intuito de identificar melhorias e problemas, a fim de fornecer uma melhor experiência do usuário.

Para este projeto será realizado o modelo de testes remoto e moderado com observação da execução das tarefas realizadas pelos participantes por meio da ferramenta Lookback.
O planejamento dos testes a serem executados com os participantes são descritos a seguir: objetivos, método e modelo utilizado, seleção dos paticipantes, roteiro das tarefas a serem desempenhadas pelos usuários e análise.

Os testes serão realizados em duas etapas, sendo a primeira etapa realizada com tarefas testes específicas tendo a aplicação ainda em desenvolvimento e executando as funcionalidades essenciais, a fim de identificar erros e sugestões de melhoria, e a segunda etapa os participantes simularão cenários testes tendo a aplicação finalizada e apresentando todas as suas funcionalidades.

# 1. Objetivos

Os seguintes objetivos foram definidos com a finalidade de possibilitar uma experiência positiva do usuário:

> - A aplicação deve possibilitar que o usuário navegue de maneira intuitiva;
> - As telas devem ser simples e compreensíveis para que o usuário realize suas tarefas de modo prático;
> - A aplicação deve disponibilizar meios para que a execução das tarefas do usuário seja factível.

Por meio dos testes será possível identificar problemas e o modo como os usuários interagem com a aplicação, respondendo deste modo questionamentos que visam a sua melhoria, são eles:

> - Os usuários navegam com facilidade e de modo intuitivo os diversos módulos da aplicação?
> - Os usuários conseguem compreender as telas acessadas e com isso executam a tarefa de modo rápido? 
> - Os usuários cometem erros ao executar as tarefas?
> - Existem obstáculos que impossibilitam a conclusão das tarefas? Se sim, quais obstáculos são esses?
> - Qual o tempo de resposta e como os usuários reagem a aplicação?

# 2. Método e modelo utilizado

Para este projeto em considereção, foi definido para aplicação dos testes o modelo remoto e moderado com método de experimentação e observação. 

Buscando reproduzir um cenário coerente com a realizade, os usuários devem acessar a aplicação de qualquer eletrônico independente da sua localização. Neste caso, o melhor modelo para observar o comportamento dos usuários durante a interação com o sistema é o modelo remoto, pois sendo a distância o participante pode realizar em seu ambiente natural.

Além disso, este modelo oferece um custo baixo para aplicação dos testes, já que não se faz necessário a locação de um estabelecimento e gastos com pessoal e materiais necessários, proporciona testar 100% da aplicação e projetos, não interfere na velocidade do desenvolvimento e para o usuário é cômodo e prático.

# 3. Participantes

Serão selecionados usuários de acordo com as personas já estabelecidas, realizando os testes como sendo os usuários secretária, paciente e empreendedor. 

Como esta aplicação está sendo desenvolvida com foco no consultório DentalIn, funcionários e o dono do consultório participarão dos testes, além de 10 participantes com perfil de paciente que possuem a intenção de agendar consultas odontológicas de forma prática. As características destes participantes são descritas a seguir:

> - Pessoas entre 18 e 70 anos;
> - Homens e mulheres;
> - Possui conexão com internet estável;
> - Possui algum eletrônico como computador, tablet ou celular;
> - Possui e-mail válido;
> - Possui número de telefone ou celular.

# 4. Procedimento

> - Envio dos links de acesso e orientações sobre acesso ao teste aos participantes;
> - Inicialização das ferramentas para gravação e reunião dos participantes;
> - Recepção dos participantes e esclarecimentos sobre a privacidade de dados, além de aceitação do termo;
> - Orientação sobre o teste: indicação dos objetivos, garantia de anonimato; observação por meio de registro de áudio, vídeo e anotações;
> - Teste: apresentação dos casos de tarefas e suas medições;
> - Debriefing do participante: entrevista após aplicação dos testes e abertura para comentários sobre o produto e preferências.

Os requisitos para realização dos testes são:

> - Conectividade de internet estável;
> - Navegador: Chrome, Firefox, Safari ou Edge;
> - Disponibilidade do participante em acessar as ferramentas a serem utilizadas no teste (Google Meet,  Webcam e Lookback).
 
# 5. Tarefas Testes

Os participantes terão como responsabilidades realizar e analizar as tarefas de modo eficiente, além de comunicar sua opinião sobre a aplicação.

As seguintes tarefas devem ser realizadas pelos participantes:

| **Caso de Teste** 	| **CTU-01 – Cadastro do Paciente** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Verificar a tela de cadastro para novos usuários |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Cadastrar-se" <br> - Preencher os campos presentes <br> - Clicar em "Cadastrar" |

| **Caso de Teste** 	| **CTU-02 – Fazer login (Tela Paciente)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Averiguar tela de login para pacientes |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Preencher os campos presentes <br> - Clicar em "Entrar" |

| **Caso de Teste** 	| **CTU-03 – Fazer login (Tela Funcionário)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária e Administrador |
| Objetivo do Teste 	| Averiguar tela de login para funcionários |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Preencher os campos presentes <br> - Clicar em "Entrar" |

| **Caso de Teste** 	| **CTU-04 – Fazer agendamentos (Home Page - Paciente)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Verificar o desempenho das telas para agendamento de consulta |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login <br> - Identificar e clicar em "Fazer agendamentos" na Home Page <br> - Navegar pelo fluxo de agendamento seguindo os passos orientados na tela e clicar em "Agendar" |

| **Caso de Teste** 	| **CTU-05 – Verificar agendamentos (Home Page - Paciente)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Verificar o desempenho das telas para apresentação dos agendamentos ao paciente |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login <br> - Identificar e clicar em "Ver agendamentos" na Home Page <br> - Navegar pela tela |

| **Caso de Teste** 	| **CTU-06 – Verificar agendamentos concluídos (Home Page - Paciente)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Verificar o desempenho das telas para apresentação dos agendamentos concluídos ao paciente |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login <br> - Identificar e clicar em "Agendamentos Concluídos" na Home Page <br> - Navegar pela tela |

| **Caso de Teste** 	| **CTU-07 – Cancelar ou reagendar agendamentos (Home Page - Paciente)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Analisar telas para alteração nos agendamentos pelo paciente |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login <br> - Identificar e clicar em "Ver agendamentos" na Home Page <br> - Selecionar algum agendamento <br> - Escolher uma das opções "Cancelar Agendamento" ou "Reagendar" se seguir o fluxo até finalizar a etapa <br> |

| **Caso de Teste** 	| **CTU-08 – Cadastrar e Atualizar Paciente (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar telas para cadastro de pacientes |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Usuários" na Home Page <br> - Identificar e clicar em "Pacientes" e logo após "Cadastrar Paciente" <br> - Preencher os campos apresentados <br> - Clicar em "Cadastrar" <br> - Selecionar algum paciente <br> - Clicar em "Atualizar Paciente" <br> |

| **Caso de Teste** 	| **CTU-09 – Fazer agendamentos (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar o desempenho das telas para agendamento de consulta |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Agendar Paciente" na Home Page <br> - Preencher os campos apresentados <br> - Navegar pelo fluxo de agendamento seguindo os passos orientados na tela e clicar em "Agendar" |

| **Caso de Teste** 	| **CTU-10 – Verificar agendamentos (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Analisar o desempenho das telas para verificação dos agendamentos |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Ver agendamentos" na Home Page <br> - Navegar pela tela e utilizar os filtros |

| **Caso de Teste** 	| **CTU-11 – Verificar agendamentos concluídos (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar o desempenho das telas para apresentação dos agendamentos concluídos ao paciente |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Agendamentos Concluídos" na Home Page <br> - Navegar pela tela |

| **Caso de Teste** 	| **CTU-12 – Cancelar ou reagendar agendamentos (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Analisar o desempenho das telas para verificação dos agendamentos |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Ver agendamentos" na Home Page <br> - Selecionar algum agendamento <br> - Escolher uma das opções "Cancelar Agendamento" ou "Reagendar" e seguir o fluxo até finalizar a etapa <br> |

| **Caso de Teste** 	| **CTU-13 – Cadastrar e Atualizar Dentista (Home Page - Secretária)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar telas para cadastro de dentistas |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Identificar e clicar em "Usuários" na Home Page <br> - Identificar e clicar em "Dentistas" e logo após "Cadastrar Dentista" <br> - Preencher os campos apresentados <br> - Clicar em "Cadastrar" <br> - Selecionar algum dentista <br> - Clicar em "Atualizar Dentista" <br> |

| **Caso de Teste** 	| **CTU-14 – Acessar relatórios (Home Page - Administrador)** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Administrador |
| Objetivo do Teste 	| Analisar telas de relatórios |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Identificar e clicar na opção "Logar como funcionário" <br> - Fazer Login <br> - Navegar pelas telas |

| **Caso de Teste** 	| **CTU-15 – Navegação e Logoff** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário (Todos) |
| Objetivo do Teste 	| Analisar telas da plataforma |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login na área correta para cada tipo usuário <br> - Navegar pelas telas <br> - Identificar e Clicar no campo "Sair" |

| **Caso de Teste** 	| **CTU-16 – Editar perfil** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário (Todos) |
| Objetivo do Teste 	| Analisar telas para alteração de informações cadastrais |
| Ações necessárias 	| - Acessar o link do site pelo browser de preferência do usuário <br> - Fazer Login <br> - Identificar e clicar em "Editar perfil" na Home Page <br> - Realizar alguma alteração nas informações presentes <br> - Clicar em "Salvar"|

# 6. Cenários Testes

Os participantes terão como responsabilidades simular e analizar eficientemente os cenários descritos, expondo sua opinião sobre a aplicação.

Os cenários a seguir devem ser realizados pelos participantes:

| **Cenário de Teste** 	| **CTU-17 – Agendar uma consulta pela primeira vez** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Verificar as telas de cadastro e agendamento |
| Cenário	| Como Paciente, você deseja realizar um agendamento, assim que possível, com um dentista ortodontista para avaliação da necessidade de aparelho ortodôntico. Para isso, você precisa fazer seu cadastro na aplicação, fazer login e ir até a área de agendamentos |

| **Cenário de Teste** 	| **CTU-18 – Recuperação de senha e atualização de dados** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Averiguar tela de recuperação de senha para pacientes, homepage e seção de editar de perfil |
| Cenário 	| Como Paciente, você não se recorda de sua senha cadastrada e precisa atualizar seu número de telefone para receber notificações. Para isso, você precisa acessar a seção de recuperação de senha e realizar os passos fornecidos. Após a alteração da senha, acessar sua conta, identificar a seção de editar perfil e alterar seu número de telefone|

| **Cenário de Teste** 	| **CTU-19 – Verificação de agendamentos concluídos e agendamento** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Paciente |
| Objetivo do Teste 	| Analisar a tela login, homepage e seção de agendamentos  e agendaments concluídos|
| Cenário 	| Como paciente, você gostaria de ser atendido novamente pelo mesmo dentista da ultima consulta, porém você não se recorda o nome e deseja seguir o tratamento com este dentista em questão. Para isso, é necessario realizar o login, identificar a seção de agendamentos concluídos, verificar o nome do dentista e realizar um agendamento com esse dentista|

| **Cenário de Teste** 	| **CTU-20 – Realizar o cadastro de dentista e atualizar status de agendamento** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar tela de login para funcionários, homepage, seção de cadastro de usuários e agendamentos  |
| Cenário 	| Como secretária, você foi solicitada para incluir o cadastro de um dentista e atualizar o status do agendamento de um paciente. Para isso, você deve realizar o login na parte de funcionário, identificar a seção de cadastro de dentistas e realizar a inclusão do cadastro, logo após ter concluído esta tarefa, você deve retornar a homepage e identificar a seção de agendamentos para atualizar o status solicitado |

| **Cenário de Teste** 	| **CTU-20 – Recuperação de senha e agendamento de consulta** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Secretária |
| Objetivo do Teste 	| Verificar tela de login para funcionários, homepage, seção de cadastro de usuários, agendamentos e recuperação de senha |
| Cenário 	| Como secretária, você não se recorda da senha cadastrada e necessita realizar o agendamento de consulta para um paciente. Para isso, você deve acessar a área de funcionários, dizer que esqueceu a senha e seguir o procedimento enviado no email de recuperação. Em seguida, fazer login com os novos credenciais, identificar a seção de agendamentos e criar um. |

| **Cenário de Teste** 	| **CTU-22 – Emitir relatórios para análise do desempenho da clínica** 	|
|:---:	|:---:	|
|	Perfil 	| Usuário Administrador |
| Objetivo do Teste 	| Verificar o desempenho das telas atribuídas ao usuário Administrador |
| Ações necessárias 	| Como administrador do consultório, você deseja analisar a performance do mesmo. Para isso, você deve realizar o login e emitir diversos relatórios para análise |

# 7. Análise dos dados

Várias métricas podem ser estabelecidas para análise dos dados a serem coletados dos testes aplicados.
A eficácia da aplicação pode ser mensurada pela quantidade de conclusão de tarefas sem erro, conclusão de tarefa com erro (não crítico), erros críticos, quantidade de ações utilizadas e quantidade de solicitações de assistência. 
A eficiência pode ser medida através do tempo de execução da tarefa e o tempo utilizado nas tentativas de execução da tarefa.
A satisfação pode ser analisada através das reações percebidas diante da execução das tarefas pelos usuários e de forma geral durante o teste. 

A tabela a seguir será utilizada para analisar cada tarefa e cenário executados pelos participantes:

| **Usuário**   | **Resposta emocional**   | **Execução**  | **Tempo (seg)**  |  **Ações/Cliques**  | **Cometeu erro?** | **Se recuperou do erro?**  | **Observações** | 
| :--------: | :--------: |  :--------: |  :--------: | :--------: | :--------: | :--------: | :--------: |
| Usuario01 | -------- |  -------- |  -------- | -------- | -------- | -------- | -------- |
| Usuario02 | -------- |  -------- |  -------- | -------- | -------- | -------- | -------- |
| Usuario03 | -------- |  -------- |  -------- | -------- | -------- | -------- | -------- |
| Usuario04 | -------- |  -------- |  -------- | -------- | -------- | -------- | -------- |
| Usuario05 | -------- |  -------- |  -------- | -------- | -------- | -------- | -------- |

As seguintes informações serão utilizadas para preencher a tabela:

> - Usuário: código de cada usuário;
> - Resposta emocional: confuso, confiante, neutro, satisfeito, insatisfeito, ou estressado;
> - Execução: concluiu ou não concluiu;
> - Tempo (seg): cronometrar e colocar o tempo em segundos utilizado para realização ou não da tarefa;
> - Ações: contabilizar quantos movimentos e cliques foram feitos para realização ou não da tarefa;
> - Cometeu erro?: sim ou não;
> - Se recuperou do erro?: sim, não ou n/a.


