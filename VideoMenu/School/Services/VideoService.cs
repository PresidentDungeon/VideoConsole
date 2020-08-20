using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.DAL;
using VideoMenu.Models;

namespace VideoMenu.Services
{
    class VideoService : IVideoService
    {
        private VideoTable videoTable;

        public VideoService()
        {
            this.videoTable = VideoTable.GetInstance();
        }

        public void AddVideo(string title, DateTime releaseDate, string story)
        {
            videoTable.AddVideo(new Video { title = title, releaseDate = releaseDate, story = story });
        }

        public Video CreateVideo()
        {
            throw new NotImplementedException();
        }

        public bool DeleteVideo(int id)
        {
            return videoTable.DeleteVideo(id);
        }

        public Video GetVideo(int id)
        {
            return videoTable.GetVideo(id);
        }

        public List<Video> GetVideos()
        {
            return videoTable.GetVideos();
        }

        public bool UpdateVideo(int id, string title, DateTime releaseDate, string story)
        {
            return videoTable.UpdateVideo(new Video { id = id, title = title, releaseDate = releaseDate, story = story }); 
        }
    }
}
