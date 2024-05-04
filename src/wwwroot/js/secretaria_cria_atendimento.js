document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("atendimento_formulario_usuario_cpf").addEventListener("change", (event) => {
        fetch("/Paciente/ByCPF?cpf=" + event.target.value).then((resposta) => {
            if (resposta.ok) {
                resposta.json().then((dados) => {
                    document.getElementById("atendimento_formulario_usuario_nome").value = dados.nome;
                    document.querySelector("#formulario-novo-atendimento-secretaria > input[name='PacienteId']").value = dados.id;
                });
            }
            else {
                document.getElementById("atendimento_formulario_usuario_nome").value = "USUÁRIO NÃO ENCONTRADO";
                documen.querySelector("#formulario-novo-atendimento-secretaria > input[name='PacienteId']").value = null;
            }
        })
    });
})