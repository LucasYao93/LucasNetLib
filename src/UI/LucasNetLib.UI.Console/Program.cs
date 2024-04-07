using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

public class Program
{
    public class SelfCell
    {
        public CellPosition Position { get; set; } = new CellPosition(0, 0);
        public string Value { get; set; } = string.Empty;
    }

    public class CellPosition
    {
        public int FirstRow;
        public int FirstCell;
        public int LastRow = 0;
        public int LastCell = 0;

        public CellPosition(
            int firstRow, 
            int firstCell)
        {
            FirstRow = firstRow;
            FirstCell = firstCell;
        }

        public bool IsRegionCell()
        {
            if ((LastRow+1 * LastCell+1) > (FirstRow+1 * FirstCell+1))
            {
                return true;
            }

            return false;
        }
    }

    public void ReportExample()
    {
        using (FileStream fs = new FileStream("001.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            var selfCells = new List<SelfCell>()
            {
                new SelfCell()
                {
                    Value = "作者",
                    Position = new CellPosition(0, 0)
                },
                new SelfCell()
                {
                    Value = "标题",
                    Position = new CellPosition(0, 1)
                    {
                        LastRow = 1,
                        LastCell = 1
                    }
                },
                 new SelfCell()
                {
                    Value = "内容",
                    Position = new CellPosition(0, 2)
                    {
                        LastRow = 0,
                        LastCell = 2 + 1
                    }
                },
                new SelfCell()
                {
                    Value = "时间",
                    Position = new CellPosition(0, 4)
                }
            };


            // 创建工作簿和工作表
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            List<CellRangeAddress> cellRangeAddresses = new List<CellRangeAddress>();

            var sortData = selfCells.GroupBy(o => o.Position.FirstRow).Select(o => new
            {
                RowIdx = o.Key,
                Cell = o.OrderBy(o => o.Position.FirstCell).ToList(),
            });


            foreach (var rowData in sortData)
            {
                IRow row = sheet.CreateRow(rowData.RowIdx);
                foreach (var cell in rowData.Cell)
                {
                    var tagetCell = row.CreateCell(cell.Position.FirstCell);

                    tagetCell.SetCellValue(cell.Value);

                    if (cell.Position.IsRegionCell())
                    {
                        cellRangeAddresses.Add(
                            new CellRangeAddress(cell.Position.FirstRow,
                                                (int)cell.Position.LastRow,
                                                cell.Position.FirstCell,
                                                (int)cell.Position.LastCell)
                            );

                        ICellStyle mergedCellStyle = workbook.CreateCellStyle();
                        mergedCellStyle.Alignment = HorizontalAlignment.Center;
                        mergedCellStyle.VerticalAlignment = VerticalAlignment.Center;
                        tagetCell.CellStyle = mergedCellStyle;
                    }
                }
            }

            foreach (var cellRange in cellRangeAddresses)
            {
                sheet.AddMergedRegion(cellRange);
            }


            //// 创建表头行
            //IRow headerRow = sheet.CreateRow(0);

            //// 创建单元格并设置内容
            //ICell cell1 = headerRow.CreateCell(0);
            //cell1.SetCellValue("Column 1");

            //ICell cell2 = headerRow.CreateCell(1);
            //cell2.SetCellValue("Column 2");

            ////// 合并单元格
            ////CellRangeAddress mergedRegion = new CellRangeAddress(0, 1, 0, 1); // 跨第一行的第一列和第二列
            ////sheet.AddMergedRegion(mergedRegion);

            //// 设置合并后单元格的样式
            //ICellStyle mergedCellStyle = workbook.CreateCellStyle();
            //mergedCellStyle.Alignment = HorizontalAlignment.Center;
            //mergedCellStyle.VerticalAlignment = VerticalAlignment.Center;
            //cell1.CellStyle = mergedCellStyle;

            workbook.Write(fs);           //写入到Excel中 
        }
    }

    public static void Main()
    {
        var observable = Enumerable.Range(1, 100).ToObservable(NewThreadScheduler.Default);

        Subject<int> subject = new Subject<int>();

        subject.Subscribe((temp) => Console.WriteLine($"当前温度: {temp}"));
        subject.Subscribe((temperature) => Console.WriteLine($"嘟嘟嘟，当前水温：{temperature}"));//订阅subject

        observable.Subscribe(subject);


        Console.ReadLine();
    }
}