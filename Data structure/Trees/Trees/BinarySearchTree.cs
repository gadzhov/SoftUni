using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node _root;

    private BinarySearchTree(Node root)
    {
        this.Copy(root);
    }

    public BinarySearchTree() { }

    public void Insert(T value)
    {
        if (_root == null)
        {
            _root = new Node(value);
            return;
        }

        RecursiveInsert(_root, value);
        //NonRecursiveInsert(value);
    }

    private Node RecursiveInsert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        // current > value
        if (node.Value.CompareTo(value) > 0)
        {
            node.Left = this.RecursiveInsert(node.Left, value);
        }
        // current < value
        else if (node.Value.CompareTo(value) < 0)
        {
            node.Right = this.RecursiveInsert(node.Right, value);
        }

        return node;
    }

    private void NonRecursiveInsert(T value)
    {
        Node parent = null;
        Node current = _root;
        while (current != null)
        {
            // current > value
            if (current.Value.CompareTo(value) > 0)
            {
                parent = current;
                current = current.Left;
            }
            // current < value
            else if (current.Value.CompareTo(value) < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        Node newNode = new Node(value);
        if (parent.Value.CompareTo(value) > 0)
        {
            parent.Left = newNode;
        }
        else if (parent.Value.CompareTo(value) < 0)
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = _root;
        while (current != null)
        {
            // current > value
            if (current.Value.CompareTo(value) > 0)
            {
                current = current.Left;
            } 
            else if (current.Value.CompareTo(value) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current != null;
    }

    public void DeleteMin()
    {
        if (_root == null)
        {
            return;
        }

        Node parent = null;
        Node min = _root;
        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent != null)
        {
            parent.Left = min.Right;
        }
        else
        {
            this._root = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = _root;
        while (current != null)
        {
            // current > item
            if (current.Value.CompareTo(item) > 0)
            {
                current = current.Left;
            }
            // current < item
            else if (current.Value.CompareTo(item) < 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return null;
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();
        this.Range(_root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }

        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }

        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(_root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}