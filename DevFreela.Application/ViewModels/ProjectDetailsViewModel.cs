using System;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startAt, DateTime? finishAt, string clientFullName, string freelancerFullname)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartAt = startAt;
            FinishAt = finishAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullname;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartAt { get; private set; }
        public DateTime? FinishAt { get; private set; }
        public string ClientFullName { get; private set;}
        public string FreelancerFullName { get; private set; }
    }
}
