namespace DevFreela.infrastructure.CloudServices
{
    public interface IFileStorageService
    {
        void uploadFile(byte[] bytes, string fileName);
    }
}
