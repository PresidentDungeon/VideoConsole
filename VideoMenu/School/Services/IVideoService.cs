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

        void AddVideo();

        bool UpdateVideo(Video video);

        bool DeleteVideo(int id);

        Video CreateVideo();

    }
}
