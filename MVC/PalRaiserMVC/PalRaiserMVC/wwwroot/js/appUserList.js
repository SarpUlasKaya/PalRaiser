var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/appUsers/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "userName", "width": "12%" },
            { "data": "createdAt", "width": "12%" },
            { "data": "lastLogin", "width": "12%" },
            { "data": "gender", "width": "12%" },
            { "data": "birthday", "width": "12%" },
            {
                "data": "projectId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Projects/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                View Profile
                            </a>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//function Delete(url) {
//    swal({
//        title: "Are you sure?",
//        text: "Once deleted, you will not be able to recover",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true
//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: "DELETE",
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    } else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}