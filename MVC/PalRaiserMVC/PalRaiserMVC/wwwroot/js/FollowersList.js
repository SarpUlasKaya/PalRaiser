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
            { "data": "senderId", "width": "10%" },
            { "data": "sender.userName", "width": "10%" },
            { "data": "sender.createdAt", "width": "10%" },
            { "data": "sender.lastLogin", "width": "10%" },
            { "data": "sender.gender", "width": "10%" },
            { "data": "sender.birthday", "width": "10%" },
            {
                "data": "senderId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/AppUsers/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                View Profile
                            </a>
                            <a href="/followRequests/DenyOrRemoveFollower?id=${data}" class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>
                                Remove Follower
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