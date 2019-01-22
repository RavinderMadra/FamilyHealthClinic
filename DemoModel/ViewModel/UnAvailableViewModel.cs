using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoModel.ViewModel
{
   public class UnAvailableViewModel
    {
        public long Id { get; set; }

        //public long PatientId { get; set; }

        //public string Problem { get; set; }

        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public  string Reason { get; set; }

        public Nullable<long> CreatedBy { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public Nullable<long> ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public bool IsActive { get; set; }
        

    }
}
