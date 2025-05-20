﻿using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace API_Dinamita.Models
{
    public class Eventos
    {
        [Key]
        public int Id_Evento { get; set; }
        public string Nombre_Evento { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Lugar { get; set; }
        public string Direccion_Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public int Duracion { get; set; }
        public int Aforo_Max { get; set; }
        public List<Tickets> Tickets { get; set; } = new List<Tickets>();
        public bool Estado { get; set; }
        public int Id_Categoria { get; set; }
    }
}
