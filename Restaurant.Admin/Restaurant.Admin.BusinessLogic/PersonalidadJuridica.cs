using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class PersonalidadJuridica
    {
        private DC.PersonalidadJuridica data = null;
        public PersonalidadJuridica()
        {
            this.data = new DC.PersonalidadJuridica();
        }

        public List<BE.PersonalidadJuridica> ObtenerPersonalidadesJuridicasActivas()
        {
            return data.ObtenerPersonalidadesJuridicasActivas();
        }
    }
}
