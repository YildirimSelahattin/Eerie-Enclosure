using System;
using UnityEngine;

public class InspectObjectsManager : MonoBehaviour
{
    public LayerMask inspectLayer;
    [SerializeField] Transform inspectArea;
    [SerializeField] Camera cam;
    [SerializeField] float mouseButtonRotateSpeed = 125f;

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
        if (isInspecting) return;

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
        inspectArea.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Time.deltaTime * mouseButtonRotateSpeed);
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
