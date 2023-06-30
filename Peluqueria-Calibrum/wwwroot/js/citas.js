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
//Para limitar que no puedan tomar hora un dia antes del dia actual
function limitarFecha() {
    // Obtener la fecha actual en formato YYYY-MM-DD
    var today = new Date().toISOString().split('T')[0];

    // Obtener todos los elementos de entrada de fecha con la clase "fecha-agregar"
    var modalFechas = document.querySelectorAll('.fecha-agregar');

    // Establecer el atributo 'min' en los elementos de entrada de fecha
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

            $("#hora").val(data.hora);
            $("#dia").val(data.dia);
            $("#nombre_cliente").val(data.nombre_cliente);
            $("#nombre_servicio").val(data.nombre_servicio);
            $("#telefono").val(data.telefono);

            $("#formEditarCita").attr("action", "/Citas/UpdateCita?id=" + data.id);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseText);
        }
    });
}

function validarNumero(input) {
    input.value = input.value.replace(/\D/g, ""); // Remueve todos los caracteres no numéricos

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

limitarFecha();
