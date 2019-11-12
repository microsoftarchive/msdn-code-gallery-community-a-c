var isdeleted;
var isedited
function OnSuccess(data) {
    var categoryName = $('#txtProductModelName').val();
    $.validator.unobtrusive.parse($("#addProductModel"));
    if (isdeleted) {
        $('#deleteProductModal').modal('toggle');
    }
    if (isedited) {
        $('#editProductModal').modal('toggle');
    }
    if (categoryName != "") {
       
        $('#txtProductModelName').val('');
        $("#addProductModel").toggle("slow");

    }
    isdeleted = false;
    isedited = false;
}

$(document).delegate("#btnAddProductModel", "click", function () {
    $("#addProductModel").toggle("slow");
});

$(document).on('click', '#edit-model', function () {
    isedited = true;
    var url = "/ProductModel/Edit"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#edit-model-container').html(data);
        $.validator.unobtrusive.parse($("#editForm"));
        $('#editProductModal').modal('show');
    });
});


$(document).on('click', '#details-model', function () {
    var url = "/ProductModel/Details"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#details-model-container').html(data);
        $('#detailsProductModal').modal('show');
    });
});

$(document).on('click', '#delete-model', function () {
    isdeleted = true;
    var url = "/ProductModel/Delete"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#delete-model-container').html(data);
        $('#deleteProductModal').modal('show');
    });
});

//$(document).on('click', '#search-productModel', function () {
//    var url = "/ProductModel/Search"; // the url to the controller
//    var name = $('#txtProductModel').val(); // the id that's given to each button in the list
//    $.get(url + '/' + name, function (data) {
//        $('#tableBody').html(data);
//    });
//});

$(document).on('click', '#search-productModel', function () {
    var name = $('#txtProductModel').val();
    $.ajax({
        url: "/ProductModel/Search",
        data: { name: name },
        //error: function () {
        //    alert(" An error occurred.");
        //},
        success: function (data) {
            $('#tableBody').html(data);
        }
    });
});


$(document).on('click', '#btnRefreshProductModel', function () {
    isdeleted = true;
    var url = "/ProductModel/List"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#tableBody').html(data);
    });
});
