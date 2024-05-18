var agenda;

document.addEventListener('DOMContentLoaded', () => {
	agenda = new AgendaEditorComponente(null, document.getElementById('dentista-agendamento-agenda'));
	agenda.load();
	document.querySelector('.odonto-botao-primario').addEventListener('click', () => {
		let formdata = new FormData(document.querySelector('form'));

		fetch('/Dentista/Create', {
			method: 'post', body: formdata
		}).then(async (resposta) => {
			let data = await resposta.json();

			if (data.success) {
				agenda.postData(data.content).then((result) => {
					if (result[0]) {
						OdontoModal.setData("Dentista cadastrado", "As informações pessoais do dentista e a agenda foram cadastradas.");
						OdontoModal.setCallback(() => window.location = "/Dentista/");
					}
					else {
						OdontoModal.setData("Erro", result[1]);
					}

					OdontoModal.open();
				});
			}
		});
	});
})

