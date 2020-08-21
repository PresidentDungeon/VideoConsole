
using System;
using System.Collections.Generic;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.DomainService
{
    public interface IVideoRepository
    {
        void AddVideo(Video video);
        List<Video> GetVideos();
        bool UpdateVideo(Video video);
        bool DeleteVideo(int id);





        Video GetVideoByID(int id);
        List<Video> GetVideoByTitle(string searchTitle);
        List<Video> GetVideoByDate(DateTime date);
    }
}
