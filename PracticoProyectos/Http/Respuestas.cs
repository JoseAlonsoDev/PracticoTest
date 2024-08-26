using PracticoProyectos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticoProyectos.Http
{
    public class RespuestaBase<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    public class RespuestaApi : RespuestaBase<object>
    {
    }

    public class RespuestaListaDeProyectos : RespuestaBase<List<Proyecto>>
    {
    }

    public class RespuestaProyecto : RespuestaBase<Proyecto>
    {
    }

    public class RespuestaCreacionProyecto : RespuestaBase<Proyecto>
    {
    }
}
