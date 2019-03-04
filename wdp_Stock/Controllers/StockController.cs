using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpCode.Core;
using Microsoft.AspNetCore.Mvc;
using wdp_Stock.Models;

namespace wdp_Stock.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        
        [HttpGet("[action]")]
        [ResponseCache(Duration = 3600)]
        public IEnumerable<ResearchReport> GetResearchReports()
        {
            HttpHelpers httpHelpers = new HttpHelpers();
            HttpItems items = new HttpItems();
            items.Url = "http://datainterface.eastmoney.com/EM_DataCenter/js.aspx?type=SR&sty=GGSR&ps=500&p=1&mkt=0&stat=0";//请求地址
            items.Method = "Get";//请求方式 post
            items.ContentType = "application/json; charset=utf-8 ";
            //items.Postdata = "{\"CategoryType\":\"SiteHome\"," +
            //                    "\"ParentCategoryId\":0," +
            //                    "\"CategoryId\":808," +
            //                    "\"PageIndex\":" + pageIndex + "," +
            //                    "\"TotalPostCount\":4000," +
            //                    "\"ItemListActionName\":\"PostList\"}";//请求数据
            HttpResults hr = httpHelpers.GetHtml(items);
            string jsonStr = hr.Html;
            List<ResearchReport> reports = JsonHelper.DeserializeJSON<List<ResearchReport>>(jsonStr.Remove(jsonStr.Length - 1, 1).Remove(0, 1)).Where(c => c.Title.Contains("超预期")).ToList();
            return reports;
        }
    }
}