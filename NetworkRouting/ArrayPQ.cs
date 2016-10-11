using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkRouting {
    public class ArrayPQ : PQueue{

        public ArrayPQ() {

        }

        public override void decreaseKey(int node) {
            // This operation is a no-op.
        }

        public override int deleteMin() {
            int minIndex = 1;
            for(int i = 2; i < nodes.Count(); i++) {
                if(dist[nodes[i]] < dist[nodes[minIndex]]) {
                    minIndex = i;
                }
            }
            int min = nodes[minIndex];
            nodes.Remove(min);
            return min;
        }

        public override void insert(int node) {
            nodes.Add(node);
        }
    }
}
