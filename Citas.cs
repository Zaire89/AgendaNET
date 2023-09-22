using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgendaNET
{
    public class Citas
    {
        bool retorno = false;
        public void BuscarFecha(DateTime fecha) //op3
        {
            FileStream agenda2 = new FileStream("agenda.txt", FileMode.OpenOrCreate);

            List<string> listCitas = new List<string>();

            byte[] infoFSc = new byte[100];
            agenda2.Read(infoFSc, 0, (int)agenda2.Length);
            agenda2.Close();

            if (infoFSc != null)
            {
                var citas = ASCIIEncoding.ASCII.GetString(infoFSc);
                var cadenasCitas = citas.Split(';').ToList();
                cadenasCitas.RemoveAt(cadenasCitas.Count - 1); // elimino última fila con los bytes 0

                foreach (var r in cadenasCitas)
                {
                    var cita = Agenda.ExtraerFecha(r);

                    if (cita.Fecha == fecha)  //// toma el -guion y barra/ como diferencia x ser String y no date.
                    {
                        listCitas.Add(r);
                        retorno = true;
                    }
                }
            }

            if (retorno)
                ListadoCitas(listCitas);
            else
            {
                Console.WriteLine($"No se encontraron citas en la agenda para la fecha: {fecha}");
            }

        }
        public void GuardarCita(DateTime date, string desc, string name) //op 1
        {
            string ok;
            Console.WriteLine($"Si desea agendar la cita con fecha: {date}, descripción: {desc}, con: {name} - Presione 'S' -");
            ok = Console.ReadLine();

            if (ok == "S" || ok == "s")
            {
                string cita = $"{date} | {desc} | {name};";

                FileStream agenda2 = new FileStream("agenda.txt", FileMode.Append);
                agenda2.Write(ASCIIEncoding.ASCII.GetBytes(cita), 0, cita.Length);
                agenda2.Close();

            }

        }

        /// <summary>
        /// /// ---------------------------------------hacer una unica q cree lista
        /// </summary>
        /// <param name="lista"></param>
        public void ListadoCitas(List<string> lista)
        {
            if (lista.Count > 0)
            {
                foreach (var f in lista)
                {
                    Console.WriteLine("Se encontraron estas citas para esa fecha");
                    Console.WriteLine($"{f}");
                }
            }
        }

       
    }
}
