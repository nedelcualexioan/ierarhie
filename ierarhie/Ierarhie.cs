using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;

namespace ierarhie
{
    public class Ierarhie
    {
        private Node root;

        public Ierarhie(Persoana data)
        {
            this.root = new Node(null, null, data);
        }

        public void addSubordinate(String role, Persoana data)
        {
            Node node = find(root, role);

            if (node != null)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(null, null, data);
                }
                else if (node.Right == null)
                {
                    node.Right = new Node(null, null, data);
                }
            }
        }

        private Node find(Node root, string value)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data.Role.Equals(value) == true)
            {

                return root;
            }

            Node left = find(root.Left, value);

            if (left!=null)
            {
                return left;
            }

            return find(root.Right, value);

        }

        public void afisare()
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            Node enumerator = root;

            while (queue.Count != 0 && enumerator != null)
            {
                if (enumerator.Left != null)
                {
                    queue.Enqueue(enumerator.Left);
                }

                if (enumerator.Right != null)
                {
                    queue.Enqueue(enumerator.Right);
                }

                Console.WriteLine(enumerator.Data.ToString() + "\n");

                queue.Dequeue();

                if (queue.Count == 0)
                    break;

                enumerator = queue.Peek();
            }


        }
    }
}