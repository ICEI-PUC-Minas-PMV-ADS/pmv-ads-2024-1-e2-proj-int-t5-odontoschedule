const formularioMultiploPropriedades = {
    0: {
        ativoIndex: null,
        lidar: lidaFluxoFormularioAtendimentoSecretaria,
        finalizar: (form) => criarAgendamento(form)
    }
};

function lidaFluxoFormulario(event) {
    let formulario = event.target.parentNode;
    let formularioPartes = formulario.querySelectorAll(".formulario-multiplo__parte");

    Array.from(formularioPartes).forEach((f, i) => {
        if (f.classList.contains("ativo")) {
            formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex = i;

            if (i !== formularioPartes.length - 1) f.classList.remove("ativo");
        }
    });

    if (formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex === formularioPartes.length - 2) {
        document.querySelector(".formulario-multiplo__botao").innerText = "Finalizar";
    }
    else {
        document.querySelector(".formulario-multiplo__botao").innerText = "Próximo";
    }
    

    if (formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex === formularioPartes.length - 1)
        return formularioMultiploPropriedades[formulario.dataset.form_id].finalizar(formulario);

    Array.from(formularioPartes)[formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex + 1].classList.add("ativo");

    if (formulario.dataset.form_id !== undefined) formularioMultiploPropriedades[formulario.dataset.form_id].lidar(Array.from(formularioPartes)[formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex + 1]);
}

function abrirPopup(popup) {
    popup.classList.add("aberto");
}

function fecharPopup(popup) {
    popup.classList.remove("aberto");
}

function criarAgendamento(form) {
    fetch("/Atendimento/Create", { method: "post", body: new FormData(form) }).then(async (response) => {
        let data = await response.json();

        if (data.success) {
            OdontoModal.setData("Agendamento Realizado!", "");
            OdontoModal.setCallback(() => window.location = "/Atendimento");
        }
        else {
            OdontoModal.setData("Erro", data.content);
        }

        OdontoModal.open();
    });
}

function lidaFluxoFormularioAtendimentoSecretaria(parte) {
    const buscarDentistas = () => {
        fetch("/Dentista/GetAll").then(async (response) => {
            let data = await response.json();

            if (data.length > 0) {
                parte.querySelector(".no-dentist").style.display = "none";

                data.forEach((dentista) => {
                    let template = parte.querySelector("#dentista-lista-template").content.querySelector("tr").cloneNode(true)

                    template.children.item(0).innerText = dentista.nome;
                    template.children.item(1).innerText = dentista.especialidade;
                    template.addEventListener("click", () => {
                        parte.parentNode.querySelector("input[name='DentistaId']").value = dentista.id;

                        Array.from(parte.querySelectorAll("table tbody tr")).forEach((i) => {
                            if (i.classList.contains("item-selecionado")) {
                                i.classList.remove("item-selecionado");
                            }
                        });

                        template.classList.add("item-selecionado");
                    });

                    parte.querySelector("table tbody").appendChild(template);
                });
            }
            else {
                document.querySelector(".formulario-multiplo__botao").style.display = "none";
                parte.querySelector("table").style.display = "none";
            }
        })
    }

    const buscarDentistaAgenda = () => {
        let dentista = parte.parentNode.querySelector("input[name='DentistaId']").value;

        new AgendaComponente(dentista, document.getElementById("secretaria-agendamento-agenda"), (info) => {
            if (info.horario.disponivel) {
                parte.parentNode.querySelector("input[name='AgendaId']").value = info.horario.agendaId;

                Array.from(document.getElementById("secretaria-agendamento-agenda").querySelectorAll(".coluna .hora.item-selecionado")).forEach((i) => {
                    i.classList.remove("item-selecionado");
                });

                document.querySelector("#secretaria-agendamento-agenda #agenda-" + info.horario.agendaId).classList.add("item-selecionado");
            }
        }).load().then((r) => {
            if (!r) {
                document.querySelector(".formulario-multiplo__botao").style.display = "none";
            }
        });
    }

    switch (parte.dataset.form_parte) {
        case "dentistas":
            buscarDentistas();
            break;
        case "agendamento":
            buscarDentistaAgenda();
            break;
    }
}

document.addEventListener("DOMContentLoaded", () => {
    Array.from(document.querySelectorAll(".formulario-multiplo__botao")).forEach((fb) => {
        fb.addEventListener("click", lidaFluxoFormulario);
    });

    Array.from(document.querySelectorAll(".popup__close")).forEach((pc) => {
        pc.addEventListener("click", () => fecharPopup(pc.parentNode.parentNode));
    });
});