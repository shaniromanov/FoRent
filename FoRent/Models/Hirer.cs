using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoRent.Models
{
    public class Hirer
    {

            public int Id { get; set; } //מספר זהות השוכר
            public string FirstName { get; set; } //שם פרטי של השוכר
            public string LastName { get; set; } //שם משפחה של השוכר
            public int Phone { get; set; } //מספר טלפון של השוכר
            public string Mail { get; set; } //כתובת מייל של השוכר
            public string Username { get; set; } //שם משתמש
            public string Password { get; set; } //סיסמא


    }
}

