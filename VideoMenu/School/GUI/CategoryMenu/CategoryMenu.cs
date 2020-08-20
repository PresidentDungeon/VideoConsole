using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Models;
using VideoMenu.Services;

namespace VideoMenu.GUI.CategoryMenu
{
    class CategoryMenu : Menu
    {
        ICategoryService categoryService;


        public CategoryMenu() : base("Category Menu", "View Categories", "Add Category", "Remove Category", "Update Category")
        {
            categoryService = new CategoryService();
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllCategories();
                    Pause();
                    break;
                case 2:
                    AddCategory();
                    Pause();
                    break;
                case 3:
                    DeleteCategoryBySelection();
                    Pause();
                    break;
                case 4:
                    UpdateCategory();
                    Pause();
                    break;
                default:
                    break;
            }
        }

        private void ShowAllCategories()
        {
            Console.WriteLine("All registered categories are: \n");
            foreach (Category category in categoryService.GetCategories())
            {
                Console.WriteLine(category);
            }
        }

        private void AddCategory()
        {
            categoryService.AddCategory();
            Console.WriteLine("\nCategory was successfully added!");
        }

        private void UpdateCategory()
        {
            List<Category> allCategories = categoryService.GetCategories();

            Console.WriteLine("\nPlease select which category to update:");

            for (int i = 0; i < allCategories.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + allCategories[i].ToString());
            }

            Console.WriteLine("\n0: Back");

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > allCategories.Count)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{allCategories.Count})");
            }

            if (selection > 0)
            {
                Category category = categoryService.CreateCategory();
                category.id = allCategories[selection - 1].id;
                Console.WriteLine((categoryService.UpdateCategory(category) ? "Category was successfully updated!" : "Error updating category. Please try again."));
            }
        }

        private void DeleteCategoryBySelection()
        {
            List<Category> allCategories = categoryService.GetCategories();

            Console.WriteLine("\nPlease select which category to delete:");

            for (int i = 0; i < allCategories.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + allCategories[i].ToString());
            }

            Console.WriteLine("\n0: Back");

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > allCategories.Count)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{allCategories.Count})");
            }

            if (selection > 0)
            {
                Console.WriteLine((categoryService.DeleteCategory(allCategories[selection - 1].id) ? "Category was successfully deleted!" : "Error - no such ID found"));
            }
        }
    }
}
