using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication2;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.InteropServices;
using Application = Microsoft.Office.Interop.Word.Application;
namespace WindowsFormsApplication2
{
    class KeyWord
    {
        private Regex regex;
        private Regex regex1;
        private string tests = "";//存储所有keyWord后面的数字信息及页行信息
        private ArrayList list = new ArrayList();//存储关键字的页行信息
        private string[] keyList = { "居住用地", "公共管理与公共服务设施用地", "商业服务业设施用地", "工业用地", "仓储物流用地", "道路与交通设施用地", "公用设施用地", "绿地与广场用地" };

        public KeyWord(string text)
        {

        }
        public KeyWord()
        {
            regex = new Regex(@"[\[\]\,.?\(\)+_*\/\\&\$#^@!%~`<>:;\{\}？，；。""·！￥……（）+｛｝“”【】、|《》]|(?!\s)'\s+|\s+'(?!\s)|\s+");
            regex1 = new Regex(@"(\d+(:\d+)+|\d+([\.～-]?)\d*(%?))([\u4e00-\u9fa5/\w\xB3\xB2\.]*)");//@"(\d+([\.～-]?)\d*(%?)|\d+(:d+)+)([\u4e00-\u9fa5/]*)"
        }
        private string abstarctRichBoxString(string keyWord, Application testWord)//暂定private testDoc提取richBox内容
        {

            testWord.Selection.Find.Text = keyWord;//查询的文字
            string s = "";
            string previous = "";
            string now = "";
            Selection
            currentSelect = testWord.Selection;
            WdInformation pageNum = WdInformation.wdActiveEndAdjustedPageNumber;
            WdInformation rowNum = WdInformation.wdFirstCharacterLineNumber;
            while (testWord.Selection.Find.Execute())
            {
                object page = currentSelect.get_Information(pageNum);
                object row = currentSelect.get_Information(rowNum);
                previous = now;
                now = currentSelect.Paragraphs[1].Range.Text.Trim();
                list.Add(page);
                list.Add(row);
                if (!now.Equals(previous))
                    s += page + "页" + row + "行  " + now + "\r\r";
            }
            testWord.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
            return s;
        }
        private void getCountNumber(Application testWord, int[] countNumber,List<string>keyItemList)//暂定private testDoc提取richBox内容
        {
            int i = 0;
            foreach (string keyWord in keyItemList)
            {
                testWord.Selection.Find.Text = keyWord;//查询的文字
                Selection currentSelect = testWord.Selection;
                while (currentSelect.Find.Execute())
                {
                    countNumber[i]++;
                }
                testWord.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                i++;
            }
        }
        private void getStatisticsInformation(int count, int k, string s)//获取第count个keyWord的统计信息且剩余字符串为s,第count+1个关键字在位置k
        {
            string midString = "";//两个关键字之间的字符串
            /*
                * 抽取出keyWord后面的数字信息
                */
            if (k != 0)//如果前一个关键字和后一个关键字之间有字符,k=0时两个关键字之间无字符跳过
            {
                if (k > 0)
                {
                    midString = s.Substring(0, k);
                }
                else if (k < 0)//此时剩余字符串无关键字，则s即为待处理字符串
                {
                    midString = s;
                }
                int location = (count - 1) * 2;//第count个关键字在list中的位置信息
                Match m = regex.Match(midString);
                Match m1 = regex1.Match(midString);
                if (m1.Length != 0)//捕获到带数字的字符串
                {
                    if (m.Length != 0)//捕获到带标点符号的字符串
                    {
                        if (m1.Index < m.Index && m1.Index <= 6)
                        {
                            tests += list[location] + "页" + list[location + 1] + "行   " + m1.ToString() + "\r";
                        }
                    }
                    else if (m1.Index <= 6)
                    {
                        tests += list[location] + "页" + list[location + 1] + "行   " + m1.ToString() + "\r";
                    }
                }

            }
        }
        private string generateRichString(Application testWord,List<string>keyItemList)
        {
            string s = "";
            foreach(string keyWord in keyItemList)
            {
                s += abstarctRichBoxString(keyWord, testWord); 
            }
            return s;
        }
        public void highLightRichString(RichTextBox rbTableTest, Application testWord, Document doc,List<string>keyItemList)
        {
            doc.Activate();
            testWord.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
            string richString = generateRichString(testWord,keyItemList);
            int[] countNumber = new int[keyItemList.Count];
            getCountNumber(testWord,countNumber,keyItemList);
            rbTableTest.Clear();
            if (richString == "")
            {
                rbTableTest.Text = "此文档不存在这些关键字信息";
                return;
            }
            else
            {
                rbTableTest.Text = richString;
            }
            int i = 0;
            int sumLength = 0;//记录标识的绝对位置
            
            foreach (string keyWord in keyItemList)
            {
                int length = keyWord.Length;
                int k = richString.IndexOf(keyWord);
                int count = 0;
                int start = 0;
                while (k >= 0)
                {
                    count++;
                    start = sumLength + k;
                    rbTableTest.Select(start, length);
                    rbTableTest.SelectionBackColor = SysColor.ERROR;
                    richString = richString.Remove(0, k + length);//缩短总的testPage
                    sumLength += k + length;
                    k = richString.IndexOf(keyWord);
                    if (count == countNumber[i])
                    {
                        break;
                    }
                }
                i++;
            }

        }

