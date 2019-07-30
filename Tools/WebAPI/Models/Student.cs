using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [DisplayName("学生")]
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "姓名")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public bool IsNormal { get; set; }
        public string Password { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [Display(Name = "生日")]
        public DateTime CreateTime { get; set; }
    }
}