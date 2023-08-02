using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Log
    {
        public int LogId { get; set; }
        public int TipoLogId { get; set; }
        public string LogDescripcion { get; set; }
        public string Response { get; set; }


        public TipoLog TipoLog { get; set; }
    }
}
