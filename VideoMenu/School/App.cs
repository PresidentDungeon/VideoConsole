using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VideoMenu.Core.ApplicationService;
using VideoMenu.Core.ApplicationService.Services;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.GUI;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace School
{
    class App
    {
        static void Main(string[] args)
        {
            //IVideoRepository videoRepository = VideoRepository.GetInstance();
            //ICategoryRepository categoryRepository= CategoryRepository.GetInstance();

            //IVideoService videoService = new VideoService(videoRepository);
            //ICategoryService categoryService = new CategoryService(categoryRepository);

            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();

            serviceCollection.AddScoped<MainMenu>();
            serviceCollection.AddScoped<VideoDeleteMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
            mainMenu.Run();

            //MainMenu mainMenu = new MainMenu(videoService, categoryService);
            //mainMenu.Run();

        }
    }

}
