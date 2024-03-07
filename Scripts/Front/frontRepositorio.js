function mostrarEditarArchivo( id,  titulo,  materia,  carrera,  autor,  tipo) {
    document.getElementById('txtidarchivoeditar').value = id;
    document.getElementById('txttituloeditar').value = titulo.trim();
    document.getElementById('dropMateriaeditar').value = materia;
    document.getElementById('dropCarreraeditar').value = carrera.trim();
    document.getElementById('txtautoreditar').value = autor;
    document.getElementById('dropTipoeditar').value = tipo.trim();


    $('#ModalEditarArchivo').modal('show')
}

function mostrarEliminarArchivo(id, titulo) {
    document.getElementById('txtidarchivoeliminar').value = id;
    document.getElementById('txttituloeliminar').value = titulo.trim();


    $('#ModalEliminarArchivo').modal('show')
}