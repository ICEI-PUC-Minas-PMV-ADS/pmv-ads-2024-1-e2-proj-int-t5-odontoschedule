function alterarSenha() {
    let formulario = new FormData(document.getElementById("formulario-alterar-senha"));
    let url = "/Usuario/CriarNovaSenhaC";

    fetch(url, { method: "post", body: formulario }).then((response) => {
        switch (response.status) {
            case 200:
                OdontoModal.setData("Sucesso", "Senha alterada");
                OdontoModal.setCallback(() => window.location = "/Paciente/Login");

                break;
            case 404:
                OdontoModal.setData("Erro", "ID de Recuperação não encontrado");

                break;
            case 400:
                OdontoModal.setData("Erro", "Código de Recuperação incorreto");

                break;
        }

        OdontoModal.open();
    });
}


document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("botao-alterar-senha").addEventListener("click", alterarSenha);
});