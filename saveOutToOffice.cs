using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Office.Interop.Word;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Sun.Winform.Util;
 
namespace Sun.Winform.Files
{
  /// <summary>
/// 将内容导出为文件类。
/// </summary>
/// <remarks>
/// 作者：SunYujing
/// 日期：2011-12-18
/// </remarks>
  public class ExportFile
  {
    /// <summary>
/// 将字符串存储为word文档格式的文件的方法(多线程)。
/// </summary>
/// <param name="strText">要保存的字符串内容。</param>
    public static void SaveAsWord(string p_str)
    {
      Thread thread = new Thread(SaveAsWordFile);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start(p_str);
    }
    /// <summary>
/// 将字符串存储为txt格式的文件的方法(多线程)。
/// </summary>
/// <param name="p_str"></param>
    public static void SaveAsTxt(string p_str)
    {
      Thread thread = new Thread(SaveAsTxtFile);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start(p_str);
    }
    /// <summary>
/// 导出数据表数据到Excel(多线程)。
/// </summary>
    public static void SaveAsExcel(System.Data.DataTable dataTable)
    {
      if (dataTable == null)
      {
        MessageUtil.ShowError("请先指定要导出的数据表");
        return;
      }
      Thread thread = new Thread(SaveAsExcelTableFile);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start(dataTable);
    }
    /// <summary>
/// 导出数据集数据到Excel(多线程)。
/// </summary>
    public static void SaveAsExcel(System.Data.DataSet dataSet)
    {
      if (dataSet == null)
      {
        MessageUtil.ShowError("请先指定要导出的数据集");
        return;
      }
      Thread thread = new Thread(SaveAsExcelSetFile);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start(dataSet);
    }
    /// <summary>
/// 将字符串存储为word文档格式的文件。
/// </summary>
/// <param name="strtext">要保存的字符串内容。</param>
    private static void SaveAsWordFile(object strtext)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "请选择文件存放路径";
      sfd.FileName = "导出数据";
      sfd.Filter = "Word文档(*.doc)|*.doc";
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      string FileName = sfd.FileName.ToLower();
      if (!FileName.Contains(".doc"))
      {
        FileName += ".doc";
      }
      if (FileName.Substring(FileName.LastIndexOf(Path.DirectorySeparatorChar)).Length <= 5)
      {
        MessageUtil.ShowThreadMessage("文件保存失败，文件名不能为空！");
        return;
      }
      try
      {
        DateTime start = DateTime.Now;
        MessageUtil.ShowThreadMessage("正在保存文件，请稍候...");
        Microsoft.Office.Interop.Word.ApplicationClass word = new Microsoft.Office.Interop.Word.ApplicationClass();
        Microsoft.Office.Interop.Word._Document doc;
        object nothing = System.Reflection.Missing.Value;
        doc = word.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
        doc.Paragraphs.Last.Range.Text = strtext.ToString();
        object myfileName = FileName;
        //将WordDoc文档对象的内容保存为doc文档
        doc.SaveAs(ref myfileName, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
        //关闭WordDoc文档对象
        doc.Close(ref nothing, ref nothing, ref nothing);
        //关闭WordApp组件对象
        word.Quit(ref nothing, ref nothing, ref nothing);
        GC.Collect();
        DateTime end = DateTime.Now;
        TimeSpan ts = end - start;
        MessageUtil.ShowMessage("文件保存成功，用时" + ts.ToString());
      }
      catch (System.Exception ex)
      {
        MessageUtil.ShowError(ex.Message);
      }
    }
    /// <summary>
/// 将字符串存储为txt文档格式的文件。
/// </summary>
/// <param name="strtext">要保存的字符串内容。</param>
    private static void SaveAsTxtFile(object strtext)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "请选择文件存放路径";
      sfd.FileName = "导出数据";
      sfd.Filter = "文本文档(*.txt)|*.txt";
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      string FileName = sfd.FileName.ToLower();
      if (!FileName.Contains(".txt"))
      {
        FileName += ".txt";
      }
      if (FileName.Substring(FileName.LastIndexOf(Path.DirectorySeparatorChar)).Length <= 5)
      {
        MessageUtil.ShowThreadMessage("文件保存失败，文件名不能为空！");
        return;
      }
      try
      {
        DateTime start = DateTime.Now;
        StreamWriter sw = new StreamWriter(FileName, false);
        sw.Write(strtext.ToString());
        sw.Flush();
        sw.Close();
        DateTime end = DateTime.Now;
        TimeSpan ts = end - start;
        MessageUtil.ShowMessage("文件保存成功，用时" + ts.ToString());
      }
      catch (Exception ex)
      {
        MessageUtil.ShowError(ex.Message);
      }
    }
    /// <summary>
/// 将数据存储为Excel文件。
/// </summary>
/// <param name="p_dt">要保存的数据表。</param>
    private static void SaveAsExcelTableFile(object p_dt)
    {
      System.Data.DataTable dt = (System.Data.DataTable)p_dt;
      if (dt.Rows.Count == 0)
      {
        MessageUtil.ShowError("没有可保存的数据");
        return;
      }
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "请选择文件存放路径";
      sfd.FileName = "导出数据";
      sfd.Filter = "Excel文档(*.xls)|*.xls";
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      string FileName = sfd.FileName.ToLower();
      if (!FileName.Contains(".xls"))
      {
        FileName += ".xls";
      }
      if (FileName.Substring(FileName.LastIndexOf(Path.DirectorySeparatorChar)).Length <= 5)
      {
        MessageUtil.ShowThreadMessage("文件保存失败，文件名不能为空！");
        return;
      }
      if (sfd.FileName != "")
      {
        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        if (excelApp == null)
        {
          MessageBox.Show("无法创建Excel对象，可能您的机器未安装Excel");
          return;
        }
        else
        {
          MessageUtil.ShowThreadMessage("正在导出数据，请稍候...");
          DateTime start = DateTime.Now;
          Microsoft.Office.Interop.Excel.Workbooks workbooks = excelApp.Workbooks;
          Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
          Microsoft.Office.Interop.Excel.Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
 
          for (int col = 1; col <= dt.Columns.Count; col++)
          {
            worksheet.Cells[1, col] = dt.Columns[col - 1].Caption.ToString();
          }
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
              worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
            }
          }
          workbook.Saved = true;
          workbook.SaveCopyAs(sfd.FileName);
          //释放资源
          System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
          worksheet = null;
          System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
          workbook = null;
          workbooks.Close();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
          workbooks = null;
          excelApp.Quit();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
          excelApp = null;
          //使用垃圾回收可以关闭EXCEL.EXE进程
          GC.Collect();
          DateTime end = DateTime.Now;
          int iTimeSpan = (end.Minute - start.Minute) * 60 + (end.Second - start.Second);
          MessageUtil.ShowMessage("数据导出完毕,用时" + iTimeSpan.ToString() + "秒");
        }
      }
    }
    /// <summary>
