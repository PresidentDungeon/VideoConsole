using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    interface IVideoService
    {
        List<Video> GetVideos();

        Video GetVideo(int id);

        void AddVideo(string title, DateTime releaseDate, string story);

        bool UpdateVideo(int id, string title, DateTime releaseDate, string story);

        bool DeleteVideo(int id);

        Video CreateVideo();

    }
}
