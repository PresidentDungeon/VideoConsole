using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;
using VideoMenu.Services;

namespace VideoMenu.GUI
{
    class DeleteMenu : Menu
    {
        private IVideoService videoService;
        public DeleteMenu() : base("Delete Menu", "Delete by ID", "Delete by selection")
        {
            videoService = new VideoService();
            shouldCloseOnFinish = true;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    DeleteByID();
                    break;
                case 2:
                    DeleteBySelection();
                    break;
                default:
                    break;
            }  
        }
        private void DeleteByID() 
        {
            Console.WriteLine("\nPlease enter ID:");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Please only enter a valid ID");
            }
            Console.WriteLine((videoService.DeleteVideo(id) ? "Video was successfully deleted!" : "Error - no such ID found"));
        }

        private void DeleteBySelection()
        {
            List<Video> allVideos = videoService.GetVideos();

            Console.WriteLine("\nPlease select which movie to delete:");

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

            if(selection > 0) 
            {
                Console.WriteLine((videoService.DeleteVideo(allVideos[selection - 1].id) ? "Video was successfully deleted!" : "Error - no such ID found"));
            }
        }


    }
}
