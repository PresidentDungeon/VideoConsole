using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using VideoMenu.GUI.CategoryMenu;
using VideoMenu.Models;
using VideoMenu.Services;

namespace VideoMenu.GUI
{
    class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu", "Video Menu", "Category Menu")
        {

        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    new VideoMenu().Run();
                    break;
                case 2:
                    new CategoryMenu.CategoryMenu().Run();
                    break;
                default:
                    break;
            }
        }
    }
}
