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

        private IServiceProvider serviceProvider;

        public MainMenu(IServiceProvider serviceProvider) : base("Main Menu", "Video Menu", "Category Menu")
        {

            this.serviceProvider = serviceProvider;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    serviceProvider.GetRequiredService<VideoMenu>().Run();
                    break;
                case 2:
                    serviceProvider.GetRequiredService<CategoryMenu>().Run();
                    break;
                default:
                    break;
            }
        }
    }
}
