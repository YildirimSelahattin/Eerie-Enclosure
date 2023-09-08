using System;
using UnityEngine;

public class InspectObjectsManager : MonoBehaviour
{
    public Transform inspectArea;
    public LayerMask inspectLayer;
    public Camera cam;
    public float mouseButtonRotateSpeed = 125f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isInspecting = false;
    private GameObject inspectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickupItem();
        }

        if (isInspecting)
        {
            MoveAndRotateInspectedObject();
        }
        else if (inspectedObject != null)
        {
            MoveObjectBackToOriginalPosition();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isInspecting)
        {
            DropItem();
        }
    }

    private void TryPickupItem()
    {
        if (isInspecting)
        {
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, inspectLayer))
        {
            inspectedObject = hit.transform.gameObject;
            originalPosition = hit.transform.position;
            originalRotation = hit.transform.rotation;
            isInspecting = true;
            PickupItem();
        }
    }


    private void PickupItem()
    {
        inspectedObject.transform.SetParent(inspectArea);
    }

    private void MoveAndRotateInspectedObject()
    {
        inspectedObject.transform.position = Vector3.Lerp(inspectedObject.transform.position, inspectArea.position, 0.2f);
        inspectArea.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * mouseButtonRotateSpeed);
    }

    private void MoveObjectBackToOriginalPosition()
    {
        inspectedObject.transform.SetParent(null);
        inspectedObject.transform.position = Vector3.Lerp(inspectedObject.transform.position, originalPosition, 0.2f);
    }

    private void DropItem()
    {
        inspectedObject.transform.rotation = originalRotation;
        isInspecting = false;
    }
}
