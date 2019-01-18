using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.EntityModel;
using ExpressMapper;
using DemoModel.ViewModel;
using System.Globalization;

namespace DemoService.HomeNamespace
{
    
   public  class HomeService
    {
      OnBoadTaskEntities _Context = new OnBoadTaskEntities();

      public bool SaveAppointment(AppointmentViewModel objAppointment)
        {
            bool status = false;
            try
            {
                Appointment tblAppointment = new Appointment();
                Mapper.Map(objAppointment, tblAppointment);
               // tblAppointment.AppointmentDate = DateTime.ParseExact(objAppointment.AppointmentDate, "MM/dd/yyyy", null);
                tblAppointment.AppointmentDate = objAppointment.AppointmentDate;
                tblAppointment.AppointmentTime = objAppointment.AppointmentTime;
                tblAppointment.Problem = objAppointment.Problem;
                tblAppointment.IsActive = true;
                tblAppointment.CreatedOn = DateTime.Now;
                tblAppointment.ModifiedOn = DateTime.Now;
                tblAppointment.CreatedBy = 101;
                tblAppointment.ModifiedBy = 101;
                //
                var Patient = _Context.Patients.Where(x => x.IsActive == true && x.Phone == objAppointment.Phone
                || x.Email == objAppointment.Email).FirstOrDefault();
                if (Patient == null)
                {
                    Patient tblPatient = new Patient();
                    Mapper.Map(objAppointment, tblPatient);
                    tblPatient.IsActive = true;
                    tblPatient.CreatedOn = DateTime.Now;
                    tblPatient.ModifiedOn = DateTime.Now;
                    tblPatient.CreatedBy = 101;
                    tblPatient.ModifiedBy = 101;
                    tblPatient.DateOfBirth = objAppointment.DateOfBirth;
                    //stblPatient.DateOfBirth= DateTime.ParseExact(objAppointment.DateOfBirth, "MM/dd/yyyy", null);
                    _Context.Patients.Add(tblPatient);
                    _Context.Configuration.ValidateOnSaveEnabled = true;
                    _Context.SaveChanges();
                    objAppointment.PatientId = tblPatient.Id;
                }
                else
                {
                    objAppointment.PatientId = Patient.Id;
                }
                tblAppointment.PatientId = objAppointment.PatientId;
                _Context.Appointments.Add(tblAppointment);
                _Context.Configuration.ValidateOnSaveEnabled = true;
                _Context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {

            }
            
            return status;
            // for new users
        }

        public List<AppointmentTime> GetAvailableAppointmentTime(string date)
        {
            List<AppointmentTime> entities = new List<AppointmentTime>();

            // var list = _Context.AppointmentTimes.Where(x => x.IsActive == true).ToList();
            // list.Remove();
            CultureInfo provider = CultureInfo.InvariantCulture;
            // Output: 10/22/2015 12:00:00 AM  
            DateTime dateTime = DateTime.ParseExact(date, new string[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy","MM/dd/yyyy", "MM-dd-yyyy", "MM.dd.yyyy" },
                provider, DateTimeStyles.None);
            var list = _Context.GetAvailableAppointment(dateTime).ToList();
            Mapper.Map(list, entities);
            return entities.ToList();
        }

    }
}
