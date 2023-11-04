using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    public GameObject HouseCanvas;
    public Text HouseName;
    public Text HousePrice;
    public Text HouseDescription;

    public string BigHousePrice = "Price: 50.000$";
    public string BigHouseDescription = "A really good looking apartament with two bedrooms, two bathrooms, a kitchen and a living room";

    public string MiddleHousePrice = "Price: 75.000$";
    public string MiddleHouseDescription = "An apartament with a large living room, two bedrooms, two bathrooms and a nice kitchen";

    public string SmallHousePrice = "Price: 200.000$";
    public string SmallHouseDescription = "A big two storey house, with a nice garden, three bedrooms, a large living room, a large kitchen and three bathrooms";

    public GameObject Cart;
    public GameObject CartScreen;

    public GameObject BigWall;

    public GameObject CartObject;
    public GameObject CartCounter;
    // public GameObject CartButton;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }


        void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (RemoveLastDigit(hit.transform.name) == "BigHouse"  )
                {
                    HouseCanvas.SetActive(true);
                    HouseName.text = hit.transform.name;
                    HousePrice.text = BigHousePrice;
                    HouseDescription.text = BigHouseDescription;
                    try
                    {
                        BigWall.SetActive(true);
                    }
                    catch {

                    }
                }
                if (RemoveLastDigit(hit.transform.name) == "MiddleHouse")
                {
                    HouseCanvas.SetActive(true);
                    HouseName.text = hit.transform.name;
                    HousePrice.text = MiddleHousePrice;
                    HouseDescription.text = MiddleHouseDescription;
                    try
                    {
                        BigWall.SetActive(true);
                    }
                    catch
                    {

                    }
                }
                if (FirstFiveDigit(hit.transform.name) == "Small")
                {
                    HouseCanvas.SetActive(true);
                    HouseName.text = hit.transform.name;
                    HousePrice.text = SmallHousePrice;
                    HouseDescription.text = SmallHouseDescription;
                    try
                    {
                        BigWall.SetActive(true);
                    }
                    catch
                    {

                    }
                }
                if (FirstFiveDigit(hit.transform.name) == "Small")
                {
                    HouseCanvas.SetActive(true);
                    HouseName.text = hit.transform.name;
                    HousePrice.text = SmallHousePrice;
                    HouseDescription.text = SmallHouseDescription;
                    try
                    {
                        BigWall.SetActive(true);
                    }
                    catch
                    {

                    }
                }
            



            }/*

            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
            */

        }



    }
    
     public void CartMenu()
        {
            CartScreen.SetActive(true);
            Cart.SetActive(false);
            CartObject.SetActive(false);
            CartCounter.SetActive(false);
        try
        {
            BigWall.SetActive(true);
        }
        catch
        {

        }
    }
        

    string RemoveLastDigit(string str)
    {
        return str.Remove(str.Length - 1, 1);
    }

  string FirstFiveDigit(string str)
    {
        return str.Substring(0, Math.Min(str.Length, 5));
    }
}
