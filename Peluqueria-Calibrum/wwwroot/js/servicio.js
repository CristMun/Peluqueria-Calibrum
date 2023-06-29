// Método eliminar servicio
function eliminar(id) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar este Servicio?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Servicio/DeleteServicios",
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

function cargarServicios(id) {
    $.ajax({
        url: "/Servicio/GetServiciosEdit",
        type: "GET",
        data: { id: id },
        success: function (data) {

            $("#nombre").val(data.nombre);
            $("#descripcion").val(data.descripcion);
            $("#precio").val(data.precio);
            // Seleccionar la opción de categoría correspondiente
            if (data.categoria === "Peluquero") {
                $("#peluquero").prop("checked", true);
            } else if (data.categoria === "Barbero") {
                $("#barbero").prop("checked", true);
            }
            // Seleccionar la opción de mostrar_home correspondiente
            if (data.mostrar_home === 1) {
                $("#1").prop("checked", true);
            } else if (data.mostrar_home === 0) {
                $("#2").prop("checked", true);
            }


            $("#formEditarServicio").attr("action", "/Servicio/UpdateServicio?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}