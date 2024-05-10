# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos com os artefatos criados (código fonte), deverão apresentadas as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Por exemplo: a tabela a seguir deverá ser preenchida considerando os artefatos desenvolvidos.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) | Responsável(is) |
|------|-----------------------------------------|----|----|  
|RF-01| A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha. | PacienteController.cs, Create.cshtml |  Kayo |
|RF-02| A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha.   | PacienteController.cs, Paciente - Login.cshtml, Funcionario - Login.cshtml| Kayo  |
|RF-03| A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.     | Atendimento - Create.cshtml, Home - Index.cshtml, AtendimentoController.cs, Atendimento.cs | Amanda e Joabe |
|RF-04| A aplicação deve permitir que o paciente seja notificado com 24h de antecedência.     |  |   |
|RF-05| A aplicação deve permitir que o paciente seja capaz de agendar uma consulta passando as seguintes informações: Informações de contato, especialidade desejada, horário, dentista e modalidade (particular ou convênio)    | Atendimento - Create.cshtml, AtendimentoController.cs | Amanda  |
|RF-06| A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.  |  |   |
|RF-07| A aplicação deve permitir que o paciente visualize no seu perfil todos os atendimentos já realizados e pendentes.   | AtenidmentoController.cs, Home - Index.cshtml  | Amanda  |
|RF-08| A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento.   | Dentista.cs, Dentista - Create.cshtml, Delete.cshtml, Details.cshtml, Edite.cshtml,  Index.cshtml |  Cassiano |
|RF-09| A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.   |  |   |
|RF-10| A aplicação deve permitir que a secretária faça agendamentos para pacientes cadastrados    | AtendimentoController.cs, Home - Index.cshtml |  Joabe |
|RF-11| A aplicação deve permitir que a secretária faça cadastro de pacientes    |  |  Alvaro |
|RF-12| A aplicação deve permitir que a secretária mude o status da consulta e inclua observações.     |  |  Joabe |
|RF-13| A aplicação deve permitir que a secretária seja capaz de visualizar todas as informações pessoais e agenda de um dentista.   |  |  Cassiano |
|RF-14| A aplicação deve permitir que a secretária visualize todas as informações pessoais e agendamentos de um paciente específico.    |  |  Alvaro |
|RF-15| A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.   |  |   |
|RF-16| A aplicação deve permitir que a secretária atualize informações de contato e endereço de um paciente.   |  | Alvaro  |
|RF-17| A aplicação deve permitir que o administrador visualize relatórios contendo informações de desempenho do consultório, como número de atendimentos.   |  |   |
|RF-18| A aplicação deverá gerar um login e senha que oferecerá acesso à área administrativa da aplicação para a secretária e o administrador.    |  |  Kayo |
|RF-19| A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas   |  | Kayo  |



# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

