let horario_selecionado = null;

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("botao-reagendar-atendimento").addEventListener("click", () => {
        abrirPopup(document.querySelector(".popup"));

        new AgendaComponente(document.getElementById("atendimento-dentista-id").value, document.querySelector(".popup .agenda-semanas"), (info) => {
            if (info.horario.disponivel) {
                horario_selecionado = `${info.data} ${info.horario.hora}`;
                document.getElementById("atendimento-agenda-id").value = info.horario.agendaId;

                Array.from(document.querySelectorAll(".popup .agenda-semanas .coluna .hora.item-selecionado")).forEach((i) => {
                    i.classList.remove("item-selecionado");
                });

                document.querySelector(".popup .agenda-semanas #agenda-" + info.horario.agendaId).classList.add("item-selecionado");
            }
        }).load();
    });

    document.querySelector(".popup-botao").addEventListener("click", () => {
        document.getElementById("atendimento-data-hora").innerText = horario_selecionado;
        horario_selecionado = null;

        Array.from(document.querySelectorAll(".popup .agenda-semanas .coluna .hora.item-selecionado")).forEach((i) => {
            i.classList.remove("item-selecionado");
        });

        fecharPopup(document.querySelector(".popup"));
    });

    document.querySelector(".popup__close").addEventListener("click", () => {
        horario_selecionado = null;

        Array.from(document.querySelectorAll(".popup .agenda-semanas .coluna .hora.item-selecionado")).forEach((i) => {
            i.classList.remove("item-selecionado");
        });

        fecharPopup(document.querySelector(".popup"));
    });

    document.querySelector("#botao-cancelar").addEventListener("click", () => {
        let atendimento_id = document.querySelector("form input[name='ID']").value;

        fetch("/Atendimento/Delete/" + atendimento_id, { method: "post" }).then(async (response) => {
            let data = await response.json();

            if (data.success) {
                window.location = '/Atendimento';
            }
            else {
                alert("Erro");
            }
        });
    });
})