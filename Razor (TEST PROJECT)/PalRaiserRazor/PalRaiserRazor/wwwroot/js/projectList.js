var dataTable;

$(document).ready(function() {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Project",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "projName", "width": "9%" },
            { "data": "summary", "width": "9%" },
            { "data": "detailedInfo", "width": "9%" },
            { "data": "type", "width": "9%" },
            { "data": "amountRaised", "width": "9%" },
            { "data": "likeCount", "width": "9%" },
            { "data": "dislikeCount", "width": "9%" },
            { "data": "reportCount", "width": "9%" },
            { "data": "testValue", "width": "9%" },
            {
                "data": "projId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/ProjectList/UpsertProj?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a  class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                                onclick=Delete('/api/Project?id='+${data})>
                                Delete
                            </a>
                           </div>`;
                }, "width": "19%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}