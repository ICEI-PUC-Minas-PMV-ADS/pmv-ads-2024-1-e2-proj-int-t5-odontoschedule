document.addEventListener("DOMContentLoaded", (event) => {
    document.querySelector(".mobile-sidebar-trigger").addEventListener("click", () => {
        document.querySelector("#barra-lateral").classList.toggle("ativo");
    });

    document.querySelectorAll("#barra-lateral__informacoes > ul > li > a").forEach(e => {
        e.addEventListener("click", () => {
            if (document.querySelector("#barra-lateral").classList.contains("ativo")) {
                document.querySelector("#barra-lateral").classList.remove("ativo");
            }
        });
    });
});