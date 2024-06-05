const abas = {
    "edicao": "menu__conteudo-edicao",
    "notificacoes": "menu__conteudo-notificacoes"
};

function mudarAba(aba) {
    document.querySelectorAll("#menu__conteudo > div.ativo").forEach((e) => {
        e.classList.remove("ativo");
    });

    document.getElementById(abas[aba]).classList.add("ativo");
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("menu__notificacao-opcao").addEventListener("click", () => {
        mudarAba("notificacoes");
    });

    document.getElementById("menu__edicao-opcao").addEventListener("click", () => {
        mudarAba("edicao");
    });
})