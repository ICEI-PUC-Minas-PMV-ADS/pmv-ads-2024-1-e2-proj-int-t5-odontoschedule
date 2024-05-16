document.addEventListener("DOMContentLoaded", (event) => {
    const menu = document.querySelector(".menu");
    const menuDropdown = menu.querySelector(".menu-dropdown");

    menu.addEventListener("click", (event) => {
        event.preventDefault();
        menu.classList.toggle("active");
    });

    document.addEventListener("click", (event) => {
        if (!menu.contains(event.target)) {
            menu.classList.remove("active");
        }
    });

    fetch("/Notificacao/").then(async (response) => {
        let data = await response.json();

        data.forEach((n) => {
            let li = document.createElement("li");
            li.innerText = n.conteudo;

            menuDropdown.appendChild(li);
        });
    })
});