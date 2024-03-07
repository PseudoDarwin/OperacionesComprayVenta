function mostrareditarCarrera(id, carrera) {
    document.getElementById('txtideditarcarrera').value = id;
    document.getElementById('txtcarreraeditar').value = carrera;

    $('#ModalEditarCarrera').modal('show')
}


function mostrareliminarCarrera(id, carrera) {
    document.getElementById('txtidcarreraeliminar').value = id;
    document.getElementById('txtcarreraeliminar').value = carrera;

    $('#ModalEliminarCarrera').modal('show')
}