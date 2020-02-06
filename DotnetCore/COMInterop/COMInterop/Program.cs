using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace COMInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Excel.Application();
            app.Visible = true;
            app.Workbooks.Add();
            Excel._Worksheet sheet = (Excel.Worksheet)app.ActiveSheet;
            sheet.Cells[1, "A"] = "Number";
            sheet.Cells[1, "B"] = "Value";

            var row = 2;
            for (int i = 0; i < 10; i++, row++)
            {
                sheet.Cells[row, "A"] = i;
                sheet.Cells[row, "B"] = i * i;
            }
            sheet.Columns[1].AutoFit();
            sheet.Columns[2].AutoFit();
            
        }
    }
}
