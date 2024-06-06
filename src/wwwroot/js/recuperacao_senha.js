function alterarSenha() {
    let formulario = new FormData(document.getElementById("formulario-alterar-senha"));
    let url = "/Usuario/CriarNovaSenhaC";

    fetch(url, { method: "post", body: formulario }).then((response) => {
        switch (response.status) {
            case 200:
                alert("Senha alterada");
                window.location = "/Paciente/Login";
                break;
            case 404:
                alert("ID de Recuperação não encontrado");
                break;
            case 400:
                alert("Código de Recuperação incorreto");
                break;
        }
    });
}


document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("botao-alterar-senha").addEventListener("click", alterarSenha);
});