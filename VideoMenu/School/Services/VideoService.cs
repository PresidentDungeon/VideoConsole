﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public Video GetVideoByID(int id)
        {
            return videoTable.GetVideo(id);
        }

        public List<Video> GetVideoByTitle(string searchTitle)
        {
            string[] searchTerms = searchTitle.ToLower().Split('%');
            List<Video> matches = new List<Video>();

            foreach (Video video in GetVideos())
            {
                int size = 0;
                if (!searchTitle.StartsWith('%'))
                {
                    if (!video.title.ToLower().StartsWith(searchTerms[0]))
                    {
                        continue;
                    }
                }
                else
                {
                    size++;
                }

                String videoTitle = video.title.ToLower();

                for (int i = size; i < searchTerms.Length; i++)
                {

                    if (videoTitle.Contains(searchTerms[i]))
                    {
                        int index = videoTitle.IndexOf(searchTerms[i]);
                        videoTitle = videoTitle.Substring(index + searchTerms[i].Length);
                    }
                    else
                    {
                        break;
                    }

                    if (searchTitle.EndsWith("%"))
                    {
                        if (videoTitle.Length > 0)
                        {
                            matches.Add(video);
                            break;
                        }
                    }
                    else
                    {
                        if (videoTitle.Length == 0)
                        {
                            matches.Add(video);
                            break;
                        }
                    }
                }
            }
            return matches;
        }

        public List<Video> GetVideoByDate(DateTime date)
        {
            return (from x in GetVideos() where x.releaseDate.Equals(date) select x).ToList();
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
