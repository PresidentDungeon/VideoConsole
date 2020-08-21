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
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();

            serviceCollection.AddScoped<MainMenu>();
            serviceCollection.AddScoped<VideoMenu.GUI.VideoMenu>();
            serviceCollection.AddScoped<VideoDeleteMenu>();
            serviceCollection.AddScoped<VideoSearchMenu>();
            serviceCollection.AddScoped<CategoryMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainMenu = serviceProvider.GetRequiredService<MainMenu>();
            mainMenu.Run();

        }
    }

}
