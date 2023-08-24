namespace DevFreela.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public string Content { get; private set; }
        public int idProject { get; private set; }
        public int idUser { get; private set; }
    }
}
