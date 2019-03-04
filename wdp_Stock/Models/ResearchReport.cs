using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wdp_Stock.Models
{
    //研报
    public class ResearchReport
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } 
        /// <summary>
        /// 评级
        /// </summary>
        public string Change { get; set; }

        /// <summary>
        /// 2019-03-01T07:24:06
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string InsName { get; set; }

        /// <summary>
        /// 跳转页面编码 
        /// http://data.eastmoney.com/report/20190301/{InfoCode}.html
        /// </summary>
        public string InfoCode { get; set; }

        /// <summary>
        /// 机构编码
        /// http://data.eastmoney.com/report/{InsCode}_0.html
        /// </summary>
        public string InsCode { get; set; }

        /// <summary>
        /// 机构等级?
        /// </summary>
        public string InsStar { get; set; }

        /// <summary>
        /// 不明
        /// </summary>
        public List<string> Jlrs { get; set; }

        public string NewPrice { get; set; }

        /// <summary>
        /// 获利年份
        /// </summary>
        public string ProfitYear { get; set; }

        /// <summary>
        /// 原文评级
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// 股票代码.市场
        /// </summary>
        public string SecuFullCode { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        public string SecuName { get; set; }

        /// <summary>
        /// 不明
        /// </summary>
        public string SratingName { get; set; }

        /// <summary>
        /// 不明
        /// </summary>
        public string Sy { get; set; }
        /// <summary>
        /// 三年预测市盈率
        /// </summary>
        public List<string> Syls { get; set; }

        /// <summary>
        /// 三年预测每股收益
        /// </summary>
        public List<string> Sys { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类型? 不明
        /// </summary>
        public string Type { get; set; }
    }
}
