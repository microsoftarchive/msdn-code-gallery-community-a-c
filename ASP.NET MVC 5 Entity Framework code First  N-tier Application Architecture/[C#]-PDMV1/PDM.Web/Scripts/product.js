var isdeleted;
function OnSuccess(data) {
    if (isdeleted) {
        $('#deleteProductModal').modal('toggle');
    }
    isdeleted = false;
}

//$(function () {
//    $(".datepicker").datepicker(
//        {
//            format: "dd/mm/yyyy",
//            autoclose: true
//        });
//});

$(document).on('change', '.ProductCategoryid', function () {
    var id = $('.ProductCategoryid :selected').val();
    $('.ddlSubcategory').html('');
    $.ajax({
        url: "/Product/GetSubCategory",
        data: { selectedValue: id },
        dataType: "json",
        error: function () {
            alert(" An error occurred.");
        },
        success: function (data) {
            $.each(data, function (i) {
                var optionhtml = '<option value="' + data[i].ProductSubCategoryID + '">' + data[i].Name + '</option>';
                $(".ddlSubcategory").append(optionhtml);
            });
        }
    });
});

$(document).on('click', '#delete-product', function () {
    isdeleted = true;
    var url = "/Product/Delete"; // the url to the controller
    var id = $(this).attr('data-id'); // the id that's given to each button in the list
    $.get(url + '/' + id, function (data) {
        $('#delete-product-container').html(data);
        $('#deleteProductModal').modal('show');
    });
});


//$(document).ready(function () {
//    $("#productAutoComplete").autocomplete({
//        source: function (request, response) {
//            $.ajax({
//                url: "/Product/Search",
//                type: "POST",
//                dataType: "json",
//                data: { name: request.term },
//                success: function (data) {
//                    response($.map(data, function (item) {
//                        return { label: item.Name, value: item.Name };
//                    }))

//                }
//            })
//        },
//        messages: {
//            noResults: "", results: ""
//        }
//    });
//})

//$("#SearchInput").autocomplete({
//    source: function (request, response) {
//        $.ajax({
//            url: "http://servername/index.pl",
//            dataType: "json",
//            data: {
//                term: request.term
//            }
//        }
//).data("autocomplete")._renderItem = function (ul, item) {
//    return $("<li></li>")
//        .data("item.autocomplete", item)
//        .append("<a>" + "<img src='" + item.imgsrc + "' />" + item.id + " - " + item.label + "</a>")
//        .appendTo(ul);
//}
//    }
//});

