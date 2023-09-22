using AgendaNET.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgendaNET
{
    public class Contactos
    {
        bool retorno = false;

        public void BuscarContacto(string name, int nOption) //op 1 y op3
        {
            OptMenu menu = new OptMenu();

            string fsTitle = (nOption == 1 || nOption == 4) ? "contacto.txt" : "agenda.txt";

            FileStream contacto = new FileStream(fsTitle, FileMode.OpenOrCreate); //p op 1

            List<string> listContact = new List<string>();

            byte[] infoFS = new byte[200];
            contacto.Read(infoFS, 0, (int)contacto.Length);
            contacto.Close();

            if (infoFS != null)
            {
                var nombres = ASCIIEncoding.ASCII.GetString(infoFS);
                var cadenasContactos = nombres.Split(';').ToList();
                cadenasContactos.RemoveAt(cadenasContactos.Count - 1); // elimino última fila con los bytes 0

                foreach(var f in cadenasContactos)
                {
                    if (nOption == 1 || nOption == 4)
                    {
                        var contact = ContactUser.ExtraerNombre(f); // op 1 y op4
                        if (contact.Name.Contains(name)) // no trae nombres similares
                        {
                            listContact.Add(contact.Name);
                            retorno = true;
                        }
                    }

                    if (nOption == 3)
                    {
                        var agenda = Agenda.ExtraerFecha(f); // op 3
                        if (agenda.Name.Contains(name)) // no trae nombres similares
                        {
                            listContact.Add(f);
                            retorno = true;
                        }
                    }
                }
            }

            if (retorno)
            {
               Listado(listContact, nOption);
            }
            else
            {
                Console.WriteLine("No se encontraron datos, primero debe Añadir los datos del Contacto");
                menu.AddContact();
            }

        }
        public void GuardarContacto(string name, string apellidos, long telefono, string localidad) //op2
        {
            string contact = $"{name} | {apellidos} | {telefono} | {localidad};";

            FileStream fsC = new FileStream("contacto.txt", FileMode.Append);
            fsC.Write(ASCIIEncoding.ASCII.GetBytes(contact), 0, contact.Length);
            fsC.Close();
        }
        public void Listado(List<string> lista, int nOption)
        {
            int numContact;
            
            if (lista.Count > 0)
            {
                if (nOption == 1 || nOption == 4)
                    Console.WriteLine("Se encontraron estas coincidencias. Tipee el número del contacto, si es uno de ellos:");

                if (nOption == 3)
                    Console.WriteLine("Se encontraron estas citas para esa fecha");

                foreach (var f in lista)
                {
                    Console.WriteLine($"{lista.IndexOf(f)} - {f}");
                }

                numContact = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Se guardará la cita con: {lista[numContact]}.");


            }

        }

        //public static ContactUser ExtraerNombre(string contact)
        //{
        //    var datos = contact.Split('|');

        //    return new ContactUser
        //    {
        //        Name = datos[0],
        //        Apellido = datos[1],
        //        Telefono = int.Parse(datos[2]),
        //        Localidad = datos[3],
        //    };
        //}
        //public void BuscarFecha(string fecha) //op3
        //{
        //    FileStream agenda2 = new FileStream("agenda.txt", FileMode.OpenOrCreate);
        //    //string citaDate = String.Format("{0:dd/MM/yyyy hh:mm}");

        //    List<string> listCitas = new List<string>();

        //    byte[] infoFSc = new byte[100];
        //    agenda2.Read(infoFSc, 0, (int)agenda2.Length);
        //    agenda2.Close();

        //    if (infoFSc != null)
        //    {
        //        var citas = ASCIIEncoding.ASCII.GetString(infoFSc);
        //        var cadenasCitas = citas.Split(';').ToList();
        //        cadenasCitas.RemoveAt(cadenasCitas.Count - 1); // elimino última fila con los bytes 0

        //        foreach (var r in cadenasCitas)
        //        {
        //            var cita = ExtraerFecha(r);

        //            if (cita.Fecha.Trim() == fecha)  //// toma el -guion y barra/ como diferencia x ser String y no date.
        //            {
        //                listCitas.Add(r) ;  
        //                retorno = true;
        //            }
        //            else
        //            {
        //                retorno = false;
        //                Console.WriteLine($"No se encontraron citas en la agenda para la fecha: {fecha}");
        //            }
        //        }
        //    }

        //    if (retorno)
        //        ListadoCitas(listCitas);

        //}
        //public void GuardarCita(string date, string desc, string name) //op 1
        //{
        //    //se guarda/agrega en agenda.txt todos los datos
        //    string ok; 
        //    Console.WriteLine($"Si desea agendar la cita con fecha: {date}, descripción: {desc}, con: {name} - Presione 'S' -");
        //    ok = Console.ReadLine();

        //    if (ok == "S" || ok == "s")
        //    {
        //        string cita = $"{date} | {desc} | {name};";

        //        FileStream agenda2 = new FileStream("./agenda.txt", FileMode.OpenOrCreate);
        //        agenda2.Write(ASCIIEncoding.ASCII.GetBytes(cita), 0, cita.Length);
        //        agenda2.Close();

        //    }

        //}



        //public void ListadoCitas (List<string> lista)
        //{
        //    if (lista.Count > 0)
        //    {
        //        foreach (var f in lista)
        //        {
        //            Console.WriteLine("Se encontraron estas citas para esa fecha");
        //            Console.WriteLine($"{f}");
        //        }
        //    }
        //}


        //public static Agenda ExtraerFecha(string cita)
        //{
        //    var datos = cita.Split('|');

        //    return new Agenda
        //    {
        //        Fecha = datos[0],
        //        Descripcion = datos[1],
        //        Name = datos[2]
        //    };
        //}
    }
}
