using HttpCode.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using wdp_Stock.Models;

namespace wdp_Stock.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        //[HttpGet("[action]")]
        //public IEnumerable<ResearchReport> GetResearchReports()
        //{
        //    HttpHelpers httpHelpers = new HttpHelpers();
        //    HttpItems items = new HttpItems();
        //    items.Url = "http://datainterface.eastmoney.com/EM_DataCenter/js.aspx?type=SR&sty=GGSR&ps=500&p=1&mkt=0&stat=0";//请求地址
        //    items.Method = "Get";//请求方式 post
        //    items.ContentType = "application/json; charset=utf-8 ";
        //    //items.Postdata = "{\"CategoryType\":\"SiteHome\"," +
        //    //                    "\"ParentCategoryId\":0," +
        //    //                    "\"CategoryId\":808," +
        //    //                    "\"PageIndex\":" + pageIndex + "," +
        //    //                    "\"TotalPostCount\":4000," +
        //    //                    "\"ItemListActionName\":\"PostList\"}";//请求数据
        //    HttpResults hr = httpHelpers.GetHtml(items);
        //    string jsonStr = hr.Html;
        //    List<ResearchReport> reports = JsonHelper.DeserializeJSON<List<ResearchReport>>(jsonStr.Remove(jsonStr.Length - 1, 1).Remove(0, 1)).Where(c=>c.Title.Contains("超预期")).ToList();
        //    return reports;
        //}
    }
}
