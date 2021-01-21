let dataTable

$(document).ready(() => {
    loadDataTable()
})

function loadDataTable() {
    dataTable = $("#DT_load").DataTable({
        "ajax": {
            "url": "api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {"data": "name", "width": "20%"},
            {"data": "author", "width": "20%"},
            {"data": "isbn", "width": "20%"},
            {
                "data": "id",
                "width": "20%",
                "render": (data) =>
                    `<div class="text-center">
                        <a href="/BookList/Upsert?id=${data}" class="btn btn-success text-white" style="cursor: pointer; width: 70px">
                            Edit
                        </a>
                        &nbsp;
                        <a onclick="deleteOne('api/book?id=${data}')" class="btn btn-danger text-white" style="cursor: pointer; width: 70px">
                            Delete
                        </a>
                    </div>`
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    })
}

function deleteOne(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover it",
        icon: "warning",
        showCancelButton: true
    }).then(respond => {
        if (respond.isConfirmed) {
            $.ajax({
                url,
                type: "DELETE",
                success: ({success, message}) => {
                    if (success) {
                        toastr.success(message)
                        dataTable.ajax.reload()
                    } else toastr.error(message)
                }
            })
        }
    })
}