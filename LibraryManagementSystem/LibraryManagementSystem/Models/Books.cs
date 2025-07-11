using System;

namespace LibraryManagementSystem.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
