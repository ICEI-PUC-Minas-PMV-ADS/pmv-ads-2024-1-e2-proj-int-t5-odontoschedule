class AgendaComponente {
	#elem;
	#hour_onclick;
	#dentist;

	constructor(dentist, element, hour_onclick=null) {
		this.#elem = element;
		this.#hour_onclick = hour_onclick;
		this.#dentist = dentist;
	}

	async load() {
		let response = await (await fetch("/Agenda/ByDentist?dentista=" + this.#dentist)).json();

		if (response.length === 0) {
			this.#elem.querySelector(".no-dentist-schedule").style.display = "block";
			this.#elem.querySelector(".agenda-semanas-lista").style.display = "none";

			return false;
		}
		else {
			this.#elem.querySelector(".no-dentist-schedule").style.display = "none";
			this.#elem.querySelector(".agenda-semanas-lista").style.display = "block";

			this.#getData(response);

			return true;
		}
	}

	#getData(response) {
		let semanas = [];
		let agenda = [];

		for (let r of response) {
			let dataPartes = r.data.split("-");
			let domingo = new Date(dataPartes[0], dataPartes[1] - 1, dataPartes[2]);
			let diasSemana = [];
			let agendaSemana = [];
			let semana = ["domingo", "segunda", "terca", "quarta", "quinta", "sexta", "sabado"];
			let data = new Date(dataPartes[0], dataPartes[1] - 1, dataPartes[2]);

			if (semanas.some((i) => i.includes(data.toLocaleDateString()))) {
				let semanaIndex = semanas.findIndex((s) => s.indexOf(data.toLocaleDateString()) !== -1);
				let diaIndex = semanas[semanaIndex].indexOf(data.toLocaleDateString());

				if (!agenda[semanaIndex][diaIndex].horarios.some((h) => h.hora === r.horario.hora)) {
					agenda[semanaIndex][diaIndex].horarios.push({ agendaId: r.id, hora: r.horario.hora, disponivel: r.disponivel });
				}

				continue;
			}

			if (data.getDay() != 0) {
				domingo.setDate(data.getDate() - data.getDay());
			}

			for (let i = 0; i <= 6; i++) {
				let diaatual = new Date(domingo.getFullYear(), domingo.getMonth(), domingo.getDate());

				diaatual.setDate(diaatual.getDate() + i);

				diasSemana.push(diaatual.toLocaleDateString());
			}

			semana.forEach((d, i) => {
				let aux = {
					dia: d,
					data: diasSemana[i],
					horarios: [],
				};

				if (d === semana[data.getDay()]) aux.horarios.push({ agendaId: r.id, hora: r.horario.hora, disponivel: r.disponivel });

				agendaSemana.push(aux);
			});

			semanas.push(diasSemana);
			agenda.push(agendaSemana);
			diasSemana = [];
			agendaSemana = [];
		}

		this.#render(agenda)
	}

	#render(agenda) {
		agenda.forEach((semana) => {
			let templateAgenda = document.getElementById("agenda-template").content.cloneNode(true).querySelector(".agenda");
	
			semana.forEach((dia) => {
				dia.horarios.forEach((horario) => {
					let horarioElemento = document.createElement("div");
					let horarioTexto = document.createElement("span");
					let horarioDisponibilidade = document.createElement("span");
	
					horarioElemento.classList.add("hora");
					horarioElemento.id = "agenda-" + horario.agendaId;
					if (horario.disponivel) horarioElemento.classList.add("disponivel");

					if (this.#hour_onclick) {
						horarioElemento.addEventListener("click", () => this.#hour_onclick({ data: dia.data, horario: horario }));
					}
	
					horarioTexto.innerText = horario.hora;
	
					horarioElemento.appendChild(horarioTexto);
					horarioElemento.appendChild(horarioDisponibilidade);
	
					templateAgenda.querySelector(`.coluna-${dia.dia}`).appendChild(horarioElemento);
				});
			});
	
			this.#elem.querySelector(".agenda-semanas-lista").appendChild(templateAgenda);
		});
	}
}