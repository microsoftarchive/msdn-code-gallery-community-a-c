
var employeeInformation;
var currentEmployeeId = 0;
$(document).ready(function (eve) {

    // To load all Employee Management data.
    LoadEmployeeManagement();

    $("#btnAddNew").on("click", function (eve) {
        $("#txtEmployeeId").removeAttr("disabled");
        $("#btnCreate").css({ "display": "inline-block" });
        $("#btnUpdate").css({ "display": "none" });
        restEmployeeForm();
    });

    $("#btnCreate").on("click", function (eve) {
        var address = {
            "StreetName": $("#txtAddress").val() + ' = ' + $("#txtStreet").val(),
            "Country": $("#selectCountry").val(),
            "City": $("#txtCity").val(),
            "PostalCode": $("#txtZipCode").val(),
            "State": $("#txtState").val()
        };

        var empData = {
            "AddressInfo": address,
            "BirthDate": $("#txtDOB").val(),
            "Comments": $("#txtComments").val(),
            "DateHired": $("#txtDOJ").val(),
            "DepartmentID": $("#selectDeptId").val(),
            "Email": $("#txtEmail").val(),
            "EmployeeID": $("#txtEmployeeId").val(),
            "Extension": $("#txtExtension").val(),
            "FirstName": $("#txtFirstName").val(),
            "LastName": $("#txtLastName").val(),
            "SocialSecurityNumber": $("#txtSSN").val(),
            "Title": $("#txtTitle").val(),
            "Voice": $("#txtLastName").val()
        };
        serverCommunication(empData);
    });

    $('#tblEmployee').on('click', '.edit', function (event) {
        $("#btnAddNew").trigger("click");
        EditEmployeeDetails($(this).parent().parent().attr("id"));
    });

    $('#tblEmployee').on('click', '.delete', function (event) {
        currentEmployeeId = $(this).parent().parent().attr("id");
    });

    $("#btnUpdate").on("click", function (eve) {

        var address = {
            "StreetName": $("#txtAddress").val() + ' = ' + $("#txtStreet").val(),
            "Country": $("#selectCountry").val(),
            "City": $("#txtCity").val(),
            "PostalCode": $("#txtZipCode").val(),
            "State": $("#txtState").val()
        };

        var empData = {
            "AddressInfo": address,
            "BirthDate": $("#txtDOB").val(),
            "Comments": $("#txtComments").val(),
            "DateHired": $("#txtDOJ").val(),
            "DepartmentID": $("#selectDeptId").val(),
            "Email": $("#txtEmail").val(),
            "EmployeeID": $("#txtEmployeeId").val(),
            "Extension": $("#txtExtension").val(),
            "FirstName": $("#txtFirstName").val(),
            "LastName": $("#txtLastName").val(),
            "SocialSecurityNumber": $("#txtSSN").val(),
            "Title": $("#txtTitle").val(),
            "Voice": $("#txtLastName").val()
        };
        UpdateEmployeeInformation(empData, $("#txtEmployeeId").val());
    });

    $("#btnConfirmOk").on("click", function (eve) {
        DeleteEmployee(currentEmployeeId)
    });

    /*POST*/
    function serverCommunication(postedData) {
        $.ajax({
            url: '/Home/CreateNewEmployee',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(postedData),
            processData: false,
            cache: false,
            success: function (data) {
                ReloadTableData();
            },
            error: function (xhr) {
                alert('error');
            }
        })
    }

    /*POST*/
    function LoadEmployeeManagement() {
        $.ajax({
            url: '/Home/GetAllEmployeeList',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            processData: false,
            cache: false,
            success: function (data) {
                employeeInformation = data;
                BindEmployeeGrid(data);
            },
            error: function (xhr) {
                alert(JSON.stringify(xhr));
            },
            complete: function (xhr) {

            }
        })
    }

    /*POST*/
    function UpdateEmployeeInformation(putData, empId)
    {
        $.ajax({
            url: '/Home/UpdateEmployee',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ postedEmployee: putData, employeeId: empId }),
            processData: false,
            cache: false,
            success: function (data) {
                ReloadTableData();
            },
            error: function (xhr) {
                alert('error' +JSON.stringify( xhr));
            }
        })
    }

    /*DELETE*/
    function DeleteEmployee(empId)
    {
        $.ajax({
            url: '/Home/DeleteEmployee',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ empId: empId }),
            processData: false,
            cache: false,
            success: function (data) {
                $("#btnConfirmCancel").trigger("click");
                ReloadTableData();
            },
            error: function (xhr) {
                alert('error' + JSON.stringify(xhr));
            }
        });
    }

    function BindEmployeeGrid(employeeCollection) {

        $('#tblEmployee >tbody tr:not(:first)').remove();
        $.each(employeeCollection, function (index, value) {

            var empData = {
                "AddressInfo": value.AddressInfo.StreetName + ', ' + value.AddressInfo.Country + ', ' + value.AddressInfo.City + ', ' + value.AddressInfo.State + ', ' + value.AddressInfo.PostalCode,
                "BirthDate": dateFormatConvertion(new Date(parseInt(value.BirthDate.substr(6)))),
                "Comments": value.Comments,
                "DateHired": dateFormatConvertion(new Date(parseInt(value.DateHired.substr(6)))),
                "DepartmentID": value.DepartmentID,
                "Email": value.Email,
                "EmployeeID": value.EmployeeID,
                "Extension": value.Extension,
                "FirstName": value.FirstName,
                "LastName": value.LastName,
                "RowId": (index + 1),
                "SocialSecurityNumber": value.SocialSecurityNumber,
                "Title": value.Title,
                "Voice": value.Voice
            };

            if ($("#tblEmployee tbody tr").length === 0) {
                $("#tblEmployee tbody").append(EmployeeTableRow(empData));
            } else {
                $("#tblEmployee tbody tr").last().after(EmployeeTableRow(empData));
            }
        });

    }

    function dateFormatConvertion(formattedDate) {
        var d = formattedDate.getDate();
        var m = formattedDate.getMonth();
        m += 1;  // JavaScript months are 0-11
        var y = formattedDate.getFullYear();
        return d + '-' + m + '-' + y;
    }

    function EmployeeTableRow(emplpyeeValue) {

        return '<tr id=' + emplpyeeValue.EmployeeID + '><td>' + emplpyeeValue.RowId + '</td><td>' + emplpyeeValue.EmployeeID + '</td><td>' + emplpyeeValue.FirstName + '</td><td>' + emplpyeeValue.LastName + '</td><td>' + emplpyeeValue.SocialSecurityNumber + '</td><td>' + emplpyeeValue.BirthDate + '</td><td>' + emplpyeeValue.DepartmentID + '</td><td>' + emplpyeeValue.Title + '</td><td>' + emplpyeeValue.DateHired + '</td><td>' + emplpyeeValue.Email + '</td><td>' + emplpyeeValue.Extension + '</td><td>' + emplpyeeValue.AddressInfo + '</td><td>' + emplpyeeValue.Comments + '</td><td> <span class="tblbutton button-orange edit" >Edit</span> <span class="tblbutton button-red delete" data-toggle="modal" data-target="#confirmModel" >Delete</span> </td></tr>';
    }

    function EditEmployeeDetails(empId)
    {
        $("#myModal #modelHeaderBackground").removeClass("modelHeaderAddNew").addClass("modelHeaderUpdate");

        var employeeInformation = findEmployeeinfo(empId);
        var addressInfo = employeeInformation.AddressInfo;

        var tempDate = dateFormatConvertion(new Date(parseInt(employeeInformation.BirthDate.substr(6))));
        var now = new Date(tempDate);
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var dateOfBirth = now.getFullYear() + "-" + (month) + "-" + (day);

        var tempDate = dateFormatConvertion(new Date(parseInt(employeeInformation.DateHired.substr(6))));
        var now = new Date(tempDate);
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var dateOfJoin = now.getFullYear() + "-" + (month) + "-" + (day);

        if (employeeInformation != null && employeeInformation != undefined)
        {
            $("#txtFirstName").val(employeeInformation.FirstName);
            $("#txtLastName").val(employeeInformation.LastName);
            $("#txtSSN").val(employeeInformation.SocialSecurityNumber);
            $('#txtDOB').val(dateOfBirth);
            $("#selectDeptId").val(employeeInformation.DepartmentID);
            $("#txtTitle").val(employeeInformation.Title);
            $("#txtDOJ").val(dateOfJoin);
            $("#txtEmail").val(employeeInformation.Email)
            $("#txtExtension").val(employeeInformation.Extension);
            $("#txtEmployeeId").val(employeeInformation.EmployeeID).attr("disabled", "disabled");
            var streetInfor = addressInfo.StreetName.split("=");
            $("#txtAddress").val(streetInfor[0]);
            $("#txtStreet").val(streetInfor[1]);
            $("#selectCountry").val(addressInfo.Country);
            $("#txtZipCode").val(addressInfo.PostalCode);
            $("#txtState").val(addressInfo.State);
            $("#txtCity").val(addressInfo.City);
            $("#txtComments").val(employeeInformation.Comments);
        }
        $("#btnUpdate").css({ "display": "inline-block" });
        $("#btnCreate").css({ "display": "none" });
    }

    function restEmployeeForm()
    {
        $("#myModal #modelHeaderBackground").removeClass("modelHeaderUpdate").addClass("modelHeaderAddNew");
        $("#txtFirstName, #txtLastName, #txtSSN, #txtTitle, #txtEmail, #txtExtension, #txtEmployeeId, #txtAddress, #txtStreet, #txtZipCode, #txtState, #txtCity ").val("");
        $("#txtDOB, #txtDOJ").val("");
        $("#selectDeptId, #selectCountry").val(0);
    }

    function findEmployeeinfo(empId)
    {
        var empInfo = $.grep(employeeInformation, function (item) {
            return item.EmployeeID == empId;
        });
        if (empInfo != null && empInfo != undefined) {
            return empInfo[0];
        }
    }

    function ReloadTableData()
    {
        $("#btnCancel").trigger("click");
        LoadEmployeeManagement();
    }

});