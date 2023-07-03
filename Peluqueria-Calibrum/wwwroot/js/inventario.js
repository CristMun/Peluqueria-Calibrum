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

function cargarInventario(id) {
    $.ajax({
        url: "/Inventario/GetInventarioEdit",
        type: "GET",
        data: { id: id },
        success: function (data) {

            //$("#imagen").val(data.imagen);
            $("#nombreInv").val(data.nombre);
            $("#descripcionInv").val(data.descripcion);
            $("#cantidad").val(data.cantidad);

            $("#formEditarInventario").attr("action", "/Inventario/UpdateInventario?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}


function buscarInventario() {
    var nombre = document.getElementById('nombre').value;
    var descripcion = document.getElementById('descripcion').value;

    fetch(`/Inventario/BuscarInventario?nombre=${nombre}&descripcion=${descripcion}`)
        .then(response => response.text())
        .then(data => {
            var tablaInventario = document.getElementById('tablaInventario');
            tablaInventario.innerHTML = data;
        })
        .catch(error => {
            console.error('Error al buscar Servicios:', error);
        });
}