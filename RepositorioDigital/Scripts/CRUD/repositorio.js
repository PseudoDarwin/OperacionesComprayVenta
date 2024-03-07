var dirip2 = 'https://localhost:44346'
async function AgregarArchivo() {
    var mensaje = document.getElementById("mensajeAgregarArchivo");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('titulo', document.getElementById("txtTituloagregar").value) //i
    urlencoded.append('materia', document.getElementById("txtMateriaagregar").value) //i
    urlencoded.append('carrera', document.getElementById("txtCarreraagregar").value); //i 
    urlencoded.append('autor', document.getElementById("txtAutoragregar").value); //
    urlencoded.append('tipo', document.getElementById("txtTipoagregar").value); //
   // urlencoded.append('rutaoriginal', document.getElementById("fileInput").value); 

    var fileInput = document.getElementById('fileInput');
    // Verificar si se seleccionó un archivo
    if (fileInput.files.length > 0) {
        // Obtener el nombre del archivo
        var fileName = fileInput.files[0].name;
    } 


    urlencoded.append('ruta',"C:\\Repositorio\\"+ fileName); 
    
    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Repositorio/AgregarArchivo', requestOptions)
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
                mensaje.innerText = "No se puede agregar el registro Titulo repetido, o ha ocurrido un error inesperado"
                setTimeout(function () {
                    mensaje.style.display = 'none';
                }, 5000);
                console.log('Error :(');
            }
            if (json.Error == 0) {
                console.log("entramos");
                //crerra modal
                //mostrar label verde
                var boton = document.getElementById("btnSubirArchivo");

                boton.click();

                //setTimeout(function () {

                //    $("#ModalAgregarArchivo").modal("hide");
                //}, 1000);



                /*location.href = "/Repositorio/ViewRepositorio";*/
                console.log('Exito :)');
            }



        })
        .catch(function (error) {
            console.log(error)
        })
}



async function EditarArchivo() {
    var mensaje = document.getElementById("mensajeeditarArchivo");

    var myHeaders = new Headers(); //i
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded"); //i
    myHeaders.append("Cookie", "csrftoken=vI89AmTt8nrNUfcv2TGpLHqJ51ZO8wp0sMc5GiRVTkdaTDvjGK1ekCZHfCg2AZ7P"); //i
    var urlencoded = new URLSearchParams(); //i

    urlencoded.append('id', document.getElementById("txtidarchivoeditar").value) //i
    urlencoded.append('titulo', document.getElementById("txttituloeditar").value) //i
    urlencoded.append('materia', document.getElementById("txtmateriaeditar").value) //i
    urlencoded.append('carrera', document.getElementById("txtcarreraeditar").value); //i 
    urlencoded.append('autor', document.getElementById("txtautoreditar").value); //
    urlencoded.append('tipo', document.getElementById("txttipoeditar").value); //




    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    await fetch(dirip2 + '/Repositorio/EditarArchivo', requestOptions)
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

                    $("#ModalEditarArchivo").modal("hide");
                }, 1000);



                location.href = "/Repositorio/ViewRepositorio";
                console.log('Exito :)');
            }



        })
        .catch(function (error) {
            console.log(error)
        })
}
