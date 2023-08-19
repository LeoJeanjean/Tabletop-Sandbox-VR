using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleTest : MonoBehaviour
{
    public Transform cube;
    private bool isScriptOn = true;
    private bool boolScaleUp = false;

    private float waitTime = 0.2f;
    private float timer = 0.0f;
    public void scaleUp()
    {
        isScriptOn = true;
        boolScaleUp = true;
        
        //Debug.Log("Test test test :)");
    }

    public void scaleDown()
    {
        isScriptOn = true;
        boolScaleUp = false;

        //Debug.Log("Test test test :)");
    }

    public void stopScaling()
    {
        isScriptOn = false;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (isScriptOn && timer > waitTime && boolScaleUp == false)
        {
            Vector3 objectScale = cube.transform.localScale;
            cube.transform.localScale = new Vector3(objectScale.x - 0.01f, objectScale.y - 0.01f, objectScale.z - 0.01f);

            timer = timer - waitTime;
        }

        if(isScriptOn && timer > waitTime && boolScaleUp == true)
        {
            Vector3 objectScale = cube.transform.localScale;
            cube.transform.localScale = new Vector3(objectScale.x + 0.01f, objectScale.y + 0.01f, objectScale.z + 0.01f);

            timer = timer - waitTime;
        }
    }
}
