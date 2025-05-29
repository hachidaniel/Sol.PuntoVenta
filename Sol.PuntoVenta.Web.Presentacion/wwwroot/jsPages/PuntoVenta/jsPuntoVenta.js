var urlstring = "";
var bEstatusGuardado = 0;
var DataRow = [] ;
$(document).ready(function () {
    if (window.location.hostname == "localhost") {
        urlstring = "https://localhost:7297/";
    } else {
        urlstring = "https://www.nettectwebsite.somee.com/";
    }

    GetAllLista('%');
});
$('.searchbtn').on('click', function () {
    var texto = $('.txt-PuntoVenta').val();
    GetAllLista(texto);
});
$('.CancelarFrm').on('click', function () {
    $('#Consulta').addClass('active show');
    $('#Matenimiento').removeClass('active show');
    $('.consultaData').addClass('active');
    $('.mantenimientoData').removeClass('active');
    DesabilitarHabilitarBotones(false);
    $("#txtDescripcion").val("");
    $("#txtDescripcion").prop("disabled", true);
    VisibilidadBotones(0);
    bEstatusGuardado = 0;
    $('#dataTablePuntoVenta tr.selected').removeClass('selected');
    DataRow = [];
});
$(".btnNuevo").on('click', function () {
    bEstatusGuardado = 1;
    $('#dataTablePuntoVenta tr.selected').removeClass('selected');
    $("#txtDescripcion").val("");
    DesabilitarHabilitarBotones(true);
    $('#Matenimiento').addClass('active show');
    $('#Consulta').removeClass('active show');
    $('.consultaData').removeClass('active');
    $('.mantenimientoData').addClass('active');
    $("#txtDescripcion").prop("disabled", false);
    VisibilidadBotones(true);
});
$('.btnActualizar').on('click', function () {
    bEstatusGuardado = 2;
    if (DataRow != undefined) {
        
        DesabilitarHabilitarBotones(true);
        $('#Matenimiento').addClass('active show');
        $('#Consulta').removeClass('active show');
        $('.consultaData').removeClass('active');
        $('.mantenimientoData').addClass('active');
        $("#txtDescripcion").prop("disabled", false);
        VisibilidadBotones(true);
        $("#txtDescripcion").val(DataRow[0].descripcion_PuntoVenta);
    } else {
        Swal.fire({
            title: "Debes de seleccionar un registro para poder actualizar",
            text: "",
            icon: "question"
        });
        bEstatusGuardado = 0;
    }
});
$('.mantenimientoData').on("click", function () {
    $("#txtDescripcion").val("");
    DesabilitarHabilitarBotones(false);
    VisibilidadBotones(0);
});
$('.consultaData').on("click", function () {
    $("#txtDescripcion").val("");
    DesabilitarHabilitarBotones(false);
    VisibilidadBotones(0);
});
$('.btnGuardarFrm').on('click', function () {
    var parametros = {};
    if (bEstatusGuardado == 1) {
        if ($("#txtDescripcion").val() === "") {
            Swal.fire({
                title: "Debes de ingresar un registro",
                text: "",
                icon: "question"
            });
        } else {
            parametros = {
                id_PuntoVenta: 0,
                descripcion_PuntoVenta: $("#txtDescripcion").val(),
                estatus: true
            };
            Ajax(JSON.stringify(parametros), urlstring + 'api/PuntoVenta').Post().then((data) => {
                /*  var x = JSON.stringify(data);*/
                if (data.isSuccess) {
                    Swal.fire({
                        title: "Exito!",
                        text: "Se guardo correctamente: " + $("#txtDescripcion").val(),
                        icon: "success"
                    });
                    $('.CancelarFrm').click();
                    GetAllLista('%');
                } else {
                    Swal.fire({
                        title: "Hubo un error al guardar",
                        text: "",
                        icon: "question"
                    });
                }

            }).catch((error) => {
                $('#mainloader').addClass('d-none');
            });
        }

    } else if (bEstatusGuardado == 2)
    {
        parametros = {
            id_PuntoVenta: DataRow[0].id_PuntoVenta,
            descripcion_PuntoVenta: $("#txtDescripcion").val(),
            estatus: true
        };
        Ajax(JSON.stringify(parametros), urlstring + 'api/PuntoVenta').Put().then((data) => {
            /*  var x = JSON.stringify(data);*/
            if (data.isSuccess) {
                Swal.fire({
                    title: "Exito!",
                    text: "Se Actualizo correctamente",
                    icon: "success"
                });
                $('.CancelarFrm').click();
                GetAllLista('%');
            } else {
                Swal.fire({
                    title: "Hubo un error al guardar",
                    text: "",
                    icon: "question"
                });
            }

        }).catch((error) => {
            $('#mainloader').addClass('d-none');
        });
        
    }
    else if (bEstatusGuardado == 3) {
        parametros = {
            id: DataRow[0].id_PuntoVenta,
            text: "",
        };

        Swal.fire({
            title: "¿Estas seguro de eliminar el registro?",
            text: "",
            icon: "warning",
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Si, quiero eliminar",
            showCancelButton: true,
            cancelButtonText:"Cancelar"
        }).then((result) => {
            if (result.isConfirmed) {
                Ajax(JSON.stringify(parametros), urlstring + 'api/PuntoVenta').Delete().then((data) => {
                    /*  var x = JSON.stringify(data);*/
                    if (data.isSuccess) {
                        Swal.fire({
                            title: "Eliminado!",
                            text: "El registro eliminado.",
                            icon: "success"
                        });
                        $('.CancelarFrm').click();
                        GetAllLista('%');
                    } else {
                        Swal.fire({
                            title: "Hubo un error al guardar",
                            text: "",
                            icon: "question"
                        });
                    }

                }).catch((error) => {
                    $('#mainloader').addClass('d-none');
                });
            }
        });

       

    }
    bEstatusGuardado = 0;
});

