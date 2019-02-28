
angular.module('Angularapp').service('DepartmentService', function ($http) {

    this.saveDeptInfo = function (objDeptView) {
        var request = $http.post("/api/Department/SaveDepartment", objDeptView);
        return request;
    }

    this.GetDepartmentData = function () {
        var request = $http.get("/api/Department/GetDisplayDepartmentData");
        return request;
    }

    this.EditDeptDataOnId = function (GetId) {
        var request = $http.get("/api/Department/GetEditDeptData?Id=" + GetId);
        return request;
    }

    this.DeleteDepartmentOnId = function (GetId) {
        var request = $http.get("/api/Employee/DeleteDepartmentOnId?Id=" + GetId);
        return request;
    }

});