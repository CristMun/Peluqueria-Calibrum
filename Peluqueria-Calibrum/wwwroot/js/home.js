//Para obtener el precio y mostrarlo en modal
function mostrarPrecioSeleccionado(selectElement) {
    var selectedOption = selectElement.options[selectElement.selectedIndex];
    var precioSeleccionado = selectedOption.getAttribute('data-precio');
    document.getElementById('precioSeleccionado').textContent = precioSeleccionado;
}

//Para limitar que no puedan tomar hora un dia antes del dia actual
function limitarFecha(){
    var fechaActual = new Date().toISOString().split('T')[0];
    document.getElementById("dia").setAttribute("min", fechaActual);
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




function mostrarServiciosDisponibles(selectEmpleado) {
    var selectServicio = document.getElementById('select-servicio');
    var cargoEmpleado = selectEmpleado.options[selectEmpleado.selectedIndex].getAttribute('data-cargo');

    for (var i = 0; i < selectServicio.options.length; i++) {
        selectServicio.options[i].disabled = false;
        selectServicio.options[i].classList.remove('opcion-no-seleccionada');
    }

    for (var i = 0; i < selectServicio.options.length; i++) {
        var categoriaServicio = selectServicio.options[i].getAttribute('data-categoria');

        if (categoriaServicio !== cargoEmpleado) {
            selectServicio.options[i].disabled = true;
            selectServicio.options[i].classList.add('opcion-no-seleccionada');
        }
    }

    selectServicio.selectedIndex = 0;

    selectServicio.disabled = false;
}


limitarFecha()
alertaEnviado()
