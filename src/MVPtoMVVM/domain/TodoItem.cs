using System;

namespace MVPtoMVVM.domain
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate  { get; set; }
    }
}