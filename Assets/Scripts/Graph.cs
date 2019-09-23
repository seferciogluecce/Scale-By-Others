using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    //Center is transform.position
    public GameObject Node; //Prefab for node object
    public GameObject Edge; //Prefab for edge object

    List<GameObject> Nodes; //List to hold the nodes of the graph
    List<GameObject> Edges; //List to hold the edges of the graph

    void Start()
    {
        Nodes = new List<GameObject>();
        Edges = new List<GameObject>();
    }

   public void AddNode()
    {
        if(Edges.Count == 0)//Graph is empty, I will add 2 nodes and a connecting edge
        {
            GameObject newNode1 = Instantiate(Node, transform);
            GameObject newNode2 = Instantiate(Node, transform);
            GameObject newEdge = Instantiate(Edge, transform);

            Nodes.Add(newNode1);
            Nodes.Add(newNode2);
            Edges.Add(newEdge);

            newNode1.transform.position = Vector3.zero;
            newNode2.transform.position = Vector3.one;

            newEdge.GetComponent<GraphEdge>().StartNode = newNode1.GetComponent<GraphNode>();
            newEdge.GetComponent<GraphEdge>().EndNode = newNode2.GetComponent<GraphNode>();
        }
        else if(Edges.Count == 1) //I have 2 nodes adding one more lets me create a polygon/triangle and a connected graph
        {
            GameObject newNode = Instantiate(Node, transform);
            GameObject newEdge1 = Instantiate(Edge, transform);
            GameObject newEdge2 = Instantiate(Edge, transform);

            Nodes.Add(newNode);
            Edges.Add(newEdge1);
            Edges.Add(newEdge2);

            newNode.transform.position = Vector3.one * Edges.Count;

            newEdge1.GetComponent<GraphEdge>().StartNode = Nodes[Nodes.Count-2].GetComponent<GraphNode>();
            newEdge1.GetComponent<GraphEdge>().EndNode = newNode.GetComponent<GraphNode>();

            newEdge2.GetComponent<GraphEdge>().StartNode = Nodes[Nodes.Count - 1].GetComponent<GraphNode>();
            newEdge2.GetComponent<GraphEdge>().EndNode = Nodes[0].GetComponent<GraphNode>();


        }
        else //If I have more than 3 nodes I can keep increasing the edge count of my graph in a circular design
        {
            GameObject newNode = Instantiate(Node, transform);
            GameObject newEdge = Instantiate(Edge, transform);

            Nodes.Add(newNode);
            Edges.Add(newEdge);

            newNode.transform.position = Vector3.one * Edges.Count;

            Edges[Edges.Count - 2].GetComponent<GraphEdge>().EndNode = newNode.GetComponent<GraphNode>();

            newEdge.GetComponent<GraphEdge>().StartNode = newNode.GetComponent<GraphNode>();
            newEdge.GetComponent<GraphEdge>().EndNode = Nodes[0].GetComponent<GraphNode>();
        }

    }



}
