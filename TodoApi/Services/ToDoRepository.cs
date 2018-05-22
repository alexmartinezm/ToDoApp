using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;
using ToDoApi.Services.Interfaces;

namespace ToDoApi.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDoItem> _toDoList;

        public ToDoRepository()
        {
            InitializeData();
        }

        public IEnumerable<ToDoItem> All
        {
            get { return _toDoList; }
        }

        public bool DoesItemExist(string id) => _toDoList.Any(item => item.Id == id);

        public ToDoItem Find(string id) => _toDoList.FirstOrDefault(item => item.Id == id);

        public void Insert(ToDoItem item)
        {
            _toDoList.Add(item);
        }

        public void Update(ToDoItem item)
        {
            var todoItem = Find(item.Id);
            var index = _toDoList.IndexOf(todoItem);
            _toDoList.RemoveAt(index);
            _toDoList.Insert(index, item);
        }

        public void Delete(string id) => _toDoList.Remove(Find(id));

        private void InitializeData()
        {
            _toDoList = new List<ToDoItem>();

            var todoItem1 = new ToDoItem
            {
                Id = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Title = "Learn app development",
                Description = "Attend Xamarin University",
                ImageName = "learning_app.png"
            };

            var todoItem2 = new ToDoItem
            {
                Id = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Title = "Develop apps",
                Description = "Use Visual Studio",
                ImageName = "developing_app.png"
            };

            var todoItem3 = new ToDoItem
            {
                Id = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Title = "Publish apps",
                Description = "All app stores",
                ImageName = "publishing_app.png"
            };

            _toDoList.Add(todoItem1);
            _toDoList.Add(todoItem2);
            _toDoList.Add(todoItem3);
        }
    }
}