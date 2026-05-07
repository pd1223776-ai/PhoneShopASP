namespace PhoneShopMVC.Services
{
    public interface IImageService
    {
        void DeleteIfExists(string rootPath, string? imagePath);
    }
}
