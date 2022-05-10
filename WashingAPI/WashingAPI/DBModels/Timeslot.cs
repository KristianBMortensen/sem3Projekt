﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WashingAPI.DBModels
{
    [Table("Timeslot")]
    public partial class Timeslot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string ResTime { get; set; }
        [StringLength(255)]
        public string RoomNo { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int DayId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey(nameof(DayId))]
        [InverseProperty("Timeslots")]
        public virtual Day Day { get; set; }
    }
}