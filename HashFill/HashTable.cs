using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFill
{
    public class HashTable
    {
        public static double A = (Math.Sqrt(5) - 1) / 2;
        public static int M; //размер хеш-таблицы
        public int key = -1;
        public string valueOpen = "";
        public LinkedList<string> chain = new LinkedList<string>();
        public BinaryTree tree = new BinaryTree();
        public HashTable() { }
        public static int intoKey(string word)
        {
            int sum = 0;
            foreach (char c in word)
            {
                sum += (int)c;
            }
            return sum;
        }
        public void hashFuncTwoLetter(string word) //хеш-функция с двумя буквами слова
        {
            this.key = ((int)word[0] + (int)word[1]) % M;
        }
        public void hashFuncConst(string word) //хеш-функция с константой
        {
            this.key = int.Parse(Math.Floor(M * ((intoKey(word) * A) % 1)).ToString());
        }
        public void nextStep(int tries) //рассчет следующего шага методом линейного опробирования
        {
            int c = 1;
            this.key = (this.key + c * tries) % M;
        }
    }
}
