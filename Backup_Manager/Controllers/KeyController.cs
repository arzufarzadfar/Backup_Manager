using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backup_Manager.APMModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backup_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {



        private readonly APMContext context;

        public KeyController(APMContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<TblKey> Get()
        {
            var result = context.TblKey.Select(s => new TblKey()
            {
               IdCostumer=s.IdCostumer,
               LiKey=s.LiKey,
               StartDate=s.StartDate,
               EndDate=s.EndDate



            }).ToList();

            return result;


        }






    }
}
