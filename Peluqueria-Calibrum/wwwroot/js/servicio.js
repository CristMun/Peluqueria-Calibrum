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
    Swal.fire({
        icon: 'success',
        title: 'Actualizado',
        text: 'El empleado ha sido modificado correctamente.',
        confirmButtonText: 'OK',
        confirmButtonColor: '#3085d6',
        timer: 1000
    });

    return true; 
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
           
            if (data.categoria === "Peluquero") {
                $("#peluquero").prop("checked", true);
            } else if (data.categoria === "Barbero") {
                $("#barbero").prop("checked", true);
            }

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

function buscarServicio() {
    var fullname = document.getElementById('nombreServicio').value;
    var cargo = document.getElementById('categoria').value;

    fetch(`/Servicio/BuscarServicios?nombre=${nombreServicio}&categoria=${categoria}`)
        .then(response => response.text())
        .then(data => {
            var tablaServicios = document.getElementById('tablaServicios');
            tablaServicios.innerHTML = data;
        })
        .catch(error => {
            console.error('Error al buscar Servicios:', error);
        });
}



