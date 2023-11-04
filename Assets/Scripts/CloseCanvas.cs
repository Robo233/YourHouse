using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public GameObject HouseCanvas;
    public GameObject CartCanvas;
    public GameObject Cart;
    public GameObject BigWall;
    public GameObject CartObject;
    public GameObject CartCounter;

    public void X()
    {
        HouseCanvas.SetActive(false);
        CartCanvas.SetActive(false);
        Cart.SetActive(true);
        BigWall.SetActive(false);
        CartObject.SetActive(true);
        CartCounter.SetActive(true);
    }
    
}
