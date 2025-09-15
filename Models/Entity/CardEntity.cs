using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_web_api.Models.Entity
{
    public class CardEntity
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

        /// <summary>
        /// 攻擊力
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// 花費
        /// </summary>
        public int Cost { get; set; }
    }
}