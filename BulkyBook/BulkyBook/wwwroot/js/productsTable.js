let dataTable;

$(document).ready(() => loadDataTable());

function loadDataTable() {
    const baseDir = location.pathname;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `${baseDir}/GetAll`
        },
        "columns": [
            {"data": "title", "width": "15%"},
            {"data": "isbn", "width": "15%"},
            {"data": "price", "width": "15%"},
            {"data": "author", "width": "15%"},
            {"data": "category.name", "width": "15%"},
            {
                "data": "id",
                "width": "25%",
                "render": (id) => `
                    <div class="text-center">
                        <a href="${baseDir}/Upsert/${id}" class="btn btn-success text-white" style="cursor: pointer">
                            <i class="fas fa-edit"></i>
                        </a>
                        <a onclick="deleteThis('${baseDir}/Delete/${id}')" class="btn btn-danger text-white" style="cursor: pointer">
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>
                `
            }
        ]
    });
}