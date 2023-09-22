using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaNET.Clases
{
    public class ContactUser
    {
        public int IdC { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Localidad { get; set; }

        public static ContactUser ExtraerNombre(string contact)
        {
            var datos = contact.Split('|');

            return new ContactUser
            {
                Name = datos[0],
                Apellido = datos[1],
                Telefono = int.Parse(datos[2]),
                Localidad = datos[3],
            };
        }

    }
}
