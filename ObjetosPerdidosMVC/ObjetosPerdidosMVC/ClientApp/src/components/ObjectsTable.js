import React from 'react';
import './ObjectsTable.css';
function convertDate(inputFormat) {
    if (inputFormat != null && inputFormat != undefined && inputFormat != "") {
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(inputFormat)
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
    }
    else return "";
}
export const ObjectsTable = ({ objectsTable }) => {
    if (objectsTable != undefined) {
        return (
            <div className='objectsTable'>
                <center><h1>Resultados Busqueda</h1></center>
                <table class="table table-striped table-responsive">
                    <thead>
                        <tr>
                            <th>Num Incidencia</th>
                            <th>Iniciativa</th>
                            <th>Objeto</th>
                            <th>Contestacion</th>
                            <th>Estado</th>
                            <th>Fecha Anotacion</th>
                            <th>Fecha Cierre</th>
                            <th>Fecha Contestacion</th>
                            <th>Num Intentos Localizacion</th>
                            <th>Resolucion</th>
                            <th>Dado De Alta</th>
                            <th>Localizado Telefonicamente</th>
                        </tr>
                    </thead>
                    <tbody>
                        {objectsTable.map((object) => {
                                return (
                                    <tr>
                                        <td>{object.NumeroIncidencia}</td>
                                        <td>{object.Iniciativa}</td>
                                        <td>{object.TipoObjeto}</td>
                                        <td>{object.ContestacionTaxistaAlaIncidencia}</td>
                                        <td>{object.Estado}</td>
                                        <td>{convertDate(object.FechaAnotacionIncidencia)}</td>
                                        <td>{convertDate(object.FechaCierreIncidencia)}</td>
                                        <td>{convertDate(object.FechaContestacionTaxistaAlaIncidencia)}</td>                                      
                                        <td>{object.NdeIntentosDeLocalizacion}</td>                                        
                                        <td>{object.Resolucion}</td>
                                        <td>{object.TaxistaDadoDeAltaEnLaApp}</td>                                        
                                        <td>{object.TaxistaLocalizadoTelefonicamente}</td>
                                    </tr>
                                )                                
                            }
                        )}
                    </tbody>
                </table>
            </div>
        )
    }
    else return "";
};
