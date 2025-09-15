
using asp_web_api.Models;
using asp_web_api.Parameters;
using asp_web_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace asp_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardRepository _cardRepository;


        /// <summary>
        /// 建構式
        /// </summary>
        public CardController(CardRepository cardRepository)
        {
            this._cardRepository =cardRepository;
        }

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Card> GetList()
        {
            return this._cardRepository.GetAll().Select(entity=>new Card { 
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            }).ToList();
        }

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public Card Get([FromRoute] int id)
        {
            var result = this._cardRepository.GetById(id);
            if (result is null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return new Card { 
            Id=result.Id,Name=result.Name,Description=result.Description};
        }

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">卡片參數</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] CardParameter parameter)
        {
            var result = this._cardRepository.Create(parameter);
            if (result > 0)
            {
                return Ok();
            }
            return StatusCode(500);
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
            var targetCard = this._cardRepository.GetById(id);
            if (targetCard is null)
            {
                return NotFound();
            }

            var isUpdateSuccess = this._cardRepository.UpdateById(id, parameter);
            if (isUpdateSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
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
            this._cardRepository.DeleteById(id);
            return Ok();
        }
    }
}