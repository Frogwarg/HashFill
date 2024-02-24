using System;
using System.Windows.Forms;

namespace HashFill
{
    public class BinaryTree
    {
        public Node<string> root;
        public Node<string> Add(string data)
        {
            return Add(new Node<string>(data));
        }
        public Node<string> Add(Node<string> node, Node<string> currentNode = null)
        {
            if (root == null)
            {
                node.Parent = null;
                return root = node;
            }

            currentNode = currentNode ?? root; //если currentNode null, тогда он станет ссылаться на root, иначе останется без изменений
            node.Parent = currentNode;
            int result;
            /*return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)                         //если элементы одинаковые, то он не добавляет их
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);*/
            return (result = node.Data.CompareTo(currentNode.Data)) < 0
                   ? currentNode.LeftNode == null                               //если элементы одинаковые, то он добавляет их
                       ? (currentNode.LeftNode = node)
                       : Add(node, currentNode.LeftNode)
                   : currentNode.RightNode == null
                       ? (currentNode.RightNode = node)
                       : Add(node, currentNode.RightNode);
        }
        public Node<string> FindNode(string data, Node<string> startWithNode = null)
        {
            startWithNode = startWithNode ?? root;
            int result;
            if (startWithNode == null) return null;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
        public void PrintTree(int key, Node<string> startNode, RichTextBox treeOutput, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? key.ToString() : side == Side.Left ? "L" : "R";
                treeOutput.Text += string.Format($"{indent}[{nodeSide}] - {startNode.Data}") + Environment.NewLine;
                indent += new string(' ', 8);
                PrintTree(key, startNode.LeftNode, treeOutput, indent, Side.Left);
                PrintTree(key, startNode.RightNode, treeOutput, indent, Side.Right);
            }
        }
    }
}