        public void highLightKeyWords(string keyWord,
                               Application testWord, Document doc, RichTextBox richTextBox, Label keyWordCountLabel, RichTextBox statisticsInfor)/*对当前testWord的Doc文档在richTextBox进行
                                                                                                                           * keyWord的高亮显示,并在listBox上显示
                                                                                                                            * 关键字个数和在staticticsInfor上输出数值信息*/
        {
            doc.Activate();
            string s = abstarctRichBoxString(keyWord, testWord);
            richTextBox.Clear();
            if (s == "")
            {
                richTextBox.Text = "此关键字不存在";
            }
            else
            {
                richTextBox.Text = s;
            }
            int sumLength = 0;//记录标识的绝对位置
            int length = keyWord.Length;
            int k = s.IndexOf(keyWord);
            int count = 0;
            int start = 0;
            while (k >= 0)
            {
                count++;
                start = sumLength + k;
                richTextBox.Select(start, length);
                richTextBox.SelectionBackColor = SysColor.ERROR;
                s = s.Remove(0, k + length);//缩短总的testPage
                sumLength += k + length;
                k = s.IndexOf(keyWord);
                getStatisticsInformation(count, k, s);
            }
            string t = "数目:" + count;
            if (keyWordCountLabel != null)
            {
                keyWordCountLabel.Text = t; ;//关键字统计的listBox赋值关键字个数
            }
            //System.Diagnostics.Debug.WriteLine(tests);
            if (statisticsInfor != null)
            {
                if (tests == "")
                {
                    statisticsInfor.Text = "未找到该关键字的数值信息";
                }
                else
                {
                    statisticsInfor.Text = tests;
                }
            }
            //清空前一次统计信息
            tests = "";
            list.Clear();
        }
        public void multiHightLigthKeyWord(string preMultiTestFilePath, string preMultiRegFilePath, string preMultiSpecFilePath, string multiTestFilePath, string multiRegFilePath, string multiSpecFilePath,
            string keyWord, ApplicationClass testWord, RichTextBox rtbTest, RichTextBox rtbReg, RichTextBox rtbSpecification, Label test, Label reg,
             Label spec, RichTextBox testStatisticsInfor, RichTextBox regStatisticsInfor, RichTextBox specStatisticsInfor, HandleDocument handleDocument, Boolean isKeyChanged)
        {
            if (checkFilePathInput(multiTestFilePath, multiRegFilePath, multiSpecFilePath) == true)
            {
                if (multiTestFilePath != "" && (!multiTestFilePath.Equals(preMultiTestFilePath) || isKeyChanged))
                {
                    anyOneDocHighLigth(multiTestFilePath, testWord, keyWord, rtbTest, test, testStatisticsInfor, handleDocument);
                }
                if (multiRegFilePath != "" && (!multiRegFilePath.Equals(preMultiRegFilePath) || isKeyChanged))
                {
                    anyOneDocHighLigth(multiRegFilePath, testWord, keyWord, rtbReg, reg, regStatisticsInfor, handleDocument);
                }
                if (multiSpecFilePath != "" && (!multiSpecFilePath.Equals(preMultiSpecFilePath) || isKeyChanged))
                {
                    anyOneDocHighLigth(multiSpecFilePath, testWord, keyWord, rtbSpecification, spec, specStatisticsInfor, handleDocument);
                }
            }
        }


