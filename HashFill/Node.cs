using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFill
{
    public enum Side
    {
        Left,
        Right
    }
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> Parent { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public Side? NodeSide => //проверяет, каким потомком является текущая нода
        Parent == null //если родителя нет
        ? (Side?)null //то текущая нода ни на какой стороне
        : Parent.LeftNode == this //если текущая нода - левый потомок
            ? Side.Left //устанавливается левая сторона
            : Side.Right; //иначе - правая
    }
}
