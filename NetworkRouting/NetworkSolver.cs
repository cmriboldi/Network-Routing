using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkRouting {

    public class NetworkSolver {
        private PQueue arrayPQ;
        private PQueue heapPQ;
        private List<PointF> points;
        private List<int> prev;
        private List<double> dist;
        private double arrayTime;
        private double heapTime;
        protected double diff;

        public List<double> Dist {
            get { return dist; }
            set { dist = value; }
        }

        public List<int> Prev {
            get { return prev; }
            set { prev = value; }
        }

        public double ArrayTime {
            get { return arrayTime; }
            set { arrayTime = value; }
        }

        public double HeapTime {
            get { return heapTime; }
            set { heapTime = value; }
        }

        

        public NetworkSolver() {
                arrayPQ = new ArrayPQ();
                heapPQ = new HeapPQ();
        }

        public void solve(List<PointF> points, List<HashSet<int>> adjacencyList, int startNodeIndex, int stopNodeIndex, bool runBoth) {
            arrayPQ = new ArrayPQ();
            heapPQ = new HeapPQ();
            this.points = points;
            this.heapTime = dijkstras(adjacencyList, startNodeIndex, stopNodeIndex, heapPQ);
            this.dist = heapPQ.Dist;
            if(runBoth) {
                this.arrayTime = dijkstras(adjacencyList, startNodeIndex, stopNodeIndex, arrayPQ);
                this.diff = arrayTime / heapTime;
            } else {
                this.arrayTime = 0;
            }
        }

        private double dijkstras(List<HashSet<int>> adjacencyList, int startNodeIndex, int stopNodeIndex, PQueue h) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            h.Dist = new List<double>();
            prev = new List<int>();


            for (int i = 0; i < points.Count(); i++) {
                h.Dist.Add(Double.MaxValue);
                prev.Add(-1);
            }
            h.Dist[startNodeIndex] = 0;
            h.makeQueue(points);
            while (!h.isEmpty()) {
                int u = h.deleteMin();
                foreach (int v in adjacencyList[u]) {
                    if(h.Dist[v] > h.Dist[u] + length(u, v)) {
                        h.Dist[v] = h.Dist[u] + length(u, v);
                        prev[v] = u;
                        h.decreaseKey(v);
                    }
                }
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds;
        }

        public double length(int u, int v) {
            PointF p1 = points[u];
            PointF p2 = points[v];
            return Math.Sqrt( Math.Pow( (p2.X - p1.X), 2 ) + Math.Pow( (p2.Y - p1.Y), 2) );
        }
    }
}