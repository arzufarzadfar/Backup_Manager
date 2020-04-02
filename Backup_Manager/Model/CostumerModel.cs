using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backup_Manager.Model
{
    public class CostumerModel
    {


        public int IdCostumer { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string MailAdress { get; set; }
        public string Telephon { get; set; }
        public string Company { get; set; }
        public string Adresss { get; set; }
        public string DateStart { get; set; }
        public int? DayStatus { get; set; }
        public int? WeekStatus { get; set; }
        public int? MonthStatus { get; set; }
    }
}
