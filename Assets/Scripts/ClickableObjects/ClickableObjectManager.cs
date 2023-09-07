using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IClickable clickable = hit.collider.GetComponent<IClickable>();
                if (clickable != null)
                {
                    clickable.Click();
                }
            }
        }
    }
}
