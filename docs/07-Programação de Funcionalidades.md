# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) | Responsável(is) |
|------|-----------------------------------------|----|----|  
|RF-01| A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha. | PacienteController.cs e Paciente/Cadastro.cshtml |  Kayo |
|RF-02| A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha.   | PacienteController.cs, FuncionarioController.cs, Paciente/Login.cshtml, Funcionario/Login.cshtml| Kayo  |
|RF-03| A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.     | Atendimento/Details.cshtml e AtendimentoController.cs | Amanda e Joabe |
|RF-04| A aplicação deve permitir que o paciente seja notificado com 24h de antecedência.     |  |  Alvaro |
|RF-05| A aplicação deve permitir que o paciente seja capaz de agendar uma consulta passando as seguintes informações: Informações de contato, especialidade desejada, horário, dentista e modalidade (particular ou convênio)    | Atendimento/Create.cshtml, AtendimentoController.cs | Amanda  |
|RF-06| A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.  |  | Alvaro |
|RF-07| A aplicação deve permitir que o paciente visualize no seu perfil todos os atendimentos já realizados e pendentes.   |  Paciente/Index.cshtml, PacienteController.cs e AtendimentoController.cs | Alvaro |
|RF-08| A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento.   | Dentista/Create.cshtml, Dentista/Details.cshtml,  Dentista/Index.cshtml e DentistaController.cs |  Cassiano |
|RF-09| A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.   | AtendimentoController.cs e Atendimento/Index.cshtml | Joabe |
|RF-10| A aplicação deve permitir que a secretária faça agendamentos para pacientes cadastrados    | AtendimentoController.cs e Atendimento/Create.cshtml |  Joabe |
|RF-11| A aplicação deve permitir que a secretária faça cadastro de pacientes    | Paciente/Create.cshtml, PacienteController.cs |  Alvaro |
|RF-12| A aplicação deve permitir que a secretária mude o status da consulta e inclua observações.     | AtendimentoController.cs e Atendimento/Details.cshtml  |  Joabe |
|RF-13| A aplicação deve permitir que a secretária seja capaz de visualizar todas as informações pessoais e agenda de um dentista.   | DentistaController.cs e Dentista/Details.cshtml |  Cassiano |
|RF-14| A aplicação deve permitir que a secretária visualize todas as informações pessoais e agendamentos de um paciente específico.    | Paciente/Details.cshtml e PacienteController.cs |  Alvaro |
|RF-15| A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.   |  | Joabe |
|RF-16| A aplicação deve permitir que a secretária atualize informações de contato e endereço de um paciente.   | Paciente/Details.cshtml e PacienteController.cs | Alvaro  |
|RF-17| A aplicação deve permitir que o administrador visualize relatórios contendo informações de desempenho do consultório, como número de atendimentos.   |  | Cassiano e Joabe |
|RF-18| A aplicação deverá gerar um login e senha que oferecerá acesso à área administrativa da aplicação para a secretária e o administrador.    | Program.cs | Kayo |
|RF-19| A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas   |  | Kayo |
|RF-20| A aplicação deve permitir que usuários do tipo secretária, administrador e paciente recuperem suas senhas   |  | Amanda |



# Instruções de acesso

### URL de acesso

Link: https://odontoschedule.azurewebsites.net/


### Usuários com acessos restritos

Administrador:<br>
&emsp;Usuário: admin<br>
&emsp;Senha: 1kE8tA0jmPVXFk3<br><br>

Secretária:<br>
&emsp;Usuário: secretária<br>
&emsp;Senha: Y730gEPDXdXauuo<br>

