﻿var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblLibros").DataTable({
        "ajax": {
            "url": "/Libro/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "titulo", "width": "50%" },
            { "data": "autor", "width": "50%" },
            { "data": "genero.nombre", "width": "50%" },
            { "data": "usuario.nombres", "width": "50%" },
            {
                "data": "ruta", "width": "50%", "render": function (data, type, row, meta) {
                    if (type === 'display') {
                        data = '<a href="' + data + '" target="_blank"><i class="fas fa-download"></i></a>';
                    }

                    return data;
                } },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <!--<a href='/Libro/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>-->
                            &nbsp;
                            <a onclick=Delete("/Libro/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}