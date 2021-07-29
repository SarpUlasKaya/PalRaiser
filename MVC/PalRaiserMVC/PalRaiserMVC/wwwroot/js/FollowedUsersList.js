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
            { "data": "receiverId", "width": "10%" },
            { "data": "receiver.userName", "width": "10%" },
            { "data": "receiver.createdAt", "width": "10%" },
            { "data": "receiver.lastLogin", "width": "10%" },
            { "data": "receiver.gender", "width": "10%" },
            { "data": "receiver.birthday", "width": "10%" },
            {
                "data": "receiverId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/AppUsers/ViewProfile?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                View Profile
                            </a>
                            <a href="/followRequests/Unfollow?id=${data}" class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>
                                Unfollow User
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