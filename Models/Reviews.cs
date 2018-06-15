using System;
using System.ComponentModel.DataAnnotations;


namespace RESTmakefood.Models
{
    
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {}

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt > DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
    
    public class Reviews
    {
        public int id { get; set; }
        [Required]
        public string user { get; set; }
        [Required]
        public string restaurant { get; set; }
        [Required]
        [MinLength(10)]
        public string content { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage="Date can't be from the future!")]
        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_visited { get; set; } 
        [Required]
        [Range(1,5)]
        public int score { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
