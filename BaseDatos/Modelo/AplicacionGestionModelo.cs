using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionGestion.BaseDatos.Modelo {
    internal class AplicacionGestionModelo {
        public class Cliente {
            public int ClientesID { get; set; }
            public string Nombre { get; set; }
            public string Gmail { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }

        public class Categoria {
            public int CategoriasID { get; set; }
            public string Nombre { get; set; }
        }

        public class Producto {
            public int ProductosID { get; set; }
            public string Nombre { get; set; }
            public int CategoriasID { get; set; }
            public double PrecioCompra { get; set; }
            public double PrecioVenta { get; set; }
            public int Stock { get; set; }
        }

        public class Caja {
            public int CajaID { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan AperturaHora { get; set; }
            public double AperturaMonto { get; set; }
            public TimeSpan? CierreHora { get; set; }
            public double? MontoCierre { get; set; }
        }

        public class Movimiento {
            public int MovimientosID { get; set; }
            public int CajaID { get; set; }
            public string Tipo { get; set; } // 'Ingreso' o 'Egreso'
            public string Descripcion { get; set; }
            public double Monto { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class Venta {
            public int VentasID { get; set; }
            public int ClientesID { get; set; }
            public int CajaID { get; set; }
            public DateTime FechaVenta { get; set; }
            public double Total { get; set; }
        }

        public class DetalleVenta {
            public int DetalleVentaID { get; set; }
            public int VentasID { get; set; }
            public int ProductosID { get; set; }
            public int Cantidad { get; set; }
            public string MedioPago { get; set; }
            public double PrecioUnitario { get; set; }
            public double Subtotal { get; set; }
        }

    }
}
