angular.module('formSimulation').controller("formSimulationController", function ($scope, $http) {

    $scope.enviarModelSimulacao = (modelSimulacao) => {
        console.log(modelSimulacao);
    };

    $scope.mensagem = "";

    $scope.init = () => {
        $scope.mensagem = "Teste";
    };

    $scope.init();

});