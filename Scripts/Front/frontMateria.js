function mostrareditarmateria(id, materia) {
    document.getElementById('txtidmateriaeditar').value = id;
    document.getElementById('txtmateriaeditar').value = materia;

    $('#ModalEditarMateria').modal('show')
}


function mostrareliminarmateria(id, materia) {
    document.getElementById('txtidmateriaidliminar').value = id;
    document.getElementById('txtmateriaeliminar').value = materia;

    $('#ModalEliminarMateria').modal('show')
}