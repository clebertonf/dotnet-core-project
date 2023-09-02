using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; private set; }
        public int idProject { get; private set; }
        public int idUser { get; private set; }
    }
}
