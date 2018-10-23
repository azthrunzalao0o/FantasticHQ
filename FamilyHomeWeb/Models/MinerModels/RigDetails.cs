using Newtonsoft.Json;
using System;

namespace FamilyHomeWeb.Models.MinerModels
{
    public class RigDetails
    {
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }
        [JsonProperty(PropertyName = "hash")]
        public double RigHashes { get; set; }
        [JsonProperty(PropertyName = "miner_instance")]
        public string MinerInstance { get; set; }

        [JsonProperty(PropertyName = "gpus")]
        public string GpusString { get; set; }
        public int Gpus { get => Convert.ToInt32(GpusString); }


        [JsonProperty(PropertyName = "uptime")]
        public string UpTimeString { get; set; }
        public string ServerUpStatus
        {
            get
            {
                int uptime = Convert.ToInt32(UpTimeString);
                DateTime startTime = DateTime.Now.AddSeconds(uptime * -1);
                return startTime.ToString(@"MMM dd, HH:mm tt");
            }
        }
        public string UpTimeStatus
        {
            get
            {
                decimal uptime = Convert.ToDecimal(UpTimeString);
                decimal days = Math.Floor(uptime / (24 * 60 * 60));
                uptime -= days * 24 * 60 * 60;
                decimal hours = Math.Floor(uptime / (60 * 60));
                uptime -= hours * 60 * 60;
                decimal minutes = Math.Floor(uptime / 60);
                decimal seconds = uptime - minutes * 60;
                return $"{days}days {hours}hrs {minutes}mins {seconds}secs";
            }
        }

        [JsonProperty(PropertyName = "temp")]
        public string TempsString { get; set; }
        public double[] Temperatures { get => Array.ConvertAll(TempsString.Split(' '), double.Parse); }
        public double RigAvgTemperature
        {
            get
            {
                double totalTemp = 0;
                foreach (double aTemp in Temperatures)
                {
                    totalTemp += aTemp;
                }
                return totalTemp / Gpus;
            }
        }

        [JsonProperty(PropertyName = "miner_hashes")]
        public string MinerHashesString { get; set; }
        public double[] MinerHashes { get => Array.ConvertAll(MinerHashesString.Split(' '), double.Parse); }

        [JsonProperty(PropertyName = "watts")]
        public string MinerWattsString { get; set; }
        public int[] MinerWatts { get => Array.ConvertAll(MinerWattsString.Split(' '), int.Parse); }
    }
}