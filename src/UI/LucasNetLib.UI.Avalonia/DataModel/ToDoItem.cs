using System;
using FreeSql.DataAnnotations;

namespace LucasNetLib.UI.Avalonia.DataModel
{
    public class ToDoItem
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public bool IsChecked { get; set; }
    }
}
