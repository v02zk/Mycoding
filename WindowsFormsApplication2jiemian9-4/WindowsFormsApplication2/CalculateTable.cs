using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class CalculateTable
    {
        private Regex regex = new Regex(@"[A-Z]\r");
        private Regex over = new Regex(@"[A-Z](\d)*");

        private List<string> itemName = new List<string>();
        private string title = "";
        private List<Decimal> originalValue = new List<Decimal>();
        private List<Decimal> calValue = new List<Decimal>();
        private List<int> lineInfo = new List<int>();

        Boolean flag = false;

        public List<string> calTableShowMssing(Table comTable, Table normalTable, DataGridView dataTableView, RichTextBox richTex, string tableName,List <int>flagList)//coTable为对比表格，normalTable为标准表格
        {
            int[] startLocation = getStartLocation(comTable);
            int columns = calColumn(comTable, startLocation[0], startLocation[1]);
            title = tableName;
            buildShowTable(dataTableView,columns,flagList);
            
            calTable(comTable, dataTableView,startLocation[0],startLocation[1],columns);
            
            checkTable(comTable, normalTable, richTex);
            return itemName;
            //showTable(columns, dataTableView);
        }
        private int calculateSum(int i, int j, Table table, int col, DataGridView dataView, int tableLine)    //一个主项递归计算（部分递归，效率提高）计算第i行j列主项的第col列值,在显示表中是第tableLine行
        {
            int itemRow = i;
            int itemColumn = j;
            int count = 0;//第几个子项（2类）

            i++;
            j++;
            Decimal sum = 0;
            while (true)     //循环计算主项里面的值
            {
                int newLine = 0;

                Decimal value = getNormalValue(i, j + col, table);
                sum += value;


                int isMItem = isMainItem(i, j, table);
                if (isMItem == 2)      //遇到子项是主项则计算主项并返回newLine
                {
                    count++;
                    newLine = calculateSum(i, j, table, col, dataView, count + tableLine);

                    i = newLine;
                }
                else               //如果子项不是主项情况2则行数递增1，继续计算
                {
                    i++;
                }
 
                Match m = over.Match(table.Cell(i, j - 1).Range.Text);
                if (m.Length == 0)//如果当前主项计算完毕，打印计算值，并返回新的计算行(左边单元格匹配不到大写字母）
                {
                    if (value != -1)
                    {
                        // System.Diagnostics.Debug.WriteLine(sum + "  ssss");
                        System.Diagnostics.Debug.WriteLine(tableLine + " dddd  " + sum);
                        lineInfo.Add(tableLine);

                        addViewItem(tableLine, col, dataView, table, itemRow, itemColumn, sum);

                        calValue.Add(sum);
                        addValueItem(itemRow, itemColumn, table, col);
                    }
                    else
                    {
                    }

                    if (i == table.Rows.Count)//遍历到最低端
                    {
                        flag = true;//结束完一轮计算
                        return table.Rows.Count;
                    }
                    return i;
                }
            }
        }

        private void addViewItem(int tableLine, int col, DataGridView dataView, Table table, int i, int j, Decimal sum)//将表中i j单元格主项添加到显示表index col 单元格
        {                                                                                                  //当添加的是col==1时，要将表项名称添加到第0列
            Decimal value = getNormalValue(i, j + col, table);
            if (col == 1)//第一次添加要加入表项名
            {
                string item = table.Cell(i, j).Range.Text;
                item = getNormalCell(item);

                addTableViewRows(tableLine, dataView);

                dataView.Rows[tableLine].Cells[0].Value = item;
            }
            dataView.Rows[tableLine].Cells[col * 2 - 1].Value = value;
            dataView.Rows[tableLine].Cells[col * 2].Value = sum;
            if (sum != value)
            {
                dataView.Rows[tableLine].Cells[col * 2].Style.BackColor = Color.Red;
            }
        }
        private void addTableViewRows(int tableLine, DataGridView dataView)
        {
            int row = dataView.Rows.Count - 2;

            while (row < tableLine)   //当插入行大于dataView的总行数时，插入行知道tableLine等于dataView行数
            {
                dataView.Rows.Add();
                row = dataView.Rows.Count - 2;
            }

        }
        private int getItems(int i, int j, Table table, Dictionary<string, string> keyItem)    //一个主项递归计算（部分递归，效率提高）
        {
            addMItems(i, j, table, keyItem);
            i++;
            j++;

            while (true)     //循环计算主项里面的值
            {
                int newLine = 0;

                addSubItems(i, j, table, keyItem);
                int isMItem = isMainItem(i, j, table);
                if (isMItem == 2)      //遇到子项是主项则计算主项并返回newLine
                {
                    newLine = getItems(i, j, table, keyItem);
                    i = newLine;
                }
                else               //如果子项不是主项情况2则行数递增1，继续计算
                {
                    i++;
                }
                if (i > table.Rows.Count)  //如果行数大于表行则终止递归,输出sum
                {
                    return i - 1;
                }
                Match m = over.Match(table.Cell(i, j - 1).Range.Text);
                if (m.Length == 0)//如果当前主项计算完毕，打印计算值，并返回新的计算行(左边单元格匹配不到大写字母）
                {

                    if (i == table.Rows.Count)//遍历到最低端
                    {
                        return table.Rows.Count;
                    }
                    return i;
                }
            }
        }
        private int isMainItem(int i, int j, Table table)
        {
            try
            {
                string cell = table.Cell(i + 1, j - 1).Range.Text;
                cell = getNormalCell(cell);
                if (cell.Equals("其中"))
                {
                    return 2;
                }
                cell = table.Cell(i, j - 1).Range.Text;
                Match m = regex.Match(cell);
                if (m.Length != 0)//如果左边是单个大写字母,则为主项情况1
                {
                    return 1;
                }

            }
            catch   //表格单元格不存在
            {

            }
            return 0;
        }
        public Boolean isNormalTable(Table table)
        {
            int[] location = getStartLocation(table);
            if (location[0] != 0 && location[1] != 0)
            {
                if (isMainItem(location[0], location[1], table) != 0)
                {
                    return true;
                }
            }
            return false;
        }
        private string getNormalCell(string cell)
        {
            int end = cell.IndexOf('\r');
            return cell.Substring(0, end);
        }
        private Decimal getNormalValue(int i, int j, Table table)
        {
            Decimal value = 0;
            try
            {
                string cell = table.Cell(i, j).Range.Text;
                cell = getNormalCell(cell);
                if (cell.Contains("-"))
                {
                    return value;
                }
                if (cell.Contains("%"))
                {
                    int end = cell.IndexOf('%');
                    cell = cell.Substring(0, end);
                }
                value = Convert.ToDecimal(cell);
                return value;
            }
            catch
            {
                return -1;//表示当前不存在（i,j）单元格即  第j列不存在
            }

        }

        private void addValueItem(int i, int j, Table table, int col)
        {
            if (flag == false)
            {
                string item = table.Cell(i, j).Range.Text;
                item = getNormalCell(item);
                itemName.Add(item);
            }
            Decimal value = getNormalValue(i, j + col, table);
            originalValue.Add(value);
        }
        private void addMItems(int i, int j, Table table, Dictionary<string, string> keyItem)
        {
            string value = table.Cell(i, j).Range.Text;
            string key = table.Cell(i, j - 1).Range.Text;
            key = getNormalCell(key);
            value = getNormalCell(value);
            if (keyItem.Count == 0)
            {
                keyItem.Add(key, value);
            }
            else if (!keyItem.Values.Last().Equals(value))
            {
                keyItem.Add(key, value);
            }
        }
        /*private void addMItems(int i, int j, Table table, List<string> itemNames)
        {
            string item = table.Cell(i, j).Range.Text;
            item = getNormalCell(item);
            if (itemNames.Count == 0)
            {
                itemNames.Add(item);
            }
            else if (!itemNames[itemNames.Count - 1].Equals(item))
            {
                itemNames.Add(item);
            }
        }*/
        private void addSubItems(int i, int j, Table table, Dictionary<string, string> itemNames)
        {
            string value = table.Cell(i, j).Range.Text;
            string key = table.Cell(i, j - 1).Range.Text;
            key = getNormalCell(key);
            value = getNormalCell(value);

            itemNames.Add(key, value);
        }
        private int[] getStartLocation(Table table)
        {
            int[] location = new int[2];
            int rows = table.Rows.Count;
            int columns = table.Columns.Count;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    try
                    {
                        string cell = table.Cell(i, j).Range.Text;
                        Match m = regex.Match(cell);
                        if (m.Length != 0)//匹配到第一个大写字母则终止查询
                        {
                            location[0] = i;
                            location[1] = j + 1;
                            return location;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return location;
        }
        private int calColumn(Table table, int i, int j)//计算有几列值需要被计算
        {
            int columns = 0;
            while (true)
            {
                try
                {
                    j++;
                    Cell cell = table.Cell(i, j);
                    columns++;
                }
                catch
                {
                    return columns;
                }
            }
        }


        private void calTable(Table table, DataGridView dataview,int startLocation0,int startLocation1,int columns) //返回计算列数
        {
            int rows = table.Rows.Count;
            int startFlag = dataview.Rows.Count;

            for (int i = 1; i <= columns; i++)    //有columns列值需要计算
            {
                int line = startLocation0;
                int tableLine = startFlag;
                while (true)
                {
                    int itemNumber = isMainItem(line, startLocation1, table);//计算主项种类：0、1、2
                    if (itemNumber == 1 || itemNumber == 0)   //如果当前单元格是主项情况1或0则继续寻找知道遇到主项2,再细算
                    {
                        line = findItem2(table, line, startLocation1);
                        if (line == 0)
                        {
                            break;
                        }
                    }

                    line = calculateSum(line, startLocation1, table, i, dataview, tableLine);

                    if (lineInfo.Count != 0)
                    {
                        tableLine = lineInfo.Max();
                        lineInfo.Clear();
                    }
                    tableLine++;
                    if (line == rows)
                    {
                        break;
                    }
                }
            }
        }
        /*   if (itemNumber == 0)
    {
        line++;
    }*/
        private void checkTable(Table comTable, Table normalTable, RichTextBox missingView)
        {
            Dictionary<string, string> dic1 = new Dictionary<string, string>();
            Dictionary<string, string> dic2 = new Dictionary<string, string>();

            for (int i = 1; i <= 2; i++)
            {
                Table table;
                if (i == 1)
                {
                    table = normalTable;
                }
                else
                {
                    table = comTable;
                }
                int rows = table.Rows.Count;
                int[] startLocation = getStartLocation(table);
                int line = startLocation[0];

                while (true)
                {
                    int itemNumber = isMainItem(line, startLocation[1], table);//计算主项种类：0、1、2
                    if (itemNumber == 1||itemNumber==0)   //如果当前单元格是主项情况1或0则继续寻找知道遇到主项2,再细算
                    {
                        if (itemNumber != 0)
                        {
                            if (i == 1)
                            {
                                addMItems(line, startLocation[1], table, dic1);
                            }
                            else
                            {
                                addMItems(line, startLocation[1], table, dic2);
                            }
                        }
                        line = findItem2(table, line, startLocation[1]);
                        if (line == 0)
                        {
                            break;
                        }
                    }

                    if (i == 1)
                    {
                        line = getItems(line, startLocation[1], table, dic1);
                    }
                    else
                    {
                        line = getItems(line, startLocation[1], table, dic2);
                    }
                    if (line == rows)
                    {
                        break;
                    }
                }
            }
            Dictionary<string, string> missingList = checkMissing(dic1, dic2);
            Dictionary<string, string> extraList = checkMissing(dic2, dic1);
            if (missingList.Count == 0)
            {
                missingView.Text += "******" + title + "******\r" + "无缺失条目\r";
            }
            else
            {
                missingView.Text += "******" + title + "******\r" + generateReport(missingList, dic1, "缺失项") + "\r";
            }
            if (extraList.Count == 0)
            {
                missingView.Text += "无多余条目\r\r";
            }
            else
            {
                missingView.Text += generateReport(extraList, dic2, "多余项") + "\r\r";
            }

        }
        private string generateReport(Dictionary<string, string> missingList, Dictionary<string, string> dic, string missingOrExtra)
        {
            string s = missingOrExtra + ":\r";
            foreach (KeyValuePair<string, string> kvp in missingList)
            {
                string t = kvp.Key.ToString();
                int length = t.Length;
                for (int i = 1; i < length; i++)
                {
                    try
                    {
                        string value = dic[t.Substring(0, i)];
                        if (i == 1)
                        {
                            s += "     *";
                        }
                        s += value + "-->";
                    }
                    catch
                    {
                    }                   
                }
                if (t.Length == 1)
                {
                    s += "     *"; 
                }
                s += kvp.Value + "\r";
            }
            return s;
        }
        private Dictionary<string, string> checkMissing(Dictionary<string, string> dic1, Dictionary<string, string> dic2)
        {
            Dictionary<string, string> missingList = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in dic1)
            {
                if (!dic2.Values.Contains(kvp.Value))
                {
                    missingList.Add(kvp.Key, kvp.Value);
                }
            }
            return missingList;
        }
        private int findItem2(Table table, int line, int column)
        {
            while (true)//循环直到找到主项情况2
            {
                line++;
                if (isMainItem(line, column, table) == 2)
                {
                    return line;
                }
                if (line == table.Rows.Count)   //大于表行还未找到则终止
                {
                    flag = true;//结束完一轮计算
                    return 0;
                }
            }
        }

        private void showTable(int columns, DataGridView dataTableView)
        {
            int rows = itemName.Count;
            if (dataTableView.Rows.Count == 0)
            {
                //buildShowTable(dataTableView,columns);
            }
            int startLine = dataTableView.Rows.Count - 2;
            for (int i = 0; i < rows + 1; i++)
            {
                if (i == 0)
                {
                    if (startLine != 0)
                    {
                        startLine++;
                        dataTableView.Rows.Add();
                    }
                    dataTableView.Rows[startLine].Cells[0].Value = title;
                    dataTableView.Rows[startLine].Cells[0].Style.Font = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                }
                else
                {
                    int index = dataTableView.Rows.Add();
                    dataTableView.Rows[index].Cells[0].Value = itemName[i - 1];
                }
            }
            for (int j = 1; j <= columns; j++)
            {
                int start = (j - 1) * rows;
                for (int i = 1; i <= rows; i++)
                {
                    dataTableView.Rows[i + startLine].Cells[j * 2 - 1].Value = originalValue[start + i - 1];
                    dataTableView.Rows[i + startLine].Cells[j * 2].Value = calValue[start + i - 1];
                    if (originalValue[start + i - 1] != calValue[start + i - 1])
                    {
                        dataTableView.Rows[i + startLine].Cells[j * 2].Style.BackColor = Color.Red;
                    }
                }
            }
        }
       /* private void buildShowTable(DataGridView dataTableView)
        {
            for (int i = 0; i < 2 * 9 + 1; i++)
            {
                dataTableView.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataTableView.Rows.Add();
            for (int j = 1; j <= 9; j++)
            {
                int start = (j - 1) * 2;
                dataTableView.Rows[0].Cells[start + 1].Value = j + "(原)";
                dataTableView.Rows[0].Cells[start + 2].Value = j + "(计)";
            }
        }*/
        private void buildShowTable(DataGridView dataTableView,int columns,List<int>flagList)
        {
           
            if (dataTableView.Rows.Count == 0)
            {
                buildColumn(dataTableView);
            }
            int startLine = dataTableView.Rows.Count-1;
            for (int j = 1; j <= 3; j++)
            {
                string name = "";
                if (j == 1)
                {
                    name = "面积（公顷）";
                }
                else if (j == 2)
                {
                    name = "所占比例(%)";
                }
                else
                {
                    name = "人均（m2/人）";
                }
                int bound = 2;
                if (columns == 6)
                {
                    bound = 4;
                }
                else if(columns==9)
                {
                    bound = 6;
                }
                int start = (j - 1) * bound;
                string s = "";
                for (int k = 1; k <= bound; k++)
                {
                    if (columns > 3)
                    {
                        if (k <= 2)
                        {
                            s = "现状";
                        }
                        if (k == 3 || k == 4)
                        {
                            s = "近期";
                        }
                        if (k > 4)
                        {
                            s = "远期";
                        }
                    }
                    else
                    {
                        s = "";
                    }
                    dataTableView.Rows[startLine].Cells[start + k].Value = name + s;
                }
            }
            dataTableView.Rows.Add();
            for (int i = 1; i <=columns; i++)
            {
                int start = (i - 1) * 2;
                dataTableView.Rows[startLine+1].Cells[start + 1].Value = "原始数据";
                dataTableView.Rows[startLine+1].Cells[start + 2].Value = "校验结果";
            }
            dataTableView.Rows[startLine].Cells[0].Value = title;
            dataTableView.Rows[startLine + 1].Cells[0].Value = title;
            flagList.Add(startLine);
        }
        private void addTableHead(int columns,DataGridView dataTableView,string name)
        {
        }
        private void buildColumn(DataGridView dataView)
        {
            for (int i = 0; i < 2 * 9 + 1; i++)
            {
                dataView.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataView.Rows.Add();
        }
        public Table getTableByName(Document doc, string title, Microsoft.Office.Interop.Word.Application testWord)  //testWord下的doc文档下
        //找到标题为title的表格
        {
            doc.Activate();
            testWord.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
            Find find = testWord.Selection.Find;
            find.Text = title;
            Selection currentSelect = testWord.Selection;
            bool ifFind = false;
            while (find.Execute())
            {
                string s = currentSelect.Paragraphs[1].Range.Text.Trim();
                if (s.Equals(title))
                {
                    ifFind = true;
                    break;
                }
            }
            if (ifFind == false)
            {
                return null;
            }
            while (currentSelect.Tables.Count == 0)
            {
                currentSelect.GoToNext(WdGoToItem.wdGoToLine);
            }
            Table table = currentSelect.Tables[1];
            return table;
        }
        /*完全递归版
private int calTable(Table table) //返回计算列数
{
    int[] startLocation = getStartLocation(table);
    int columns = calColumn(table, startLocation[0], startLocation[1]);
    for (int i = 1; i <= columns; i++)
    {
       calculateSum(startLocation[0], startLocation[1], table, i);
    }
    return columns;
}
 * */
        /*完全递归计算表格
        private int calculateSum(int i,int j,Table table,int col)
        {
            int itemRow = i;
            int itemColumn = j;

            i++;
            j++;
            Decimal sum = 0;
            while (true)     //循环计算主项里面的值
            {
                int newLine=0;
                
                Decimal value=getNormalValue(i,j+col,table);;
                sum += value;
                
                int isMItem = isMainItem(i, j, table);
                if (isMItem==2)      //遇到子项是主项则计算主项并返回newLine
                {
                    newLine = calculateSum(i, j, table,col);
                    i = newLine;
                }
                else               //如果子项不是主项情况2则行数递增1，继续计算
                {
                    i++;
                }
                if (i > table.Rows.Count)  //如果行数大于表行则终止递归,输出sum
                {
                    System.Diagnostics.Debug.WriteLine(sum+"  dddd");
                    calValue.Add(sum);
                    addValueItem(itemRow, itemColumn, table, col);
                    return i-1;
                }
                Match m = over.Match(table.Cell(i, j - 1).Range.Text);
                if (m.Length==0)//如果当前主项计算完毕，打印计算值，并返回新的计算行(左边单元格匹配不到大写字母）
                {
                    System.Diagnostics.Debug.WriteLine(sum+"  ssss");
                    calValue.Add(sum);
                    addValueItem(itemRow, itemColumn, table, col);
                    
                    if (i == table.Rows.Count)//遍历到最低端
                    {
                        flag = true;//结束完一轮计算
                        return 0;
                    }

                    if (isMainItem(i, j - 1, table) == 2)
                    {
                        calculateSum(i, j - 1, table,col);//   如果（i，j-1）是主项2继续计算下一个主项
                    }
                    else if (isMainItem(i, j-1, table) == 1)   //如果当前单元格是主项情况1则继续寻找知道遇到主项2,再细算
                    {
                        while (true)//循环直到找到主项情况2
                        {
                            i++;
                            if (isMainItem(i, j - 1, table) == 2)
                            {
                                calculateSum(i, j - 1, table,col);//   如果（i，j-1）是主项2继续计算下一个主项
                                return 0;
                            }
                            if (i > table.Rows.Count)   //大于表行还未找到则终止
                            {
                                flag = true;//结束完一轮计算
                                return 0;
                            }
                        }
                    }
                    return i;
                }  
            }
        }*/

    }
}
