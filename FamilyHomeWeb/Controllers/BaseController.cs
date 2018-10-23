using FamilyHomeWeb.Controllers.ExternalSystemControllers;
using FamilyHomeWeb.Models.FinanceModels;
using FamilyHomeWeb.Models.MinerModels;
using FamilyHomeWeb.Models.WeatherModels;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace FamilyHomeWeb.Controllers
{
    public class BaseController : Controller
    {
        protected PanelDetails GetMinerDetails()
        {
            PanelDetails panel = null;
            try
            {
                using (EthosAPIController ethos = new EthosAPIController())
                {
                    panel = JsonConvert.DeserializeObject<PanelDetails>(ethos.GetEthosPanelData());
                    panel.HasAPIError = false;
                    panel.UpdatedDateTime = DateTime.Now;
                }
            }
            catch (WebException ex)
            {
                panel = new PanelDetails
                {
                    HasAPIError = true,
                    ErrorMessage = ex.Message
                };
            }
            return panel;
        }

        protected YahooStockModel GetFinanceModel()
        {
            YahooStockModel stockModel = null;
            try
            {
                using (YahooFinanceAPIController yahoo = new YahooFinanceAPIController())
                {
                    stockModel = yahoo.GetStockDetails();
                    stockModel.HasAPIError = false;
                    stockModel.UpdatedDateTime = DateTime.Now;
                }
            }
            catch (WebException ex)
            {
                stockModel = new YahooStockModel()
                {
                    HasAPIError = true,
                    ErrorMessage = ex.Message
                };
            }
            return stockModel;
        }

        protected OpenWeatherMapModel GetWeatherInformation()
        {
            OpenWeatherMapModel weather = null;
            try
            {
                using (OpenWeatherMapAPIController openWeatherMap = new OpenWeatherMapAPIController())
                {
                    weather = JsonConvert.DeserializeObject<OpenWeatherMapModel>(openWeatherMap.GetOpenWeatherMapData());
                    weather.HasAPIError = false;
                }
            }
            catch (WebException ex)
            {
                weather = new OpenWeatherMapModel
                {
                    HasAPIError = true,
                    ErrorMessage = ex.Message
                };
            }
            return weather;
        }
    }
}