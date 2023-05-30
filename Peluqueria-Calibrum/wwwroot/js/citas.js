function eliminar(id) {
    if (confirm("¿Está seguro que desea eliminar esta cita?")) {
    $.ajax({
        url: "/Citas/DeleteCitas",
        type: "DELETE",
        data: { id: id },
        success: function (data) {
            // Actualizar la vista después de eliminar el elemento
            location.reload();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
    }
}