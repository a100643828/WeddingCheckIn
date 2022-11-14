using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAPI.Model;
using WeddingAPI.Parameter;

namespace WeddingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingController : ControllerBase
    {
        private readonly ILogger<WeddingController> _logger;
        private readonly MySqlConnectionStringBuilder _mySqlConnectionStringBuilder;
        private readonly string _connectString = "Server=/cloudsql/positiontest:us-west1:XXXX;Uid=root;Password=Vcxf]pgxx1o-^h>N;Database=MySchema;Protocol=unix";

        public WeddingController(ILogger<WeddingController> logger, MySqlConnectionStringBuilder mySqlConnectionStringBuilder)
        {
            _logger = logger;
            _mySqlConnectionStringBuilder = mySqlConnectionStringBuilder;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("test");
        }

        [HttpPost("Guest")]
        public GuestWithTable Create([FromBody] CreateGuest createGuest)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                string sql = @"
                    INSERT INTO `MySchema`.`guest`
                    (`Name`,`Owner`,`Relation`,`WeddingCake`,`NameForSearch`,`Partner`)
                    VALUES
                    (@Name,@Owner,@Relation,@WeddingCake,@NameForSearch,@Partner);
                    select * from MySchema.guest
                    left join MySchema.table on table.Id = guest.TableId
                    where guest.Id = LAST_INSERT_ID();";
                var result = conn.Query<Guest, Table, GuestWithTable>(sql, (g, t) => { return new GuestWithTable { Guest = g, Table = t }; }, new
                {
                    Name = createGuest.Name,
                    Owner = createGuest.Owner.ToString(),
                    Relation = createGuest.Relation.ToString(),
                    WeddingCake = createGuest.WeddingCake ? WeddingCake.小餅.ToString() : WeddingCake.無須領取.ToString(),
                    NameForSearch = createGuest.Name,
                    Partner = createGuest.Partner
                }, splitOn: "Id");
                if (!result.Any())
                    throw new Exception("新增失敗");
                return result.First();

            }

        }

        /// <summary>
        /// 取得賓客資訊&座位
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Guest/{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                using (var conn = new MySqlConnection(_connectString))
                {
                    string sql = @"
                    select * from MySchema.guest
                    left join MySchema.table on table.Id = guest.TableId
                    where NameForSearch like @name;";
                    var result = conn.Query<Guest, Table, GuestWithTable>(sql, (g, t) => { return new GuestWithTable { Guest = g, Table = t }; }, new { name = $"%{name}%" }, splitOn: "Id");
                    if (!result.Any())
                        return NotFound();
                    return Ok(result.First());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" <=== Get Error ===>");
                throw;
            }
        }

        /// <summary>
        /// 依所屬人&關係取得賓客名單
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        [HttpGet("Guests/{owner}/{relation}")]
        public IEnumerable<GuestIdAndName> Get(Owner owner, Relation relation)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                string sql = @"
                    select Id, Name from MySchema.guest
                    where Owner = @owner and Relation = @relation";
                var result = conn.Query<GuestIdAndName>(sql, new { owner = owner.ToString(), relation = relation.ToString() });
                return result;
            }
        }

        /// <summary>
        /// 更新賓客禮金
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPatch("Guest/{id}/CashGift/{amount}")]
        public bool UpdateCashGift(int id, int amount)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                string sql = @"update MySchema.guest set CashGift = @amount where Id = @id";
                var result = conn.Execute(sql, new { amount, id });
                return result > 0;
            }
        }
    }
}
