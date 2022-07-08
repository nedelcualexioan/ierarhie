using System.Net.NetworkInformation;

namespace ierarhie
{
    public class Node
    {
        private Node left;
        private Node right;
        private Persoana data;

        public Node(Node left, Node right, Persoana data)
        {
            this.left = left;
            this.right = right;
            this.data = data;
        }

        public Node()
        {
        }

        public Node Left
        {
            get => left;
            set => left = value;
        }

        public Node Right
        {
            get => right;
            set => right = value;
        }

        public Persoana Data
        {
            get => data;
            set => data = value;
        }


    }
}