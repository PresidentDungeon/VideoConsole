using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace VideoMenu.GUI
{
    class CategoryMenu : Menu
    {
        ICategoryRepository categoryRepository;

        public CategoryMenu() : base("Category Menu", "View Categories", "Add Category", "Remove Category", "Update Category")
        {
            categoryRepository = CategoryRepository.GetInstance();
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

        private Category CreateCategory()
        {
            Console.WriteLine("\nEnter category title:");
            string title = Console.ReadLine();

            while (title.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid name");
                title = Console.ReadLine();
            }

            return new Category { title = title };
        }

        private void ShowAllCategories()
        {
            Console.WriteLine("All registered categories are: \n");
            foreach (Category category in categoryRepository.GetCategories())
            {
                Console.WriteLine(category);
            }
        }

        private void AddCategory()
        {
            categoryRepository.AddCategory(CreateCategory());
            Console.WriteLine("\nCategory was successfully added!");
        }

        private void UpdateCategory()
        {
            List<Category> allCategories = categoryRepository.GetCategories();

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
                Category category = CreateCategory();
                category.id = allCategories[selection - 1].id;
                Console.WriteLine((categoryRepository.UpdateCategory(category) ? "Category was successfully updated!" : "Error updating category. Please try again."));
            }
        }

        private void DeleteCategoryBySelection()
        {
            List<Category> allCategories = categoryRepository.GetCategories();

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
                Console.WriteLine((categoryRepository.DeleteCategory(allCategories[selection - 1].id) ? "Category was successfully deleted!" : "Error - no such ID found"));
            }
        }
    }
}
