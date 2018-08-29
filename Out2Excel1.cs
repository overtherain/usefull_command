public void Out2Excel(string sTableName,string url) 
{ 
Excel.Application oExcel=new Excel.Application(); 
Workbooks oBooks; 
Workbook oBook; 
Sheets oSheets; 
Worksheet oSheet; 
Range oCells; 
string sFile="",sTemplate=""; 
// 
System.Data.DataTable dt=TableOut(sTableName).Tables[0]; 

sFile=url+"\\myExcel.xls"; 
sTemplate=url+"\\MyTemplate.xls"; 
// 
oExcel.Visible=false; 
oExcel.DisplayAlerts=false; 
//定义一个新的工作簿 
oBooks=oExcel.Workbooks; 
oBooks.Open(sTemplate,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing, Type.Missing, Type.Missing); 
oBook=oBooks.get_Item(1); 
oSheets=oBook.Worksheets; 
oSheet=(Worksheet)oSheets.get_Item(1); 
//命名该sheet 
oSheet.Name="Sheet1"; 

oCells=oSheet.Cells; 
//调用dumpdata过程，将数据导入到Excel中去 
DumpData(dt,oCells); 
//保存 
oSheet.SaveAs(sFile,Excel.XlFileFormat.xlTemplate,Type.Missing,Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing); 
oBook.Close(false, Type.Missing,Type.Missing); 
//退出Excel，并且释放调用的COM资源 
oExcel.Quit(); 

GC.Collect(); 
KillProcess("Excel"); 
} 

private void KillProcess(string processName) 
{ 
System.Diagnostics.Process myproc= new System.Diagnostics.Process(); 
//得到所有打开的进程 
try 
{ 
foreach (Process thisproc in Process.GetProcessesByName(processName)) 
{ 
if(!thisproc.CloseMainWindow()) 
{ 
thisproc.Kill(); 
} 
} 
} 
catch(Exception Exc) 
{ 
throw new Exception("",Exc); 
} 
} 