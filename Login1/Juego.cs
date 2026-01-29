using System;

namespace Login1
{
    public class Juego
    {
        // Estas propiedades coinciden EXACTAMENTE con tu tabla de MySQL
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Fabricante { get; set; }
        public int Anio { get; set; }

        // La imagen en base de datos es BLOB, aquí es un array de bytes
        public byte[] Imagen { get; set; }

        // Visible en BD es TINYINT(1), aquí es bool (true/false)
        public bool Visible { get; set; }

        // Constructor vacío
        public Juego() { }

        // Constructor para crear juegos rápidamente (sin ID, porque es automático)
        public Juego(string titulo, string descripcion, decimal precio, string categoria, string fab, int anio, byte[] img, bool visible)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            Fabricante = fab;
            Anio = anio;
            Imagen = img;
            Visible = visible;
        }
    }
}