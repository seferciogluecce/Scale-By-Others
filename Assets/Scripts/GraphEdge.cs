using UnityEngine;

public enum TestMode
{
    Scene,
    Game
}

public class GraphEdge : MonoBehaviour
{
    public GraphNode StartNode;
    public GraphNode EndNode;
    public TestMode testMode = TestMode.Scene;

    bool Scaled = false;

    void FixedUpdate()
    {
        if (StartNode.transform.hasChanged || EndNode.transform.hasChanged)
        {
            Scale();
        }
    }

    void Update()
    {
        if (!Scaled)
            return;

        if (testMode == TestMode.Scene)
        {
            StartNode.transform.hasChanged = false;
            EndNode.transform.hasChanged = false;
        }
        Scaled = false;
    }

    void Scale()
    {
        float distance = Vector3.Distance(StartNode.transform.position, EndNode.transform.position); //Change Scale
        transform.localScale = new Vector3(0.25f, 0.25f, distance);

        Vector3 middlePoint = (StartNode.transform.position + EndNode.transform.position) / 2; //Change Position
        transform.position = middlePoint;

        Vector3 rotationDirection = (EndNode.transform.position - StartNode.transform.position); //Change Rotation
        transform.rotation = Quaternion.LookRotation(rotationDirection);

        Scaled = true;
    }
}
