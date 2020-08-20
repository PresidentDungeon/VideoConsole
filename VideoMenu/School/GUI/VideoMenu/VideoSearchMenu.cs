using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;
using VideoMenu.Services;

namespace VideoMenu.GUI
{
    class VideoSearchMenu : Menu
    {
        private IVideoService videoService;
        public VideoSearchMenu() : base("Search Menu", "Search by ID", "Search by Title", "Search by Date")
        {
            videoService = new VideoService();
            shouldCloseOnFinish = true;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    SearchByID();
                    break;
                case 2:
                    SearchByTitle();
                    break;
                case 3:
                    SearchByDate();
                    break;
                default:
                    break;
            }

        }
        private void SearchByID()
        {
            Console.WriteLine("\nPlease enter ID:");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("\nPlease only enter a valid ID");
            }
            Video video = videoService.GetVideoByID(id);
            Console.WriteLine((video != null) ? $"Found video:\n\nTitle: {video.title} ({video.id})\n\nRelease: {video.releaseDate.ToString("dd/MM/yyyy")}\n\nStory: {video.story}\n\n{video.category}" : "\nNo video was found");
        }

        private void SearchByTitle()
        {
            Console.WriteLine("\nPlease enter a title (use % to break title):");
            List<Video> foundVideos = videoService.GetVideoByTitle(Console.ReadLine());
            
            if(foundVideos.Count == 0)
            {
                Console.WriteLine("\nNo videos were found with that title...");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nMatches are-----------------------\n");
                foreach (Video video in foundVideos)
                {
                    Console.WriteLine($"\nTitle: {video.title} ({video.id})\nRelease: {video.releaseDate.ToString("dd/MM/yyyy")}\nStory: {video.story}\nCategory: {video.category}\n");
                }
            }
        }

        private void SearchByDate()
        {
            Console.WriteLine("\nEnter release date:");
            DateTime releaseDate;

            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
            {
                Console.WriteLine("Please enter a valid release date (dd/mm/yyyy)");
            }

            List<Video> foundVideos = videoService.GetVideoByDate(releaseDate);

            if (foundVideos.Count == 0)
            {
                Console.WriteLine("\nNo videos were found with that title...");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nMatches are-----------------------\n");
                foreach (Video video in foundVideos)
                {
                    Console.WriteLine($"\nTitle: {video.title} ({video.id})\nRelease: {video.releaseDate.ToString("dd/MM/yyyy")}\nStory: {video.story}\nCategory: {video.category}\n");
                }
            }
        }








    }
}
