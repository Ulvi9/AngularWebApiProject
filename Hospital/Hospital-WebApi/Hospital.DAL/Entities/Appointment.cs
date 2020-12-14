using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Hospital.DAL.Entities
{
    public class Appointment:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}