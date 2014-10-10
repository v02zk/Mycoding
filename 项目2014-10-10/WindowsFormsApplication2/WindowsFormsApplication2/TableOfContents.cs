using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WindowsFormsApplication2
{
    class TableOfContents
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal,int size, string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        public List<string> getAllRegContents()
        {
            List<string> result;
            StringBuilder temp = new StringBuilder(2000);
            int re = GetPrivateProfileString("section-text", "history", "", temp, 2000, filePath.TOCFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            result = new List<string>(key);
            result.RemoveAll(spaceContents);
            return result;
        }

        public List<string> getAllSpecificationContents()
        {
            List<string> result;
            StringBuilder temp = new StringBuilder(2000);
            int re = GetPrivateProfileString("section-specification", "history", "", temp, 2000, filePath.TOCFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            result = new List<string>(key);
            result.RemoveAll(spaceContents);
            return result;
        }

        public void update(ComboBox cbx)
        {
            List<string> result1 = getAllRegContents();
            List<string> result2 = getAllSpecificationContents();
            List<string> result = new List<string>();
            result.AddRange(result1);
            result.AddRange(result2);
            cbx.Items.Clear();
            foreach (string s in result)
            {
                cbx.Items.Add(s);
            }
        }

        public void deleteTextContent(string name)
        {
            List<string> result;
            StringBuilder temp = new StringBuilder(2000);
            int re = GetPrivateProfileString("section-text", "history", "", temp, 2000, filePath.TOCFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            result = new List<string>(key);
            result.Remove(name);


            string value = null;
            foreach (string s in result)
            {
                if (s != "")
                    value += s + ",";
            }
            WritePrivateProfileString("section-text", "history", value, filePath.TOCFILEPATH);

            string path = System.Environment.CurrentDirectory;
            string filepath = path + "\\resources\\" + name + ".doc";
            File.Delete(filepath);

        }

        public void deleteSpecificationContent(string name)
        {
            List<string> result;
            StringBuilder temp = new StringBuilder(2000);
            int re = GetPrivateProfileString("section-specification", "history", "", temp, 2000, filePath.TOCFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            result = new List<string>(key);
            result.Remove(name);


            string value = null;
            foreach (string s in result)
            {
                if (s != "")
                    value += s + ",";
            }

            WritePrivateProfileString("section-specification", "history", value, filePath.TOCFILEPATH);
        }

        /// <summary>
        /// put new reg document into history file
        /// </summary>
        /// <param name="name"></param>
        public void putNewRegTocInINIFile(string name)
        {
            if (File.Exists(filePath.TOCFILEPATH))
            {
                StringBuilder temp = new StringBuilder(500);
                int re = GetPrivateProfileString("section-text", "history", "", temp, 500, filePath.TOCFILEPATH);
                string t = temp.ToString();

                char[] chSplit = ",".ToCharArray();
                string[] key = t.Split(chSplit);

                List<string> keyList = new List<string>(key);
                if(!keyList.Contains(name))
                    keyList.Add(name);
                keyList.RemoveAll(spaceContents);

                string value = null;
                foreach (string s in keyList)
                {
                    if (s != "")
                        value += s + ",";
                }

                WritePrivateProfileString("section-text", "history", value, filePath.TOCFILEPATH);
            }
        }
        /// <summary>
        /// predicate to remove "" or null string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool spaceContents(string s )
        {
            if (s == "" || s == null)
                return true;
            return false;
        }

        /// <summary>
        /// put new regulation document into system resource and extract toc 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public Dictionary<string, List<TermContainer>> AddRegToSysResource(string filepath)
        {
            string fname = filepath.Substring(filepath.LastIndexOf("\\") + 1, filepath.LastIndexOf(".") - filepath.LastIndexOf("\\") - 1);
            putNewRegTocInINIFile(fname);

            ApplicationClass regWord = new ApplicationClass();
            Document regDoc = new Document();
            HandleDocument handleDocument = new HandleDocument();
  
            regDoc = handleDocument.openDocument(filepath, regWord);
            
            Table table = regDoc.Tables[1];
            int rows = table.Rows.Count;
            Dictionary<string, List<TermContainer>> dic = new Dictionary<string, List<TermContainer>>();
            
            string key = "";
            string section = "";
            for(int i = 1;i<= rows;i++)
            {                 
                string text = getTableCellText(table, i, 1);               
                if (isLevel1Cell(text))
                {
                    section = "";
                    key = text; 
                    dic.Add(text, new List<TermContainer>());             
                }
                else 
                {
                    if (isLevelSection(text))
                    {                  
                        section = text;
                    }
                    else
                    {
                        TermContainer term = getTableCellContainer(section,table, i);
                        dic[key].Add(term);
                    }
                }
            }

            string path = System.Environment.CurrentDirectory;
            string name = path + "\\resources\\"+regDoc.Name;
            object saveAsName = path + "\\resources\\" + regDoc.Name;
            
            object unknow = Type.Missing;

            if (!File.Exists(name))
            {
                regDoc.SaveAs(ref saveAsName, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow);
            }
            else
            {
                //shifou ti huan
                File.Delete(name);
                regDoc.SaveAs(ref saveAsName, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow, ref unknow);
            }
            quit(regWord, regDoc);
            return dic;
        }

        /// <summary>
        /// 将说明书文档的内容存入系统
        /// </summary>
        /// <param name="dict"></param>
        public Dictionary<string, List<string>> AddSpecificationToSysResource(string filepath)
        {
            HandleDocument handleDocument = new HandleDocument();
            Dictionary<string, List<string>> dict = handleDocument.generateSpecificationRegTOC(filepath);

            ////将目录以一定格式存入系统文件           
            string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1, filepath.LastIndexOf(".") - filepath.LastIndexOf("\\") - 1);

            string s = "";
            foreach (KeyValuePair<string, List<string>> kvp in dict)
            {
                s += kvp.Key + "-";
                foreach (string ss in kvp.Value)
                {
                    s += ss + ",";
                }
                s += ";";
            }
            WritePrivateProfileString("specification-"+filename, filename, s, filePath.SPEC);
            
            StringBuilder temp = new StringBuilder(2500);
            int re = GetPrivateProfileString("section-specification", "history", "", temp, 2500, filePath.TOCFILEPATH);
            string t = temp.ToString();

            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);

            List<string> keyList = new List<string>(key);
            if(!keyList.Contains(filename))
                keyList.Add(filename);
            keyList.RemoveAll(spaceContents);

            string value = null;
            foreach (string ss in keyList)
            {
                if (keyList.Last() != ss)
                    value += ss + ",";
                else
                    value += ss + ",";
            }

            WritePrivateProfileString("section-specification", "history", value, filePath.TOCFILEPATH);
            return dict;    
        }
        /*
         * get regulation table of content in document or db by name
         */
        public Dictionary<string, List<TermContainer>> getTOCContentsByName(string name)
        {
            string path = System.Environment.CurrentDirectory;          
            name = path +  "\\resources\\"+ name+".doc";   
            ApplicationClass regWord = new ApplicationClass();
            Document regDoc = new Document();
            HandleDocument handleDocument = new HandleDocument();
    
            regDoc = handleDocument.openDocument(name, regWord);

            Table table = regDoc.Tables[1];
            int rows = table.Rows.Count;
            Dictionary<string, List<TermContainer>> dic = new Dictionary<string, List<TermContainer>>();

            string key = "";
            string section = "";
            for (int i = 1; i <= rows; i++)
            {
                string text = getTableCellText(table, i, 1);
                if (isLevel1Cell(text))
                {
                    section = "";
                    key = text;
                    dic.Add(text, new List<TermContainer>());
                }
                else
                {
                    if (isLevelSection(text))
                    {
                        section = text;
                    }
                    else
                    {
                        TermContainer term = getTableCellContainer(section, table, i);
                        dic[key].Add(term);
                    }
                }
            }
            quit(regWord,regDoc);
            return dic;
        }

        /// <summary>
        /// 按照说明书文档名字获取目录项
        /// </summary>
        public Dictionary<string, List<string>> getSpecificationTOCContentsByName(string name)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();

            StringBuilder temp = new StringBuilder(2500);
            int re = GetPrivateProfileString("specification-" + name, name, "", temp, 2500, filePath.SPEC);
            string t = temp.ToString();

            char[] chSplit = ";".ToCharArray();
            string[] key = t.Split(chSplit);

            char[] chSplit2 = "-".ToCharArray();
            char[] chSplit3 = ",".ToCharArray();
            foreach (string section in key)
            {
                if (section != "")
                {
                    string chapter = section.Split(chSplit2)[0];
                    
                    dict.Add(chapter,new List<string>());
                    string[] levels = section.Split(chSplit2)[1].Split(chSplit3);
                    foreach (string s in levels)
                    {
                        if(s != "")
                            dict[chapter].Add(s);
                    }
                }
            }
            

            return dict;
        }

        private TermContainer getTableCellContainer(string section,Table table, int row)
        {
            string name = table.Cell(row, 2).Range.Text;
            string tip = table.Cell(row, 3).Range.Text;
            name = delimiterEnterChar(name);
            tip = delimiterEnterChar(tip);
            return new TermContainer(section,name, tip);
        }
        private string getTableCellText(Table table,int row, int column)
        {
            string text = table.Cell(row, column).Range.Text;
            text = delimiterEnterChar(text);
            return text;
        }

        /*
         * if row is Level 1 ==> 判断显示章的行
         */
        private bool isLevel1Cell(string s)
        {
            if (s.Contains("章") && s.Contains("第"))
                return true;
            return false;
        }
        
        /*
         * if row is Level section ==> 判断显示节的行
         */
        private bool isLevelSection(string s)
        {
            if (s.Contains("节") && s.Contains("第"))
                return true;
            return false;
        }

        private void quit(ApplicationClass word, Document doc )
        {
            Object saveChanges = false;
            object unknow = Type.Missing;
           
            doc.Close(ref saveChanges, ref unknow, ref unknow);
            word.Quit(ref saveChanges, ref unknow, ref unknow);
        }

        /*
         * delimiter \r\a char in text
         */
        private string delimiterEnterChar(string text)
        {
            string strDelimiters = "\r\a";
            char[] a_charDelimiter = strDelimiters.ToCharArray();
            text = text.TrimEnd(a_charDelimiter);
            return text;
        }
        /*
         * convert elements in string to every element
         */
        private string[] convertToStrings(StringBuilder sb)
        {
            string t = sb.ToString();
            char[] chSplit = ",".ToCharArray();
            string[] key = t.Split(chSplit);
            return key;
        }

        /// <summary>
        /// generate tree view function
        /// </summary>
        /// <param name="result"></param>
        /// <param name="tv"></param>
        private void generateTreeView(Dictionary<string, List<TermContainer>> result, TreeView tv)
        {
            string temp = "";
            foreach (KeyValuePair<string, List<TermContainer>> kvp in result)
            {
                TreeNode ChapterNode = tv.Nodes.Add(kvp.Key);
                List<TermContainer> list = kvp.Value;
                
                if (list.First().Section != "")
                {
                    TreeNode SectionNode = ChapterNode.Nodes.Add(list.First().Section);
                    temp = list.First().Section;
                    foreach (TermContainer tc in list)
                    {
                        if (tc.Section != temp)
                        {
                            SectionNode = ChapterNode.Nodes.Add(tc.Section);
                            temp = tc.Section;
                        }
                        SectionNode.Nodes.Add(tc.TermName);
                    }
                }
                else
                {
                    foreach (TermContainer tc in list)
                    {
                        ChapterNode.Nodes.Add(tc.TermName); 
                    }
                }
            }
        }

        /*
       * generate table of contents in tree view component in regulation document
       */
        public void generateRegTreeView(Dictionary<string, List<TermContainer>> result, TreeView tv)
        {
            generateTreeView(result, tv);
            tv.Update();
            tv.ExpandAll();
            tv.Nodes[0].EnsureVisible();
        }

        /*
         * generate table of contents in tree view component in test document
         */
        public Dictionary<string, int> generateTestTextTreeView(Dictionary<string, List<TermContainer>> result, TreeView tv, TreeView regTreeView,Dictionary<string, List<string>> dictionaryList)
        {
            Dictionary<string, int> dict;
            generateTreeView(result, tv);
            dict = colorTreeView(tv,regTreeView,dictionaryList);
            tv.Update();
            tv.ExpandAll();
            tv.Nodes[0].EnsureVisible();
            regTreeView.Update();
            regTreeView.ExpandAll();
            regTreeView.Nodes[0].EnsureVisible();
            return dict;
        }
        /// <summary>
        /// 生成说明书文档目录结构
        /// </summary>
        /// <param name="result"></param>
        /// <param name="tv"></param>
        /// <param name="regTreeView"></param>
        /// <returns></returns>
        public Dictionary<string, int> generateTestSpecificationTreeView(Dictionary<string, List<TermContainer>> result, TreeView tv, TreeView regTreeView)
        {
            Dictionary<string, int> dict = new Dictionary<string,int>();
            generateSpecificationTreeView(result, tv);
            dict = colorSpecificationTreeView(tv, regTreeView);
            tv.Update();
            tv.ExpandAll();
            tv.Nodes[0].EnsureVisible();
            return dict;
        }

        /// <summary>
        /// 生成说明书文档目录,忽略section
        /// </summary>
        /// <param name="result"></param>
        /// <param name="tv"></param>
        private void generateSpecificationTreeView(Dictionary<string, List<TermContainer>> result, TreeView tv)
        {
            foreach (KeyValuePair<string, List<TermContainer>> kvp in result)
            {
                TreeNode ChapterNode = tv.Nodes.Add(kvp.Key);
                List<TermContainer> list = kvp.Value;
                foreach (TermContainer tc in list)
                {
                    ChapterNode.Nodes.Add(tc.TermName);
                }             
            }
        }

       
        /// <summary>
        /// 为文档作涂色处理
        /// </summary>
        /// <param name="testTreeView"></param>
        /// <param name="regTreeView"></param>
        private Dictionary<string, int> colorTreeView(TreeView testTreeView, TreeView regTreeView,Dictionary<string,List<string>> dictionaryList)
        {
            int error = 0;
            int spare = 0;
            int miss = 0;

            int testcount = testTreeView.Nodes.Count;
            int regcount = regTreeView.Nodes.Count;

            if (regcount >= testcount)
            {
                //////将规程文档中缺失的项目在规程文档中涂色
                for (int k = testcount; k < regcount; k++)
                {
                    regTreeView.Nodes[k].BackColor = SysColor.MISS;
                    miss += 1;
                    dictionaryList["missing"].Add(regTreeView.Nodes[k].Text);
                    if (regTreeView.Nodes[k].Nodes.Count != 0)
                    {
                        for (int j = 0; j < regTreeView.Nodes[k].Nodes.Count; j++)
                        {
                            regTreeView.Nodes[k].Nodes[j].BackColor = SysColor.MISS;
                            miss += 1;
                            dictionaryList["missing"].Add(regTreeView.Nodes[k].Nodes[j].Text);
                        }
                    }
                }              
                return colorSamePart(testTreeView, regTreeView, ref error, ref spare, ref miss, testcount,dictionaryList);
            }
            else if(regcount < testcount)
            {
                //////将测试文档中多余的项目在规程文档中涂色
                for (int k = regcount; k < testcount; k++)
                {
                    testTreeView.Nodes[k].BackColor = SysColor.SPARE;
                    spare += 1;
                    dictionaryList["spare"].Add(testTreeView.Nodes[k].Text);
                    if (testTreeView.Nodes[k].Nodes.Count != 0)
                    {
                        for (int j = 0; j < testTreeView.Nodes[k].Nodes.Count; j++)
                        {
                            testTreeView.Nodes[k].Nodes[j].BackColor = SysColor.SPARE;
                            dictionaryList["spare"].Add(testTreeView.Nodes[k].Nodes[j].Text);
                            spare += 1;
                        }
                    }
                }
                //////
                return colorSamePart(testTreeView, regTreeView, ref error, ref spare, ref miss, regcount,dictionaryList);
            }
            return null;
        }

        /// <summary>
        /// 为测试文档和规程文档中相同部分作涂色处理
        /// </summary>
        /// <param name="testTreeView"></param>
        /// <param name="regTreeView"></param>
        /// <param name="error"></param>
        /// <param name="spare"></param>
        /// <param name="miss"></param>
        /// <param name="testcount"></param>
        private Dictionary<string, int> colorSamePart(TreeView testTreeView, TreeView regTreeView, ref int error, ref int spare, ref int miss, int testcount,Dictionary<string,List<string>> dictionaryList)
        {
            for (int i = 0; i < testcount; i++)
            {
                if (testTreeView.Nodes[i].Text.Contains(regTreeView.Nodes[i].Text))
                {
                    //正确，无操作
                }
                else
                {
                    testTreeView.Nodes[i].BackColor = SysColor.ERROR;
                    error += 1;
                    dictionaryList["error"].Add(testTreeView.Nodes[i].Text);
                }

                ////////////判断test document是否包含节 ---〉包含   
                if (testTreeView.Nodes[i].Nodes[0].Text.IndexOf("第") == 0 && testTreeView.Nodes[i].Nodes[0].Text.IndexOf("节") == 2)
                {
                    /////成果规程不包含节  
                    if (regTreeView.Nodes[i].Nodes[0].Text.IndexOf("第") != 0 && regTreeView.Nodes[i].Nodes[0].Text.IndexOf("节") != 2)
                    {
                        int spareC = testTreeView.Nodes[i].Nodes.Count;
                        spare += spareC;
                        for (int j = 0; j < spareC; j++)
                        {
                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.SPARE;
                            dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                        }
                    }
                    ////成果规程包含节
                    else if (regTreeView.Nodes[i].Nodes.Count > 0)
                    {
                        int testSectionC = testTreeView.Nodes[i].Nodes.Count;
                        int regSectionC = regTreeView.Nodes[i].Nodes.Count;

                        ///////测试文档节数多于规程文档的节数
                        if (testSectionC > regSectionC)
                        {
                            ////将测试文档中多余节标为多余属性
                            for (int j = regSectionC; j < testSectionC; j++)
                            {
                                testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.SPARE;
                                spare += 1;
                                dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                            }
                            ////判断测试文档中是否匹配规程文档
                            for (int j = 0; j < regSectionC; j++)
                            {
                                int testSubsectionC = testTreeView.Nodes[i].Nodes[j].Nodes.Count;
                                int regSubsectionC = regTreeView.Nodes[i].Nodes[j].Nodes.Count;

                                if (testSubsectionC > regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < regSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将测试文档中中多余的项目在规程中涂色
                                    for (int k = regSubsectionC; k < testSubsectionC; k++)
                                    {
                                        testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.SPARE;
                                        spare += 1;
                                        dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC < regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将测试文档中中缺失的项目在规程中涂色
                                    for (int k = testSubsectionC; k < regSubsectionC; k++)
                                    {
                                        regTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.MISS;
                                        miss += 1;
                                        dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC == regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                }
                            }
                        }
                        ///////测试文档节数少于规程文档的节数
                        else if (testSectionC < regSectionC)
                        {
                            ////将规程文档中缺失节标为缺失属性
                            for (int j = testSectionC; j < regSectionC; j++)
                            {
                                regTreeView.Nodes[i].Nodes[j].BackColor = SysColor.MISS;
                                miss += 1;
                                dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[j].Text);
                            }
                            ////判断测试文档中是否匹配规程文档
                            for (int j = 0; j < testSectionC; j++)
                            {
                                int testSubsectionC = testTreeView.Nodes[i].Nodes[j].Nodes.Count;
                                int regSubsectionC = regTreeView.Nodes[i].Nodes[j].Nodes.Count;

                                if (testSubsectionC > regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < regSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将测试文档中中多余的项目在规程中涂色
                                    for (int k = regSubsectionC; k < testSubsectionC; k++)
                                    {
                                        testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.SPARE;
                                        spare += 1;
                                        dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC < regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将规程文档中中缺失的项目在规程中涂色
                                    for (int k = testSubsectionC; k < regSubsectionC; k++)
                                    {
                                        regTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.MISS;
                                        miss += 1;
                                        dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC == regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                }
                            }
                        }
                        ///////测试文档和规程文档的节数相同,则判断节内条数是否相同
                        else
                        {
                            for (int j = 0; j < testSectionC; j++)
                            {
                                int testSubsectionC = testTreeView.Nodes[i].Nodes[j].Nodes.Count;
                                int regSubsectionC = regTreeView.Nodes[i].Nodes[j].Nodes.Count;

                                if (testSubsectionC > regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < regSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将测试文档中中多余的项目在规程中涂色
                                    for (int k = regSubsectionC; k < testSubsectionC; k++)
                                    {
                                        testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.SPARE;
                                        spare += 1;
                                        dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC < regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                    /////将测试文档中中缺失的项目在规程中涂色
                                    for (int k = testSubsectionC; k < regSubsectionC; k++)
                                    {
                                        regTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.MISS;
                                        miss += 1;
                                        dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                    }
                                }
                                else if (testSubsectionC == regSubsectionC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int k = 0; k < testSubsectionC; k++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Nodes[k].Text.Contains(regTreeView.Nodes[i].Nodes[j].Nodes[k].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].Nodes[k].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Nodes[k].Text);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                ////////////判断test document是否包含节 ---〉不包含
                else
                {
                    ///////判断成果规程对应项目是否包含节 ---> 不包含
                    if (regTreeView.Nodes[i].Nodes[0].Text.IndexOf("第") != 0 && regTreeView.Nodes[i].Nodes[0].Text.IndexOf("节") != 2)
                    {
                        ////规程文档条数不为零
                        if (testTreeView.Nodes[i].Nodes.Count != 0)
                        {
                            /////测试规程
                            if (regTreeView.Nodes[i].Nodes.Count == 0)
                            {
                                int spareC = testTreeView.Nodes[i].Nodes.Count;
                                spare += spareC;
                                for (int j = 0; j < spareC; j++)
                                {
                                    testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.SPARE;
                                    dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                                }
                            }
                            else
                            {
                                int testC = testTreeView.Nodes[i].Nodes.Count;
                                int regC = regTreeView.Nodes[i].Nodes.Count;

                                if (testC > regC)
                                {
                                    ///判断测试文档中是否匹配规程文档
                                    for (int j = 0; j < regC; j++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                                        }
                                    }
                                    /////将测试文档中中多余的项目在规程中涂色
                                    for (int k = regC; k < testC; k++)
                                    {
                                        testTreeView.Nodes[i].Nodes[k].BackColor = SysColor.SPARE;
                                        spare += 1;
                                        dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[k].Text);
                                    }
                                }
                                else if (testC < regC)
                                {
                                    ////判断测试文档中是否匹配规程文档
                                    for (int j = 0; j < testC; j++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                                        }
                                    }
                                    /////将测试文档中中缺失的项目在规程中涂色
                                    for (int k = testC; k < regC; k++)
                                    {
                                        regTreeView.Nodes[i].Nodes[k].BackColor = SysColor.MISS;
                                        miss += 1;
                                        dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[k].Text);
                                    }
                                }
                                else if (testC == regC)
                                {
                                    for (int j = 0; j < regC; j++)
                                    {
                                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                                        {
                                            //正确，无操作
                                        }
                                        else
                                        {
                                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                                            error += 1;
                                            dictionaryList["error"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            int missC = regTreeView.Nodes[i].Nodes.Count;
                            miss += missC;
                            for (int j = 0; j < missC; j++)
                            {
                                regTreeView.Nodes[i].Nodes[j].BackColor = SysColor.MISS;
                                dictionaryList["missing"].Add(regTreeView.Nodes[i].Nodes[j].Text);
                            }
                        }
                    }
                    ////  -----> 成果规程不包含节,测试文档包含节。标记为
                    else
                    {
                        int spareC = testTreeView.Nodes[i].Nodes.Count;
                        spare += spareC;
                        for (int j = 0; j < spareC; j++)
                        {
                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.SPARE;
                            dictionaryList["spare"].Add(testTreeView.Nodes[i].Nodes[j].Text);
                        }
                    }
                }
            }
            Dictionary<string,int> dict = new Dictionary<string,int>();
            dict.Add("error", error);
            dict.Add("miss", miss);
            dict.Add("spare", spare);
            return dict;
        }
        /// <summary>
        /// 为说明书文档目录结构涂色
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> colorSpecificationTreeView(TreeView testTreeView, TreeView regTreeView)
        {
            int error = 0;
            int spare = 0;
            int miss = 0;

            int testcount = testTreeView.Nodes.Count;
            int regcount = regTreeView.Nodes.Count;
            if (regcount >= testcount)
            {
                //////将规程文档中缺失的项目在规程文档中涂色
                for (int k = testcount; k < regcount; k++)
                {
                    regTreeView.Nodes[k].BackColor = SysColor.MISS;
                    miss += 1;
                    if (regTreeView.Nodes[k].Nodes.Count != 0)
                    {
                        for (int j = 0; j < testTreeView.Nodes[k].Nodes.Count; j++)
                        {
                            regTreeView.Nodes[k].Nodes[j].BackColor = SysColor.MISS;
                            miss += 1;
                        }
                    }
                }
                //////
                return colorSpecificationSamePart(testTreeView, regTreeView, ref error, ref spare, ref miss, testcount);
            }
            else if (regcount < testcount)
            {
                //////将测试文档中多余的项目在规程文档中涂色
                for (int k = regcount; k < testcount; k++)
                {
                    testTreeView.Nodes[k].BackColor = SysColor.SPARE;
                    spare += 1;
                    if (testTreeView.Nodes[k].Nodes.Count != 0)
                    {
                        for (int j = 0; j < testTreeView.Nodes[k].Nodes.Count; j++)
                        {
                            testTreeView.Nodes[k].Nodes[j].BackColor = SysColor.SPARE;
                            spare += 1;
                        }                 
                    }
                }
                //////
                return colorSpecificationSamePart(testTreeView, regTreeView, ref error, ref spare, ref miss, regcount);
            }
            return null;
        }

        private Dictionary<string, int> colorSpecificationSamePart(TreeView testTreeView, TreeView regTreeView, ref int error, ref int spare, ref int miss, int testcount)
        {
            for (int i = 0; i < testcount; i++)
            {
                if (testTreeView.Nodes[i].Text.Contains(regTreeView.Nodes[i].Text))
                {
                    //正确，无操作
                }
                else
                {
                    testTreeView.Nodes[i].BackColor = SysColor.ERROR;
                    error += 1;
                }

                ///判断字节点错误信息
                int testSectionCount = testTreeView.Nodes[i].Nodes.Count;
                int regSectionCount = regTreeView.Nodes[i].Nodes.Count;
                if (testSectionCount > regSectionCount)
                {
                    for (int j = 0; j < regSectionCount; j++)
                    {
                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                        {
                            //正确，无操作
                        }
                        else
                        {
                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                            error += 1;
                        }
                    }
                    for (int k = regSectionCount; k < testSectionCount; k++)
                    {
                        testTreeView.Nodes[i].Nodes[k].BackColor = SysColor.SPARE;
                        spare++;
                    }
                }
                else if (testSectionCount < regSectionCount)
                {
                    for (int j = 0; j < testSectionCount; j++)
                    {
                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                        {
                            //正确，无操作
                        }
                        else
                        {
                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                            error += 1;
                        }
                    }
                    for (int k = testSectionCount; k < regSectionCount; k++)
                    {
                        regTreeView.Nodes[i].Nodes[k].BackColor = SysColor.MISS;
                        miss++;
                    }
                }
                else
                {
                    for (int j = 0; j < testSectionCount; j++)
                    {
                        if (testTreeView.Nodes[i].Nodes[j].Text.Contains(regTreeView.Nodes[i].Nodes[j].Text))
                        {
                            //正确，无操作
                        }
                        else
                        {
                            testTreeView.Nodes[i].Nodes[j].BackColor = SysColor.ERROR;
                            error += 1;
                        }
                    }
                }
            }
            
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("error", error);
            dict.Add("miss", miss);
            dict.Add("spare", spare);
            return dict;
        }
    }
}
