var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/appUsers/getUserProjects/",
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
                            <a href="/Projects/UpsertProj?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a  class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                                onclick=Delete('/projects/Delete?id='+${data})>
                                Delete
                            </a>
                           </div>`;
                }, "width": "40%"
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