function validation1() {

    var combo1 = document.getElementById("<%=cbotipo_busqueda.ClientID%>")
    if (combo1.value == null || combo1.value == "0") {
        alert("Porfavor, seleccione el perfil correspondiente");
        document.getElementById("<%=cbotipo_busqueda.ClientID%>").style.border = "2px solid red";
        return false;
    }
    else {
        document.getElementById("<%=cbotipo_busqueda.ClientID%>").style.border = "";
    }

    var txt = document.getElementById("txtfiltro");
    if (txt.value == "" || txt.value == null) {
        alert("Porfavor, ingrese su rut");
        txt.style.border = "2px solid red";
        return false;
    }


    else {
        txt.style.border = "";

    }


    return true;
}

