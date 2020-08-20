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

        public Video CreateVideo()
        {
            Console.WriteLine("\nEnter movie title:");
            string title = Console.ReadLine();

            while (title.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid name");
                title = Console.ReadLine();
            }

            Console.WriteLine("\nEnter release date:");
            DateTime releaseDate;

            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
            {
                Console.WriteLine("Please enter a valid release date (dd/mm/yyyy)");
            }

            Console.WriteLine("\nEnter movie description:");
            string story = Console.ReadLine();

            return new Video { title = title, releaseDate = releaseDate, story = story };
        }



        public void AddVideo()
        {
            videoTable.AddVideo(CreateVideo());
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

        public bool UpdateVideo(Video video)
        {
            return videoTable.UpdateVideo(video); 
        }
    }
}
