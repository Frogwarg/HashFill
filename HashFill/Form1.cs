using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace HashFill
{
    public partial class Form1 : Form
    {
        public string[] source;
        public int collisions = 0;
        public bool filled = false;
        public HashTable[] hashTable;
        public int findAttempts = 0;
        public int findCounts = 0;
        public Form1()
        {
            InitializeComponent();
            InitTable(openTable);
            InitTable(chainTable);
            comboBox1.SelectedIndex = 0;
        }
        public void InitTable(DataGridView table)
        {
            table.Columns.Add("Hash-value", "Хеш-значение");
            table.Columns.Add("id", "Идентификатор");
        }
        public bool getText()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Text File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox2.Text = "";
                    source = File.ReadAllLines(openFileDialog.FileName, Encoding.GetEncoding(1251));
                    foreach (string str in source)
                    {
                        textBox2.Text = textBox2.Text + str + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ошибка при загрузке файла: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
                return false;
            }
            return true;
        }
        public bool FillTable(ref HashTable[] hashTableArray, int func, int method, ref int collisions)
        {
            collisions = 0;
            HashTable.M = source.Length * 2;
            hashTableArray = new HashTable[HashTable.M];
            for (int i = 0; i < hashTableArray.Length; i++)
                hashTableArray[i] = new HashTable();
            for (int i = 0; i < source.Length; i++)
            {
                int tries = 1;
                int colPerElem = 0;
                HashTable elem = new HashTable();
                if (func == 0)
                    elem.hashFuncTwoLetter(source[i]);
                else
                    elem.hashFuncConst(source[i]);
                string word = source[i];
                bool result = false;
                switch (method)
                {
                    case 0: result = openAddressation(hashTableArray, elem, tries, word, ref colPerElem); break;
                    case 1: result = chainMethod(hashTableArray, elem, word, ref colPerElem); break;
                    case 2: result = binTreeMethod(hashTableArray, elem, word, ref colPerElem); break;
                }
                if (!result)
                    return false;
                collisions += colPerElem;
            }
            if (collisions >= HashTable.M)
                return false;
            switch (method)
            {
                case 0: openOutput(hashTableArray); break;
                case 1: chainOutput(hashTableArray); break;
                case 2: binTreeOutput(hashTableArray); break;
            }
            return true;
        }
        public int FindElement(string word, HashTable[] hashtable, int func,int method, ref int tries)
        {
            HashTable elem = new HashTable();
            tries = 0;
            if (func == 0)
                elem.hashFuncTwoLetter(word);
            else
                elem.hashFuncConst(word);
            if (hashtable[elem.key].key < 0)
            {
                return -1;
            }
            if (hashTable[elem.key].key == elem.key && method !=0)
            {
                return elem.key;
            }
            if (hashTable[elem.key].key != elem.key && method == 0)
            {
                tries++;
                bool success = false;
                while (!success)
                {
                    elem.nextStep(tries);
                    if (hashTable[elem.key].key == elem.key)
                    {
                        success = true;
                    }else
                    {
                        tries++;
                    }
                }
            }
            return elem.key;
        }
        public int openFind(HashTable[] hashTable,HashTable elem,ref int tries, string word)
        {
            elem.valueOpen = word;
            if (hashTable[elem.key].key >= 0)
            {
                while (hashTable[elem.key].valueOpen != word && tries < HashTable.M)
                {
                    elem.nextStep(tries);
                    if (hashTable[elem.key].valueOpen == word)
                    {
                        break;
                    }
                    tries++;
                    if (tries >= HashTable.M / 3)
                        return -1;
                }
            }else
            {
                return -1;
            }
            return elem.key;
        }
        public bool openAddressation(HashTable[] hashTable,HashTable elem, int tries, string word, ref int colPerElem)
        {
            elem.valueOpen = word;
            if (hashTable[elem.key].key < 0)
            {
                hashTable[elem.key] = elem;
            }
            else
            {
                while (hashTable[elem.key].key >= 0 && collisions < HashTable.M)
                {
                    elem.nextStep(tries);
                    tries++;
                    if (hashTable[elem.key].key < 0)
                    {
                        hashTable[elem.key] = elem;
                        break;
                    }
                    colPerElem++;
                    if (colPerElem >= HashTable.M / 3)
                        return false;
                }
            }
            return true;
        }
        public bool chainMethod(HashTable[] hashTable, HashTable elem, string word, ref int colPerElem)
        {
            if (hashTable[elem.key].chain.Count > 0)
            {
                ++colPerElem;
                if (colPerElem >= HashTable.M / 3)
                    return false;
            }
            hashTable[elem.key].key = elem.key;
            hashTable[elem.key].chain.Add(word);
            return true;
        }
        public bool binTreeMethod(HashTable[] hashTable, HashTable elem, string word, ref int colPerElem)
        {
            if (hashTable[elem.key].tree.root != null)
            {
                ++colPerElem;
                if (colPerElem >= HashTable.M / 3)
                    return false;
            }
            hashTable[elem.key].key = elem.key;
            hashTable[elem.key].tree.Add(word);
            return true;
        }
        public void openOutput(HashTable[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].key >= 0)
                    openTable.Rows.Add(table[i].key, table[i].valueOpen);
            }
        }
        public void chainOutput(HashTable[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].key >= 0)
                {
                    string str = string.Join(", ", table[i].chain.ToList<string>());
                    chainTable.Rows.Add(table[i].key, str);
                }
            }
        }
        public void binTreeOutput(HashTable[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].key >= 0)
                    table[i].tree.PrintTree(table[i].key,table[i].tree.root, treeOutput);
            }
        }
        private void buildBtn_Click(object sender, EventArgs e)
        {
            if (!getText())
            {
                return;
            }
            foreach(string word in source)
            {
                if (word.Length < 2)
                {
                    MessageBox.Show("Есть слово, короче двух букв");
                    return;
                }
            }
            collisions = 0;
            bool success = false;
            int func = 0;
            while (!success)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        openTable.Rows.Clear();
                        break;
                    case 1:
                        chainTable.Rows.Clear();
                        break;
                    case 2:
                        treeOutput.Text = "";
                        break;
                }
                success = FillTable(ref hashTable, func, comboBox1.SelectedIndex, ref collisions);
                tabControl.SelectedTab = tabControl.TabPages[comboBox1.SelectedIndex];
                ++func;
                if (!success)
                {
                    MessageBox.Show("Так как количество коллизий(" + collisions + ") превысило порог, то будет проведено рехеширование");
                }
                if (func > 1 && !success)
                {
                    MessageBox.Show("Хеш функции закончились, рехеширование не удалось");
                    break;
                }
            }
            collisionLabel.Text = string.Format("Среднее количество коллизий: {0:f2}", ((double)collisions / (double)source.Length));
            filled = true;
        }
        private void findBtn_Click(object sender, EventArgs e)
        {
            if (!filled)
            {
                MessageBox.Show("Таблица не готова к поиску");
                return;
            }
            string word = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Введите название идентификатора");
                return;
            }
            int tries = 1;
            if (word.Length < 2)
            {
                MessageBox.Show("Слово меньше 2-х букв");
                return;
            }
            HashTable elem = new HashTable();
            elem.hashFuncTwoLetter(word);
            bool notFound = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (openFind(hashTable, elem, ref tries, word) == -1)
                    {
                        notFound = true;
                    } break;
                case 1:
                    if (hashTable[elem.key].key < 0 || !hashTable[elem.key].chain.Contains(word))
                    {
                        notFound = true;
                    } break;
                case 2:
                    if (hashTable[elem.key].tree.FindNode(word) == null)
                    {
                        notFound = true;
                    }
                    break;
            }
            if (notFound)
            {
                MessageBox.Show("Идентификатор \"" + word + "\" не был найден");
                return;
            }
            findAttempts += tries;
            findCounts++;
            if (comboBox1.SelectedIndex == 2)
            {
                treeOutput.SelectionColor = Color.Black;
                treeOutput.Select(treeOutput.Text.LastIndexOf(word), word.Length);
                treeOutput.SelectionColor = Color.Red;
                label2.Text = string.Format("Среднее число попыток поиска: {0:f2}", ((double)(findAttempts / (double)findCounts)));
                return;
            }
            DataGridView current=new DataGridView();
            switch (comboBox1.SelectedIndex)
            {
                case 0: current = openTable; break;
                case 1: current = chainTable; break;
            }
            foreach (DataGridViewRow row in current.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
            for (int i = 0; i < current.Rows.Count; i++)
            {
                var cellValue = current.Rows[i].Cells[1].Value;
                if (cellValue != null && cellValue.ToString().Contains(word))
                {
                    current.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    break;
                }
            }
            label2.Text = string.Format("Среднее число попыток поиска: {0:f2}", ((double)(findAttempts / (double)findCounts)));
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[comboBox1.SelectedIndex];
            findAttempts = 0;
            findCounts = 0;
        }
    }
}
