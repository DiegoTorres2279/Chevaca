let actualStep;
var validator;
var buttonNext;
var buttonFinish;


$(document).ready(function () {

    var btnFinish = $('<button id="btn_wizard_finish" data-color=\'Chevaca\'></button>').text('Finish')
        .addClass('btn btn-wiz btn-info')
        .on('click', function(){ onFinishCallback(); });

    var btnNext = $('<button id="btn_wizard_next" data-color=\'Chevaca\'></button>').text('Next')
        .addClass('btn btn-wiz btn-info')
        .on('click', function(){ onLeaveStepCallback(actualStep); });

    $('#smartwizard').smartWizard({
        selected: 0,
        theme:'progress',
        transition: {
            animation: 'slide-horizontal', // Effect on navigation, none/fade/slide-horizontal/slide-vertical/slide-swing
        },
        toolbarSettings: {
            toolbarPosition: 'bottom', // both bottom,
            showNextButton:false,
            toolbarExtraButtons: [btnNext,btnFinish ]
        },
        anchorSettings: {
            removeDoneStepOnNavigateBack:true,
        },
        keyboardSettings: {
            keyNavigation: false,
        }
    });

    $("#smartwizard").on("showStep", function (e,anchorObject, stepIndex, stepDirection){
        saveStep(stepIndex);
        blurValidator();
    });

    loadValidator();

    document.forms[0].addEventListener('blur', function (e) {
        validator.checkField(e.target);
        blurValidator()
    }, true);
});



function buttonDisabled(){
    // buttonNext.addClass("buttonDisabled");
    buttonNext.prop('disabled', true);
    buttonNext.attr("aria-disabled",true);
}

function saveStep(stepIndex, stepDirection){
    actualStep=stepIndex;
    buttonNext = $("#btn_wizard_next");
    buttonFinish= $("#btn_wizard_finish");
}

$("#btn_wizard_next").click(onLeaveStepCallback(actualStep));

async function onLeaveStepCallback(step){
    if(actualStep == 0){
        var rut= document.getElementById('txb_EstanciaOrg_Rut');
        var nombreFiscal = document.getElementById('txb_EstanciaOrg_DisplayName');
        var razonSocial = document.getElementById('txb_EstanciaOrg_Nombre');
        var maxDevices = document.getElementById('txb_EstanciaMaxDevice');
        var maxGateway = document.getElementById('txb_EstanciaMaxGateway');

        var chGateway=document.getElementById("chGateways");

        $('#smartwizard').smartWizard("loader", "show");
        
        var orgExist = await $.ajax({
            method: "GET",
            url: "/Administrador/validarOrganizationEnChirpstack",
            dataType: "JSON",
            content: 'application/json; charset=utf-8',
            data: {"name": razonSocial.value},
        });

        var estanciaExist = await $.ajax({
            method: "GET",
            url: "/Administrador/validarOrganizationEnChirpstack",
            dataType: "JSON",
            content: 'application/json; charset=utf-8',
            data: {"name": razonSocial.value}
        });
        
        let mensaje = "";
        if (orgExist.result === "" && estanciaExist.result === "") {
            $('#smartwizard').smartWizard("loader", "hide");
            $('#smartwizard').smartWizard("next");
        } else if ((orgExist.result === razonSocial.value)) {
            mensaje= `<p> Ya existe una Organizacion con con el nombre ${razonSocial.value}. <br>
                           Revide los datos ingresados. </p>`;

            $('#smartwizard').smartWizard("loader", "hide");
            
            $("#modalErrorBody").replaceWith(mensaje);
            $("#modalError").modal('show');
        } else if (estanciaExist.result === rut.value) {
            mensaje= `<p> Ya existe una Estancia con el Rut ${rut.value}. <br>
                               Revise los datos ingresados. </p>`;
                $("#modalErrorBody").replaceWith(mensaje);
                $("#modalError").modal('show');

                $('#smartwizard').smartWizard("loader", "hide");

        } else{
            mensaje= `<p>Error Desconocido</p>`;
            $("#modalErrorBody").replaceWith(mensaje);
            $("#modalError").modal('show');

            $('#smartwizard').smartWizard("loader", "hide");

        }
    }
}

function onFinishCallback(){
    document.getElementById('FormEstOrgSP').submit();
}

async function existeOrgEnChirpstack(name){
    let resultado = "";

    try {
        resultado = await $.ajax({
            url:"/Administrador/validarOrganizationEnChirpstack",
            type: "GET",
            dataType:"JSON",
            content:'application/json; charset=utf-8',
            data: { "name": name }
        });
        return resultado;

    }catch (e){
        resultado = e.message;
        return resultado;
    }
}

