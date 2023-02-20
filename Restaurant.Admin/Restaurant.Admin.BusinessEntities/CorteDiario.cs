using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class CorteDiario
    {
        public int CorteDiarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal MontoFinal { get; set; }
        public DateTime FechaRegistroMontoInicial { get; set; }
        public DateTime FechaRegistroMontoFinal { get; set; }
        public int FormaPagoId { get; set; }


        public Usuario Usuario { get; set; }
        public FormaPago FormaPago { get; set; }
    }
}
