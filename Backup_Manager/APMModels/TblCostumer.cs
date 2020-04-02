using System;
using System.Collections.Generic;

namespace Backup_Manager.APMModels
{
    public partial class TblCostumer
    {
        public TblCostumer()
        {
            TblKey = new HashSet<TblKey>();
        }

        public int IdCostumer { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string MailAdress { get; set; }
        public string Telephon { get; set; }
        public string Company { get; set; }
        public string Adresss { get; set; }
        public string MacAdress { get; set; }
        public string HddNumber { get; set; }
        public string DateStart { get; set; }
        public int? DayStatus { get; set; }
        public int? WeekStatus { get; set; }
        public int? MonthStatus { get; set; }

        public virtual ICollection<TblKey> TblKey { get; set; }
    }
}
