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