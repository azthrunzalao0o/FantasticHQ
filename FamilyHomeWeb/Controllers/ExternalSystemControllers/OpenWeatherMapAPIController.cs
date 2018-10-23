using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace FamilyHomeWeb.Controllers.ExternalSystemControllers
{
    public class OpenWeatherMapAPIController : IDisposable
    {
        public string GetOpenWeatherMapData()
        {
            try
            {
                string apiKey = ConfigurationManager.AppSettings["OpenWeatherMapAPIKey"];
                string zipCode = ConfigurationManager.AppSettings["LocationZipCode"];
                string countryCode = ConfigurationManager.AppSettings["CountryCode"];
                string uri = BuildAPIUriString(zipCode, countryCode, apiKey);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = @"GET";
                request.Accept = @"application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw new WebException(@"There is an ERROR using OpenWeatherMap API.");
            }
        }

        private string BuildAPIUriString(string zipCode, string countryCode, string apiKey)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&units=metric&APPID={apiKey}";
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~OpenWeatherMapAPI() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}