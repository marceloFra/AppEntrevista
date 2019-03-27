using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppEntrevista.Model
{
    //[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Pregunta
    { 
       public List<Requerimiento> requerimiento { get; set; }
    }

     
}
