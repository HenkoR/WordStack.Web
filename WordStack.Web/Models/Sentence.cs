using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordStack.Web.Models
{
    public class Sentence
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("stringValue")]
        public string StringValue { get; set; }
    }
}
