var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/followRequests/getFollowers/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "sender.userName", "width": "12%" },
            { "data": "sender.createdAt", "width": "12%" },
            { "data": "sender.lastLogin", "width": "12%" },
            { "data": "sender.gender", "width": "12%" },
            {
                "data": "senderId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/AppUsers/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:130px;'>
                                View Profile
                            </a>
                            <a href="/followRequests/DenyOrRemoveFollower?id=${data}" class='btn btn-danger text-white' style='cursor:pointer; width:130px;'>
                                Remove Follower
                            </a>`;
                }, "width": "52%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}