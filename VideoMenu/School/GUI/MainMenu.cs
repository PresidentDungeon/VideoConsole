using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using VideoMenu.Core.Entity;
using VideoMenu.GUI;

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
                    new CategoryMenu().Run();
                    break;
                default:
                    break;
            }
        }
    }
}
