using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HashFill
{
    public partial class Form1 : Form
    {
        public string[] source;
        public int collisions = 0;
        public bool filled = false;
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
        public bool FillTable(int func, int method, ref int collisions)
        {
            collisions = 0;
            HashTable.M = source.Length * 2;
            HashTable[] hashTableArray = new HashTable[HashTable.M];
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
                    table[i].tree.PrintTree(table[i].key, table[i].tree.root, treeOutput);
            }
        }
        private void buildBtn_Click(object sender, EventArgs e)
        {
            if (!getText())
            {
                return;
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
                success = FillTable(func, comboBox1.SelectedIndex, ref collisions);
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
            }
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: openTable.Rows.Clear(); break;
                    case 1: chainTable.Rows.Clear(); break;
                    case 2: treeOutput.Text = ""; break;
                }
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[comboBox1.SelectedIndex];
        }
    }
}
