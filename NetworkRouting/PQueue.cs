using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkRouting {
    abstract public class PQueue {

        protected List<int> nodes;
        protected List<double> dist;

        public List<Double> Dist {
            get { return dist; }
            set { dist = value; }
        }

        public PQueue() {
            nodes = new List<int>();
            dist = new List<double>();
        }

        public void makeQueue(List<PointF> points) {
            this.nodes.Add(-1);
            for (int i = 0; i < points.Count(); i++) {
                this.insert(i);
            }

        }

        public bool isEmpty() {
            return nodes.Count() == 1;
        }
        
        abstract public void decreaseKey(int node);
        abstract public int deleteMin();
        abstract public void insert(int node);
    }
}
