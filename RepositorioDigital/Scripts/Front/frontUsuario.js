function mostrarEditarArchivo(id, nombreuser, correouser) {
    document.getElementById('idusereditar').value = id;
    document.getElementById('idnombreusereditar').value = nombreuser.trim();
    document.getElementById('idcorreousereditar').value = correouser;


    $('#ModalEditarUsuario').modal('show')
}

function mostrarEliminarArchivo(id, nombreuser) {
    document.getElementById('txtuserideliminar').value = id;
    document.getElementById('txtusernombreeliminar').value = nombreuser.trim();

    $('#ModalEliminarUsuario').modal('show')
}

function mostrarEditarContra(id) {
    document.getElementById('txtidcambiarcontra').value = id;
    $('#ModalCambiarContraUsuario').modal('show')
}
