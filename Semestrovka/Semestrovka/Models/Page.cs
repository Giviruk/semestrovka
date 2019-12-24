using System.Collections.Generic;
//Хранит информацию о количестве страниц и их контроллерах
namespace Semestrovka.Models
{
    public class Page
    {
        public string Name;
        public string Controller;
        
        public Page(string name):this(name,"Other")
        {
            
        }
        public Page(string name, string contr)
        {
            Name = name;
            Controller = contr;
        }
        public static List<Page> pages = new List<Page>()
        {
            new Page("Index", "Home"),
            new Page("Shop"),
            new Page("Single Product"),
            new Page("Cart","Cart"),
            new Page("Checkout","Cart"),
            new Page("Category"),
            new Page("Others"),
            new Page("Contact")
        };
    }
}