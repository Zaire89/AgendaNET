using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace AgendaNET
{
    class OptMenu : IMenu
    {
        string introName = "Introduzca el nombre con quien se tendrá la cita";
        string fechaaa;
        string descript = string.Empty;
        string name = string.Empty;

        string apellidos = string.Empty;
        long telefono = 0;
        string localidad = string.Empty;

        string ok = string.Empty;
        Contactos con = new Contactos();  
        Citas cCitas = new Citas();
        public void AddCita(int nOption)
        {
            Console.WriteLine("Introduzca día/mes/año y hora.minutos de la cita");


            string d = Console.ReadLine();//DateTime.Parse("01/12/2022");
             
            //d = Console.ReadLine();




            //fechaaa = String.Format("{0:dd/MM/yyyy hh:mm}");
            fechaaa =  Console.ReadLine(); /// como ingresar fecha y horas
            DateTime dtFecha = DateTime.Parse(fechaaa); //2022-12-01   

            Console.WriteLine("Descripción de la cita");
            descript = Console.ReadLine();

            Console.WriteLine(introName);
            name = Console.ReadLine();

            if (name != null)
            {
                con.BuscarContacto(name, nOption);
                cCitas.GuardarCita(dtFecha, descript, name);
            }
        }
        public void AddContact()
        {
            Console.WriteLine(introName);
            name = Console.ReadLine();

            Console.WriteLine("Introduzca sus apellidos");
            apellidos = Console.ReadLine();

            Console.WriteLine("Introduzca su número de teléfono");
            telefono = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Introduzca la localidad");
            localidad = Console.ReadLine();

            Console.WriteLine($"Si desea agendar a {name} {apellidos} | teléfono: {telefono} | localidad: {localidad} - Presione 'S' -");
            ok = Console.ReadLine();

            if (ok == "S" || ok == "s")
            {
                con.GuardarContacto(name,apellidos,telefono,localidad);
            }
            else
            {
                Initial.Menu();
            }

        }

        public void ConsultaCita(int nOption)
        {
            int nConsulta;

            Console.WriteLine("[______ CONSULTAS _____]");
            Console.WriteLine("1 - Consulta por Fecha ");
            Console.WriteLine("2 - Consulta por Contacto");

            Console.WriteLine("Escriba el número de la opción solicitada");
            nConsulta = Convert.ToInt32(Console.ReadLine());

            if (nConsulta == 1)
            {
                Console.WriteLine("Ingrese día/mes/año a consultar");
                ///funcion consulta x fecha
                fechaaa = Console.ReadLine(); /// como ingresar fecha y horas
                DateTime dtF = DateTime.Parse(fechaaa);

                cCitas.BuscarFecha(dtF);
            }
            else if (nConsulta == 2)
            {
                Console.WriteLine("Ingrese el nombre del contacto a consultar");
                ///funcion consulta x contacto
                name = Console.ReadLine();

                /// funcion de busqueda x nombre en agenda en un if (este muestra un listado)
                con.BuscarContacto(name, nOption);
            }
            else
            {
                Console.WriteLine("El número de opción no es válido.");
            }
            
        }

        public void BuscarContacto(int nOption)
        {
            Console.WriteLine("Introduzca el nombre a buscar");
            name = Console.ReadLine();

            con.BuscarContacto(name, nOption);
        }

        public void Salir()
        {
            Console.WriteLine("¿Desea salir de la Agenda?  Presione 'S' para salir");
            ok = Console.ReadLine();

            if (ok == "S" || ok == "s")
            {
                Environment.Exit(0);
            }
            else
            {
                Initial.Menu();
            }
        }
    }
}
