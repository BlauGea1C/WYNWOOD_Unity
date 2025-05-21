
using UnityEngine;

public class Scr_Movimiento3D : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Vector3 lastMousePosition;

    private Transform[] allParts;
    private GameObject currentObj;

    public void SetObjectToRotate(GameObject newObj)
    {
        currentObj = newObj;
        allParts = currentObj.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (currentObj == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotX = delta.y * rotationSpeed * Time.deltaTime;
            float rotY = -delta.x * rotationSpeed * Time.deltaTime;

            foreach (Transform part in allParts)
            {
                part.Rotate(Vector3.right, rotX, Space.World);
                part.Rotate(Vector3.up, rotY, Space.World);
            }

            lastMousePosition = Input.mousePosition;
        }
    }
}