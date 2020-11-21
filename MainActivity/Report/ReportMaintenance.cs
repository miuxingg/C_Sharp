using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace MainActivity.Report
{
    class ReportMaintenance
    {
        public ReportMaintenance()
        {
            
        }

        public void ReportMainenance1(DataTable tableMonth, DataTable tableQuy, DataTable tableYear)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            //Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1]; // dua con tro vao A1

            Excel.Range header = (Excel.Range)exSheet.Cells[1, 2];
            header.Font.Size = 30;
            header.Font.Color = Color.Red;
            header.Font.Bold = true;
            header.Value = "Báo cáo tổng tiền thuê máy của từng phòng";

            Excel.Range titelMonth = (Excel.Range)exSheet.Cells[4, 4];
            titelMonth.Font.Size = 20;
            titelMonth.Font.Color = Color.Blue;
            titelMonth.Font.Bold = true;
            titelMonth.Value = "Báo cáo tổng tiền thuê máy theo tháng";

            exSheet.get_Range("D7:Q7").Font.Bold = true;
            exSheet.get_Range("D7:Q7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //exSheet.get_Range("D7:Q7").
            
            exSheet.get_Range("D7").Value = "STT";
            exSheet.get_Range("E7").Value = "Tên phòng";
            exSheet.get_Range("F7").Value = "Tháng 1";
            exSheet.get_Range("G7").Value = "Tháng 2";
            exSheet.get_Range("H7").Value = "Tháng 3";
            exSheet.get_Range("I7").Value = "Tháng 4";
            exSheet.get_Range("J7").Value = "Tháng 5";
            exSheet.get_Range("K7").Value = "Tháng 6";
            exSheet.get_Range("L7").Value = "Tháng 7";
            exSheet.get_Range("M7").Value = "Tháng 8";
            exSheet.get_Range("N7").Value = "Tháng 9";
            exSheet.get_Range("O7").Value = "Tháng 10";
            exSheet.get_Range("P7").Value = "Tháng 11";
            exSheet.get_Range("Q7").Value = "Tháng 12";

            for(int i =0; i< tableMonth.Rows.Count; i++)
            {
                exSheet.get_Range("D" + (i + 8).ToString() + ":Q" + (i + 8).ToString()).Font.Bold = false;
                exSheet.get_Range("D" + (i + 8).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("E" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Phòng"].ToString();
                exSheet.get_Range("F" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 1"].ToString();
                exSheet.get_Range("G" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 2"].ToString();
                exSheet.get_Range("H" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 3"].ToString();
                exSheet.get_Range("I" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 4"].ToString();
                exSheet.get_Range("J" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 5"].ToString();
                exSheet.get_Range("K" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 6"].ToString();
                exSheet.get_Range("L" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 7"].ToString();
                exSheet.get_Range("M" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 8"].ToString();
                exSheet.get_Range("N" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 9"].ToString();
                exSheet.get_Range("O" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 10"].ToString();
                exSheet.get_Range("P" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 11"].ToString();
                exSheet.get_Range("Q" + (i + 8).ToString()).Value = tableMonth.Rows[i]["Tháng 12"].ToString();
            }

            Excel.Range titelQuy = (Excel.Range)exSheet.Cells[15, 4];
            titelQuy.Font.Size = 20;
            titelQuy.Font.Color = Color.Blue;
            titelQuy.Font.Bold = true;
            titelQuy.Value = "Báo cáo tổng tiền thuê máy theo Quý";

            exSheet.get_Range("D17:I17").Font.Bold = true;
            exSheet.get_Range("D17:I17").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("D17").Value = "STT";
            exSheet.get_Range("E17").Value = "Tên phòng";
            exSheet.get_Range("F17").Value = "Quý 1";
            exSheet.get_Range("G17").Value = "Quý 2";
            exSheet.get_Range("H17").Value = "Quý 3";
            exSheet.get_Range("I17").Value = "Quý 4";

            for(int i = 0; i < tableQuy.Rows.Count; i++)
            {
                exSheet.get_Range("D" + (i + 18).ToString() + ":I" + (i + 18).ToString()).Font.Bold = false;
                exSheet.get_Range("D" + (i + 18).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("E" + (i + 18).ToString()).Value = tableQuy.Rows[i]["Phòng"].ToString();
                exSheet.get_Range("F" + (i + 18).ToString()).Value = tableQuy.Rows[i]["Quý 1"].ToString();
                exSheet.get_Range("G" + (i + 18).ToString()).Value = tableQuy.Rows[i]["Quý 2"].ToString();
                exSheet.get_Range("H" + (i + 18).ToString()).Value = tableQuy.Rows[i]["Quý 3"].ToString();
                exSheet.get_Range("I" + (i + 18).ToString()).Value = tableQuy.Rows[i]["Quý 4"].ToString();

            }

            Excel.Range titelYear = (Excel.Range)exSheet.Cells[25, 4];
            titelYear.Font.Size = 20;
            titelYear.Font.Color = Color.Blue;
            titelYear.Font.Bold = true;
            titelYear.Value = "Báo cáo tổng tiền thuê máy theo năm";

            exSheet.get_Range("D27:F27").Font.Bold = true;
            exSheet.get_Range("D27:F27").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("D27").Value = "STT";
            exSheet.get_Range("E27").Value = "Phòng";
            exSheet.get_Range("F27").Value = "Năm";

            for (int i = 0; i < tableYear.Rows.Count; i++)
            {
                exSheet.get_Range("D" + (i + 28).ToString() + ":I" + (i + 28).ToString()).Font.Bold = false;
                exSheet.get_Range("D" + (i + 28).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("E" + (i + 28).ToString()).Value = tableYear.Rows[i]["Phòng"].ToString();
                exSheet.get_Range("F" + (i + 28).ToString()).Value = tableYear.Rows[i]["Năm"].ToString();


            }

            exSheet.Name = "Báo cáo";
            exBook.Activate();
            //Thiết lập các thuộc tính của SaveFileDialog
            SaveFileDialog dlgSave;
            dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc)| *.doc | All files(*.*) | *.* ";
            dlgSave.FilterIndex = 1;
            dlgSave.FileName = "Báo cáo doanh thu";
            dlgSave.AddExtension = true;
            dlgSave.DefaultExt = ".xls";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel
            exApp.Quit();
        }
    }
}
