const formularioMultiploPropriedades = {
    0: {
        ativoIndex: null,
        lidar: lidaFluxoFormularioAtendimentoSecretaria
    }
};

function lidaFluxoFormulario(event) {
    let formulario = event.target.parentNode;
    let formularioPartes = formulario.querySelectorAll(".formulario-multiplo__parte");

    Array.from(formularioPartes).forEach((f, i) => {
        if (f.classList.contains("ativo")) {
            formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex = i;

            f.classList.remove("ativo");
        }
    });

    if (formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex === formularioPartes.length - 1)
        return formulario.submit();

    Array.from(formularioPartes)[formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex + 1].classList.add("ativo");

    if (formulario.dataset.form_id !== undefined) formularioMultiploPropriedades[formulario.dataset.form_id].lidar(Array.from(formularioPartes)[formularioMultiploPropriedades[formulario.dataset.form_id].ativoIndex + 1]);
}

function abrirPopup(popup) {
    popup.classList.add("aberto");
}

function fecharPopup(popup) {
    popup.classList.remove("aberto");
}

function lidaFluxoFormularioAtendimentoSecretaria(parte) {
    const buscarDentistas = () => {
        fetch("/Dentista/GetAll").then(async (response) => {
            (await response.json()).forEach((dentista) => {
                let template = parte.querySelector("#dentista-lista-template").content.querySelector("tr").cloneNode(true)

                template.children.item(0).innerText = dentista.nome;
                template.children.item(1).innerText = dentista.especialidade;
                template.addEventListener("click", () => {
                    parte.parentNode.querySelector("input[name='DentistaId']").value = dentista.id;
                });

                parte.querySelector("table tbody").appendChild(template);
            });
        })
    }

    const buscarDentistaAgenda = () => {
        let dentista = parte.parentNode.querySelector("input[name='DentistaId']").value;

        new AgendaComponente(dentista, document.getElementById("secretaria-agendamento-agenda"), (info) => {
            parte.parentNode.querySelector("input[name='AgendaId']").value = info.horario.agendaId;
        }).load();
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