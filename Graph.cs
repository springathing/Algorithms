using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class Graph
    {
        public void CheckVertices()
        {
            var la = new Vertex<string>("Los Angeles");
            var sf = new Vertex<string>("San Francisco");
            var lv = new Vertex<string>("Las Vegas");
            var se = new Vertex<string>("Seattle");
            var au = new Vertex<string>("Austin");
            var po = new Vertex<string>("Portland");

            var testGraph = new UndirectedGenericGraph<string>();

            // la <=> sf, lv, po
            testGraph.AddPair(la, sf);
            testGraph.AddPair(la, lv);
            testGraph.AddPair(la, po);

            // sf <=> se, po
            testGraph.AddPair(sf, se);
            testGraph.AddPair(sf, po);

            // lv <=> au
            testGraph.AddPair(lv, au);

            // se <=> po
            testGraph.AddPair(se, po);

            // Check to see that all neighbors are properly set up
            foreach (var vertex in testGraph.Vertices)
            {
                System.Diagnostics.Debug.WriteLine(vertex.ToString());
            }

            // Test searching algorithms
            testGraph.DepthFirstSearch(la, (m) => System.Diagnostics.Debug.WriteLine(m));

        }
    }

    public class Vertex<T>
    {
        public Vertex(T value, params Vertex<T>[] parameters)
            : this(value, (IEnumerable<Vertex<T>>)parameters) { }

        public Vertex(T value, IEnumerable<Vertex<T>> neighbors = null)
        {
            Value = value;
            Neighbors = neighbors?.ToList() ?? new List<Vertex<T>>();
            IsVisited = false;  // can be omitted, default is false but some
                                // people like to have everything explicitly
                                // initialized
        }

        public T Value { get; }   // can be made writable

        public List<Vertex<T>> Neighbors { get; }

        public bool IsVisited { get; set; }

        public int NeighborCount => Neighbors.Count;

        public void AddEdge(Vertex<T> vertex)
        {
            Neighbors.Add(vertex);
        }

        public void AddEdges(params Vertex<T>[] newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }

        public void AddEdges(IEnumerable<Vertex<T>> newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            Neighbors.Remove(vertex);
        }

        public override string ToString()
        {
            return Neighbors.Aggregate(new StringBuilder($"{Value}: "), (sb, n) => sb.Append($"{n.Value} ")).ToString();
            //return $"{Value}: {(string.Join(" ", Neighbors.Select(n => n.Value)))}";
        }

    }

    public class UndirectedGenericGraph<T>
    {

        public UndirectedGenericGraph(params Vertex<T>[] initialNodes)
            : this((IEnumerable<Vertex<T>>)initialNodes) { }

        public UndirectedGenericGraph(IEnumerable<Vertex<T>> initialNodes = null)
        {
            Vertices = initialNodes?.ToList() ?? new List<Vertex<T>>();
        }

        public List<Vertex<T>> Vertices { get; }

        public int Size => Vertices.Count;

        public void AddPair(Vertex<T> first, Vertex<T> second)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second);
        }

        public void DepthFirstSearch(Vertex<T> root, Action<string> writer)
        {
            UnvisitAll();
            DepthFirstSearchImplementation(root, writer);

        }

        private void DepthFirstSearchImplementation(Vertex<T> root, Action<string> writer)
        {
            if (!root.IsVisited)
            {
                writer($"{root.Value} ");
                root.IsVisited = true;

                foreach (Vertex<T> neighbor in root.Neighbors)
                {
                    DepthFirstSearchImplementation(neighbor, writer);
                }
            }
        }

        private void AddToList(Vertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        private void AddNeighbors(Vertex<T> first, Vertex<T> second)
        {
            AddNeighbor(first, second);
            AddNeighbor(second, first);
        }

        private void AddNeighbor(Vertex<T> first, Vertex<T> second)
        {
            if (!first.Neighbors.Contains(second))
            {
                first.AddEdge(second);
            }
        }

        private void UnvisitAll()
        {
            foreach (var vertex in Vertices)
            {
                vertex.IsVisited = false;
            }
        }

    }
}
