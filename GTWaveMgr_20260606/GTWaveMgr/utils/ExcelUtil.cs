using AnyLosk.widget;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireFly.utils
{
	public	class	ExcelUtil
	{
        public  void    ReadExcelData(string biz_no, string title, string fileExcel, MySqlDataReader table)
        {
            if (File.Exists(fileExcel) == false)
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application  excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook     workBook = null;

            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();                             // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(fileExcel,
                    0,
                    true,
                    5,
                    "",
                    "",
                    true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                    "\t",
                    false,
                    false,
                    0,
                    true,
                    1,
                    0);

                Microsoft.Office.Interop.Excel.Worksheet workSheet = workBook.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;

                // Sheet항목들을 돌아가면서 내용을 확인
                //foreach (Microsoft.Office.Interop.Excel.Worksheet workSheet in workBook.Worksheets)
                //{
                //buff.Add("");
                Console.WriteLine(workSheet.Name); // 표시용 데이터 추가

                Microsoft.Office.Interop.Excel.Range range = workSheet.UsedRange;    // 사용중인 셀 범위를 가져오기

                /*
                // 가져온 행(row) 만큼 반복
                for (int row = 1; row <= range.Rows.Count; row++)
                {
                    //List<string> lstCell = new List<string>();

                    // 가져온 열(row) 만큼 반복
                    for (int column = 1; column <= range.Columns.Count; column++)
                    {
                        object obj = (range.Cells[row, column] as Microsoft.Office.Interop.Excel.Range).Value2;
                        string str = obj.ToString();    // 셀 데이터 가져옴
                        //lstCell.Add(str);               // 리스트에 할당
                        Console.WriteLine(str); // 표시용 데이터 추가
                    }

                }
                */
                int row = 3;
                
                while (table.Read())
                {
                    (range.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value2 = table["SALE_SUM"].ToString();

                    //CouSaleInfo loan = new CouSaleInfo();
                    //loan.setInfo4Excel(table);
                    //loan.mMemId = table["MEM_ID"].ToString();
                    //loan.mMemNm = table["MEM_NAME"].ToString();

                    //ListViewItem lv_sale = loan.getItem4Loan(3);
                    //lv_pawn_excel.Items.Add(lv_sale);
                    row++;
                }

                object missing  = Type.Missing;
                object noSave   = false;

                string nowDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                string pathFilename = string.Empty;

                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Title = "Excel 파일 저장",
                    DefaultExt = "xlsx",
                    FileName = $"{title}_{nowDateTime}.xlsx",
                    Filter = "Xlsx files(*.xlsx)|*.xlsx"
                };

                // OK버튼을 눌렀을때의 동작
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    // 경로와 파일명을 fileName에 저장
                    pathFilename = saveFile.FileName.ToString();
                    workBook.SaveAs(Filename: pathFilename);
                }

                
                workBook.Close(noSave, missing, missing); // 엑셀 웨크북 종료
                excelApp.Quit();        // 엑셀 어플리케이션 종료
            }
            finally
            {
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }

        }

        void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    // 객체 메모리 해제
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();   // 가비지 수집
            }
        }

        public  void    ReportToExcel(Form form, string title, ListView lv, DateTime s_date, DateTime e_date)
        {
            string nowDateTime  = DateTime.Now.ToString("yyyyMMddHHmmss");
            string pathFilename = string.Empty;

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Title = "Excel 파일 저장",
                DefaultExt = "xlsx",
                FileName = $"{title}_{nowDateTime}.xlsx",
                Filter = "Xlsx files(*.xlsx)|*.xlsx"
            };

            // OK버튼을 눌렀을때의 동작
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                ProgressForm.Start();

                // 경로와 파일명을 fileName에 저장
                pathFilename = saveFile.FileName.ToString();

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                excel.DisplayAlerts = false;

                //1. 워크시트 선택
                //처음에는 Sheet1로 1개 있음
                Worksheet worksheet = workbook.Worksheets.Item["Sheet1"];
                //여러 시트를 하려면 인덱스를 추가해서 받아서 사용 (2번째 부터는)
                //workbook.Worksheets.Add(After: workbook.Worksheets[index - 1]);
                //Worksheet worksheet = workbook.Worksheets.Item[index];

                //2. 필요시 시트 이름 변경
                worksheet.Name = nowDateTime;

                //3. 컬럼 별로 너비 변경
                Range ModRange = worksheet.Columns[1];
                ModRange.ColumnWidth = 30;
                ModRange = worksheet.Columns[2];
                ModRange.ColumnWidth = 30;
                //넘버포맷을 사용하면 뒤 컬럼부터는 숫자형식으로 적용
                ModRange.NumberFormat = "@";
                ModRange = worksheet.Columns[3];
                ModRange.ColumnWidth = 30;
                ModRange = worksheet.Columns[4];
                ModRange.ColumnWidth = 30;

                //4. 첫번째 줄 타이틀 생성 - 예쁘게 하기 위해
                //Range는 엑셀을 실행해서 참고하기 좋음 (첫줄이라 1라인)
                ModRange = (Range)worksheet.get_Range("A1", "D1");
                ModRange.Merge(true); //병합하고
                ModRange.Value = title;
                ModRange.Font.Size = 16; //폰트 키우고
                ModRange.Font.Bold = true; //Bold 주고
                ModRange.HorizontalAlignment = XlHAlign.xlHAlignLeft; //좌측 정렬
                                                                      //테두리 까지 끝
                ModRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, XlColorIndex.xlColorIndexAutomatic);

                //5. 2번째 줄에는 리포트 기간 및 파일 설명 추가
                ModRange = (Range)worksheet.get_Range("A2", "D2");
                ModRange.Merge(true);
                //DateTimePicker의 값을 그대로 넣어서 정보로 활용할 수 있음
                ModRange.Value = $"기간: {s_date:yyyy-MM-dd} ~ {e_date:yyyy-MM-dd}";
                //2번째 설명은 우측 정렬
                ModRange.HorizontalAlignment = XlHAlign.xlHAlignRight;

                //ex. 테두리를 위해 그리드 축 개수를 담아두고
                int columnCount = lv.Columns.Count;
                int rowCount = lv.Items.Count;

                //5. 헤드열 추가
                //cell은 1부터 row나 column은 일반적인 0부터라 차이가 있는 점 주의
                for (int i = 0; i < columnCount; i++)
                {
                    ModRange = (Range)worksheet.Cells[3, 1 + i];
                    ModRange.Value = lv.Columns[i].Text;
                    ModRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    //data 테두리
                    ModRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, XlColorIndex.xlColorIndexAutomatic);
                    ModRange.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium; //위 테두리
                    if (i == 0) //시작 컬럼에서 왼쪽 테두리
                    {
                        ModRange.Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlMedium;
                    }
                    else if (i == (columnCount - 1)) //마지막 컬럼에서 우측 테두리
                    {
                        ModRange.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                    }
                    //아래 2줄 얇은 테두리
                    ModRange.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                    ModRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThick;
                }

                //6. 데이터 열 추가
                for (int i = 0; i < rowCount; i++)
                {
                    ListViewItem item = lv.Items[i];
                    for (int j = 0; j < columnCount; j++)
                    {
                        //타이틀, 추가설명, 헤드, 0->1 때문에 i에 4를 더함
                        ModRange = (Range)worksheet.Cells[4 + i, 1 + j];
                        ModRange.Value = item.SubItems[j].Text == null ? string.Empty : item.SubItems[j].Text;

                        //data 테두리
                        ModRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, XlColorIndex.xlColorIndexAutomatic);
                        if (j == 0) //시작 컬럼에서 왼쪽 테두리
                        {
                            ModRange.Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlMedium;
                        }
                        else if (j == (columnCount - 1)) //마지막 컬럼에서 우측 테두리
                        {
                            ModRange.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                        }
                        if (i == (rowCount - 1)) //마지막 로우에서 우측 테두리
                        {
                            ModRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                            //결산 같은 마지막 줄 값이 존재하면 이걸 사용합니다.
                            //ModRange.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlDouble;
                        }
                    }
                }

                //7. 상단 고정필드 설정
                worksheet.Application.ActiveWindow.SplitRow = 1;
                worksheet.Application.ActiveWindow.FreezePanes = true;
                worksheet.Application.ActiveWindow.SplitRow = 2;
                worksheet.Application.ActiveWindow.FreezePanes = true;
                worksheet.Application.ActiveWindow.SplitRow = 3;
                worksheet.Application.ActiveWindow.FreezePanes = true;

                //8. 파일 저장 (앞선 SaveFileDialog로 만들어진 pathFilename 경로로 파일 저장
                workbook.SaveAs(Filename: pathFilename);
                workbook.Close();
                MessageBox.Show("출력 완료.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProgressForm.Close(form);
            }
        }
    }
}
