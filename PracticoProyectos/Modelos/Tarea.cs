using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticoProyectos.Modelos
{
    public class Tarea
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime Start_date { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("hours")]
        public string Hours { get; set; }

        [JsonPropertyName("area")]
        public string area { get; set; }

        [JsonPropertyName("project_id")]
        public string Project_id { get; set; }

        [JsonPropertyName("user_id")]
        public string User_id { get; set; }

    }
}
