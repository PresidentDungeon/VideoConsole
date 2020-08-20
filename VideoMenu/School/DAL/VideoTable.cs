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
            Video vid = videos.Where((x) => { return x.id == video.id; }).FirstOrDefault();
            if (vid != null)
            {
                vid = video;
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
    }
}
