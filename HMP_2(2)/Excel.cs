using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal class Excel
    {
        DataTable schedule;
        string path;
        public Excel(DataTable schedule, string path) 
        {
            this.schedule = schedule;
            this.path = path;
        }
        public void generation_excelTable()
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet ws = wb.Worksheets.Add("DataTableToExcel");
            ws.Columns[0].ColumnWidth = 15;
            ws.Columns[1].ColumnWidth = 10;
            ws.Columns[2].ColumnWidth = 45;
            ws.Columns[3].ColumnWidth = 45;
            ws.Columns[4].ColumnWidth = 45;
            ws.Columns[5].ColumnWidth = 45;
            for (int i = 0; i < Program.day_subject; i++)
            {
                string range1 = "A" + (i * 6 + 2).ToString();
                string range2 = "A" + (i * 6 + 2 + 5).ToString();
                ws[range1 + ":" + range2].Merge();
            }
            for (int j = 0; j < Program.day_week; j++)
            {
                string range1 = "F" + (j * 6 + 2).ToString();
                string range2 = "F" + (j * 6 + 2 + 5).ToString();
                ws[range1 + ":" + range2].Merge();
            }
            using (var range = ws["A1:F37"])
            {
                range.Style.HorizontalAlignment = HorizontalAlignType.Center;
                range.Style.VerticalAlignment = VerticalAlignType.Center;
            }
            using (var range = ws["A1:F1"])
            {
                range.Style.Font.IsBold = true;
                range.Style.Font.Size = 12;
            }
            using (var range = ws["A1:A37"])
            {
                range.Style.Font.IsBold = true;
                range.Style.Font.Size = 12;
            }
            ws.InsertDataTable(schedule, true, 1, 1, true);
            wb.SaveToFile(path, ExcelVersion.Version2016);
            wb.Dispose();
        }

    }
}
