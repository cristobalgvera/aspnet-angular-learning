﻿let dataTable;

$(document).ready(() => loadDataTable());

function loadDataTable() {
    const baseDir = location.pathname;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `${baseDir}/GetAll`
        },
        "columns": [
            {"data": "name", "width": "67%"},
            {
                "data": "id",
                "width": "33%",
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

const deleteThis = async (url) => {
    const {isConfirmed} = await Swal.fire({
        title: "Are you sure you want to delete this?",
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