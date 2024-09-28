namespace MegaReports.Models

{
    public class Orden_trabajo
    {
        public int id {get; set;}
        public int Suscriptor_id {get; set;}
        public int trabajo_id {get; set;}
         public int tecnico_id {get; set;}
        public int fecha_inicio {get; set;}
        public int fecha_fin {get; set;} // cuidado con los ints para las fechas 
         public required string estatus {get; set;}
    }
}