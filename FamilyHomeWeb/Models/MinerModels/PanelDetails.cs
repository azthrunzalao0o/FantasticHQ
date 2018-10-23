using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyHomeWeb.Models.MinerModels
{
    public class PanelDetails
    {
        [JsonProperty(PropertyName = "rigs")]
        public Dictionary<string, RigDetails> Rigs { get; set; }
        
        public DateTime UpdatedDateTime { get; set; }
        public bool HasAPIError { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}