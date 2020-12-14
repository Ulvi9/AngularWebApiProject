﻿using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.DTO.User
{
    public class UserForRegisterDto
    {
        [Required]
        public string  Username { get; set; }
        public string Email { get; set; }

        [StringLength(8,MinimumLength =3,ErrorMessage ="8den kicik 3den boyuk olmalidir")]
        public string Password { get; set; }
        public int RoleId  { get; set; }
    }
}