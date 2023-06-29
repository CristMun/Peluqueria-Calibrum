//Metodo para mostrar el elemento seleccionado -->
function cargarEmpleado(id) {
    $.ajax({
        url: "/Empleado/GetEmpleadoEdit",
        type: "GET",
        data: { id: id },
        success: function (data) {

            $("#nombre").val(data.nombre);
            $("#apellido").val(data.apellido);
            $("#usuario").val(data.usuario);
            $("#contrasena").val(data.contrasena);
            $("#cargo").val(data.cargo);
            $("#dias").val(data.dias);
            $("#hora").val(data.hora);
            $("#servicios").val(data.servicios);

            $("#formEditarEmpleado").attr("action", "/Empleado/UpdateEmpleado?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}

// Método eliminar elementos
function eliminar(id) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar este empleado?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Empleado/DeleteEmpleado",
                type: "DELETE",
                data: { id: id },
                success: function (data) {
                    Swal.fire('¡Eliminado!', 'El empleado ha sido eliminado con éxito', 'success');
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(xhr.responseText);
                }
            });
        }
    });
}