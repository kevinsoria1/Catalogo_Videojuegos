using System;

namespace Login1
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime FechaBloqueo { get; set; } // <--- NUEVO: Hora del bloqueo

        public Usuario() { }

        public Usuario(string user, string pass)
        {
            Username = user;
            Password = pass;
            IntentosFallidos = 0;
            FechaBloqueo = DateTime.MinValue; // Por defecto, una fecha muy antigua
        }
    }
}