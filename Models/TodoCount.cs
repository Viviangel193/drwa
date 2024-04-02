using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoCount
    {
        public int Count { get; set; }
        public List<TodoItem> DataTodoItem { get; set; }
        public TodoCount(int count, List<TodoItem> datatodoitem)
        {
            Count = count;
            DataTodoItem = datatodoitem;
        }
    }
}
