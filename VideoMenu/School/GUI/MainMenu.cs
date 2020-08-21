using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using VideoMenu.Core.ApplicationService;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.GUI;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace VideoMenu.GUI
{
    class MainMenu : Menu
    {
        private IVideoService videoService;
        private ICategoryService categoryService;

        public MainMenu(IVideoService videoService, ICategoryService categoryService) : base("Main Menu", "Video Menu", "Category Menu")
        {
            this.videoService = videoService;
            this.categoryService = categoryService;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    new VideoMenu(videoService, categoryService).Run();
                    break;
                case 2:
                    new CategoryMenu(categoryService).Run();
                    break;
                default:
                    break;
            }
        }
    }
}
