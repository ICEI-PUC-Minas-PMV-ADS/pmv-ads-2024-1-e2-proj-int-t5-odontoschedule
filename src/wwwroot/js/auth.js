document.addEventListener("DOMContentLoaded", () => {
    document.querySelector(".login-formulario").addEventListener("submit", (event) => {
        event.preventDefault();

        let formData = new FormData(event.target);


        console.log(formData);
        fetch(event.target.dataset.url, {
            method: "post",
            body: formData
        }).then(async (response) => {
            let dados = await response.json();

            if (dados.success) {
                window.location = "/";
            }
            else{
                document.querySelector(".error-text").innerText = dados.content;
            }
        })
    });
})