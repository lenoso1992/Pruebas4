using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pruebas4.Extensions
{
    public class ExcelResult : ActionResult
    {
        private string _name { get; set; }
        private IEnumerable<Album> _data { get; set; }

        public ExcelResult(string name, IEnumerable<Album> data)
        {
            _name = name;
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_data == null)
            {
                return;
            }

            var response = context.HttpContext.Response;
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=" + _name + ".xlsx");

            using (var stream = createExcelFile(_name, _data))
            {
                stream.WriteTo(response.OutputStream);
            }
        }

        private MemoryStream createExcelFile(string name, IEnumerable<object> data)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet(name);
            var row = 1;
            var col = 1;

            var type = data.First().GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                var cell = worksheet.Cell(row, col++);
                cell.Value = prop.Name;
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.Blue;
            }

            foreach (var elem in data)
            {
                row++;
                col = 1;
                foreach (var prop in props)
                {
                    var cell = worksheet.Cell(row, col++);
                    cell.Value = prop.GetValue(elem);
                }
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream;
        }
    }
}