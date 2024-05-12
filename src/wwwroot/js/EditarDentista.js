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
				agenda.postData();
			}
		})
	});
})

