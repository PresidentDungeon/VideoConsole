using System;
using System.Collections.Generic;
using VideoMenu.Core.ApplicationService;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace VideoMenu.GUI
{
    class VideoMenu : Menu
    {
        private IVideoService videoService;
        private ICategoryService categoryService;

        public VideoMenu(IVideoService videoService, ICategoryService categoryService) : base("Video Menu", "View Videos", "Search video", "Add Video", "Remove Video", "Update Video")
        {
            this.videoService = videoService;
            this.categoryService = categoryService;
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
                    new VideoSearchMenu(videoService).Run();
                    Pause();
                    break;
                case 3:
                    CreateVideo();
                    Pause();
                    break;
                case 4:
                    new VideoDeleteMenu(categoryService).Run();
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

        private Video CreateVideo()
        {
            List<Category> allCategories = categoryService.GetCategories();

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

            Console.WriteLine("\nSelect a valid category");

            for (int i = 0; i < allCategories.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + allCategories[i].ToString());
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > allCategories.Count)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{allCategories.Count})");
            }

            Video video = videoService.CreateVideo(title, releaseDate, story, allCategories[selection - 1]);
            videoService.AddVideo(video);
            Console.WriteLine("\nVideo was successfully added!");
            return video;
        }

        private void ShowAllVideos()
        {
            Console.WriteLine("All registered videos are: \n");
            foreach (Video video in videoService.GetAllVideos())
            {
                Console.WriteLine(video);
            }
        }

        private void Updatevideo()
        {
            List<Video> allVideos = videoService.GetAllVideos();

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
                Video video = CreateVideo();
                video.id = allVideos[selection - 1].id;
                Console.WriteLine((videoService.UpdateVideo(video)) ? "Video was successfully updated!" : "Error updating video. Please try again."));
                
            }
        }
    }
}
