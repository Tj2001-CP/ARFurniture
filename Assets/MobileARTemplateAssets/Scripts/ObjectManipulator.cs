using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    private Transform selectedObject;

    void Update()
    {
        // Select object with mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Manipulatable"))
                {
                    selectedObject = hit.transform;
                }
            }
        }

        // Resize object
        if (selectedObject != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                selectedObject.localScale += Vector3.one * 0.01f;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                selectedObject.localScale -= Vector3.one * 0.01f;
            }

            // Rotate object
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                selectedObject.Rotate(Vector3.up, -1f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                selectedObject.Rotate(Vector3.up, 1f);
            }

            if (Input.GetKey(KeyCode.PageUp))
            {
                selectedObject.Rotate(Vector3.right, 1f);
            }

            if (Input.GetKey(KeyCode.PageDown))
            {
                selectedObject.Rotate(Vector3.right, -1f);
            }
        }
    }
}
