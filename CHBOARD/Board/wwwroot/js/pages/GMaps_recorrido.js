var GMaps_map_recorrido;
var GMaps_update_thread_recorrido;
// Crear polígonos en mapas: http://apps.headwallphotonics.com/

var GMap_polygon_recorrido;
var nodo_nombre;

$(document).ready(function () {
    cargarEventos_recorrido();

    setTimeout(function () {
        if (isMobile()) {
            $("#GMaps_map_recorrido_ID").css("height", "400px");
        } else {
        }
    }, 1000);
});

function init_recorrido() {
    iniciarMapa_recorrido(); // Inicia el mapa
    getNodosDelBackend_recorrido(); // Inicia marcadores
}

function cargarEventos_recorrido() {
    $('#txtCantidadMinutos').bootstrapNumber();
}

// Dibujar área en mapa | Ojo con el orden de los datos en el array Lat y Long
function iniciarMapa_recorrido() {

    var map_index = $('#ddlListaMapas')[0].selectedIndex;
    if (map_index !== null && map_index !== undefined) {

        GMaps_map_recorrido = new google.maps.Map(document.getElementById("GMaps_map_recorrido_ID"), {
            center: GMaps_lista_mapas[map_index].mapa_posicion_inicial,
            //center: { lat: -32.22765760461139, lng: -54.14543190267292 },
            zoom: 14,
            mapTypeId: 'satellite',
            disableDefaultUI: true
        });

        GMap_polygon_recorrido = new google.maps.Polygon({
            /*
            paths: GMaps_campo_taladro,
            strokeColor: 'rgb(8, 47, 104)',
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: 'rgba(12, 98, 189, 0.47)',
            fillOpacity: 0.35,
            */
            paths: GMaps_lista_mapas[map_index].mapa_perimetro,
            strokeColor: 'rgb(8, 47, 104)',
            strokeOpacity: 1,
            strokeWeight: 3,
            fillColor: 'rgba(12, 98, 189, 0.47)',
            fillOpacity: 0.24,
        });

        GMap_polygon_recorrido.setMap(GMaps_map_recorrido);
    }
}

function actualizarHistorial() {
    init_recorrido();
}

function getNodosDelBackend_recorrido() {
    nodo_nombre = $("#txtNodo_nombre").val();
    var cantidadMinutos = $("#txtCantidadMinutos").val();
    
    if (nodo_nombre !== null && nodo_nombre !== undefined && cantidadMinutos !== null && cantidadMinutos !== undefined) {

        var cantidad_ultimos_minutos_int = TryParseInt(cantidadMinutos, 10);
        if (cantidad_ultimos_minutos_int > 0) {

            // Ajax call parameters
            console.log("Ajax call: /Board/Dashboard/GetNodos_Recorrido Params:");
            console.log("nodo_nombre, type: " + type(nodo_nombre) + ", value: " + nodo_nombre);
            console.log("cantidad_ultimos_minutos_int, type: " + type(cantidad_ultimos_minutos_int) + ", value: " + cantidad_ultimos_minutos_int);

            // Ejemplo: https://www.yogihosting.com/jquery-ajax-aspnet-core/
            //https://stackoverflow.com/questions/26371688/asp-net-mvc-ajax-post-returns-404-not-found

            $.ajax({
                type: "POST",
                url: "/Board/Dashboard/GetNodos_Recorrido",
                data: { nodo_nombre: nodo_nombre, cantidad_ultimos_minutos_int: cantidad_ultimos_minutos_int },
                success: function (response) {
                    if (response !== null && response !== undefined) {
                        if (response.length > 0) {
                            console.log("---- Recorrido_resultados: " + response.length);
                            colocarMarcadores_recorrido(response);
                        } else {
                            console.log("---- Recorrido_resultados: 0");
                        }
                    } else {
                        console.log("---- Recorrido_resultados: NULL");
                    }
                }, // end success
                failure: function (response) {
                    console.log("---- Recorrido_resultados: ERROR");
                }
            }); // Ajax    
        }
    }
}

