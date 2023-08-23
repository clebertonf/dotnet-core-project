using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>()
            {
                new Project("Projeto dotnet core 1", "Descrição do projeto 1", 1, 1, 30000),
                new Project("Projeto dotnet core 2", "Descrição do projeto 2", 1, 1, 40000),
                new Project("Projeto dotnet core 3", "Descrição do projeto 3", 1, 1, 50000)
            };

            Users = new List<User>()
            {
                new User("Cleberton", "cleberton@gmail.com", new DateTime(1993, 09, 21)),
                new User("Lucas", "lucas@gmail.com", new DateTime(1995, 04, 25)),
                new User("Tiago", "tiago@gmail.com", new DateTime(1990, 01, 29))
            };

            Skills = new List<Skill>()
            {
                new Skill("C#"),
                new Skill("Dotnet"),
                new Skill("Java Script")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
