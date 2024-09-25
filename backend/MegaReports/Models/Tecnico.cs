using Microsoft.VisualBasic;

namespace MegaReports.Models

{
    public class Tecnico 
    {
        public int id {get; set;}
        public required int Numero_empleado {get; set;}
        public required string nombre {get; set;}
        public required string apellido_P {get; set;}
        public required string apellido_M {get; set;}
        public int cuadrillaId {get; set;}
    }

}