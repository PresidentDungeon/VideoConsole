using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using VideoMenu.GUI;
using VideoMenu.Models;
using VideoMenu.Services;

namespace School.GUI
{
    class MainMenu : Menu
    {
        private IVideoService videoService;

        public MainMenu() : base("Main Menu", "View Videos", "Add Video","Remove Video","Update Video")
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
                    AddVideo();
                    Pause();
                    break;
                case 3:
                    new DeleteMenu().Run();
                    Pause();
                    break;
                case 4:
                    Console.WriteLine("Not implemented yet!!!");
                    Pause();
                    break;
                case 5:
                    Console.WriteLine("Not implemented yet!!!");
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

            videoService.AddVideo(title, releaseDate, story);
            Console.WriteLine("\nVideo was successfully added!");
        }

    }
}
