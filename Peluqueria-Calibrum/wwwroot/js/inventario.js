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

function guardar() {

    Swal.fire({
        icon: 'success',
        title: '¡Creado!',
        text: 'El empleado ha sido creado con éxito',
        showConfirmButton: false,
        timer: 1000
    });

    // Devuelve true para enviar el formulario
    return true;
}

function modificar() {
    // Realizar la petición al servidor para actualizar el empleado
    // Aquí debes implementar el código necesario para enviar la solicitud al servidor

    // Mostrar SweetAlert cuando la petición se haya completado exitosamente
    Swal.fire({
        icon: 'success',
        title: 'Actualizado',
        text: 'El empleado ha sido modificado correctamente.',
        confirmButtonText: 'OK',// Personalizar el texto del botón de confirmación
        confirmButtonColor: '#3085d6',
        timer: 1000
    });

    return true; // Permitir el envío del formulario
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