angular.module('formSimulation').controller("formSimulationController", function ($scope, $http) {
    $scope.materias = [];
    $scope.incrementarIndice = 1;

    $scope.enviarModelSimulacao = (modelSimulacao) => {
        
    };

    $scope.addMateria = (materia) => {
        $scope.materias.push(materia);
        $scope.inserirNaTabela(materia);
    };

    $scope.removeMateria = () => {
        if ($scope.materias.length > 0) {
            $scope.materias.pop();
            $scope.incrementarIndice;
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