        private void anyOneDocHighLigth(string multiFilePath, ApplicationClass testWord, string keyWord, RichTextBox rtbHightLight,
            Label count, RichTextBox StatisticsInfor, HandleDocument handleDocument)
        {
            WaitingForm wf = new WaitingForm();
            HandleWaitingForm.startWaitingForm(wf);

            Document doc = handleDocument.openDocument(multiFilePath, testWord);
            highLightKeyWords(keyWord, testWord, doc, rtbHightLight, count, StatisticsInfor);
            closeDoc(doc);

            HandleWaitingForm.closeWaitingForm(wf);
        }
        private Boolean checkFilePathInput(string test, string reg, string spec)
        {
            Boolean c1 = false;
            Boolean c2 = false;
            if (test != "" || reg != "" || spec != "")
            {
                c1 = test.Equals(reg);
                c2 = test.Equals(spec);
                if (c1 || c2)
                {
                    if (c1 && test != "" && reg != "")
                    {
                        MessageBox.Show("目标文档规程文档应选择不同的路径");
                        return false;
                    }
                    else if (test != "" && spec != "")
                    {
                        MessageBox.Show("目标文档说明文档应选择不同的路径");
                        return false;
                    }
                }
                else if (reg.Equals(spec) && reg != "" && spec != "")
                {
                    MessageBox.Show("规程文档说明文档应选择不同的路径");
                    return false;
                }
            }
            return true;
        }
        private void closeDoc(Document doc)
        {
            Object saveChanges = false;
            object unknow = Type.Missing;

            doc.Close(ref saveChanges, ref unknow, ref unknow);
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        public string getExistStandard(string keyword)
        {
            StringBuilder temp = new StringBuilder(50);
            int re = GetPrivateProfileString("section", keyword, "", temp, 50, filePath.STANDARDVALUE);
            string t = temp.ToString();
            if (t.Length > 0)
                return t;
            return null;
        }
        public string getStandardList()
        {
            string standardList = "";
            foreach (string keyWord in keyList)
            {
                string value = getExistStandard(keyWord);
                if (value != null)
                {
                    standardList += keyWord+getExistStandard(keyWord) + "\r";
                }               
            }
            return standardList;
        }
    }
}
/*
                  if (k > 0)//如果前一个关键字和后一个关键字之间有字符
                {

                    midString = s.Substring(0, k);
                    Match m = regex.Match(midString);
                    Match m1 = regex1.Match(midString);
                    if (m1.Length != 0)//捕获到带数字的字符串
                    {
                        if (m.Length != 0)//捕获到带标点符号的字符串
                        {
                            if (m1.Index < m.Index && m1.Index <= 6)
                            {
                                tests += m1.ToString() + "\r";
                            }
                        }
                        else if (m1.Index <= 6)
                        {
                            tests += m1.ToString() + "\r";
                        }
                    }

                }
                else if (k < 0)
                {
                    midString = s;
                    Match m = regex.Match(midString);
                    Match m1 = regex1.Match(midString);
                    if (m1.Length != 0)//捕获到带数字的字符串
                    {
                        if (m.Length != 0)//捕获到带标点符号的字符串
                        {
                            if (m1.Index < m.Index && m1.Index <= 6)
                            {
                                tests += m1.ToString() + "\r";
                            }
                        }
                        else if (m1.Index <= 6)
                        {
                               tests += m1.ToString() + "\r";
                        }
                    }
                }
 * 
*/