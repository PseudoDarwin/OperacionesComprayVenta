var dirip2 = 'https://localhost:44346'


async function AgregaUsuario() {
    var mensaje = document.getElementById("mensajeAgregarUsuario");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('nombreUsuario', document.getElementById("txtnombreusuarioagregar").value) //i
    urlencoded.append('correo', document.getElementById("txtcorreusuariooagregar").value) //i
    urlencoded.append('contra', document.getElementById("txtcontraagregar").value) //i
    urlencoded.append('contra2', document.getElementById("txtcontra2agregar").value); //i 

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Usuario/AgregarUsuario', requestOptions)
        .then(function (response) {
            if (response.ok) {
                hubo_respuesta = true;
            }
            else {
                hubo_respuesta = false;
            }
            return response.json();
        })
        .then(function (myJson) {
            json = myJson;

            if (json.Error == 1) {
                //mostrar label rojo
                setTimeout(function () {
                    mensaje.style.display = 'block';
                }, 500);
                mensaje.innerText = "No se puede agregar el registro ha ocurrido un error inesperado"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            if (json.Error == 2) {
                //mostrar label rojo
                setTimeout(function () {
                    mensaje.style.display = 'block';
                }, 500);
                mensaje.innerText = "No se puede hacer el registro, las contraseñas no coinciden"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            if (json.Error == 0) {
                console.log("entramos");
                //crerra modal
                //mostrar label verde


                setTimeout(function () {

                    $("#ModalAgregarUsuario").modal("hide");
                }, 1000);



                location.href = "/Usuario/ViewUsuario";
                console.log('Exito :)');
            }



        })
        .catch(function (error) {
            console.log(error)
        })
}


async function EditarUsuario() {
    var mensaje = document.getElementById("mensajeEditarUsuario");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i
    
    urlencoded.append('nombreUsuario', document.getElementById("idnombreusereditar").value) //i
    urlencoded.append('correo', document.getElementById("idcorreousereditar").value) //i
    urlencoded.append('iduser', document.getElementById("idusereditar").value) //i

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Usuario/EditarUsuario', requestOptions)
        .then(function (response) {
            if (response.ok) {
                hubo_respuesta = true;
            }
            else {
                hubo_respuesta = false;
            }
            return response.json();
        })
        .then(function (myJson) {
            json = myJson;

            if (json.Error == 1) {
                //mostrar label rojo
                setTimeout(function () {
                    mensaje.style.display = 'block';
                }, 500);
                mensaje.innerText = "No se puede editar el registro ha ocurrido un error inesperado"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            
            if (json.Error == 0) {
                console.log("entramos");
                //crerra modal
                //mostrar label verde
                setTimeout(function () {
                    $("#ModalEditarUsuario").modal("hide");
                }, 1000);
                location.href = "/Usuario/ViewUsuario";
                console.log('Exito :)');
            }
        })
        .catch(function (error) {
            console.log(error)
        })
}


async function EditarContra() {
    var mensaje = document.getElementById("mensajecambiarcontra");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('idusuario', document.getElementById("txtidcambiarcontra").value) //i
    urlencoded.append('contra', document.getElementById("idcambiarcontra1").value) //i
    urlencoded.append('contra2', document.getElementById("idcambiarcontra2").value); //i 

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Usuario/CambiarContra', requestOptions)
        .then(function (response) {
            if (response.ok) {
                hubo_respuesta = true;
            }
            else {
                hubo_respuesta = false;
            }
            return response.json();
        })
        .then(function (myJson) {
            json = myJson;

            if (json.Error == 1) {
                //mostrar label rojo
                setTimeout(function () {
                    mensaje.style.display = 'block';
                }, 500);
                mensaje.innerText = "No se puede cambiar la contraseña ha ocurrido un error inesperado"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            if (json.Error == 2) {
                //mostrar label rojo
                setTimeout(function () {
                    mensaje.style.display = 'block';
                }, 500);
                mensaje.innerText = "No se puede hacer el registro, las contraseñas no coinciden"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            if (json.Error == 0) {
                console.log("entramos");
                //crerra modal
                //mostrar label verde


                setTimeout(function () {

                    $("#ModalCambiarContraUsuario").modal("hide");
                }, 1000);



                location.href = "/Usuario/ViewUsuario";
                console.log('Exito :)');
            }



        })
        .catch(function (error) {
            console.log(error)
        })
}