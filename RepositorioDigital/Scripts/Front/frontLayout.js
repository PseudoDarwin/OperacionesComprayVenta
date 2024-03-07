document.addEventListener('DOMContentLoaded', function () {
// Obtener el enlace y los elementos li
    var tipouser = document.getElementById('htipouser');
var liRepositorio = document.getElementById('liRepositorio');
var liUsuario = document.getElementById('liUsuario');


// Verificar la condición y ocultar los elementos si es necesario
if (tipouser.innerHTML != '1') {
    liRepositorio.style.display = 'none';
    liUsuario.style.display = 'none';
}
});
