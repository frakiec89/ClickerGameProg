
namespace ClickerGameProg
{
    public class MyListView :BaseObject
    {
        public string Value { get; set; }
        public string Message { get; set; }

        public bool IsEnabled { get; set; }
        public string IsDelete { get; set; } = "Collapsed";

        public object MyObject { get; set; } 
    }
}