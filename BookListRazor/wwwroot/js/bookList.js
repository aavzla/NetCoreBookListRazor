//This is the JavaScript to handle the load of the second table at the Index Page in Book Pages

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            //Properties names should be in camel-case. Ex. nameOfBook.
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "30%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    //The link for Edit can be pointed to the Edit page or the Upsert Page (Create and Edit at the same page)
                    return `
                        <div class="text-center">
                            <a href="/Book/Upsert?id=${data}" class='btn btn-success text-white m-1' style='cursor: pointer; width: 70px;'>
                                Edit
                            </a>
                            <a class='btn btn-danger text-white m-1' style='cursor: pointer; width: 70px;' onclick=Delete('/api/book?id='+${data})>
                                Delete
                            </a>
                        </div>
                    `;
                },
                "width" : "20%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    //sweetalert
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
                    }
                    else {
                        tostr.success(data.message);
                    }
                }
            });
        }
    });
}