async function existeEstanciaEnChevaca(rut){
    let resultado= "";
    
    try {
        resultado= await $.ajax({
            url: "/Administrador/validarExistenciaEstancia",
            type: "POST",
            dataType: "JSON",
            content: 'application/json; charset=utf-8',
            data: {"rut": rut.value}
        });
        return resultado;
            
    }catch (e){
        resultado= e.message;
        return resultado;
    }
}

function loadValidator(){
     validator = new FormValidator({
        texts: {
            empty: 'Este campo es obligatorio',
            short: 'El numero ingresado \nes demasiado corto',
            long: `El numero ingresado \nes demasiado largo`
        }
    });
}



function blurValidator() {

    if(actualStep == 0){
        buttonFinish.prop('disabled', true);
        buttonFinish.attr("aria-disabled",true);
        
        let nombreEstanciaOrg = document.getElementById('txb_EstanciaOrg_Nombre');
        let rutEstanciaOrg = document.getElementById('txb_EstanciaOrg_Rut');

        let nombreCorrecto = false;
        let rutCorrecto = false;


        if (nombreEstanciaOrg.value != nombreEstanciaOrg.defaultValue && rutEstanciaOrg.value != rutEstanciaOrg.defaultValue) {
            
            if(nombreEstanciaOrg.value.length > 0){
                nombreEstanciaOrg.value= nombreEstanciaOrg.value.trim();
            }

            var rutValidado = validator.checkField(rutEstanciaOrg);
            var nombreValidado = validator.checkField(nombreEstanciaOrg);

            if (nombreValidado.valid && rutValidado.valid) {
                nombreCorrecto = true;
                rutCorrecto = true;
            }
        }

        if (nombreEstanciaOrg.value != nombreEstanciaOrg.defaultValue) {

            if(nombreEstanciaOrg.value.length > 0){
                nombreEstanciaOrg.value= nombreEstanciaOrg.value.trim();
            }
            
            var nombreValidado = validator.checkField(nombreEstanciaOrg);

            if (nombreValidado.valid) {
                nombreCorrecto = true;
            }
        }

        if (rutEstanciaOrg.value != rutEstanciaOrg.defaultValue) {

            var rutValidado = validator.checkField(rutEstanciaOrg);
            
            if (rutValidado.valid) {
                rutCorrecto = true;
            }
        }

        if (nombreCorrecto && rutCorrecto ) {
            // buttonNext.removeClass("buttonDisabled")
            buttonNext.prop('disabled', false);
            buttonNext.attr("aria-disabled",false);
        } else {
            // buttonNext.addClass("buttonDisabled");
            buttonNext.prop('disabled', true);
            buttonNext.attr("aria-disabled",true);
        }
    }else if(actualStep == 1){
        buttonNext.prop('disabled', true);
        buttonNext.attr("aria-disabled",true);
        let spName = document.getElementById("txb_spName");
        let selNsID = document.getElementById("sel_nsID");
        let spNameCorrecto = false;
        let selNSCorrecto= false; 
        
        if(spName.value != spName.defaultValue && selNsID.value != ""){
            
            if(spName.value.length > 0){
                spName.value= spName.value.trim();                
            }
            
            let spNameValid = validator.checkField(spName);
            let selNSValid= validator.checkField(selNsID);
            
            if(spNameValid.valid){
                spNameCorrecto = true;
            }
            
            if(selNSValid.valid){
                selNSCorrecto= true;
            }
        }
        
        if(spName.value != spName.defaultValue){
            if(spName.value.length > 0){
                spName.value= spName.value.trim();
            }

            let spNameValid = validator.checkField(spName);
            
            if(spNameValid.valid){
                spNameCorrecto = true;
            }
        }
        
        if(selNsID.value != ""){
            
            let selNSValid= validator.checkField(selNsID);
            
            if(selNSValid.valid){
                selNSCorrecto= true;
            }
        }
        
        if(spNameCorrecto && selNSCorrecto){
            // buttonFinish.removeClass("buttonDisabled");
            buttonFinish.prop('disabled', false);
            buttonNext.attr("aria-disabled",false);
        }else{
            // buttonFinish.addClass("buttonDisabled");
            buttonFinish.prop('disabled', true);
            buttonFinish.attr("aria-disabled",true);
        }
    }
}