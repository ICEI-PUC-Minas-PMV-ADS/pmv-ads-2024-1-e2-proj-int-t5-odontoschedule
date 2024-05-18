class OdontoModal {
    static #callback = () => OdontoModal.close();

    static getModal() {
        return document.querySelector(".odonto-modal");
    }

    static setData(title, text) {
        OdontoModal.getModal().querySelector(".modal__title").innerText = title;
        OdontoModal.getModal().querySelector(".modal__text").innerText = text;
    }

    static getCallback() {
        return OdontoModal.#callback;
    }

    static setCallback(callback) {
        OdontoModal.#callback = callback;
    }

    static open() {
        OdontoModal.getModal().classList.add("aberto");
    }

    static close() {
        OdontoModal.getModal().classList.remove("aberto");
    }

    static toggle() {
        OdontoModal.getModal().classList.toggle("aberto");
    }
}

document.addEventListener("DOMContentLoaded", () => {
    OdontoModal.getModal().querySelector(".modal__btn").addEventListener("click", () => {
        OdontoModal.getCallback()();
    });
});