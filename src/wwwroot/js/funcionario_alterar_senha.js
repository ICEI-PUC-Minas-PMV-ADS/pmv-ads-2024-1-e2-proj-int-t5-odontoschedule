document.addEventListener("DOMContentLoaded", () => {
    document.querySelector(".odonto-trocar-senha form").addEventListener("submit", (event) => {
        event.preventDefault();

        let formData = new FormData(document.querySelector(".odonto-trocar-senha form"));

        fetch("/Funcionario/ChangePassword", { method: "post", body: formData }).then(async (response) => {
            let data = await response.json();

            if (data.success) {
                OdontoModal.setData("Sucesso", "Senha alterada");
                OdontoModal.setCallback(() => { document.querySelector(".odonto-trocar-senha").style.display = "none"; OdontoModal.close() });
            }
            else {
                OdontoModal.setData("Erro", "Ocorreu um erro ao tentar fazer a alteração da sua senha");
            }

            OdontoModal.open();
        })
    });

    document.querySelector(".trocar-senha-fechar").addEventListener("click", () => {
        document.querySelector(".odonto-trocar-senha").style.display = "none";
    });

    document.querySelector("#opcao-alterar-senha").addEventListener("click", abrirAlteracaoSenha);
});

function abrirAlteracaoSenha() {
    document.querySelector(".odonto-trocar-senha").style.display = "flex";
}