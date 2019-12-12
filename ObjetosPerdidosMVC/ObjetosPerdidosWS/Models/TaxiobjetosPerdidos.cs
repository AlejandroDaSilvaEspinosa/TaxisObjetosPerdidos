using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ObjetosPerdidosWS.Models
{
    public partial class TaxiobjetosPerdidos
    {
        [Key]
        public short NumeroIncidencia { get; set; }
        public string Iniciativa { get; set; }
        public string TipoObjeto { get; set; }
        public DateTime? FechaAnotacionIncidencia { get; set; }
        public DateTime? FechaCierreIncidencia { get; set; }
        public string TaxistaDadoDeAltaEnLaApp { get; set; }
        public string ContestacionTaxistaAlaIncidencia { get; set; }
        public DateTime? FechaContestacionTaxistaAlaIncidencia { get; set; }
        public string TaxistaLocalizadoTelefonicamente { get; set; }
        public byte? NdeIntentosDeLocalizacion { get; set; }
        public string Estado { get; set; }
        public string Resolucion { get; set; }
    }
}
