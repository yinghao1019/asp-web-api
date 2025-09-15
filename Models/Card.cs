using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_web_api.Models
{
    /// <summary>
    /// 卡片
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 卡片編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 卡片名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 卡片描述
        /// </summary>
        public string Description { get; set; }
    }
}