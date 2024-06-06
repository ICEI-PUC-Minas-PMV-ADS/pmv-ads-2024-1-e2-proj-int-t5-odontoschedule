document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("link-esqueceu-senha").addEventListener("click", () => {
        fetch("/Funcionario/EsqueciMinhaSenhaC", { method: "post" }).then(async (response) => {
            switch (response.status) {
                case 400:
                    alert(response.text);
                    break;
                case 200:
                    alert("Email de recuperação enviado!");
                    break;
                default:
                    alert("Erro inesperado");
                    break;
            }
        })
    });
})