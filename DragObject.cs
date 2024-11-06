using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    public bool HasSun = false;
    public bool HasWater = false;
    public bool HasEngrais = false;
    public GameObject dragObject;
    private Vector3 offset;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        if (dragObject.name == "SoleilPNG")
        {
            HasSun = true;
        }
        if (dragObject.name == "WaterPNG")
        {
            HasWater = true;
        }
        if (dragObject.name == "EngraisPNG")
        {
            HasEngrais = true;
        }
        offset = dragObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        HandleMouseHold();
    }

    void OnMouseUp()
    {
        ReplaceObject();
        if (dragObject.name == "SoleilPNG")
        {
            HasSun = false;
        }
        if (dragObject.name == "WaterPNG")
        {
            HasWater = false;
        }
        if (dragObject.name == "EngraisPNG")
        {
            HasEngrais = false;
        }
    }
    void HandleMouseHold()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        dragObject.transform.position = worldMousePos + offset;
    }

    void ReplaceObject()
    {
        dragObject.transform.position = position;
    }

    
}
