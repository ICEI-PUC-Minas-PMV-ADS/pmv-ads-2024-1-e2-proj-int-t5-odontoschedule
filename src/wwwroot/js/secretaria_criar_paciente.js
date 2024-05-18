document.addEventListener("DOMContentLoaded", () => {
    document.querySelector("#container-cadastrar-paciente form").addEventListener("submit", (event) => {
        event.preventDefault();

        let formData = new FormData(document.querySelector("#container-cadastrar-paciente form"));

        fetch("/Paciente/Create", { method: "post", body: formData }).then(async (response) => {
            let data = await response.json();

            if (data.success) {
                OdontoModal.setData("Cadastro finalizado!", "O paciente foi cadastrado.");
                OdontoModal.setCallback(() => {
                    window.location = "/Paciente/";
                });
            }
            else {
                OdontoModal.setData("Erro", data.content);
            }

            OdontoModal.open();
        });
    });
})