angular.module("formSimulation").factory("simulacaoAPI", function ($http) {

    var _postSimulacao = function (modelSimulacao) {
        return $http.post("/simulacao/Create", modelSimulacao, "application/json");
    };

    return {
        postSimulacao: _postSimulacao
    };
});