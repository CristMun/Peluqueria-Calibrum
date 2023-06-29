// Método eliminar Objeto inventario
function eliminar(id) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar este elemento?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Inventario/DeleteInventario",
                type: "DELETE",
                data: { id: id },
                success: function (data) {
                    Swal.fire('¡Eliminado!', 'El elemento ha sido eliminado con éxito', 'success').then(() => {
                        location.reload();
                    });
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(xhr.responseText);
                }
            });
        }
    });
}

function cargarInventario(id) {
    $.ajax({
        url: "/Inventario/GetInventarioEdit",
        type: "GET",
        data: { id: id },
        success: function (data) {

            //$("#imagen").val(data.imagen);
            $("#nombre").val(data.nombre);
            $("#descripcion").val(data.descripcion);
            $("#cantidad").val(data.cantidad);

            $("#formEditarInventario").attr("action", "/Inventario/UpdateInventario?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}