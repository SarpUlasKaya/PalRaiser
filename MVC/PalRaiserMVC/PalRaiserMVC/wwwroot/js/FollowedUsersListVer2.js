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
            { "data": "receiver.userName", "width": "10%" },
            { "data": "receiver.createdAt", "width": "10%" },
            { "data": "receiver.lastLogin", "width": "10%" },
            { "data": "receiver.gender", "width": "10%" },
            { "data": "receiver.birthday", "width": "10%" },
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
                }, "width": "50%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}