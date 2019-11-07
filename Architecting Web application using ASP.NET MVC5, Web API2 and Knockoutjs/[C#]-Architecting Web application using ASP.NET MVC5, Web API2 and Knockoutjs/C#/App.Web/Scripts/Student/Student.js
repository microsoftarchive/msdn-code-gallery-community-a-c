$(document).ready(function () {
    
    InitializestudentViewModel();
});

function StudentViewModel() {
    
    this.StudentID = ko.observable("");
    this.FirstName = ko.observable("");
    this.LastName = ko.observable("");
    this.Remarks = ko.observable("");
    this.DateOfBirth = ko.observable("");
    this.CountryLookup = GetCountryLookup();
    this.SelectedGender = ko.observable("");
    this.SelectedCountry = ko.observable();

    
    this.PaymentMethods = ko.observableArray([
		        		{ name: "Credit Card", id: 1, isChecked: false },
				        { name: "Cash", id: 2, isChecked: false },
         { name: "Bank Transfer", id: 3, isChecked: false }
    ]);
    
    this.SelectedPaymentMethods = ko.observableArray([]);
    
    this.CreateStudent = function () {
        CreateStudent();
    };
}

//Load country
function GetCountryLookup() {
    var countries = ko.observableArray([{ CountryId: 0, CountryName: 'Select Country' }]);
    $.getJSON("/api/students/allcountries", function(result) {
        ko.utils.arrayMap(result, function(item) {
            countries.push({ CountryId: item.CountryId, CountryName: item.CountryName });
        });
    });
    return countries;
}


function InitializestudentViewModel() {

    studentViewModel = new StudentViewModel();
    ko.applyBindings(studentViewModel);
   
    studentViewModel.StudentID(studentD);
}

function CreateStudent() {
    AppCommonScript.ShowWaitBlock();
    var student = new InitializeStudent();
    
    $.ajax({
        type: "POST",
        url: "/api/students/create",
        data: $.parseJSON(ko.toJSON(student)),
        dataType: "json",
        success: function (response) {
            Successed(response);
        },
        error: function(jqxhr) {
            Failed(JSON.parse(jqxhr.responseText));
        }
    });
}

function Successed(response) {
    AppCommonScript.HideWaitBlock();
    AppCommonScript.showNotify(response);
}

function Failed(response) {
    AppCommonScript.HideWaitBlock();
    AppCommonScript.showNotify(response);
}

function InitializeStudent() {
    
    var student = new function () { };
    if (studentViewModel.StudentID() != "") {
        student.StudentID = studentViewModel.StudentID();
    }

    student.FirstName = studentViewModel.FirstName();
    student.LastName = studentViewModel.LastName();
    student.Remarks = studentViewModel.Remarks();
    student.DateOfBirth = studentViewModel.DateOfBirth();
    student.SelectedGender = studentViewModel.SelectedGender();
    student.CountryId = studentViewModel.SelectedCountry();
    student.SelectedPaymentMethods = studentViewModel.SelectedPaymentMethods;

    return student;
}
