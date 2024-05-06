document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("botao-reagendar-atendimento").addEventListener("click", () => {
        abrirPopup(document.querySelector(".popup"));

        new AgendaComponente(document.getElementById("atendimento-dentista-id").value, document.querySelector(".popup .agenda-semanas"), (info) => {
            if (info.horario.disponivel) {
                document.getElementById("atendimento-data-hora").value = `${info.data} ${info.horario.hora}`;
                document.getElementById("atendimento-agenda-id").value = info.horario.agendaId;

                fecharPopup(document.querySelector(".popup"));
            }
        }).load();
    });
})