using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ReporteTemplate
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DatoEntero1 { get; set; }
        public int DatoEntero2 { get; set; }
        public int DatoEntero3 { get; set; }
        public int DatoEntero4 { get; set; }
        public int DatoEntero5 { get; set; }
        public int DatoEntero6 { get; set; }
        public int DatoEntero7 { get; set; }
        public int DatoEntero8 { get; set; }
        public int DatoEntero9 { get; set; }
        public int DatoEntero10 { get; set; }
        public decimal DatoDecimal1 { get; set; }
        public decimal DatoDecimal2 { get; set; }
        public decimal DatoDecimal3 { get; set; }
        public decimal DatoDecimal4 { get; set; }
        public decimal DatoDecimal5 { get; set; }
        public decimal DatoDecimal6 { get; set; }
        public decimal DatoDecimal7 { get; set; }
        public decimal DatoDecimal8 { get; set; }
        public decimal DatoDecimal9 { get; set; }
        public decimal DatoDecimal10 { get; set; }
        public decimal DatoDecimal11 { get; set; }
        public decimal DatoDecimal12 { get; set; }
        public decimal DatoDecimal13 { get; set; }
        public decimal DatoDecimal14 { get; set; }
        public decimal DatoDecimal15 { get; set; }
        public decimal DatoDecimal16 { get; set; }
        public string DatoString1 { get; set; }
        public string DatoString2 { get; set; }
        public string DatoString3 { get; set; }
        public string DatoString4 { get; set; }
        public string DatoString5 { get; set; }
        public string DatoString6 { get; set; }
        public string DatoString7 { get; set; }
        public string DatoString8 { get; set; }
        public string DatoString9 { get; set; }
        public string DatoString10 { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<VentaProducto> Productos1 { get; set; }
        public List<VentaProducto> Productos2 { get; set; }
        public List<VentaProducto> Productos3 { get; set; }
        public List<VentaProducto> Productos4 { get; set; }
        public List<VentaFormaPago> FormasPago1 { get; set; }
        public List<VentaFormaPago> FormasPago2 { get; set; }
        public List<VentaFormaPago> FormasPago3 { get; set; }
        public List<VentaFormaPago> FormasPago4 { get; set; }
    }
}
