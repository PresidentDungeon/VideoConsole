using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace VideoMenu.GUI
{
    class VideoSearchMenu : Menu
    {
        private IVideoRepository videoRepository;
        public VideoSearchMenu() : base("Search Menu", "Search by ID", "Search by Title", "Search by Date")
        {
            videoRepository = VideoRepository.GetInstance();
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
            Video video = videoRepository.GetVideoByID(id);
            Console.WriteLine((video != null) ? $"Found video:\n\nTitle: {video.title} ({video.id})\n\nRelease: {video.releaseDate.ToString("dd/MM/yyyy")}\n\nStory: {video.story}\n\n{video.category}" : "\nNo video was found");
        }

        private void SearchByTitle()
        {
            Console.WriteLine("\nPlease enter a title (use % to break title):");
            List<Video> foundVideos = videoRepository.GetVideoByTitle(Console.ReadLine());
            
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

            List<Video> foundVideos = videoRepository.GetVideoByDate(releaseDate);

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
