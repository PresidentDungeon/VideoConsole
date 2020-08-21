using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.ApplicationService
{
   public interface IVideoService
    {


        Video CreateVideo(string title, DateTime releaseDate, string story, Category category);

        void AddVideo(Video video);

        List<Video> GetAllVideos();

        Video GetVideoByID(int id);

        List<Video> GetVideoByTitle(string searchTitle);

        List<Video> GetVideoByDate(DateTime date);

        bool UpdateVideo(Video video, int id);

        bool DeleteVideo(int id);

    }
}
