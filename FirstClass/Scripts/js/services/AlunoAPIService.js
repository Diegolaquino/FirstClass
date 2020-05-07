angular.module("formSimulation").factory("alunoAPI", function ($http) {

    var _getProvas = function (idAluno) {
        return $http.get(`/Provas/GetProvas?idAluno=${idAluno}`);
    };

    return {
        getProvas: _getProvas
    };
});