function CustomizedAlertError(texto) {
    swal({
        title: 'Error!',
        text: texto,
        type: 'error',
        confirmButtonText: 'Aceptar',
        width: '350'

    });
}
function CustomizedAlertWarning(texto) {
    swal({
        title: 'Advertencia!',
        text: texto,
        type: 'warning',
        confirmButtonText: 'Aceptar',
        width: '350'

    });
}
function CustomizedAlertSuccess(texto) {
    swal({
        title: 'Exito!',
        text: texto,
        type: 'success',
        confirmButtonText: 'Aceptar',
        width: '350'

    });
}
function CustomizedAlertInfo(texto) {
    swal({
        title: 'Informacion!',
        text: texto,
        type: 'info',
        confirmButtonText: 'Aceptar',
        width: '350'

    });
}