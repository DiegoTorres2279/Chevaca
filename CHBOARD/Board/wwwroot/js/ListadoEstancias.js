document.getElementById("btn_Borrarestancias").onclick = BorrarBulk; 

async function BorrarBulk(){
    let lands= document.getElementById("tbody_lista_estancias").querySelectorAll('tr td input');
    // let ids = [];
    let ids= new Array();
    
    for(let x=0; x<lands.length; x++){
        let est = lands[x];
        
        if(est.checked){
            ids.push(parseInt(est.dataset.est));
        }
    }
    
    let obj = JSON.stringify(ids).toString();
    
    let result = await $.ajax({
       url: '/Administrador/BorrarestanciasBulk',
       type: 'GET',
       dataType: 'JSON',
       contentType: 'application/json; charset=utf-8',
       data: {"idx":obj}
    });
    
    console.log(result);

    EvaluarBorrado(result);
}

function EvaluarBorrado(lands){
    
    let hayErrores = false;
    let x = 0;
    
    while (x < lands.listDeleted.length && !hayErrores){
        let est = lands.listDeleted[x];
        if(est.operationResult !== 0){
            hayErrores = true;
        }
        x++;
    }

    if (!hayErrores){
        window.location.href = "/Administrador/Listadoestancias";
    }else{
        //Mostrar un board
    }
    
}