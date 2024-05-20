const meses = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
var chartByModality;
var chartPatientsByMonth;


function renderizaGraficos() {
    graficoPorModalidade();
    graficoPacientePorMes();
}


async function graficoPacientePorMes() {
    let dados = await (await fetch("/Paciente/GetCountByMonth")).json();
    let grafico_dados = new Array(12).fill(0);

    for (let mes in dados) grafico_dados[mes - 1] = dados[mes]; 

    const config = {
        type: 'bar',
        data: {
            labels: meses,
            datasets: [{
                data: grafico_dados,
                backgroundColor: '#54BCFF'
            }]
        },
        options: {
            plugins: {
                legend: {
                    display: false,
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        precision: 0,
                        min: 10
                    }
                }
            }
        },
    };

    chartPatientsByMonth = new Chart(document.getElementById("grafico-pacientes-por-mes"), config);
}

async function graficoPorModalidade() {
    let dados = await (await fetch("/Atendimento/GetCountByModality")).json();
    const config = {
        type: 'pie',
        data: {
            labels: [
                'Particular',
                'Convênio'
            ],
            datasets: [{
                label: 'Modalidade',
                data: [dados.convenio, dados.particular],
                backgroundColor: [
                    '#54BCFF',
                    '#A7E3FC'
                ],
                hoverOffset: 4
            }]
        }
    };

    chartByModality = new Chart(document.getElementById("grafico-por-modalidade"), config);
}


document.addEventListener("DOMContentLoaded", () => {
    renderizaGraficos();
});