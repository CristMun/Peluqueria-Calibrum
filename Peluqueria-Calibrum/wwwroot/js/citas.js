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
            $("#precio_total").val(data.precio_total);

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