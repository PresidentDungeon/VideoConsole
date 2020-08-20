using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Models;

namespace VideoMenu.DAL
{
    class VideoTable
    {
        private int id;
        private List<Video> videos;
        private static VideoTable videoTable;

        private VideoTable()
        {
            this.id = 0;
            this.videos = new List<Video>();
        }

        public static VideoTable GetInstance()
        {
            return videoTable ??= new VideoTable();
        }

        public List<Video> GetVideos()
        {
            return this.videos;
        }

        public Video GetVideo(int id)
        {
            return videos.Where((x) => { return x.id == id; }).FirstOrDefault();
        }

        public void AddVideo(Video video)
        {
            id++;
            video.id = id;
            videos.Add(video);
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
            if(video != null)
            {
                videos.Remove(video);
                return true;
            }
            return false;
        }

        public bool DeleteCatoryAssignedToVideo(int id)
        {
            foreach (Video video in videos.Where(x => x.category.id == id))
            {
                video.category = null;
            }
            return true;
        }
    }
}
