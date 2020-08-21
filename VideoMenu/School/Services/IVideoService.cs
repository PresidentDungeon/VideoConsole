using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    interface IVideoService
    {
        List<Video> GetVideos();
        Video GetVideoByID(int id);
        List<Video> GetVideoByTitle(string searchTitle);
        List<Video> GetVideoByDate(DateTime date);
        void AddVideo(Video video);
        bool UpdateVideo(Video video);
        bool DeleteVideo(int id);
        Video CreateVideo(string title, DateTime releaseDate, string story, Category category);

    }
}
