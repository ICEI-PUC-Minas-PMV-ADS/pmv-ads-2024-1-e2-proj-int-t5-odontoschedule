var agenda;

document.addEventListener('DOMContentLoaded', () => {
	agenda = new AgendaEditorComponente(document.querySelector('form input[name="ID"]').value, document.getElementById('dentista-agendamento-agenda'));
	agenda.load();
	document.querySelector('.odonto-botao-primario').addEventListener('click', () => {
		let formdata = new FormData(document.querySelector('form'));

		fetch('/Dentista/Edit/' + document.querySelector('form input[name="ID"]').value, {
			method: 'post', body: formdata
		}).then(async (resposta) => {
			let data = await resposta.json();

			if (data.success) {
				agenda.postData().then((result) => {
					if (result[0]) {
						OdontoModal.setData("Dentista atualizado", "As informações pessoais do dentista e da agenda foram atualizadas.");
						OdontoModal.setCallback(() => window.location.reload());
					}
					else {
						OdontoModal.setData("Erro", result[1]);
					}

					OdontoModal.open();
				});
			}
		})
	});
})

