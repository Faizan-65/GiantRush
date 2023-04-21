using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacement : MonoBehaviour
{
    public List<GameObject> leftLane=new List<GameObject>();
    public List<GameObject> middleLane=new List<GameObject>();
    public List<GameObject> rightLane=new List<GameObject>();


    // Start is called before the first frame update
    public void PlaceFood(Material rightColor, Material wrongColor)
    {
        Debug.Log(rightColor.name);
        Debug.Log(wrongColor.name);
        foreach (var item in leftLane)
        {
            item.SetActive(true);
            
            item.GetComponent<Renderer>().material = rightColor;
        }
        foreach (var item in middleLane)
        {
            item.SetActive(false);
        }
        foreach (var item in rightLane)
        {
            item.SetActive(true);
            item.GetComponent<Renderer>().material = wrongColor;
        }
    }

}
