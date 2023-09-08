using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour, IClickable
{
    bool isDrawerOpen;

    public void Click()
    {
        InteractionDrawer();
    }

    void InteractionDrawer()
    {
        if (!isDrawerOpen)
        {
            transform.DOLocalMoveY(-0.0052f, 1f);
            isDrawerOpen = true;
        }
        else
        {
            transform.DOLocalMoveY(-.0027f, 1f); 
            isDrawerOpen = false; 
        }
    }
}
