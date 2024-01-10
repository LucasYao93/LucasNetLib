using LucasNetLib.UI.Avalonia.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.UI.Avalonia.Repository
{
    public static class DBFressSql
    {
        private static readonly IFreeSql _Instance = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=D:\freedb.db")
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
        .Build();

        public static IFreeSql Instance
        {
            get { return _Instance; }
        }

        public static void SyncStructure()
        {
            Instance.CodeFirst.SyncStructure<ToDoItem>();
        }

        public static async Task InitTableDataAsync()
        {
            var items = new[]
            {
                new ToDoItem { Description = "Walk the dog" },
                new ToDoItem { Description = "Buy some milk" },
                new ToDoItem { Description = "Learn Avalonia", IsChecked = true },
            };

            await Instance.Insert<ToDoItem>().AppendData(items).ExecuteAffrowsAsync();
        }
    }
}
