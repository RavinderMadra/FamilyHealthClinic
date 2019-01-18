using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoModel.ViewModel
{
   public class AppointmentViewModel
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public string Problem { get; set; }

        public Nullable<System.DateTime> AppointmentDate { get; set; }

        public  int  AppointmentTime { get; set; }

        public Nullable<long> CreatedBy { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public Nullable<long> ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public bool IsActive { get; set; }
        public string AppointmentTimeName { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public Nullable<int> Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Name { get; set; }


    }
}
