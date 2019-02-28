
angular.module('Angularapp').controller('EmployeeController', function ($scope, EmployeeService) {
    $scope.Employee = {};
    $scope.DepartmentNameList = {};
    $scope.EmpDispLoadData = {};
    $scope.dispEmpInfo = true;
    GetDepartmentNameLoadDDL();
    setTimeout(function () {
        GetEmployeeListLoad();
    }, 0);


    $scope.btnAddNewEmp = function () {
        $scope.dispEmpInfo = false;
        clearData();
    }

    $scope.btnShowList = function () {
        $scope.dispEmpInfo = true;
        GetEmployeeListLoad();
    }

    $scope.btnSaveEmpInfo = function () {
        if (ValidateEmployees()) {
            EmployeeService.saveEmployeeInfo($scope.Employee).then(function (p1) {
                if (p1.data.Message == "SavedSuccessfully") {
                    alert("Data Saved Successfully");
                    $scope.dispEmpInfo = true;
                    GetEmployeeListLoad();
                    clearData();
                }

            }, function (error) {
                alert(error);
            });
        }
    }

    $scope.GetEditEmpDataOnId = function (GetEmpId) {
        EmployeeService.EditEmpDataOnId(GetEmpId).then(function (p1) {
            if (p1.data != null) {
                $scope.dispEmpInfo = false;
                $scope.Employee = p1.data;
            }
        });
    }

    $scope.DeleteEmpOnId = function (EmpId) {
        EmployeeService.DeleteEmployeeOnId(EmpId).then(function (p1) {
            if (p1.data == "Deleted") {
                GetEmployeeListLoad();
                clearData();
                alert("Record deleted successfully");
            }
            else if (p1.data = "NotDeleted") {
                alert("Something is wrong!");
            }

        }, function (error) {
            alert(error);
        });
    }

    function GetDepartmentNameLoadDDL() {
        EmployeeService.GetDeptNameList().then(function (p1) {
            if (p1.data != null) {
                $scope.DepartmentNameList = p1.data;
            }
        });
    }

    function GetEmployeeListLoad() {
        EmployeeService.GetEmployeeDataLoad().then(function (p1) {
            if (p1.data != null) {
                $scope.EmpDispLoadData = p1.data;
            }
        });
    }

    function clearData() {
        $scope.Employee = {};
        ClearMessage($("#txtEmpName"));
        ClearMessage($("#txtEmpSurName"));
        ClearMessage($("#txtEmpAddress"));
        ClearMessage($("#txtQualification"));
        ClearMessage($("#txtContactNumber"));
        ClearMessage($("#ddlDeptId"));
    }

    function ValidateEmployees() {
        var flag = true;
        if (!ValidationRequired($("#txtEmpName"), "Employee Name required", 'after')) {
            flag = false;
        }
        if (!ValidationRequired($("#txtEmpSurName"), "Surname is required", 'after')) {
            flag = false;
        }
        if (!ValidationRequired($("#txtEmpAddress"), "Address is required", 'after')) {
            flag = false;
        }
        if (!ValidationRequired($("#txtQualification"), "Qualification is required", 'after')) {
            flag = false;
        }
        if (!ValidationRequired($("#txtContactNumber"), "ContactNo is  required", 'after')) {
            flag = false;
        }
        if (!ValidationRequired($("#ddlDeptId"), "Please select department", 'after')) {
            flag = false;
        }

        return flag;
    }

});