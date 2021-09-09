let dataTable;
$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblTabla').DataTable({
        "ajax": {//usamos el controlador que trae todoslos lientes
            "url":"/Cliente/ObtenerClientes"
        },
        "columns": [ /*columnas*/
            { "data": "nombres", "width": "20%" },
            { "data": "apellidos", "width": "20%" },
            { "data": "direccion", "width": "20%" },
            { "data": "telefono", "width": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    } else {
                        return "Intactivo";
                    }
                }, "width":"20%",
            }
        ]
    });


}