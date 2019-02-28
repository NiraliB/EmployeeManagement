
angular.module('Angularapp').controller('DeptController', function ($scope, DepartmentService) {
    setTimeout(function () {
        GetDepartmentDataLoad();
    }, 0);

    $scope.Department = {};
    $scope.dispDeptTableData = {};
    $scope.dispDeptInfo = true;

    $scope.btnAddNewDept = function () {
        $scope.dispDeptInfo = false;
        clearData();
    }

    $scope.btnShowList = function () {
        $scope.dispDeptInfo = true;
        GetDepartmentDataLoad();
    }

    $scope.btnSaveDeptInfo = function () {
        if (ValidateDepartment()) {
            DepartmentService.saveDeptInfo($scope.Department).then(function (deptData) {
                if (deptData.data.Message == "SavedSuccessfully") {
                    alert("Data Saved Successfully");
                    $scope.dispDeptInfo = true;
                    GetDepartmentDataLoad();
                    clearData();
                }

            }, function (error) {
                alert(error);
            });
        }
    }

    function clearData() {
        $scope.Department = {};
        ClearMessage($("#txtDeptName"));
    }

    function GetDepartmentDataLoad() {
        DepartmentService.GetDepartmentData().then(function (deptData) {
            if (deptData.data != null) {
                $scope.dispDeptTableData = deptData.data;
            }

        });
    }

    $scope.GetEditDeptDataOnId = function (GetId) {
        DepartmentService.EditDeptDataOnId(GetId).then(function (deptData) {
            if (deptData.data != null) {
                $scope.dispDeptInfo = false;
                $scope.Department = deptData.data;

            }
        });
    }

    $scope.DeleteDeptOnId = function (GetId) {
        DepartmentService.DeleteDepartmentOnId(GetId).then(function (p1) {
            if (p1.data == "Deleted") {
                GetDepartmentDataLoad();
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

    function ValidateDepartment() {
        var flag = true;
        if (!ValidationRequired($("#txtDeptName"), "Department Name required", 'after')) {
            flag = false;
        }
        return flag;
    }

});