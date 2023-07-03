function eliminar(id) {
    Swal.fire({
        title: '¿Está seguro que desea eliminar esta cita?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Citas/DeleteCitas",
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

function guardar() {
    document.getElementById("btnAgregar").setAttribute("disabled", "disabled");

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

    // Mostrar SweetAlert cuando la petición se haya completado exitosamente
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


//Para limitar que no puedan tomar hora un dia antes del dia actual
function limitarFecha() {
    var today = new Date().toISOString().split('T')[0];

    var modalFechas = document.querySelectorAll('.fecha-agregar');

    modalFechas.forEach(function (element) {
        element.setAttribute('min', today);
    });
}

function cargarCitas(id) {
    $.ajax({
        url: "/Citas/GetCitaEdit",
        type: "GET",
        data: { id: id },
        success: function (data) {

            $("#id_servicio").val(data.id_servicio);
            $("#id_empleado").val(data.id_empleado);
            $("#dia").val(data.dia);
            $("#hora").val(data.hora);
            $("#nombre_cliente").val(data.nombre_cliente);
            $("#telefono").val(data.telefono);


            $("#formEditarCita").attr("action", "/Citas/UpdateCita?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}

function validarNumero(input) {
    input.value = input.value.replace(/\D/g, "");
    var numero = input.value;
    var esIgual = numero.split('').every(function (digito) {
        return digito === numero[0];
    });

    if (esIgual) {
        input.setCustomValidity("Ingrese un numero valido");
    } else {
        input.setCustomValidity("");
    }
}


function finalizado() {
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

function confirmarFinalizarCita(citaId) {
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
            marcarCitaFinalizada(citaId);
        } else {
        }
    });
}

function marcarCitaFinalizada(citaId) {
    $.ajax({
        url: '/Citas/FinalizarCita',
        type: 'POST',
        data: { citaId: citaId },
        success: function (result) {
            console.log(result);

            finalizado();
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}



marcarCitaFinalizada();
limitarFecha();
