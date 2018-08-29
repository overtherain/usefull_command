protected void ExportExcel() 
{ 
gridbind(); 

if(ds1==null) return; 

string saveFileName=""; 
// bool fileSaved=false; 
SaveFileDialog saveDialog=new SaveFileDialog(); 
saveDialog.DefaultExt ="xls"; 
saveDialog.Filter="Excel文件|*.xls"; 
saveDialog.FileName ="Sheet1"; 
saveDialog.ShowDialog(); 
saveFileName=saveDialog.FileName; 
if(saveFileName.IndexOf(":")<0) return; //被点了取消 
// excelapp.Workbooks.Open (App.path & \\工程进度表.xls) 


Excel.Application xlApp=new Excel.Application(); 
object missing=System.Reflection.Missing.Value; 


if(xlApp==null) 
{ 
MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel"); 
return; 
} 
Excel.Workbooks workbooks=xlApp.Workbooks; 
Excel.Workbook workbook=workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet); 
Excel.Worksheet worksheet=(Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
Excel.Range range; 


string oldCaption=Title_label .Text.Trim (); 
long totalCount=ds1.Tables[0].Rows.Count; 
long rowRead=0; 
float percent=0; 

worksheet.Cells[1,1]=Title_label .Text.Trim (); 
//写入字段 
for(int i=0;i<ds1.Tables[0].Columns.Count;i++) 
{ 
worksheet.Cells[2,i+1]=ds1.Tables[0].Columns.ColumnName; 
range=(Excel.Range)worksheet.Cells[2,i+1]; 
range.Interior.ColorIndex = 15; 
range.Font.Bold = true; 

} 
//写入数值 
Caption .Visible = true; 
for(int r=0;r<ds1.Tables[0].Rows.Count;r++) 
{ 
for(int i=0;i<ds1.Tables[0].Columns.Count;i++) 
{ 
worksheet.Cells[r+3,i+1]=ds1.Tables[0].Rows[r]; 
} 
rowRead++; 
percent=((float)(100*rowRead))/totalCount; 
this.Caption.Text= "正在导出数据["+ percent.ToString("0.00") +"%]..."; 
Application.DoEvents(); 
} 
worksheet.SaveAs(saveFileName,missing,missing,missing,missing,missing,missing,missing,missing); 

this.Caption.Visible= false; 
this.Caption.Text= oldCaption; 

range=worksheet.get_Range(worksheet.Cells[2,1],worksheet.Cells[ds1.Tables[0].Rows.Count+2,ds1.Tables[0].Columns.Count]); 
range.BorderAround(Excel.XlLineStyle.xlContinuous,Excel.XlBorderWeight.xlThin,Excel.XlColorIndex.xlColorIndexAutomatic,null); 

range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic; 
range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =Excel.XlLineStyle.xlContinuous; 
range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight =Excel.XlBorderWeight.xlThin; 

if(ds1.Tables[0].Columns.Count>1) 
{ 
range.Borders[Excel.XlBordersIndex.xlInsideVertical].ColorIndex=Excel.XlColorIndex.xlColorIndexAutomatic; 
} 
workbook.Close(missing,missing,missing); 
xlApp.Quit(); 
} 