using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_web_api.Models.Entity;
using asp_web_api.Parameters;
using Dapper;
using MySqlConnector;

namespace asp_web_api.Repositories
{
    /// <summary>
    /// 卡片資料操作
    /// </summary>
    public class CardRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectString = @"Server=(LocalDB)\MSSQLLocalDB;Database=Newbie;Trusted_Connection=True;";
        public IEnumerable<CardEntity> GetAll()
        {
            using (var conn = new MySqlConnection(_connectString))
                return conn.Query<CardEntity>("SELECT * FROM card");
        }

        public CardEntity getById(int id)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<CardEntity>("SELECT TOP 1 * FROM Card Where Id = @id", new
                {
                    Id = id,
                });
                return result;
            }

        }

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public CardEntity create(CardParameter cardParameter)
        {
            var sql = @""
        }
    }
}