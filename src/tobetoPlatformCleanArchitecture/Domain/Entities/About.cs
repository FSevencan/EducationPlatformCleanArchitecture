using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class About : Entity<Guid>
{
    public string Text { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public string EstimatedDuration { get; set; } 
    public int TotalContent { get; set; } 
    public int TotalAssignments { get; set; } 
    public int TotalVideos { get; set; } 
    public string? ProducerCompany { get; set; }  


    public Course Course { get; set; }
    public Guid CourseId { get; set; }
}

