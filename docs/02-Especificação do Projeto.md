# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foram consolidados com a participação de funcionários, donos do negócio e pacientes por meio de entrevistas e reuniões. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas a seguir:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/9c6b1403-005f-4136-8ab4-39b632bab804)
(Secretária) - Juliana é a secretária do consultório DentalIn. É uma profissional dedicada, porém sente-se sobrecarregada com a gestão de tantos arquivos e documentos físicos, bem como o gerenciamento das agendas dos dentistas. Essa sobrecarga influencia na qualidade do atendimento ao cliente, uma vez que não possui um acesso rápido e simplificado ao agendamento das consultas. Juliana busca uma solução que facilite o agendamento e o armazenamento de documentos e históricos dos pacientes, permitindo-lhe focar mais na qualidade do serviço prestado.

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/93d49a2f-2932-48cf-8d31-b82e1c8f0633)
(Paciente) - Felipe é um paciente regular do consultório DentalIn. Jovem e sempre conectado, ele deseja ter acesso fácil e simplificado ao seu histórico de tratamento. Felipe gostaria de poder marcar suas consultas online e acompanhar tanto o agendamento quanto o seu histórico, a fim de gerenciar sua saúde bucal de forma mais eficaz. 

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/a3938e13-f84e-447b-86ea-23dad65531cd)
(Administrador) - Carolina é uma empreendedora que possui um consultório odontológico em sua região. Ela é responsável por supervisionar o funcionamento do consultório, garantindo que todos os processos operacionais estejam funcionando de maneira eficiente. Carolina busca uma solução que possa auxiliar na gestão do consultório, facilitando o agendamento das consultas, o acompanhamento dos atendimentos, etc. Ela deseja uma ferramenta que forneça insights sobre o desempenho do consultório como a taxa de ocupação das agendas, o número de consultas realizadas em determinado intervalo de tempo, satisfação dos clientes, etc. Carolina está interessada em investir em tecnologias que melhorem a qualidade do serviço oferecido pelo consultório, aumentando a satisfação dos pacientes e impulsionando o crescimento do negócio. 


## Histórias de Usuários

A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários.

| Quem                | O que                                                                                                            | Por que                                                                                                                                       |
| ------------------- | ---------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| Paciente            | Deseja ser atendido no consultório odontológico DentalIn.| Necessidade de começar um tratamento |
| Paciente            | Deseja realizar agendamentos de forma autônoma e rápida, sem a necessidade de ligar para o consultório ou ir até ele.                                                                      |Realizado desta forma é mais cômodo e o paciente não precisa sair de casa e economiza tempo.|
| Paciente | Deseja ter noção de como anda o desempenho do consultório                                                        | Obter uma visão geral do andamento do negócio e definir metas.                                                                                |
| Paciente            | Deseja fazer agendamentos de forma autônoma, sem a necessidade de ligar para o consultório ou ir até ele.        | Devido a praticidade. Não é necessário esperar por filas ao ligar para o estabelecimento, nem mesmo ir ao local e enfrentar o mesmo problema. |
| Paciente            | Precisa fazer cancelamento ou reagendamento de consultas sem necessidade de um contato direto com o consultório. | Caso ocorram imprevistos cotidianos, é importante a possibilidade de se reagendar ou cancelar uma consulta de forma rápida.                   |
| Paciente          | Deseja cadastrar o quadro de horários de um dentista específico                                                  | Disponibilizar a lista de horários disponíveis para que os pacientes façam agendamentos                                                       |
| Paciente            | Precisa fazer a alteração de alguma informação inserida durante o cadastro.                                      | Alguma informação de contato ou endereço do paciente pode vir a mudar. Além de que é comum a necessidade de troca de senha.                   |
| Secretária          | Necessita de armazenar informações da consulta de cada paciente digitalmente.                                    | A fim de se ter um histórico do tratamento do paciente de forma digital.                                                                      |
| Secretária          | Precisa visualizar todos os agendamentos do dia.                                                                 | A fim de informar aos dentistas as consultas a serem realizadas.                                                                              |
| Secretária          | Precisa criar, agendar e reagendar consultas para usuários.                                                      | Pode acontecer de um usuário ligar direto no consultório ou então ir até lá.                                                                  |
| Secretária          | Precisa cadastrar e disponibilizar os horários e datas de atendimento de cada dentista.                          | Para permitir que os pacientes possam escolher o melhor horário e dentista para ele.                                                          |
| Secretária          | Precisa fazer o cadastro de pacientes na aplicação.                                                              | O paciente pode aparecer no consultório querendo fazer um agendamento sem ainda ter um cadastro.                                              |
| Secretária          | Precisa ser notificada de quaisquer agendamentos e alterações nos mesmos.                                        | É necessário se manter informado dos agendamentos para repassar as informações para a equipe.                                                 |
| Paciente            | Necessita saber de alterações em suas consultas.                                                                 | É importante que saiba de cancelamentos, reagendamentos e observações de consultas.                                                           |
| Paciente            | Necessita de visualizar todos os seus atendimentos, juntamente com as informações do mesmo.                      | Isso é necessário para que seja recuperada alguma informação ou observação incluída em uma consulta antiga.                                   |

## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues.

| RF-01 | A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha.     | Alta  |
| ----- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----- |
| RF-02 | A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha.                                                               | Alta  |
| RF-03 | A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.                                                                                                                            | Alta  |
| RF-04 | A aplicação deve permitir que o paciente seja notificado com 24h de antecedência.                                                                                                                                       | Baixa |
| RF-05 | A aplicação deve permitir que o paciente seja capaz de agendar uma consulta passando as seguintes informações: Informações de contato, especialidade desejada, horário, dentista e modalidade (particular ou convênio)  | Alta  |
| RF-06 | A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.                                                                                              | Alta  |
| RF-07 | A aplicação deve permitir que o paciente visualize no seu perfil todos os atendimentos já realizados e pendentes.                                                                                                       | Alta  |
| RF-08 | A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento. | Alta  |
| RF-09 | A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.                                                                                                                    | Alta  |
| RF-10 | A aplicação deve permitir que a secretária faça agendamentos para pacientes cadastrados                                                                                                                                 | Média |
| RF-11 | A aplicação deve permitir que a secretária faça cadastro de pacientes                                                                                                                                                   | Média |
| RF-12 | A aplicação deve permitir que a secretária mude o status da consulta e inclua observações.                                                                                                                              | Alta  |
| RF-13 | A aplicação deve permitir que a secretária seja capaz de visualizar todas as informações pessoais e agenda de um dentista.                                                                                              | Alta  |
| RF-14 | A aplicação deve permitir que a secretária visualize todas as informações pessoais e agendamentos de um usuário específico.                                                                                             | Alta  |
| RF-15 | A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.                                                                                              | Alta  |
| RF-16 | A aplicação deve permitir que a secretária atualize informações de contato e endereço de um paciente.                                                                                                                   | Alta  |
| RF-17 | A aplicação deve permitir que o administrador visualize relatórios contendo informações de desempenho do consultório, como número de atendimentos.                                                                      | Alta  |
| RF-18 | A aplicação deverá gerar um login e senha que oferecerá acesso à área administrativa da aplicação para a secretária e o administrador.                                                                                  | Alta  |
| RF-19 | A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas                                                                                                                 | Alta  |

### Requisitos não Funcionais

A tabela a seguir apresenta os requisitos não funcionais que o projeto deverá atender.

| ID     | Descrição                                                                                                                                               | Prioridade |
| ------ | ------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------- |
| RNF-01 | A aplicação deve estar disponível 24 horas por dia, 7 dias por semana.                                                                                  | Alta       |
| RNF-02 | A aplicação deve ser compatível com os principais navegadores (Chrome, Firefox e Edge)                                                                  | Alta       |
| RNF-03 | A aplicação deve utilizar o Microsoft SQL Server para armazenamento de dados                                                                            | Alta |
| RNF-04 | A aplicação deve ser responsiva                                                                                                                         | Alta       |
| RNF-05 | Para que qualquer usuário utilize a aplicação é necessário que esteja logado em sua conta. | Alta       |
| RNF-06 | A linguagem a ser utilizada para  o desenvolvimento da aplicação deve ser o C# juntamente com a Entity Framework.                                          | Alta       |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

![Casos de Uso](/docs/img/casos_de_uso.jpg)
