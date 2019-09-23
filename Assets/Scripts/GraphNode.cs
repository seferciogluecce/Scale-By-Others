using UnityEngine;

public class GraphNode : MonoBehaviour
{
    void OnMouseDrag()
    {
        float WorldZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //z axis of the game object for screen view
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, WorldZCoordinate); //z axis added to screen point 
        Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point
        transform.position = NewWorldPosition;
    }
    void OnMouseExit() //There will be no transform change
    {
        transform.hasChanged = false;
    }
}
