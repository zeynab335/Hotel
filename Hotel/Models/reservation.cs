﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    [Table("reservation")]
    public partial class reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string first_name { get; set; }
        [Required]
        [StringLength(50)]
        public string last_name { get; set; }
        [Required]
        [StringLength(50)]
        public string birth_day { get; set; }
        [Required]
        [StringLength(50)]
        public string gender { get; set; }
        [Required]
        [StringLength(50)]
        public string phone_number { get; set; }
        [Required]
        public string email_address { get; set; }
        public int number_guest { get; set; }
        [Required]
        public string street_address { get; set; }
        [Required]
        [StringLength(50)]
        public string apt_suite { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        [StringLength(50)]
        public string state { get; set; }
        [Required]
        [StringLength(10)]
        public string zip_code { get; set; }
        [Required]
        [StringLength(10)]
        public string room_type { get; set; }
        [Required]
        [StringLength(10)]
        public string room_floor { get; set; }
        [Required]
        [StringLength(10)]
        public string room_number { get; set; }
        public double total_bill { get; set; }
        [Required]
        [StringLength(10)]
        public string payment_type { get; set; }
        [Required]
        [StringLength(10)]
        public string card_type { get; set; }
        [Required]
        [StringLength(50)]
        public string card_number { get; set; }
        [Required]
        [StringLength(50)]
        public string card_exp { get; set; }
        [Required]
        [StringLength(10)]
        public string card_cvc { get; set; }
        [Column(TypeName = "date")]
        public DateTime arrival_time { get; set; }
        [Column(TypeName = "date")]
        public DateTime leaving_time { get; set; }
        public bool check_in { get; set; }
        public int break_fast { get; set; }
        public int lunch { get; set; }
        public int dinner { get; set; }
        public bool cleaning { get; set; }
        public bool towel { get; set; }
        public bool s_surprise { get; set; }
        public bool supply_status { get; set; }
        public int food_bill { get; set; }
    }
}
