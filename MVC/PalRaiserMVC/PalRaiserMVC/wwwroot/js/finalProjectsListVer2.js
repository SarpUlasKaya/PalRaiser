var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/projects/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "projName", "width": "10%" },
            { "data": "type", "width": "10%" },
            { "data": "amountRaised", "width": "10%" },
            { "data": "likeCount", "width": "10%" },
            { "data": "dislikeCount", "width": "10%" },
            { "data": "reportCount", "width": "10%" },
            {
                "data": "projectId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Projects/ViewProj?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                View Project
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