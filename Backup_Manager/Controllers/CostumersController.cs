using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backup_Manager.APMModels;
using Backup_Manager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backup_Manager.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {


        private readonly APMContext context;

        public CostumersController(APMContext context)
        {
            this.context = context;
        }






        [HttpGet]
        public List<CostumerModel> Get()
        {
            var result = context.TblCostumer.Select(s => new CostumerModel()
            {
                IdCostumer = s.IdCostumer,
                Name = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.Name)),
                Family = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.Family)),
                MailAdress = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.MailAdress)),
                Telephon = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.Telephon)),
                Company = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.Company)),
                Adresss = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s.Adresss)),
                DateStart = s.DateStart,
                DayStatus = s.DayStatus,
                WeekStatus = s.WeekStatus,
                MonthStatus = s.MonthStatus


            }).ToList();

            return result;


        }


        [HttpGet("key")]
        public async Task<ActionResult<TblKey>>Getkey([FromHeader]int id)
        {

            var result = context.TblCostumer.Where(x => x.IdCostumer == id)

                .Include(c => c.TblKey)
                .ThenInclude(v=>v.LiKey)
               
                .ToList();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
