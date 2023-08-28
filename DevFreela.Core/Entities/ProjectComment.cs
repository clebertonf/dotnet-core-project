using System;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            this.idProject = idProject;
            this.idUser = idUser;
        }

        public string Content { get; private set; }
        public int idProject { get; private set; }
        public Project Project { get; private set; }
        public int idUser { get; private set; }
        public User User { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
