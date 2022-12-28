using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Node
    {
        public delegate bool searchRuleCallBack(Node node);
        public string Name;
        public List<Node> Childs = new List<Node>();

        public Node(string name) {
            Name = name;
        }
        public Node(string name, List<Node> childs) {
            Name = name;
            Childs = childs;
        }
 
        public Node? SearchNearstChid(searchRuleCallBack callBack)
        {
            Queue<Node> search = new Queue<Node>();
            Stack<Node> searched = new Stack<Node>();

            foreach (Node childNode in Childs) search.Enqueue(childNode);

            while (search.Count > 0)
            {
                Node node = search.Dequeue();
                if (searched.Contains(node)) continue;

                if (callBack(node))
                {
                    return node;
                } 
                else
                {
                    searched.Push(node);
                    foreach (Node childNode in node.Childs) search.Enqueue(childNode);
                }

            }

            return null;
        }
    }
}
