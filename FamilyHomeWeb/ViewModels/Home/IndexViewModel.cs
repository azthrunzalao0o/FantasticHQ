using FamilyHomeWeb.Models.EntityFramework;
using FamilyHomeWeb.Models.FinanceModels;
using FamilyHomeWeb.Models.MinerModels;
using FamilyHomeWeb.Models.WeatherModels;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FamilyHomeWeb.ViewModels.Home
{
    public class IndexViewModel
    {
        public string ZipCode { get => ConfigurationManager.AppSettings["LocationZipCode"]; }
        public OpenWeatherMapModel WeatherModel { get; set; }
        public PanelDetails MinerModel { get; set; }
        public YahooStockModel StockModel { get; set; }
        public List<Reminder> Reminders { get; set; }

        public string PartOftheDay
        {
            get
            {
                int hourHand = DateTime.Now.Hour;
                if (hourHand >= 4 && hourHand <= 11)
                {
                    return @"Morning";
                }
                else if (hourHand >= 12 && hourHand <= 6)
                {
                    return @"Afternoon";
                }
                else
                {
                    return @"Evening";
                }
            }
        }
    }
}