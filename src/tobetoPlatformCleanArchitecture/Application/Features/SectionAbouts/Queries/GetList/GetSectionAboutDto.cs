using Core.Application.Dtos;
using System;
namespace Application.Features.SectionAbouts.Queries.GetList
{
    public class GetSectionAboutDto : IDto
    {
        public string? Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? EstimatedDuration { get; set; }
    }
}

