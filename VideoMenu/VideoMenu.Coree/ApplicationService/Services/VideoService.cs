using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.ApplicationService.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public Video CreateVideo(string title, DateTime releaseDate, string story, Category category)
        {
            return new Video { title = title, releaseDate = releaseDate, story = story, category = category };
        }

        public void AddVideo(Video video)
        {
            videoRepository.AddVideo(video);
        }

        public List<Video> GetAllVideos()
        {
            return videoRepository.GetVideos();
        }

        public Video GetVideoByID(int id)
        {
            return GetAllVideos().Where((x) => { return x.id == id; }).FirstOrDefault();
        }

        public List<Video> GetVideoByTitle(string searchTitle)
        {
            string[] searchTerms = searchTitle.ToLower().Split('%');
            List<Video> matches = new List<Video>();

            foreach (Video video in GetAllVideos())
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
            return (from x in GetAllVideos() where x.releaseDate.Equals(date) select x).ToList();
        }

        public bool UpdateVideo(Video video)
        {
            return videoRepository.UpdateVideo(video);
        }

        public bool DeleteVideo(int id)
        {
            return videoRepository.DeleteVideo(id);
        }

    }

}
