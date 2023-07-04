function eliminarCH(id) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar esta cita?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Inicio/DeleteCitas",
                type: "DELETE",
                data: { id: id },
                success: function (data) {
                    Swal.fire('Adios...', 'Cita eliminada con éxito', 'success');
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

function finalizadoCH() {
    Swal.fire({
        icon: 'success',
        title: 'Cita finalizada',
        text: 'La cita fue finalizada correctamente.',
        confirmButtonText: 'OK',
        confirmButtonColor: '#3085d6',
        timer: 1000
    }).then(function () {
        location.reload();
    });

    return true;
}

function confirmarFinalizarCitaHoy(citaId) {
    Swal.fire({
        icon: 'warning',
        title: '¿Estás seguro?',
        text: 'Esta acción marcará la cita como finalizada.',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'Cancelar',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33'
    }).then((result) => {
        if (result.isConfirmed) {
            marcarCitaFinalizadaCH(citaId);
        } else {
        }
    });
}

function marcarCitaFinalizadaCH(citaId) {
    $.ajax({
        url: '/Inicio/FinalizarCita',
        type: 'POST',
        data: { citaId: citaId },
        success: function (result) {
            console.log(result);

            finalizadoCH();
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}



marcarCitaFinalizada();
limitarFecha();
