document.addEventListener("DOMContentLoaded", () => {
    Array.from(document.querySelectorAll(".lista__atendimento")).forEach((e) => {
        e.addEventListener("click", () => {
            window.location = `/Atendimento/Details/${e.dataset.atendimento_id}`;
        });
    });

    let tipo_filtro = document.getElementById("filtro-tipo");
    let filtro_valor = document.getElementById("filtro-valor");

    document.getElementById("atendimentos-filtro-botao").addEventListener("click", () => {
        window.location = "/Atendimento/Index?tipo_filtro=" + tipo_filtro.value + "&filtro_valor=" + filtro_valor.value + ((new URLSearchParams(window.location.search)).get("status") === null ? "" : "&status=" + (new URLSearchParams(window.location.search)).get("status"));
    });
});