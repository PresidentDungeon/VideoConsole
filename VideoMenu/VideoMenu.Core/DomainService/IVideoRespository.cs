
namespace VideoMenu.Core.DomainService
{
    interface IVideoRespository
    {
        Video CreateVideo(string title, DateTime releaseDate, string story, Category category);
        void Create(Video video);
        List<Video> GetAll();
        Video GetByID(int id);
        List<Video> GetByTitle(string searchTitle);
        List<Video> GetByDate(DateTime date);
        bool UpdateVideo(Video video);
        bool DeleteVideo(int id);
    }
}
