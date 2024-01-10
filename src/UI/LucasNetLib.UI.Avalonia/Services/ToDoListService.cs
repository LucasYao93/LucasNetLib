using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LucasNetLib.UI.Avalonia.DataModel;
using LucasNetLib.UI.Avalonia.Repository;

namespace LucasNetLib.UI.Avalonia.Services
{
    public class ToDoListService
    {
        public async Task<IEnumerable<ToDoItem>> GetItemsAsync()
        {
            return await DBFressSql.Instance.Select<ToDoItem>().ToListAsync();
        }

        public async Task AddItemAsync(ToDoItem toDoItem)
        {
            await DBFressSql.Instance.Insert(toDoItem).ExecuteAffrowsAsync();
        }
    }
}
