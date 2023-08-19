using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defineTable : MonoBehaviour
{
    public Transform indexTip;
    public Transform tableTransform;
    public Transform inventoryTransform;

    public float rapport;

    public GameObject tableObject;
    public GameObject inventory;
    public GameObject indexCube;

    [HideInInspector]
    public static Vector3 corner1 = new Vector3(0f, 0f, 0f);
    [HideInInspector]
    public static Vector3 corner2 = new Vector3(0f, 0f, 0f);
    [HideInInspector]
    public static Vector3 corner3 = new Vector3(0f, 0f, 0f);
    [HideInInspector]
    public static Vector3 corner4 = new Vector3(0f, 0f, 0f);

    public GameObject Corner1sphere;
    public GameObject Corner2sphere;
    public GameObject Corner3sphere;
    public GameObject Corner4sphere;

    public bool isTableSet = false;

    // Start is called before the first frame update
    void Start()
    {
        tableObject.SetActive(false);
        inventory.SetActive(false);
    }

    public void defineCorner()
    {
        if(isTableSet == false)
        {
            if (corner1 == new Vector3(0f, 0f, 0f))
            {
                corner1 = indexTip.position;
                Corner1sphere.transform.position = corner1;
                Debug.Log(corner1);
            }
            else if (corner2 == new Vector3(0f, 0f, 0f))
            {
                corner2 = indexTip.position;
                Debug.Log(corner2);
                Corner2sphere.transform.position = corner2;
            }
            else if (corner3 == new Vector3(0f, 0f, 0f))
            {
                corner3 = indexTip.position;
                Debug.Log(corner3);
                Corner3sphere.transform.position = corner3;
            }
            else if (corner4 == new Vector3(0f, 0f, 0f))
            {
                corner4 = indexTip.position;
                Debug.Log(corner4);
                Corner4sphere.transform.position = corner4;
            }
            else
            {
                Debug.Log("Tous les coins ont été définis.");
                setTable();
            }
        }
    }

    public void setTable()
    {
        // First, set all heights of the corners to the lowest Y value of the four (to have a flat table)
        float[] cornerList = { corner1.y, corner2.y, corner3.y, corner4.y };
        corner1.y = GetLargestElementUsingFor(cornerList);
        corner2.y = GetLargestElementUsingFor(cornerList);
        corner3.y = GetLargestElementUsingFor(cornerList);
        corner4.y = GetLargestElementUsingFor(cornerList);

        // Second, make sure it's a rectangle by specifying the values of x4 based on all 3 other points -> WIP
        //float tableHypotenuse = Mathf.Sqrt(Squared(corner3.x - corner1.x) + Squared(corner3.z - corner1.z));

        // Third, calculate the size of the table and change the size of the table

        //float tableLenght = Mathf.Sqrt(Squared(corner2.x - corner1.x) + Squared(corner2.z - corner1.z));
        //float tableWidth = Mathf.Sqrt(Squared(corner3.x - corner2.x) + Squared(corner3.z - corner2.z));

        float tableLenght = Vector3.Distance(corner1, corner2);
        float tableWidth = Vector3.Distance(corner2, corner3);
        tableObject.SetActive(true);
        inventory.SetActive(true);
        //tableTransform.transform.localScale = new Vector3(tableLenght, corner1.y, tableWidth);
        tableTransform.transform.localScale = new Vector3(tableLenght, (float)0.2, tableWidth);

        Debug.Log("tableLenght:" + tableLenght);
        Debug.Log("tableWidth:" + tableWidth);

        // Fourth, place the table to the center of the four vectors
        // tableTransform.transform.position = new Vector3((corner1.x+corner2.x+corner3.x+corner4.x)/4, corner1.y/2, (corner1.z + corner2.z + corner3.z + corner4.z)/4);
        tableTransform.transform.position = new Vector3((corner1.x + corner2.x + corner3.x + corner4.x) / 4, corner1.y - (float)0.1, (corner1.z + corner2.z + corner3.z + corner4.z) / 4);
        //( (x1 + x2) / 2, (y1 + y2) / 2 )

        // FIve, set table orientation
        Vector3 lookAtVector = ((corner1 + corner2) / 2);
        lookAtVector.y = lookAtVector.y - (float)0.1;
        tableTransform.transform.LookAt(lookAtVector);

        // Six, scale inventory to the length of the board and place it in the middle

        if(tableLenght > tableWidth) {
            rapport = tableLenght / 1;
            inventoryTransform.transform.localScale = new Vector3(inventoryTransform.transform.localScale.x * rapport, inventoryTransform.transform.localScale.y * rapport, inventoryTransform.transform.localScale.z * rapport);
        } else
         {
             rapport = tableWidth / 1;
             inventoryTransform.transform.localScale = new Vector3(inventoryTransform.transform.localScale.x * rapport, inventoryTransform.transform.localScale.y * rapport, inventoryTransform.transform.localScale.z * rapport);
         }

        Debug.Log("X avant:"+inventoryTransform.transform.localPosition.x);
        Debug.Log("Z avant:" + inventoryTransform.transform.localPosition.z);

        inventoryTransform.transform.position = new Vector3((corner1.x + corner2.x + corner3.x + corner4.x) / 4, corner1.y, (corner1.z + corner2.z + corner3.z + corner4.z) / 4);
        lookAtVector.y = lookAtVector.y + (float)0.1;
        inventoryTransform.transform.LookAt(lookAtVector);

        inventoryTransform.transform.position = new Vector3((corner1.x + corner2.x ) / 2, inventoryTransform.transform.position.y, (corner1.z + corner2.z) / 2 - inventoryTransform.transform.localScale.z / 2);

        Debug.Log("X après:" + inventoryTransform.transform.localPosition.x);
        Debug.Log("Z après:" + inventoryTransform.transform.localPosition.z);

        //indexCube.SetActive(false);
        Corner1sphere.SetActive(false);
        Corner2sphere.SetActive(false);
        Corner3sphere.SetActive(false);
        Corner4sphere.SetActive(false);

        isTableSet = true;
    }

    // MATH
    public float GetLargestElementUsingFor(float[] sourceArray)
    {
        float maxElement = sourceArray[0];
        for (int index = 1; index < sourceArray.Length; index++)
        {
            if (sourceArray[index] < maxElement)
                maxElement = sourceArray[index];
        }
        return maxElement;
    }
    public static float Squared(float a)
    {
        return (a * a);
    }
}
