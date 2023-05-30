

function cargarEmpleado(id) {
    $.ajax({
        url: "/Empleado/GetEmpleado",
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

function eliminar(id) {
    if (confirm("¿Está seguro que desea eliminar este elemento?")) {
        $.ajax({
            url: "/Empleado/DeleteEmpleado",
            type: "DELETE",
            data: { id: id },
            success: function (data) {
                location.reload();
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseText);
            }
        });
    }
}