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
            { "data": "userName", "width": "15%" },
            { "data": "createdAt", "width": "15%" },
            { "data": "lastLogin", "width": "15%" },
            { "data": "gender", "width": "15%" },
            {
                "data": "userId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/AppUsers/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:200px;'>
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