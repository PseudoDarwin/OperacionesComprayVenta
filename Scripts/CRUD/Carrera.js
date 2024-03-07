var dirip2 = 'https://localhost:44346'


async function AgregarCarrera() {
    var mensaje = document.getElementById("mensajeAgregarCarrera");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('carrera', document.getElementById("txtcarreraagregar").value) //i

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Carrera/AgregarCarrera', requestOptions)
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
            if (json.Error == 0) {
                console.log("entramos");
                //crerra modal
                //mostrar label verde
                setTimeout(function () {

                    $("#ModalAgregarCarrera").modal("hide");
                }, 1000);
                location.href = "/Carrera/ViewCarrera";
                console.log('Exito :)');
            }
        })
        .catch(function (error) {
            console.log(error)
        })
}


async function EditarCarrera() {
    var mensaje = document.getElementById("mensajeEditarCarrera");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('idcarrera', document.getElementById("txtideditarcarrera").value) //i
    urlencoded.append('carrera', document.getElementById("txtcarreraeditar").value)


    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Carrera/EditarCarrera', requestOptions)
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

                    $("#ModalEditarCarrera").modal("hide");
                }, 1000);
                location.href = "/Carrera/ViewCarrera";
                console.log('Exito :)');
            }
        })
        .catch(function (error) {
            console.log(error)
        })
}

