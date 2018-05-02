



//--------------------validaciones login-------------------------

function validar() {
    var user, password;
    user = document.getElementById("user").value;
    password = document.getElementById("password").value;

    if (user == '' && password == '') {        
        texto = "Por Favor Ingrese usuario y Clave";
        CustomizedAlertWarning(texto);
        return false;
    }

    if (user == '') {
        texto = "Por Favor Ingrese el usuario";
        CustomizedAlertWarning(texto);
        return false;
    }

    if (password == '') {
        texto = "Por Favor Ingrese su Clave";
        CustomizedAlertWarning(texto);
        return false;
    }

    return true;
}
//--------------------Fin validaciones login-------------------------


//--------------------validaciones Buscar Tramites-------------------------
function ValidarBuscarTramites()
{
    var nombre="", No_Folio="", No_Credito="";
    try
    {
        
        nombre = document.getElementById("ContentPlaceHolder1_txt_nombre_bs").value;
        No_Folio = document.getElementById("ContentPlaceHolder1_txt_Folio_bs").value;
        No_Credito = document.getElementById("ContentPlaceHolder1_txt_NoCredito_bs").value;

        if (nombre == "" &&  No_Folio == "" && No_Credito == "")
        {
            texto = "Por favor Ingrese alguno de los dato para realizar la busqueda (Nombre, Folio o Credito)";
            CustomizedAlertInfo(texto);
            return false;
        }

        return true;
    
    }
    catch(err)
    {
        texto = "Error en el proceso de javascript";
        CustomizedAlertError(texto);
        return false;
    }
    
}

//--------------------Fin validaciones Buscar Tramites---------------------

//--------------------validaciones Historial de Contacto--------------------
function ValidarHistorialContacto() {
    var nombre = "", No_Folio = "", No_Credito = "";
    try {

        nombre = document.getElementById("ContentPlaceHolder1_txt_nombre").value;
        No_Folio = document.getElementById("ContentPlaceHolder1_txt_Folio").value;
        No_Credito = document.getElementById("ContentPlaceHolder1_txt_NoCredito").value;

        if (nombre == "" && No_Folio == "" && No_Credito == "") {
            texto = "Por favor Ingrese alguno de los dato para realizar la busqueda (Nombre, Folio o Credito)";
            CustomizedAlertInfo(texto);
            return false;
        }

        return true;

    }
    catch (err) {
        texto = "Error en el proceso de javascript";
        CustomizedAlertError(texto);
        return false;
    }

}
//--------------------------------------------------------------------------