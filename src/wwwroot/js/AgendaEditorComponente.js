class AgendaEditorComponente {
	#elem;
	#dentist;
	#data;

	constructor(dentist, element) {
		this.#elem = element;
		this.#dentist = dentist;
		this.#data = {agendas: [], horarios: [], datas: []};
	}

	async load() {
		let agenda = this.#dentist ? await (await fetch("/Agenda/ByDentist?dentista=" + this.#dentist)).json() : [];
		let horarios = await (await fetch("/Horario/")).json();

		this.#getData(agenda, horarios)
	}

	#getData(agendasCadastradas, horarios) {
		let agenda = [];
		let diasSemana = [];
		let domingo = new Date((new Date()).getFullYear(), (new Date()).getMonth(), (new Date()).getDate());

		if ((new Date()).getDay() != 0) {
			domingo.setDate((new Date()).getDate() - (new Date()).getDay());
		}

		for (let i = 0; i <= 6; i++) {
			let diaatual = new Date(domingo.getFullYear(), domingo.getMonth(), domingo.getDate());


			diaatual.setDate(diaatual.getDate() + i);


			diasSemana.push(diaatual.toLocaleDateString());
		}

		for (let r of agendasCadastradas) {
			let dataPartes = r.data.split("-");
			let semana = ["domingo", "segunda", "terca", "quarta", "quinta", "sexta", "sabado"];
			let data = new Date(dataPartes[0], dataPartes[1] - 1, dataPartes[2]);

			if (agenda.some((i) => i.data == data.toLocaleDateString())) {
				let diaIndex = agenda.indexOf(agenda.find((a) => a.data === data.toLocaleDateString()));


				if (!agenda[diaIndex].horarios.some((h) => h.hora === r.horario.hora)) {
					agenda[diaIndex].horarios.push({ agendaId: r.id, hora: r.horario.hora, disponivel: r.disponivel });
				}

				continue;
			}

			
			semana.forEach((d, i) => {
				let aux = {
					dia: d,
					data: diasSemana[i],
					horarios: [],
				};

				if (d === semana[data.getDay()]) aux.horarios.push({ agendaId: r.id, hora: r.horario.hora, disponivel: r.disponivel });

				agenda.push(aux);
			});
		}

		this.#render(diasSemana, agenda, horarios)
	}

	#render(diasSemana, agenda, horarios) {
		let diaInter = 0;
		let templateAgenda = document.getElementById("agenda-template").content.cloneNode(true).querySelector(".agenda");
		this.#elem.querySelector(".agenda-semanas-lista").appendChild(templateAgenda);

		Array.from(this.#elem.querySelectorAll(".agenda-semanas-lista .coluna")).forEach((c) => {
			let diaHorarios = (agenda.length !== 0 ? agenda[diaInter].horarios : []);

			horarios.forEach((horario) => {
				let horarioElemento = document.createElement("div");
				let horarioTexto = document.createElement("span");
				let horarioDisponibilidade = document.createElement("span");
				let data = diasSemana[diaInter];

				horarioElemento.classList.add("hora");

				if (diaHorarios.some((h) => h.hora === horario.hora)) {
					horarioElemento.id = "agenda-" + (diaHorarios.find((h) => h.hora === horario.hora)).agendaId;

					if ((diaHorarios.find((h) => h.hora === horario.hora)).disponivel) horarioElemento.classList.add("disponivel");

					horarioElemento.addEventListener("click", () => {
						if (this.#data.agendas.includes((diaHorarios.find((h) => h.hora === horario.hora)).agendaId)) {
							this.#data.agendas.splice(this.#data.agendas.indexOf((diaHorarios.find((h) => h.hora === horario.hora)).agendaId), 1);
						}
						else {
							this.#data.agendas.push((diaHorarios.find((h) => h.hora === horario.hora)).agendaId);
						}

						horarioElemento.classList.toggle("item-selecionado");
					});
				}
				else {
					horarioElemento.classList.add("unset");

					horarioElemento.addEventListener("click", (event) => {
						this.#data.horarios.push(horario.id);
						this.#data.datas.push(data);

						horarioElemento.classList.toggle("item-selecionado");
					});
				}

				horarioTexto.innerText = horario.hora;

				horarioElemento.appendChild(horarioTexto);
				horarioElemento.appendChild(horarioDisponibilidade);

				c.appendChild(horarioElemento);
			});

			diaInter += 1;
		});

		this.#elem.querySelector(".agenda-semanas-lista .agenda").style.display = "flex";
	}

	getData() {
		return this.#data;
	}

	async postData(dentista = this.#dentist) {
		let formDataAdd = new FormData();
		formDataAdd.append("dentista", dentista);

		this.#data.horarios.forEach((horario, index) => {
			formDataAdd.append('horarios[' + index + ']', horario);
		});

		this.#data.datas.forEach((data, index) => {
			formDataAdd.append('datas[' + index + ']', data);
		});

		let formDataDelete = new FormData();
		formDataDelete.append("dentista", dentista);

		this.#data.agendas.forEach((agenda, index) => {
			formDataDelete.append('agendas[' + index + ']', agenda);
		});



		return new Promise((resolve, reject) => {
			fetch("/Agenda/Create", { method: "post", body: formDataAdd }).then(async (response) => {
				let data = await response.json();

				if (!data.success) {
					resolve([false, "Erro ao adicionar horário"]);
				}
				else {
					fetch("/Agenda/Delete", { method: "post", body: formDataDelete }).then(async (responset) => {
						data = await responset.json();

						if (!data.success) {
							resolve([false, "Erro ao remover horários"]);
						}
						else {
							resolve([true, null]);
						}
					})
				}
			});
		});
	}
}