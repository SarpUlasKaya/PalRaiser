var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/followRequests/getFollowedUsers/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "receiver.userName", "width": "12%" },
            { "data": "receiver.createdAt", "width": "12%" },
            { "data": "receiver.lastLogin", "width": "12%" },
            { "data": "receiver.gender", "width": "12%" },
            {
                "data": "receiverId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/AppUsers/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:130px;'>
                                View Profile
                            </a>
                            <a href="/followRequests/Unfollow?id=${data}" class='btn btn-danger text-white' style='cursor:pointer; width:130px;'>
                                Unfollow User
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