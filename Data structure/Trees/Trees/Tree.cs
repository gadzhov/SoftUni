using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (Tree<T> child in children)
        {
            this.Children.Add(child);
        }
    }

    public T Value { get; set; }

    public IList<Tree<T>> Children { get; set; }

    public void Print(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent * 2)}{this.Value}");

        foreach (Tree<T> child in this.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (Tree<T> child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();
        this.DFS(this, result);

        return result;
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.Value);
            foreach (Tree<T> child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (Tree<T> child in tree.Children)
        {
            this.DFS(child, result);
        }

        result.Add(tree.Value);
    }
}
