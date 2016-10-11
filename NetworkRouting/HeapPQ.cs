using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkRouting {
    public class HeapPQ : PQueue{

        private List<int> positions;

        public HeapPQ() {
            nodes = new List<int>();
            dist = new List<double>();
            positions = new List<int>();
        }

        public override void decreaseKey(int node) {
            bubbleUp(node);
        }

        public override int deleteMin() {
            //if (!this.isEmpty()) {
                int min = nodes[1];
                nodes[1] = nodes.Last();
                positions[nodes[1]] = 1;
                nodes.RemoveAt(nodes.Count() - 1);
                if (!this.isEmpty()) {
                    bubbleDown(nodes[1]);
                }
                return min;
            //} else {
             //   return nodes[0];
            //}
        }

        public override void insert(int node) {
            nodes.Add(node);
            positions.Add(nodes.Count() - 1);
            bubbleUp(node);
        }

        private void bubbleUp(int node) {
            int parent = Parent(node);
            while (positions[node] > 0 && dist[node] < dist[Parent(node)]) {
                swap(node, Parent(node));
            }
        }

        private void bubbleDown(int node) {
            while (positions[node] < nodes.Count() - 1 && dist[node] < dist[minChild(node)]) {
                swap(node, minChild(node));
            }
        }

        private void swap(int node1, int node2) {
            int pos1 = positions[node1];
            int pos2 = positions[node2];
            nodes[pos1] = node2;
            nodes[pos2] = node1;
            positions[node1] = pos2;
            positions[node2] = pos1;
        }

        private int Parent(int node) {
            return (positions[node] == 1)? node : nodes[positions[node] / 2];
        }

        private int minChild(int node) {
            if(positions[node]*2 > nodes.Count() - 1) {
                return node;
            } else if (positions[node] * 2 + 1 > nodes.Count() - 1) {
                return nodes[positions[node] * 2];
            } else {
                return (dist[nodes[positions[node] * 2]] > dist[nodes[(positions[node] * 2) + 1]]) ? nodes[positions[node] * 2] : nodes[(positions[node] * 2) + 1];
            }
        }

        //For parent pass back the node itself.
        //demeteMin you have to update the positions of the nodes.
        //On delete min make sure you check if(!isEmpty())
        //pubble up make sure you're not at the top.
        //Find smallest Child instead of the dist. Because of the 
        //Don't bullble up whne position[node] != 


    }
}
