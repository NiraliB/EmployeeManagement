angular.module('Angularapp').service('EmployeeService', function ($http) {

    this.GetDeptNameList = function () {
        var request = $http.get("/api/Employee/GetDepartmentNameListDDL");
        return request;
    }

    this.saveEmployeeInfo = function (objEmpView) {
        var request = $http.post("/api/Employee/SaveEmployeeData", objEmpView);
        return request;
    }

    this.GetEmployeeDataLoad = function () {
        var request = $http.get("/api/Employee/GetEmployeeDataOnLoad");
        return request;
    }

    this.EditEmpDataOnId = function (GetId) {
        var request = $http.get("/api/Employee/GetEmployeeRecordOnId?Id=" + GetId);
        return request;
    }

    this.DeleteEmployeeOnId = function (GetId) {
        var request = $http.get("/api/Employee/DeleteEmployeeOnId?Id=" + GetId);
        return request;
    }
});