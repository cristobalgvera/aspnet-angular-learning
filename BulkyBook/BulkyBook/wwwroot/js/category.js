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
                        <a class="btn btn-danger text-white" style="cursor: pointer">
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>
                `
            }
        ]
    });
}