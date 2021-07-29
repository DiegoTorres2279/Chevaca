$("#btn_cambiar_org").click(function (){
    $("#filter_body").html("");
    $("#modalFilterOrgs").modal('show');
});

document.getElementById("btn_filtrar").onclick=filtrarOrgs;

document.getElementById("btn_select_estancia").onclick=selecEstancia;


document.getElementById("filter_body").querySelectorAll("tr td input").onclick=function () {
    filterBodyCkeckbox();  
};

async function selecEstancia(){
    let inputs = document.getElementById("filter_body").querySelectorAll('tr td input');
    let x=0;
    let chk= false;
    let name = "";
    let estanciaID=0;
    let orgID=0;
    let orgSps;

    while(x<inputs.length && !chk){
        let inp = inputs[x];
        if(inp.checked){
            chk = true;
            estanciaID=inp.dataset.est;
            orgID=inp.dataset.org;
            name = inp.dataset.estname;
        }
        x++;
    }
    
    if(chk){
        orgSps= await $.ajax({
            url: '/Administrador/ServiceProfilesByOrgId',
            type:'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            data: {"orgID":orgID}
        });
    }

    if(!chk){
        //Pablo: Lanzar un error en el modal, innetHtml.
        //Si no hay ningun check presionado mostrar un error si no enviarlo al servidor
    }else{
        document.getElementById("txb_EstanciaOrg_OrgID").value = estanciaID;
        document.getElementById("txb_EstanciaOrg_OrgName").value = name;
        
        let select = document.getElementById("select_org_sps");
        select.innerHTML="";
        let opt = document.createElement("option");
        opt.value="";
        opt.text="Choose a Service Profile";
        select.add(opt);

        for(let y=0; y < orgSps.length; y++){
            let sp= orgSps[y];
            let opt = document.createElement("option");
            opt.value=sp.id;
            opt.text=sp.name;
            select.add(opt);
        }
        
        $("#modalFilterOrgs").modal('hide');
    }
}

function filterBodyCkeckbox(checked, bodyID){
    
    let inputs= document.getElementById(bodyID).querySelectorAll('tr td input');
    
    let selectedItem="";
    let x=0;
    let check=false;
    
    while(x < inputs.length && !check ){
        let inpCh= inputs[x];
        if(inpCh.checked === true && inpCh !== checked ){
            if(checked.checked === true){
                inpCh.checked=false;
            }
            check=true;
        }
        x++;
    }
}

async function filtrarOrgs(){
    let Id= parseInt(document.getElementById("txb_filter_id").value);
    let name= document.getElementById("txb_filter_name").value;
    let tbodyRef = document.getElementById("filter_table").getElementsByTagName('tbody')[0];
    tbodyRef.innerHTML="";
    
    let respuesta = await $.ajax({
        method:"GET",
        url:"/Administrador/filtrarestancias",
        dataType:"JSON",
        content: 'application/json; charset=utf-8',
        data:{"estID":Id, "estName":name }
    });
    
    for(let x=0; x < respuesta.length; x++){
        let est= respuesta[x];
        tbodyRef.insertRow().innerHTML=`<td><input id="chkBox_${est.estanciaId}" data-est="${est.estanciaId}" data-estname="${est.name}" data-org="${est.organizationId}" type="checkbox" onchange="filterBodyCkeckbox(this,'filter_body')"></td><td>${est.estanciaId}</td><td>${est.organizationId}</td><td>${est.rut}</td><td>${est.name}</td><td>${est.displayName}</td>`
    }
}