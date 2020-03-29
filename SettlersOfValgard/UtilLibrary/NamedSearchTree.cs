using System.Collections.Generic;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.UtilLibrary
{
    public class NamedSearchTree<T> where T : INamed
    {
        private class Node<T>
        {
            public Node(string name, T value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; set; }
            public T Value { get; set; }
            public List<Node<T>> Children { get; } = new List<Node<T>>();
        }

        private Node<T> _root;

        public NamedSearchTree(List<T> list)
        {
            _root = new Node<T>("", default);
            foreach (var t in list)
            {
                Add(t);
            }
        }

        public void Add(T newValue)
        {
            Add(newValue.Name, newValue, _root);
        }

        private void Add(string name, T newValue, Node<T> selected)
        {
            name = name.Substring(selected.Name.Length);
            
            for (int i = 0; i < name.Length - 1; i++)
            {
                foreach (var node in selected.Children)
                {
                    if (node.Name.StartsWith(name.Substring(0, i)))
                    {
                        var leftovers = node.Name.Substring(i);
                        if (leftovers != "")
                        {
                            var leftoverValue = node.Value;
                            node.Value = default;
                            node.Children.Add(new Node<T>(leftovers, leftoverValue));
                        }
                        
                        Add(name.Substring(i), newValue, node);
                        return;
                    }
                }
            }
            
            selected.Children.Add(new Node<T>(name, newValue));
        }

        public T Search(string name)
        {
            return Search(name, _root);
        }

        private T Search(string name, Node<T> selected)
        {
            if (name == "")
            {
                return selected.Value;
            } else {
                for (int i = 0; i < name.Length; i++)
                {
                    foreach (var node in selected.Children)
                    {
                        if (node.Name.StartsWith(name.Substring(0, i)))
                        {
                            if (node.Children.Count == 0) return node.Value; // End node
                            var leftovers = name.Substring(i);
                            return Search(leftovers, node);
                        }
                    }
                }
            }

            return default;
        }
    }
}