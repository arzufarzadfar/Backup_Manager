using System;
using System.Collections.Generic;

namespace Backup_Manager.APMModels
{
    public partial class TblKey
    {
        public int IdKey { get; set; }
        public string LiKey { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? IdCostumer { get; set; }

        public virtual TblCostumer IdCostumerNavigation { get; set; }
    }
}
