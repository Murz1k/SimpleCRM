var app = angular.module("app", []);
app.controller("ClientController", function ($scope) {
    $scope.Refresh = function () {
        $scope.clearClient();
        $.ajax({
            url: "/Client/GetAllClients",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            success: function (clients) {
                $scope.clients = clients;
                $.ajax({
                    url: "/Client/GetAllGenders",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json",
                    success: function (genders) {
                        $scope.genders = genders;
                        $scope.$apply();
                    }
                });
            }
        });
    };
    $scope.chooseClient = function (client) {
        $scope.currentClient = {
            Id: client.Id,
            FirstName: client.FirstName,
            Age: client.Age,
            LastName: client.LastName,
            Gender: client.Gender,
            City: client.City
        };
    }
    $scope.GetGender = function (id) {
        var sex = "";
        $.ajax({
            async: false,
            url: "/Client/GetGender",
            type: "post",
            data: { id: id },
            dataType: "html",
            success: function (gender) {
                sex = gender;
            }
        });
        return sex;
    };
    $scope.clearClient = function () {
        $scope.currentClient = {
            Id: -1
        };
    };
    $scope.addClient = function () {
        if ($scope.currentClient.FirstName == null) {
            alert("Выберите имя.");
            return 0;
        }
        if ($scope.currentClient.LastName == null) {
            alert("Выберите фамилию.");
            return 0;
        }
        if ($scope.currentClient.Age == null) {
            alert("Выберите возраст.");
            return 0;
        }
        if ($scope.currentClient.City == null) {
            alert("Выберите город.");
            return 0;
        }
        $.ajax({
            url: "/Client/AddClient",
            data: { client: $scope.currentClient },
            type: "post",
            dataType: "html",
            success: function () {
                $scope.Refresh();
            }
        });
    };
    $scope.editClient = function () {
        if ($scope.currentClient.Id < 0) {
            alert("Выберите клиента.");
            return 0;
        }
        $.ajax({
            url: "/Client/EditClient",
            data: { id: $scope.currentClient.Id, client: $scope.currentClient },
            type: "post",
            dataType: "html",
            success: function () {
                $scope.Refresh();
            }
        });
    };
    $scope.deleteClient = function () {
        if ($scope.currentClient.Id < 0) {
            alert("Выберите клиента.");
            return 0;
        }
        $.ajax({
            url: "/Client/DeleteClient",
            data: { id: $scope.currentClient.Id },
            type: "post",
            dataType: "html",
            success: function () {
                $scope.Refresh();
            }
        });
    };
});