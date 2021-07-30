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