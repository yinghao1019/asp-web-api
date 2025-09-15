using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        /// <summary>
        /// 測試用的資料集合
        /// </summary>
        private static List<Card> _cards = new List<Card>();

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Card> GetList()
        {
            return _cards;
        }
    }
}