# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Cadastro do Paciente** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site - Clicar em "Cadastrar-se" <br> - Preencher os campos presentes <br> - Clicar em "Cadastrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login como Paciente	|
|Requisito Associado | RF-02 - A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha. |
| Objetivo do Teste 	| Verificar se o paciente consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos CPF e senha <br> - Clicar em "Entrar" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-03 – Efetuar login como Secretária	|
|Requisito Associado | RF-02 - A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha. |
| Objetivo do Teste 	| Verificar se a secretária consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Logar como funcionário" <br> - Preencher os campos usuário e senha <br> - Clicar em "Entrar" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-04 – Efetuar login como Administrador	|
|Requisito Associado | RF-02 - A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha. |
| Objetivo do Teste 	| Verificar se o administrador consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Logar como funcionário" <br> - Preencher os campos usuário e senha <br> - Clicar em "Entrar" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-05 – Reagendar agendamento como secretária	|
|Requisito Associado | RF-03 - A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.      |
| Objetivo do Teste 	| Verificar se a secretária consegue reagendar um agendamento |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Logar como funcionário" <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" - Clicar em "Ver agendamentos" <br> - Clicar em algum agendamento disponível <br> - Clicar em "Reagendar" <br> - Selecione uma nova data e hora <br> - Clicar em "Agendar" |
|Critério de Êxito | - A Data e hora do agendamento foram atualizados |
|  	|  	|
| Caso de Teste 	| CT-06 – Reagendar agendamento como paciente	|
|Requisito Associado | RF-03 - A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.      |
| Objetivo do Teste 	| Verificar se a paciente consegue reagendar um agendamento |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" - Clicar em "Ver agendamentos" <br> - Clicar em algum agendamento disponível <br> - Clicar em "Reagendar" <br> - Selecionar uma nova data e hora <br> - Clicar em "Agendar"|
|Critério de Êxito | - A Data e hora do agendamento foram atualizados |
|  	|  	|
| Caso de Teste 	| CT-07 – Agendar consulta como Paciente	|
|Requisito Associado | RF-05 - A aplicação deve permitir que o paciente seja capaz de agendar uma consulta passando as seguintes informações: Informações de contato, especialidade desejada, horário, dentista e modalidade (particular ou convênio)       |
| Objetivo do Teste 	| Verificar se o paciente consegue agendar uma consulta |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" <br> - Clicar em "Fazer agendamentos" <br> - Preencher todas as informações do solicitadas |
|Critério de Êxito | - Deve aparecer um popup de confirmação de finalização do agendamento |
|  	|  	|
| Caso de Teste 	| CT-08 – Notificação de agendamento com 24 horas de antecedência da consulta	|
|Requisito Associado | RF-04 - A aplicação deve permitir que o paciente seja notificado com 24h de antecedência.       |
| Objetivo do Teste 	| Verificar se o paciente é notificado da sua consulta com 24 horas de antecedência |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" - Clicar em "Fazer agendamentos" <br> - Preencha todas as informações do agendamento, mas coloque a data e hora para o dia seguinte no mesmo horário que está sendo criado o agendamento<br> - Ao finalizar o agendamento, recarregue a página |
|Critério de Êxito | - Deve aparecer uma notificação informando que há um agendamento para o dia seguinte |
|  	|  	|
| Caso de Teste 	| CT-09 – Notificar cancelamento do agendamento ao paciente	|
|Requisito Associado | RF-06 - A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.       |
| Objetivo do Teste 	| Verificar se o paciente é notificado de cancelamento do agendamento |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais - Finalizar o agendamento e clicar em "Sair" na barra lateral - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Clicar no agendamento criado anteriormente e, em seguida, em "Cancelar Agendamento"<br> - Clicar em "Sair" <br> - Entrar com os credenciais do paciente que criou o agendamento |
|Critério de Êxito | - Deve haver uma notificação informando o cancelamento do agendamento |
|  	|  	|
| Caso de Teste 	| CT-10 – Notificar remarcação do agendamento ao paciente	|
|Requisito Associado | RF-06 - A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.       |
| Objetivo do Teste 	| Verificar se o paciente é notificado de alteração no horário do agendamento |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais - Finalizar o agendamento e clicar em "Sair" na barra lateral - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Clicar no agendamento criado anteriormente e, em seguida, em "Reagendar"<br> - Selecionar uma data e hora disponível<br> - Saia do perfil da secretária clicando em "Sair"<br> - Entrar com os credenciais do paciente que criou o agendamento |
|Critério de Êxito | - Deve haver uma notificação informando a mudança de data e hora do agendamento |
|  	|  	|
| Caso de Teste 	| CT-11 – Notificar alteração de status do agendamento ao paciente	|
|Requisito Associado | RF-06 - A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.       |
| Objetivo do Teste 	| Verificar se o paciente é notificado de alterações no status do agendamento |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais - Finalizar o agendamento e clicar em "Sair" na barra lateral - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Clicar no agendamento criado anteriormente e, em seguida, em mudar o status para "CONCLUIDO"<br> - Sair do perfil da secretária clicando em "Sair"<br> - Entre com os credenciais do paciente que criou o agendamento |
|Critério de Êxito | - Deve haver uma notificação informando a conclusão da consulta |
|  	|  	|
| Caso de Teste 	| CT-12 – Paciente visualizar atendimentos em aberto e já concluídos	|
|Requisito Associado | RF-07 - A aplicação deve permitir que o paciente visualize no seu perfil todos os atendimentos já realizados e pendentes.       |
| Objetivo do Teste 	| Verificar se o paciente é capaz de visualizar seus atendimentos pendentes e concluídos |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Criar 2 agendamentos com informações convencionais<br> - Clicar em "Sair"<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Localizar um dos agendamentos criados anteriormente e mudar o status do mesmo para "CONCLUIDO"<br> - Clicar em "Sair" - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Ver agendamentos"<br> - Clicar em "Agendamentos Concluídos" |
|Critério de Êxito | - Na aba "Ver agendamentos" deve estar listado o agendamento criado que não houve o status alterado e em "Agendamentos concluídos" o qual houve alteração no status |
|  	|  	|
| Caso de Teste 	| CT-13 – Secretária cadastrar dentista	|
|Requisito Associado | RF-08 - A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento.       |
| Objetivo do Teste 	| Verificar se a secretária é capaz de fazer o cadastro de um dentista |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Clicar em "Dentistas"<br> - Clicar em "Cadastrar Dentista"<br> - Preencher as informações do formulário e determinar a disponibilidade do profissional<br> - Clicar em "Cadastrar" |
|Critério de Êxito | - Na aba "Usuários" > "Dentistas" deve estar listado o novo profissional cadastrado |
|  	|  	|
| Caso de Teste 	| CT-14 – Secretária visualizar e filtrar atendimentos por dentista	|
|Requisito Associado | RF-09 - A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de visualizar e filtrar os atendimentos por dentista |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Preencher o primeiro campo com o filtro "Dentista" e no segundo um nome de dentista<br> - Clicar em Filtrar |
|Critério de Êxito | - Devem ser exibidos todos os agendamentos em aberto e após a filtragem devem ser exibidos apenas os agendamentos vinculados ao dentista selecionado |
|  	|  	|
| Caso de Teste 	| CT-15 – Secretária visualizar e filtrar atendimentos por data	|
|Requisito Associado | RF-09 - A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de visualizar e filtrar os atendimentos por data |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Preencher o primeiro campo com o filtro "Data" e no selecionar uma data<br> - Clicar em Filtrar |
|Critério de Êxito | - Devem ser exibidos todos os agendamentos em aberto e após a filtragem devem ser exibidos apenas os agendamentos marcados para a data selecionada |
|  	|  	|
| Caso de Teste 	| CT-16 – Secretária fazer um agendamento	|
|Requisito Associado | RF-10 - A aplicação deve permitir que a secretária faça agendamentos para pacientes cadastrados      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de agendar uma consulta para um paciente já cadastrado |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Agendar Paciente"<br> - Preencher o formulário, assim como selecionar o dentista e o horário do atendimento<br> - Clicar em "Agendar" |
|Critério de Êxito | - Ao acessar a aba "Ver agendamentos", o agendamento criado deve estar listado lá. |
|  	|  	|
| Caso de Teste 	| CT-17 – Secretária fazer cadastro de um paciente	|
|Requisito Associado | RF-11 - A aplicação deve permitir que a secretária faça cadastro de pacientes      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de fazer cadastro de pacientes |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Na aba "Pacientes", clicar em "Cadastrar Paciente"<br> - Preencha o formulário e clique em "Cadastrar" |
|Critério de Êxito | - Ao acessar o menu "Usuários > Pacientes" o novo paciente deve estar presente |
|  	|  	|
| Caso de Teste 	| CT-18 – Secretária mudar status do agendamento	|
|Requisito Associado | RF-12 - A aplicação deve permitir que a secretária mude o status da consulta e inclua observações.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de fazer alteração de status do agendamento e adicionar observações |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Ver agendamentos"<br> - Selecionar um agendamento<br> - Alterar seu status para "CONCLUIDO" e adicionar uma observação |
|Critério de Êxito | - Ao acessar a aba de "Agendamentos Concluídos", o agendamento alterado deve estar presente. E ao clicar nesse agendamento, o campo de observação deve contêr o valor inserido anteriormente. |
|  	|  	|
| Caso de Teste 	| CT-19 – Secretária visualizar informações e agenda de um dentista	|
|Requisito Associado | RF-13 - A aplicação deve permitir que a secretária seja capaz de visualizar todas as informações pessoais e agenda de um dentista.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de visualizar as informações pessoais e a agenda de um dentista |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Clicar em "Dentistas"<br> - Selecionar um dentista |
|Critério de Êxito | - As informações do dentista e sua agenda serão exibidas corretamente. |
|  	|  	|
| Caso de Teste 	| CT-20 – Secretária visualizar informações e agendamentos de um paciente	|
|Requisito Associado | RF-14 - A aplicação deve permitir que a secretária visualize todas as informações pessoais e agendamentos de um paciente específico.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de visualizar as informações pessoais e os agendamentos de um paciente |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Clicar em "Pacientes"<br> - Selecionar um Paciente |
|Critério de Êxito | - As informações do paciente e seus agendamentos serão exibidas corretamente. |
|  	|  	|
| Caso de Teste 	| CT-21 – Notificar novo agendamento à secretária	|
|Requisito Associado | RF-15 - A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.      |
| Objetivo do Teste 	| Verificar se a secretária é notificada de um novo agendamento |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais - Finalizar o agendamento e clicar em "Sair" na barra lateral - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais da Secretária |
|Critério de Êxito | - Deve haver uma notificação informando um novo agendamento |
|  	|  	|
| Caso de Teste 	| CT-22 – Notificar cancelamento do agendamento à secretária	|
|Requisito Associado | RF-15 - A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.      |
| Objetivo do Teste 	| Verificar se a secretária é notificada de cancelamento do agendamento |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais<br> - Finalizar o agendamento<br> - Clicar em "Ver Agendamentos"<br> - Selecionar o agendamento criado<br> - Clicar em "Cancelar Agendamento"<br> - Clicar em "Sair"<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária |
|Critério de Êxito | - Deve haver uma notificação informando o cancelamento do agendamento |
|  	|  	|
| Caso de Teste 	| CT-23 – Notificar remarcação do agendamento à secretária	|
|Requisito Associado | RF-15 - A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.      |
| Objetivo do Teste 	| Verificar se a secretária é notificada de alterações na data e hora do agendamento. |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Fazer agendamentos"<br> - Preencher o formulário com informações convencionais<br> - Finalizar o agendamento<br> - Clicar em "Ver Agendamentos"<br> - Selecionar o agendamento criado<br> - Clicar em "Reagendar"<br> - Selecionar um novo horário<br> - Clicar em "Sair"<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária |
|Critério de Êxito | - Deve haver uma notificação informando a alteração na data e hora do agendamento. |
|  	|  	|
| Caso de Teste 	| CT-24 – Secretária atualizar contato e endereço do paciente	|
|Requisito Associado | RF-16 - A aplicação deve permitir que a secretária atualize informações de contato e endereço de um paciente.      |
| Objetivo do Teste 	| Verificar se a secretária é capaz de alterar o contato e o endereço do paciente. |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Na aba "Pacientes", clicar no paciente desejado<br> - Inserir novas informações nos campos de endereço e contato<br> - Recarregar a página |
|Critério de Êxito | - As informações atualizadas devem se manter ao atualizar a página |
|  	|  	|
| Caso de Teste 	| CT-25 – Administrador visualizar métricas do consultório	|
|Requisito Associado | RF-17 - A aplicação deve permitir que o administrador visualize relatórios contendo informações de desempenho do consultório, como número de atendimentos.      |
| Objetivo do Teste 	| Verificar se o administrador é capaz de visualizar métricas do consultório |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais do Administrador |
|Critério de Êxito | - No centro da página devem existir gráficos contendo informações compátiveis com a quantidade de agendamentos e pacientes |
|  	|  	|
| Caso de Teste 	| CT-26 – Obter credenciais de funcionário	|
|Requisito Associado | RF-18 - A aplicação deverá gerar um login e senha que oferecerá acesso à área administrativa da aplicação para a secretária e o administrador.      |
| Objetivo do Teste 	| Verificar se o administrador e a secretária são capazes de obter seus credenciais |
| Passos 	| - Acessar o raiz dos arquivos da aplicação<br> - Verificar se existe um arquivo chamado config.txt. Se existir, apagar o mesmo.<br> - Clicar em "Entrar como Funcionário"<br> - Reiniciar o servidor HTTP<br> - Monitorar o console do servidor |
|Critério de Êxito | - No console devem ser exibidos os pares de credenciais do administrador e da secretária |
|  	|  	|
| Caso de Teste 	| CT-27 – Paciente alterar senha	|
|Requisito Associado | RF-19 - A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas      |
| Objetivo do Teste 	| Verificar se o paciente consegue alterar sua senha |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Preencha os campos com os credenciais de um paciente<br> - Clicar em "Editar Perfil"<br> - Atualizar o valor do campo "Senha"<br> - Clicar em "Salvar"<br> - Clicar em "Sair" |
|Critério de Êxito | - Após um novo login, a senha antiga não funcionará mais |
|  	|  	|
| Caso de Teste 	| CT-28 – Secretária alterar senha	|
|Requisito Associado | RF-19 - A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas      |
| Objetivo do Teste 	| Verificar se a secretária consegue alterar sua senha |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais da secretária<br> - Clicar em "Alterar senha"<br> - Atualizar o valor do campo exibido<br> - Clicar em "Salvar"<br> - Clicar em "Sair" |
|Critério de Êxito | - Após um novo login, a senha antiga não funcionará mais |
|  	|  	|
| Caso de Teste 	| CT-29 – Administrador alterar senha	|
|Requisito Associado | RF-19 - A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas      |
| Objetivo do Teste 	| Verificar se o administrador consegue alterar sua senha |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencha os campos com os credenciais do administrador<br> - Clicar em "Alterar senha"<br> - Atualizar o valor do campo exibido<br> - Clicar em "Salvar"<br> - Clicar em "Sair" |
|Critério de Êxito | - Após um novo login, a senha antiga não funcionará mais |
|  	|  	|
| Caso de Teste 	| CT-30 – Cancelar agendamento como secretária	|
|Requisito Associado | RF-03 - A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.      |
| Objetivo do Teste 	| Verificar se a secretária consegue cancelar um agendamento |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Logar como funcionário" <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" <br> - Clicar em "Ver agendamentos" <br> - Clicar em algum agendamento disponível <br> - Clicar em "Cancelar Agendamento" <br> - Clicar em "Ver agendamentos" |
|Critério de Êxito | - O agendamento não aparece mais na listagem |
|  	|  	|
| Caso de Teste 	| CT-31 – Cancelar agendamento como paciente	|
|Requisito Associado | RF-03 - A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.      |
| Objetivo do Teste 	| Verificar se o paciente consegue cancelar um agendamento |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos solicitados <br> - Clicar em "Entrar" <br> - Clicar em "Ver agendamentos" <br> - Clicar em algum agendamento disponível <br> - Clicar em "Cancelar Agendamento" <br> - Clicar em "Ver agendamentos" |
|Critério de Êxito | - O agendamento não aparece mais na listagem |
|  	|  	|
| Caso de Teste 	| CT-32 – Secretária mudar agenda de dentista	|
|Requisito Associado | RF-08 - A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento.       |
| Objetivo do Teste 	| Verificar se a secretária é capaz de alterar a agenda de um dentista |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do site<br> - Clicar em "Entrar como Funcionário"<br> - Preencher os campos com os credenciais da Secretária<br> - Clicar em "Usuários"<br> - Clicar em "Dentistas"<br> - Selecionar um dentista<br> - Na agenda, adicionar um novo horário<br> - Clicar em "Atualizar Dentista" <br> - Recarregar a página  |
|Critério de Êxito | - O horário adicionado deve aparecer como disponível |
|  	|  	|
| Caso de Teste 	| CT-33 – Atualizar perfil como paciente	|
|	Requisito Associado 	| RF-01 - A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha. |
| Objetivo do Teste 	| Verificar se o paciente consegue alterar suas informações. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Preencher os campos CPF e senha <br> - Clicar em "Entrar" <br> - Clicar em "Editar Perfil" - Alterar o campo "Telefone" <br> - Clicar em "Salvar" - Recarregar a página |
|Critério de Êxito | - O Telefone atualizado deve ser mantido |