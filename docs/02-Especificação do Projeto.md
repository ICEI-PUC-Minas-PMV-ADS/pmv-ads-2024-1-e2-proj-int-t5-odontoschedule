# Especificações do Projeto

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foram consolidados com a participação de funcionários, donos do negócio e pacientes por meio de entrevistas e reuniões. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas a seguir:

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/9c6b1403-005f-4136-8ab4-39b632bab804" width=300/><br>
(Secretária) - Juliana é a secretária do consultório DentalIn. É uma profissional dedicada, porém sente-se sobrecarregada com a gestão de tantos arquivos e documentos físicos, bem como o gerenciamento das agendas dos dentistas. Essa sobrecarga influencia na qualidade do atendimento ao cliente, uma vez que não possui um acesso rápido e simplificado ao agendamento das consultas. Juliana busca uma solução que facilite o agendamento e o armazenamento de documentos e históricos dos pacientes, permitindo-lhe focar mais na qualidade do serviço prestado.

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/93d49a2f-2932-48cf-8d31-b82e1c8f0633" width=300/><br>
(Paciente) - Felipe é um paciente regular do consultório DentalIn. Jovem e sempre conectado, ele deseja ter acesso fácil e simplificado ao seu histórico de tratamento. Felipe gostaria de poder marcar suas consultas online e acompanhar tanto o agendamento quanto o seu histórico, a fim de gerenciar sua saúde bucal de forma mais eficaz. 

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t5-odontoschedule/assets/144942087/a3938e13-f84e-447b-86ea-23dad65531cd" width=300/><br>
(Empreendedora) - Carolina é uma empreendedora que possui um consultório odontológico em sua região. Ela é responsável por supervisionar o funcionamento do consultório, garantindo que todos os processos operacionais estejam funcionando de maneira eficiente. Carolina busca uma solução que possa auxiliar na gestão do consultório, facilitando o agendamento das consultas, o acompanhamento dos atendimentos, etc. Ela deseja uma ferramenta que forneça insights sobre o desempenho do consultório como a taxa de ocupação das agendas, o número de consultas realizadas em determinado intervalo de tempo, satisfação dos clientes, etc. Carolina está interessada em investir em tecnologias que melhorem a qualidade do serviço oferecido pelo consultório, aumentando a satisfação dos pacientes e impulsionando o crescimento do negócio. 


## Histórias de Usuários

A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários.

| Quem                | O que                                                                                                            | Por que                                                                                                                                       |
| ------------------- | ---------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| Paciente            | Deseja ser atendido no consultório odontológico DentalIn.| Necessidade de começar um tratamento. |
| Paciente            | Deseja realizar agendamentos de forma autônoma e rápida, sem a necessidade de ligar para o consultório ou ir até ele.|Realizado desta forma é mais cômodo e o paciente não precisa sair de casa e economiza tempo.|
| Paciente | Precisa fazer cancelamento ou reagendamento de consultas sem necessidade de um contato direto com o consultório.| Caso ocorram imprevistos cotidianos, é importante a possibilidade de se reagendar ou cancelar uma consulta de forma rápida.|
| Paciente            | Necessita visualizar todos os seus atendimentos, juntamente com as informações do mesmo.| Para verificar alguma informação ou observação incluída em uma consulta antiga.|
| Paciente            | Necessita saber de alterações em suas consultas.| É importante que seja notificado de cancelamentos, reagendamentos e tenha acesso a observações de consultas.|
| Secretária          | Deseja ter acesso aos atendimentos do dia de forma prática e rápida.| Verificar agenda para algum paciente ou outro funcionário e informar a agenda aos dentistas.|
| Secretária          | Deseja gerir os dados de dentistas e pacientes de forma eficiente e por meio de tecnologias.|Otimizar seu tempo para que ela possa focar em outras atividades.|
| Secretária          | Deseja acessar de modo rápido e fácil informações de consulta de cada paciente. | Assim conseguirá atender os pacientes de forma mais ágil e proativa.|
| Dono do consultório          | Deseja ter noção de como anda o desempenho do consultório. | Obter uma visão geral do andamento do negócio e definir metas. |
| Dono do consultório          | Deseja diminuir a taxa de não comparecimento. | Para maximizar o lucro do consultório. |

## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues.

| ID     | Descrição                                                                                                                                               | Prioridade |
| ------ | ------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------- |
| RF-01 | A aplicação deve permitir que um paciente gerencie seu cadastro. O paciente deve ser capaz de se cadastrar, fornecendo os seguintes dados: Nome completo, CPF (campo de login), endereço, e-mail, telefone e senha.     | Alta  |
| RF-02 | A aplicação deve permitir que um paciente faça login utilizando CPF e senha. E caso seja um administrador ou secretária, utilize nome de usuário e senha.                                                               | Alta  |
| RF-03 | A aplicação deve permitir que o paciente e a secretária cancelem e remarquem um atendimento.                                                                                                                            | Alta  |
| RF-04 | A aplicação deve permitir que o paciente receba um aviso com 24h de antecedência do seu atendimento.                                                                                                                                       | Baixa |
| RF-05 | A aplicação deve permitir que o paciente seja capaz de agendar uma consulta passando as seguintes informações: Informações de contato, especialidade desejada, horário, dentista e modalidade (particular ou convênio)  | Alta  |
| RF-06 | A aplicação deve permitir que o paciente receba uma notificação quando uma consulta for cancelada, remarcada ou concluída.                                                                                              | Alta  |
| RF-07 | A aplicação deve permitir que o paciente visualize no seu perfil todos os atendimentos já realizados e pendentes.                                                                                                       | Alta  |
| RF-08 | A aplicação deve permitir que um usuário do tipo secretária gerencie os dentistas. Além disso, no cadastro devem ser fornecidos dados como: nome, CRO, especialidade e seus respectivos dias e horários de atendimento. | Alta  |
| RF-09 | A aplicação deve permitir que a secretária visualize os agendamentos e filtre-os por dia e dentista.                                                                                                                    | Alta  |
| RF-10 | A aplicação deve permitir que a secretária faça agendamentos para pacientes cadastrados                                                                                                                                 | Média |
| RF-11 | A aplicação deve permitir que a secretária faça cadastro de pacientes                                                                                                                                                   | Média |
| RF-12 | A aplicação deve permitir que a secretária mude o status da consulta e inclua observações.                                                                                                                              | Alta  |
| RF-13 | A aplicação deve permitir que a secretária seja capaz de visualizar todas as informações pessoais e agenda de um dentista.                                                                                              | Alta  |
| RF-14 | A aplicação deve permitir que a secretária visualize todas as informações pessoais e agendamentos de um paciente específico.                                                                                             | Alta  |
| RF-15 | A aplicação deve permitir que a secretária receba uma notificação quando uma consulta foi agendada, cancelada e remarcada.                                                                                              | Alta  |
| RF-16 | A aplicação deve permitir que a secretária atualize informações de contato e endereço de um paciente.                                                                                                                   | Alta  |
| RF-17 | A aplicação deve permitir que o administrador visualize relatórios contendo informações de desempenho do consultório, como número de atendimentos.                                                                      | Alta  |
| RF-18 | A aplicação deverá gerar um login e senha que oferecerá acesso à área administrativa da aplicação para a secretária e o administrador.                                                                                  | Alta  |
| RF-19 | A aplicação deve permitir que usuários do tipo secretária, administrador e paciente alterem suas senhas                                                                                                                 | Alta  |
| RF-20 | A aplicação deve permitir que usuários do tipo secretária, administrador e paciente recuperem suas senhas | Media  |

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
|02| O Deploy dá aplicação na Microsoft Azure deve custar, no máximo, 100 dólares |

## Diagrama de Casos de Uso

![Casos de Uso](/docs/img/casos_de_uso.jpg)
