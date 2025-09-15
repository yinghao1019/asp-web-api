using asp_web_api.Models.Entity;
using asp_web_api.Parameters;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

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

        public CardEntity GetById(int id)
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
        public int Create(CardParameter cardParameter)
        {
            var sql =
     @"
        INSERT INTO Card 
        (
            Name,
            Description,
            Attack,
            Health,
            Cost
        ) 
        VALUES 
        (
            @Name,
            @Description,
            @Attack,
            @Health,
            @Cost
        );

        SELECT LAST_INSERT_ID();
    ";

            using (var conn = new MySqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<int>(sql, cardParameter);
                return result;
            }
        }

        /// <summary>
        /// 修改卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public bool UpdateById(int id, CardParameter cardParameter) {
            var sql = @"  UPDATE Card
        SET 
             Name = @Name
            ,Description = @Description
            ,Attack = @Attack
            ,Health = @Health
            ,Cost = @Cost
        WHERE 
            Id = @id";

            var dynamicParams=new DynamicParameters();
            dynamicParams.Add("Id", id,System.Data.DbType.Int32);
            using (var conn = new MySqlConnection(_connectString)) {
                var result = conn.Execute(sql, dynamicParams);
                return result > 0;
            }
        }


        public void DeleteById(int id) {
            var sql =
       @"
            DELETE FROM Card
            WHERE Id = @Id
        ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new MySqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
            }
        }
    }
}