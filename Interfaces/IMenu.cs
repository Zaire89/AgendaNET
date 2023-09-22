using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaNET
{
    interface IMenu
    {
        void AddCita(int nOption);
        void AddContact();
        void ConsultaCita(int nOption);
        void BuscarContacto(int nOption);
        void Salir();
        
    }
}
