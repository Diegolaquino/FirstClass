angular.module("formSimulation").controller("formSimulationController", function ($scope, $http, simulacaoAPI) {
    $scope.materias = [];
    $scope.incrementarIndice = 1;

    $scope.enviarModelSimulacao = (modelSimulacao) => {
        modelSimulacao.materias = $scope.materias;

        console.log(modelSimulacao);

        simulacaoAPI.postSimulacao(modelSimulacao).then(function sucessCallBack(data) {
            console.log(data);
        }, function errorCallBack(data) {
            console.log(data);
        });
    };

    $scope.addMateria = (materia) => {
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
        let tdNome = createElement('td', null, materia);
        
        tr.appendChild(td);
        tr.appendChild(tdNome);

        $('tbody').append(tr);

        $scope.incrementarIndice++;
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