$('.btEliminar').on('click', function () {
    bEstatusGuardado = 3;
    if (DataRow != undefined) {

        DesabilitarHabilitarBotones(true);
        $('#Matenimiento').addClass('active show');
        $('#Consulta').removeClass('active show');
        $('.consultaData').removeClass('active');
        $('.mantenimientoData').addClass('active');
        $("#txtDescripcion").prop("disabled", true);
        VisibilidadBotones(true);
        $("#txtDescripcion").val(DataRow[0].descripcion_PuntoVenta);
    } else {
        Swal.fire({
            title: "Debes de seleccionar un registro para poder actualizar",
            text: "",
            icon: "question"
        });
        bEstatusGuardado = 0;
    }
});

$('#dataTablePuntoVenta').on('click', 'tbody tr', function (e) {
    let classList = e.currentTarget.classList;

    if (classList.contains('selected')) {
        classList.remove('selected');
        $(".btnNuevo").prop("disabled", false);
        $(".btnActualizar").prop("disabled", false);
        $(".btEliminar").prop("disabled", false);
        $(".btnReporte").prop("disabled", false);
        $(".btnSalir").prop("disabled", false);
    }
    else {
        $('#dataTablePuntoVenta').DataTable().rows('.selected').nodes().each((row) => row.classList.remove('selected'));
        classList.add('selected');
        $(".btnNuevo").prop("disabled", true);
        $(".btnActualizar").prop("disabled", false);
        $(".btEliminar").prop("disabled", false);
        $(".btnReporte").prop("disabled", true);
        $(".btnSalir").prop("disabled", true);
    }
    DataRow = $('#dataTablePuntoVenta').DataTable().rows('.selected').data()

});
function GetAllLista(text) {

    $('#mainloader').removeClass('d-none');
    Ajax("", urlstring + 'api/PuntoVenta?text=' + text).Get().then((data) => {
        /*  var x = JSON.stringify(data);*/
        new DataTable('#dataTablePuntoVenta', {
            destroy: true,
            select: true,
            responsive: true,
            "paging": true,
            "ordering": true,
            "info": false,
            data: data.data,
            "searching": false,
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
            columns: [
                { data: "id_PuntoVenta", "autoWidth": true },
                { data: "descripcion_PuntoVenta", "autoWidth": true },
                {
                    data: "estatus", "autoWidth": true, render: function (data, type, row) {
                        return '<i class="fa fa-check" aria-hidden="true" style="color: green;"></i>';  // Icono de una verificación

                    }
                },

            ],
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
        });

    }).catch((error) => {
        $('#mainloader').addClass('d-none');
    });
}
function DesabilitarHabilitarBotones(bEstatus) {

    $(".btnNuevo").prop("disabled", bEstatus);
    $(".btnActualizar").prop("disabled", bEstatus);
    $(".btEliminar").prop("disabled", bEstatus);
    $(".btnReporte").prop("disabled", bEstatus);
    $(".btnSalir").prop("disabled", bEstatus);
}
function VisibilidadBotones(Estatus) {

    if (Estatus == 1) {
        $(".CancelarFrm").removeClass('d-none');
        $(".btnGuardarFrm").removeClass('d-none');
        $(".btnRetornarFrm").addClass('d-none');
    } else if (Estatus == 2) {
        $(".CancelarFrm").addClass('d-none');
        $(".btnGuardarFrm").addClass('d-none');
        $(".btnRetornarFrm").removeClass('d-none');
    } else {
        $(".CancelarFrm").addClass('d-none');
        $(".btnGuardarFrm").addClass('d-none');
        $(".btnRetornarFrm").addClass('d-none');
    }


}