using System.Collections.Generic;

//Хранит информацию о количестве страниц и их контроллерах
namespace Semestrovka.Models
{
    public class Page
    {
        public static List<Page> pages = new List<Page>
        {
            new Page("Shop"),
            new Page("Cart", "Cart"),
            new Page("Checkout", "Cart"),
            new Page("Category", "Categories"),
            new Page("Others"),
            new Page("Contact")
        };

        public string Controller;
        public string Name;

        public Page(string name) : this(name, "Other")
        {
        }

        public Page(string name, string contr)
        {
            Name = name;
            Controller = contr;
        }
    }
}