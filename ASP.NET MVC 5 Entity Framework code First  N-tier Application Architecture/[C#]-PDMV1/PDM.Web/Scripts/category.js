
var isdeleted;
var isedited;

function OnSuccess(data) {
    if (isdeleted) {
        $('#deleteCategoryModal').modal('toggle');
    }
    if (isedited) {
        $('#editCategoryModal').modal('toggle');
    }
    var categoryName = $('#txtProductCategoryName').val();
    $.validator.unobtrusive.parse($("#addCategory"));
    if (categoryName != "") {
        $('#txtProductCategoryName').val('');
        $("#addCategory").toggle("slow");
    }
    isdeleted = false;
    isedited = false;
}

$(document).delegate("#btnAddCategory", "click", function () {
    $("#addCategory").toggle("slow");
});

$(document).on('click', '#edit-category', function () {
    isedited = true;
    var url = "/ProductCategory/Edit"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#edit-category-container').html(data);
        $.validator.unobtrusive.parse($("#editCategoryForm"));
        $('#editCategoryModal').modal('show');
    });
});


$(document).on('click', '#details-category', function () {

    var url = "/ProductCategory/Details"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#details-category-container').html(data);
        $('#detailsCategoryModal').modal('show');
    });
});

$(document).on('click', '#delete-category', function () {
    isdeleted = true;
    var url = "/ProductCategory/Delete"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#delete-category-container').html(data);
        $('#deleteCategoryModal').modal('show');
    });
});


$(document).on('click', '#search-category', function () {
    var name = $('#SearchCategory').val();
    $.ajax({
        url: "/ProductCategory/Search",
        data: { name: name },
        //error: function () {
        //    alert(" An error occurred.");
        //},
        success: function (data) {
            $('#tableBody').html(data);
        }
    });
});

$(document).on('click', '#btnrefreshCategory', function () {
    isdeleted = true;
    var url = "/ProductCategory/List"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#tableBody').html(data);
    });
});
