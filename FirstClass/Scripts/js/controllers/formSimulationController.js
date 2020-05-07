angular.module("formSimulation").controller("formSimulationController", function ($scope, simulacaoAPI, $window, alunoAPI) {
    $scope.materias = [];
    $scope.provas = {};
    $scope.incrementarIndice = 1;

    $scope.enviarModelSimulacao = (modelSimulacao) => {
        modelSimulacao.materias = $scope.materias;

        console.log(modelSimulacao);

        simulacaoAPI.postSimulacao(modelSimulacao).then(function sucessCallBack(data) {
            console.log(data);
            $window.location.href = "/home/index";
        }, function errorCallBack(data) {
            console.log(data);
        });
    };

    $scope.addMateria = (nome, peso1, peso2, peso3) => {

        let materia = materiaFactory(nome, peso1, peso2, peso3);
        $scope.materias.push(materia);
        $scope.inserirNaTabela(materia);
    };

    $scope.removeMateria = () => {
        if ($scope.materias.length > 0) {
            $scope.materias.pop();
            $scope.incrementarIndice--;
        }

        $('tbody tr:last-child').remove();
    };

    $scope.inserirNaTabela = (materia) => {

        let tr = createElement('tr', null, null);
        let idAttribute = createAttribute('id', $scope.incrementarIndice);
        tr.attributes.setNamedItem(idAttribute);

        let td = createElement('td', null, $scope.incrementarIndice);
        let tdNome = createElement('td', null, materia.nome);
        let tdPeso1 = createElement('td', null, materia.peso1);
        let tdPeso2 = createElement('td', null, materia.peso2);
        let tdPeso3 = createElement('td', null, materia.peso3);

        
        tr.appendChild(td);
        tr.appendChild(tdNome);
        tr.appendChild(tdPeso1);
        tr.appendChild(tdPeso2);
        tr.appendChild(tdPeso3);

        $('tbody').append(tr);

        $scope.incrementarIndice++;
    };

    $scope.gerarProvas = () => {
        alunoAPI.gerarProvas().then(function sucessCallBack(response) {
            console.log(response);
        }, function errorCallBack(response) {
            console.log(response);
        });
    };

    $scope.pegarProvas = (idAluno) => {
        alunoAPI.getProvas(idAluno).then(function sucessCallBack(response) {
           
            $scope.provas = mapeandoProvasENotas(response.data.provasModel);

            console.log($scope.provas);

        }, function errorCallBack(data) {
            console.log(data);
        });
    };

    $scope.canSend = () => {
        return $scope.materias.length > 0;
    };

    var materiaFactory = (nome, peso1, peso2, peso3) => {
        let materia = {};

        materia.nome = nome;
        materia.peso1 = peso1;
        materia.peso2 = peso2;
        materia.peso3 = peso3;

        return materia;
    };

    var bimestreFactory = (materia) => {
        let bimestre = {};

        bimestre.materia = materia;
        bimestre.notas = [];

        return bimestre;
    };

    var mapeandoProvasENotas = (arrayProvas) => {
        var elements = arrayProvas.map((el) => { return el.Materia; });

        let setMaterias = new Set(elements);

        let arrayMaterias = Array.from(setMaterias);

        let bimestres = [];

        for (let i = 0; i < arrayMaterias.length; i++) {
            
            bimestres.push(bimestreFactory(arrayMaterias[i]));
        }

        for (let i = 0; i < bimestres.length; i++) {
            let values = arrayProvas.filter(x => x.Materia === bimestres[i].materia);
            bimestres[i].notas = values;
        }

        return bimestres;
    };

    var createElement = (name, classList, text = null) => {
        let element = document.createElement(name);

        if (classList !== null) {
            for (let i = 0; i < classList.length; i++) {
                element.classList.add(classList[i]);
            }
        }

        if (text !== null) {
            element.innerText = text;
        }

        return element;
    };

    var createAttribute = (name, value) => {
        let attribute = document.createAttribute(name);

        if (value !== null)
            attribute.value = value;

        return attribute;
    };

    $scope.mensagem = "";

    $scope.init = () => {
        $scope.mensagem = "Teste";
    };

    $scope.init();

});