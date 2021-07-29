$("#btn_CambiarOrg").click(function () {
    $("#modalBuscarOrg").modal('show');
});

// document.getElementById('btn_AgregarCamposSistemas').onclick= function (){
//     caminoAgregarCamposSistemas();
// };



function caminoAgregarCamposSistemas(){
    let estanciaID = parseInt(document.getElementById("txb_estanciaID").value);
    
    $.ajax({
        url:"/Administrador/AddEstanciaCampo",
        type:"GET",
        dataType:"JSON",
        contentType:'application/json',
        data:{"estanciaID": estanciaID}
    })
}