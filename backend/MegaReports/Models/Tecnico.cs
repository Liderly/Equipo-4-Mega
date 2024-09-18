using Microsoft.VisualBasic;

namespace MegaReports.Models

{
    public class Tecnico 
    {
        public int id {get; set;}
        public required string nombre {get; set;}
        public required string apellidos {get; set;}
        public int cuadrilla_id {get; set;}
    }

}