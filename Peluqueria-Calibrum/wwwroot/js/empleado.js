﻿//Metodo para mostrar el elemento seleccionado -->
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
        confirmButtonColor: '#3085d6',
        cancelButtonText: 'No',
        cancelButtonColor: '#d33',
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