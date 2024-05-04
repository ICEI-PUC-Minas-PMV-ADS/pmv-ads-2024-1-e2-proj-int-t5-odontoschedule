document.addEventListener("DOMContentLoaded", () => {
    Array.from(document.querySelectorAll(".lista__atendimento")).forEach((e) => {
        e.addEventListener("click", () => {
            window.location = `/Atendimento/Details/${e.dataset.atendimento_id}`;
        });
    });
})