using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaNET
{
    class Initial
    {
        public static void Menu()
        {
            //Console.WriteLine("MENÚ:"  + " 1-Añadir cita." +  " 2 - Añadir contacto."  + "3 - Consultar cita. " + " 4 - Buscar contacto. " +  " 0 - Salir");
            Console.WriteLine("[_____ MENÚ _____]");
            Console.WriteLine("1 - Añadir Cita ");
            Console.WriteLine("2 - Añadir Contacto");
            Console.WriteLine("3 - Consultar Cita");
            Console.WriteLine("4 - Buscar Contacto");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("Escriba el número de la opción solicitada");

            int nOption = int.Parse(Console.ReadLine());
            OptMenu menu = new OptMenu();

            switch (nOption)
            {
                case 1:
                    menu.AddCita(nOption);
                    break;

                case 2:
                    menu.AddContact();
                    break;

                case 3:
                    menu.ConsultaCita(nOption);
                    break;

                case 4:
                    menu.BuscarContacto(nOption);
                    break;

                case 0:
                    menu.Salir();
                    break;
            }

        }
    }
}
