document.addEventListener("DOMContentLoaded", () => {
    document.querySelector(".odonto-trocar-email form").addEventListener("submit", (event) => {
        event.preventDefault();

        let formData = new FormData(document.querySelector(".odonto-trocar-email form"));

        fetch("/Funcionario/ChangeRecoveryEmail", { method: "post", body: formData }).then(async (response) => {
            if (response.status == 200) {
                OdontoModal.setData("Sucesso", "Email de recuperação alterado!");
                OdontoModal.setCallback(() => { document.querySelector(".odonto-trocar-email").style.display = "none"; OdontoModal.close() });
            }
            else {
                OdontoModal.setData("Erro", response.text);
            }

            OdontoModal.open();
        })
    });

    document.querySelector(".trocar-email-fechar").addEventListener("click", () => {
        document.querySelector(".odonto-trocar-email").style.display = "none";
    });

    document.querySelector("#opcao-alterar-email").addEventListener("click", abrirAlteracaoEmail);
});

function abrirAlteracaoEmail() {
    document.querySelector(".odonto-trocar-email").style.display = "flex";
}