
using asp_web_api.Models;
using asp_web_api.Parameters;
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
        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">卡片參數</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult insert([FromBody] CardParameter cardParameter)
        {
            _cards.Add(new Card()
            {
                Id = _cards.Any()
          ? _cards.Max(card => card.Id) + 1
          : 0, // 臨時防呆，如果沒東西就從 0 開始
                Name = cardParameter.Name,
                Description = cardParameter.Description
            });
            return Ok();

        }

        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">卡片參數</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] CardParameter parameter)
        {
            var targetCard = _cards.FirstOrDefault(card => card.Id == id);
            if (targetCard is null)
            {
                return NotFound();
            }

            targetCard.Name = parameter.Name;
            targetCard.Description = parameter.Description;

            return Ok();
        }


        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _cards.RemoveAll(card => card.Id == id);
            return Ok();
        }
    }
}