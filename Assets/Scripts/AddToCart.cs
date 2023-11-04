using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToCart : MonoBehaviour
{
    List<string> HouseNames = new List<string>();
    public Text HouseName;
    public Text CartCounter;
    public Text HouseList;
    int price;
    int totalPrice;
    public Text totalPriceText;
    public GameObject totalPriceObject;
    public GameObject BuyButton;
    public GameObject ClearButton;
    public GameObject EmptyText;
    public RawImage CartCounterObject;
    float OldPositionX;
    
    Vector3 CartCounterOriginalPosition;
    Vector3 CartCounterNewPosition;
    
    void Start()
    {
        totalPrice = 0;
       
        
    }

    public void AddToCartFunction()
    {
        BuyButton.SetActive(true);
        ClearButton.SetActive(true);
        EmptyText.SetActive(false);
        HouseNames.Add(HouseName.text);
       
        CartCounter.text = HouseNames.Count.ToString();
        if (HouseNames.Count >= 10)
        {
            
            CartCounterObject.rectTransform.sizeDelta = new Vector2(45, CartCounterObject.rectTransform.rect.height);
            CartCounterObject.rectTransform.anchoredPosition = new Vector2(448, -25);
         


        }
        else
        {
            CartCounterObject.rectTransform.sizeDelta = new Vector2(35, CartCounterObject.rectTransform.rect.height);
            CartCounterObject.rectTransform.anchoredPosition = new Vector2(440, -25);

        }

        if (RemoveLastDigit(HouseName.text) == "MiddleHouse")
        {
            price = 75000;
        }
        else if(RemoveLastDigit(HouseName.text) == "BigHouse")
        {
            price = 50000;
        }
        else
        {
            price = 200000;
        }
        HouseList.text += HouseName.text + "          Price: " + price.ToString() + "$" + "\r\n\r\n";
        totalPrice += price;
      
        totalPriceText.text = "Total price: " + totalPrice.ToString() + "$";
       
    }

    public void ClearCart()
    {
        HouseList.text = " ";
        totalPriceText.text = " ";
        CartCounter.text = "0";
        HouseNames.Clear();
        CartCounterObject.rectTransform.sizeDelta = new Vector2(35, CartCounterObject.rectTransform.rect.height);
        CartCounterObject.rectTransform.anchoredPosition = new Vector2(440, -25);
        totalPrice = 0;
        BuyButton.SetActive(false);
        ClearButton.SetActive(false);
        EmptyText.SetActive(true);
    }

    string RemoveLastDigit(string str)
    {
        return str.Remove(str.Length - 1,1);
    }
}
