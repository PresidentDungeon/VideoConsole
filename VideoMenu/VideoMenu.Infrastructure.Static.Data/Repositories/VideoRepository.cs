using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;

namespace VideoMenu.Infrastructure.Static.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private int id;
        private List<Video> videos;
        private static VideoRepository videoRespository;

        private VideoRepository()
        {
            this.id = 0;
            this.videos = new List<Video>();
        }

        public static VideoRepository GetInstance()
        {
            return videoRespository ??= new VideoRepository();
        }

        public void AddVideo(Video video)
        {
            id++;
            video.id = id;
            videos.Add(video);
        }

        public List<Video> GetVideos()
        {
            return this.videos;
        }

        public bool UpdateVideo(Video video)
        {
            int index = videos.FindIndex((x) => { return x.id == video.id; });
            //Video vid = videos.Where((x) => { return x.id == video.id; }).FirstOrDefault();
            if (index != -1)
            {
                videos[index] = video;
                return true;
            }
            return false;
        }

        public bool DeleteVideo(int id)
        {
            Video video = videos.Where((x) => { return x.id == id; }).FirstOrDefault();
            if (video != null)
            {
                videos.Remove(video);
                return true;
            }
            return false;
        }

        private void CreateInitialData()
        {
            throw new NotImplementedException();
        }
    }
}
