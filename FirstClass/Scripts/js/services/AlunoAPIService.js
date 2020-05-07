angular.module("formSimulation").factory("alunoAPI", function ($http) {

    var _getProvas = function (idAluno) {
        return $http.get(`/Provas/GetProvas?idAluno=${idAluno}`);
    };

    var _gerarProvas = function () {
        return $http.get("/Provas/GerarProvas");
    };

    return {
        getProvas: _getProvas,
        gerarProvas: _gerarProvas
    };
});