function colocarMarcadores_recorrido(locations_array) {
    if (locations_array.length > 0) {

        var divCantidadResultados = $("#divCantidadResultados");
        if (divCantidadResultados !== null && divCantidadResultados !== undefined) {
            divCantidadResultados.text(locations_array.length);
        }

        var isRecorridoSaleDelPredio = false;
        var lista_nodos = [];
        var nodo_informacion_ultimaPosicion;

        for (var i = 0; i < locations_array.length; i++) {
            var Gateway = check_nullValues(locations_array[i].applicationName);
            var Nodo = check_nullValues(locations_array[i].deviceName);
            var Alt = check_nullValues(locations_array[i].alt);
            var Hdop = check_nullValues(locations_array[i].hdop);
            var Latitud = check_nullValues(locations_array[i].latitud);
            var Longitud = check_nullValues(locations_array[i].longitud);

            var DatetimeFin = moment(check_nullValues(locations_array[i].datetime_Fin), "YYYY-MM-DD").format("DD-MM-YYYY");

            console.log("");
            console.log("Posición: " + (i + 1));
            console.log("DatetimeFin, type: " + type(DatetimeFin) + ", value: " + DatetimeFin);
            console.log("Gateway, type: " + type(Gateway) + ", value: " + Gateway);
            console.log("Nodo, type: " + type(Nodo) + ", value: " + Nodo);
            console.log("Alt, type: " + type(Alt) + ", value: " + Alt);
            console.log("Hdop, type: " + type(Hdop) + ", value: " + Hdop);
            console.log("Latitud, type: " + type(Latitud) + ", value: " + Latitud);
            console.log("Longitud, type: " + type(Longitud) + ", value: " + Longitud);
            console.log("----------------------------");

            if (Latitud !== "" || Longitud !== "") {
                nodo_informacion_ultimaPosicion = { DatetimeFin: DatetimeFin, Gateway: Gateway, Nodo: Nodo, Alt: Alt, Hdop: Hdop, Latitud: Latitud, Longitud: Longitud }
                var nodo_posicion = { lat: TryParseFloat(Latitud, 0), lng: TryParseFloat(Longitud, 0) }; // formato de Google maps

                // Si es Nodo 1 ==> Localiza el mapa
                if (i === 0) {
                    GMaps_map_recorrido.setCenter(nodo_posicion);
                    GMaps_map_recorrido.setZoom(18); //20
                }

                //agregarMarcador_recorrido(nodo_posicion, nodo_info);
                if (isRecorridoAfueraZona(nodo_posicion)) {
                    isRecorridoSaleDelPredio = true;
                }

                lista_nodos.push(nodo_posicion);
            }
        } // for

        dibujarLineas_recorrido(lista_nodos, nodo_informacion_ultimaPosicion, isRecorridoSaleDelPredio);
    }
}

function dibujarLineas_recorrido(lista_nodos, nodo_informacion_ultimaPosicion, isRecorridoSaleDelPredio) {

    // nodo_informacion_ultimaPosicion: llega con la info completa de la última posición del recorrido
    if (lista_nodos !== null && lista_nodos.length > 0 && nodo_informacion_ultimaPosicion !== null && nodo_informacion_ultimaPosicion !== undefined) {        
        if (lista_nodos.length > 1) {

            var posicion_primera = lista_nodos[0];
            var posicion_ultima = lista_nodos[lista_nodos.length - 1];
            if (posicion_primera !== null && posicion_primera !== undefined && posicion_ultima !== null && posicion_ultima !== undefined) {
                var recorrido_color = "#00FF00"; // Verde
                if (isRecorridoSaleDelPredio) {
                    recorrido_color = "#FF0000"; // Rojo
                }

                // Dibuja el recorrido
                const nodos_recorrido = new google.maps.Polyline({
                    path: lista_nodos,
                    geodesic: true,
                    strokeColor: recorrido_color,
                    strokeOpacity: 1.0,
                    strokeWeight: 6
                });
                nodos_recorrido.setMap(GMaps_map_recorrido);

                agregarMarcador_recorrido(posicion_primera, nodo_informacion_ultimaPosicion, false);
                agregarMarcador_recorrido(posicion_ultima, nodo_informacion_ultimaPosicion, true);
            }
        } else {
            agregarMarcador_recorrido(lista_nodos[0], nodo_informacion_ultimaPosicion, true);
        }

    }
}

function isRecorridoAfueraZona(nodo_posicion) {
    if (nodo_posicion !== null && nodo_posicion !== undefined) {
        var point = new google.maps.LatLng(nodo_posicion.lat, nodo_posicion.lng);
        return google.maps.geometry.poly.containsLocation(point, GMap_polygon_recorrido) ? false : true;
    }
    return false;
}

function agregarMarcador_recorrido(nodo_posicion, nodo_informacion_ultimaPosicion, esNodoInicio) {
    if (nodo_posicion !== null && nodo_posicion !== undefined && nodo_informacion_ultimaPosicion !== null && nodo_informacion_ultimaPosicion !== undefined) {
        var point = new google.maps.LatLng(nodo_posicion.lat, nodo_posicion.lng);

        const is_nodo_adentro = google.maps.geometry.poly.containsLocation(point, GMap_polygon_recorrido) ? true : false;

        var icon_url = GMaps_marcador_verde_inicio;
        if (!esNodoInicio) {
            icon_url = GMaps_marcador_verde_fin;
        }

        if (!is_nodo_adentro) {
            icon_url = GMaps_marcador_rojo_inicio;
            if (!esNodoInicio) {
                icon_url = GMaps_marcador_rojo_fin;
            }
        }

        var icon = {
            url: icon_url,
            scaledSize: new google.maps.Size(40, 40), // scaled size
            origin: new google.maps.Point(0, 0), // origin
            anchor: new google.maps.Point(20, 20) // anchor
        };

        var marcador = new google.maps.Marker({
            position: nodo_posicion,
            map: GMaps_map_recorrido,
            title: nodo_informacion_ultimaPosicion.Nodo,
            icon: icon
        });

        var marcador_contenido =
            '<div id="content">' +
            '<h3 id="firstHeading" class="firstHeading">' + nodo_informacion_ultimaPosicion.Nodo + '</h3>' +
            '<div id="bodyContent">' +
            "<p>" +
            "Última actualización = " + nodo_informacion_ultimaPosicion.DatetimeFin +
            "</p>" +
            "</div>" +
            "</div>";

        var infowindow = new google.maps.InfoWindow({
            content: marcador_contenido
        });

        marcador.addListener("click", () => {
            infowindow.open(GMaps_map_recorrido, marcador);
        });
    }
}