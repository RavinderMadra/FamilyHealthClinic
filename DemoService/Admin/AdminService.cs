using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.EntityModel;
using ExpressMapper;
using DemoModel.ViewModel;

namespace DemoService.AdminNamespace
{
    
   public  class AdminService
    {
        OnBoadTaskEntities _Context = new OnBoadTaskEntities();

        public List<AppointmentViewModel> GetAppointmentList()
        {
            List<AppointmentViewModel> lstAppointmentViewModel = new List<AppointmentViewModel>();
           
            var tableList = from a in _Context.Appointments
                            join p in _Context.Patients on a.PatientId equals p.Id
                            join t in _Context.AppointmentTimes on a.AppointmentTime equals t.Id
                            select new { table1 = a, table2 = p ,table3=t};
            foreach (var x in tableList)
            {
                AppointmentViewModel appointmentVM = new AppointmentViewModel();
                appointmentVM.Name = x.table2.Name;
                appointmentVM.Phone = x.table2.Phone;
                appointmentVM.Email = x.table2.Email;
                appointmentVM.DateOfBirth = x.table2.DateOfBirth;
                appointmentVM.Address = x.table2.Address;
                appointmentVM.Gender = x.table2.Gender;
                appointmentVM.PatientId = x.table1.PatientId;
                appointmentVM.Problem = x.table1.Problem;
                appointmentVM.AppointmentDate = x.table1.AppointmentDate;
                appointmentVM.AppointmentTimeName = x.table3.Times ;
                appointmentVM.AppointmentTime = (int)x.table3.Id;
                appointmentVM.Id = (int)x.table1.Id;
                lstAppointmentViewModel.Add(appointmentVM);
            }
            

            return lstAppointmentViewModel.ToList();
        }
        public List<AppointmentViewModel> GetPaitentList()
        {
            List<AppointmentViewModel> entities = new List<AppointmentViewModel>();

            var list = _Context.Patients.Where(x => x.IsActive == true).ToList();

            Mapper.Map(list, entities);

            return entities.ToList();
        }
        public AppointmentViewModel GetPatientdetailById(int Id)
        {
            AppointmentViewModel entities = new AppointmentViewModel();

            var list = _Context.Patients.Where(x => x.IsActive == true && x.Id == Id).FirstOrDefault();

            Mapper.Map(list, entities);

            return entities;
        }
        public bool SaveUnAvailableDate(UnAvailableViewModel data)
        {
            bool status = false;
            try
            {
                UnAvailableDate unAvailableDate = new UnAvailableDate();
                Mapper.Map(data, unAvailableDate);
                unAvailableDate.CreatedOn = DateTime.Now;
                unAvailableDate.IsActive = true;
                _Context.UnAvailableDates.Add(unAvailableDate);
                _Context.Configuration.ValidateOnSaveEnabled = true;
                _Context.SaveChanges();
                return status = true;
            }
            catch(Exception ex)
            {
                return status;
            }
           
            
        }
    }
}
