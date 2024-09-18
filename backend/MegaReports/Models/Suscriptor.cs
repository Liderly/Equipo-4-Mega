namespace MegaReports.Models

{
    public class Suscriptor
    {
        public int id {get; set;}
        public required string nombre {get; set;}
        public required string apellidos {get; set;}
        public required string domicilio {get; set;}
        public required int telefono {get; set;}
    }

}