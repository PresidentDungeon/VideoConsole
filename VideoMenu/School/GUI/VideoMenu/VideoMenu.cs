using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;
using VideoMenu.Services;

namespace VideoMenu.GUI
{
    class VideoMenu : Menu
    {
        private IVideoService videoService;

        public VideoMenu() : base("Video Menu", "View Videos", "Search video", "Add Video", "Remove Video", "Update Video")
        {
            videoService = new VideoService();
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllVideos();
                    Pause();
                    break;
                case 2:
                    new VideoSearchMenu().Run();
                    Pause();
                    break;
                case 3:
                    AddVideo();
                    Pause();
                    break;
                case 4:
                    new VideoDeleteMenu().Run();
                    Pause();
                    break;
                case 5:
                    Updatevideo();
                    Pause();
                    break;
                default:
                    break;
            }
        }

        private void ShowAllVideos()
        {
            Console.WriteLine("All registered videos are: \n");
            foreach (Video video in videoService.GetVideos())
            {
                Console.WriteLine(video);
            }
        }

        private void AddVideo()
        {
            videoService.AddVideo();
            Console.WriteLine("\nVideo was successfully added!");
        }

        private void Updatevideo()
        {
            List<Video> allVideos = videoService.GetVideos();

            Console.WriteLine("\nPlease select which movie to update:");

            for (int i = 0; i < allVideos.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + allVideos[i].ToString());
            }

            Console.WriteLine("\n0: Back");

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > allVideos.Count)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{allVideos.Count})");
            }

            if (selection > 0)
            {
                Video video = videoService.CreateVideo();
                video.id = allVideos[selection - 1].id;
                Console.WriteLine((videoService.UpdateVideo(video) ? "Video was successfully updated!" : "Error updating video. Please try again."));
            }
        }
    }
}
