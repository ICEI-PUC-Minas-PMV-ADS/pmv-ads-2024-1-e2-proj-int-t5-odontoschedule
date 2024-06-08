document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll(".cpf-mask").forEach((e) => {
        e.addEventListener("keydown", (event) => {
            let v = event.target.value;

            v = v.replace(/\D/g, "")
            v = v.replace(/(\d{3})(\d)/, "$1.$2")
            v = v.replace(/(\d{3})(\d)/, "$1.$2")       
            v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2")

            event.target.value = v;
        });
    });
});