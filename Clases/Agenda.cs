using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaNET
{
    public class Agenda
    {
        public int IdA { get; set; }
        public string Name { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public static Agenda ExtraerFecha(string cita)
        {
            var datos = cita.Split('|');

            return new Agenda
            {
                Fecha = datos[0],
                Descripcion = datos[1],
                Name = datos[2]
            };
        }

    }
}
