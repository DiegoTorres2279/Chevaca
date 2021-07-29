
let buttonSubmit= document.getElementById("btn_submit_ns");
let buttonReset= document.getElementById("btn_reset_ns");
let nsName= document.getElementById("txb_nsName"); 
let nsAddress= document.getElementById("txb_nsAddress");

$(document).ready(function (){
    buttonSubmitDisabled();
    validator = loadValidator(); 
    document.forms[0].addEventListener('blur', function(e){
        validator.checkField(e.target);
        blurValidator();
    }, true);
});

$("#btn_submit_ns").click( async function (){
    let nsExist = await existeNSenChirpstack(nsName.value, nsAddress.value);
    
    console.log(nsExist);
    
    if(nsExist.result == ""){
        let body=`<p>Revise la informacion: <br>
                Nombre Network Server: ${nsName.value}<br>
                Network Server Address: ${nsAddress.value}<br></p>`;

        $("#modalBody").replaceWith(body);
        $("#myModal").modal('show');
        $('#SubForm').click(function (){
            $("#formAddNS").submit();
        });
        return;
    }else {
        let obj = JSON.parse(nsExist);
        let message= `<p>Se encontraron los siguientes errores: <br>` ;
        let errorName = false;
        let errorAddress = false;
        
        if(obj.name == nsName.value){
            message+= `Ya existe un Network Server con el nombre ${nsName}`;
            errorName= true;
        }
        
        if(obj.address == nsAddress.value.trim()){
            message += `<br> Ya existe un Network Server con la direccion ${nsAddress}`;
            errorName= true;
        }
        
        if(!errorName && !errorAddress){
            message += nsExist;
        }
        
        message += `</p>`;

        $("#modalErrorBody").replaceWith(message);
        $("#modalError").modal('show');

        return;
    }
});

$("#btn_reset_ns").click( function (){
    $("#formAddNS").trigger("reset");
})

function buttonSubmitDisabled(){
    buttonSubmit.disabled=true;
}

function blurValidator(){
    let validator = loadValidator();
    
    let nameCorrecto= false;
    let addressCorrecto= false;
    
    if(nsName.value != nsName.defaultValue && nsAddress.value != nsAddress.defaultValue){
        let nameValidado= validator.checkField(nsName);
        let addressValiada= validator.checkField(nsAddress);
        
        if(nameValidado.valid && addressValiada.valid){
            nameCorrecto = true;
            addressCorrecto= true;
        }
    }
    
    if(nsName.value != nsName.defaultValue){
        let nameValidado = validator.checkField(nsName);
        
        if(nameValidado.valid){
            nameCorrecto=true;
        }
    }
    
    if(nsAddress.value != nsAddress.defaultValue){
        let addressValidada = validator.checkField(nsAddress);
        
        if(addressValidada.valid){
            addressCorrecto= true;            
        }
    }
    
    if(addressCorrecto && nameCorrecto){
        buttonSubmit.disabled=false;
    }else{
        buttonSubmit.disabled= true;
    }
}

function loadValidator(){
    let validatorFunc= new FormValidator({
        texts:{
            empty: 'Este campo es obligatorio',
            short: 'El numero ingresado \nes demasiado corto',
            long: `El numero ingresado \nes demasiado largo`,
            url: 'Ingrese una URL valida',
        }
    });
    return validatorFunc;
}

async function existeNSenChirpstack(name, address){
    let resultado = "";
    
    try {
        resultado= await $.ajax({
            url: "/Administrador/validarNSenChirpStack",
            type: "POST",
            dataType: 'JSON',
            content: 'application/json; charset=utf-8',
            data: {"name": name, "address": address}
        });
        return resultado;
    }catch (e){
        resultado = e.message;
        return resultado;
    }
}