/// 将数据集存储为Excel文件。
/// </summary>
/// <param name="p_ds">要导出的数据集。</param>
    private static void SaveAsExcelSetFile(object p_ds)
    {
      System.Data.DataSet ds = (System.Data.DataSet)p_ds;
      if (ds == null || ds.Tables.Count == 0)
      {
        MessageUtil.ShowError("没有可保存的数据");
        return;
      }
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "请选择文件存放路径";
      sfd.FileName = "导出数据";
      sfd.Filter = "Excel文档(*.xls)|*.xls";
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      string FileName = sfd.FileName.ToLower();
      if (!FileName.Contains(".xls"))
      {
        FileName += ".xls";
      }
      if (FileName.Substring(FileName.LastIndexOf(Path.DirectorySeparatorChar)).Length <= 5)
      {
        MessageUtil.ShowThreadMessage("文件保存失败，文件名不能为空！");
        return;
      }
      if (sfd.FileName != "")
      {
        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        if (excelApp == null)
        {
          MessageBox.Show("无法创建Excel对象，可能您的机器未安装Excel");
          return;
        }
        else
        {
          MessageUtil.ShowThreadMessage("正在导出数据，请稍候...");
          DateTime start = DateTime.Now;
          Microsoft.Office.Interop.Excel.Workbooks workbooks = excelApp.Workbooks;
          Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
          Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
          object objMissing = System.Reflection.Missing.Value;
          for (int m = 0; m < ds.Tables.Count; m++)
          {
            System.Data.DataTable dt = ds.Tables[m];
            worksheet = (Worksheet)workbook.ActiveSheet;
            worksheet.Name = dt.TableName;
            for (int col = 1; col <= dt.Columns.Count; col++)
            {
              worksheet.Cells[1, col] = dt.Columns[col - 1].Caption.ToString();
            }
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
              for (int j = 1; j <= dt.Columns.Count; j++)
              {
                worksheet.Cells[i + 1, j] = dt.Rows[i - 1][j - 1].ToString();
              }
            }
            if (m < ds.Tables.Count - 1)
            {
              workbook.Sheets.Add(objMissing, objMissing, 1, XlSheetType.xlWorksheet);
            }
          }
          workbook.Saved = true;
          workbook.SaveCopyAs(sfd.FileName);
          //释放资源
          System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
          worksheet = null;
          System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
          workbook = null;
          workbooks.Close();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
          workbooks = null;
          excelApp.Quit();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
          excelApp = null;
          GC.Collect();
          DateTime end = DateTime.Now;
          int iTimeSapn = (end.Minute - start.Minute) * 60 + (end.Second - start.Second);
          MessageUtil.ShowMessage("数据导出完毕,用时" + (iTimeSapn / 60).ToString() + "分" + (iTimeSapn % 60).ToString() + "秒");
        }
      }
    }
  }
}