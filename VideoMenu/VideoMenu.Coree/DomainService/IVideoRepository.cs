
using System;
using System.Collections.Generic;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.DomainService
{
    public interface IVideoRepository
    {
        void AddVideo(Video video);
        IEnumerable<Video> GetVideos();
        bool UpdateVideo(Video video);
        bool DeleteVideo(int id);
    }
}
