let dataTable;

$(document).ready(() => {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            {"data": "name", "width": "60%"},
            {
                "data": "id",
                "width": "40%",
                "render": (id) => `
                    <div class="text-center">
                        <a href="/Admin/Category/Upsert/${id}" class="btn btn-success text-white" style="cursor: pointer">
                            <i class="fas fa-edit"></i>
                        </a>
                        <a onclick="deleteCategory('/Admin/Category/Delete/${id}')" class="btn btn-danger text-white" style="cursor: pointer">
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>
                `
            }
        ]
    });
}

const deleteCategory = async (url) => {
    const {isConfirmed} = await Swal.fire({
        title: "Are you sure you want to delete this category?",
        text: "You will not be able to restore the data",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "red",
    });

    if (!isConfirmed) return;

    $.ajax({
        type: 'DELETE',
        url: url,
        success: ({success, message}) => {
            if (success) {
                toastr.success(message);
                dataTable.ajax.reload();
            } else toastr.error(message);
        }
    })
}