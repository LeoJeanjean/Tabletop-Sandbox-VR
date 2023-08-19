using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewItem : MonoBehaviour
{

    public GameObject table;
    public GameObject indexCube;
    private bool collision = false;
    protected static bool snap = false;

    private static GameObject spawnable;
    private static GameObject empty;
    private static GameObject cliquedObject;

    public GameObject Bush_1_grabbable;
    public GameObject Bush_2_grabbable;
    public GameObject Bush_3_grabbable;
    public GameObject Log_1_grabbable;
    public GameObject Log_3_grabbable;
    public GameObject Plant_1_grabbable;
    public GameObject Plant_2_grabbable;
    public GameObject Plant_3_grabbable;
    public GameObject Plant_6_grabbable;
    public GameObject Plant_7_grabbable;
    public GameObject Rock_1_grabbable;
    public GameObject Rock_2_grabbable;
    public GameObject Rock_3_grabbable;

    private void OnTriggerEnter(Collider other)
    {
        if(collision == false)
        {
            if (other.gameObject.tag == "palette")
            {
                snap = true;
                switch (other.gameObject.name)
                {
                    case "Bush_1":
                        spawnable = Bush_1_grabbable;
                        break;
                    case "Bush_2":
                        spawnable = Bush_2_grabbable;
                        break;
                    case "Bush_3":
                        spawnable = Bush_3_grabbable;
                        break;
                    case "Log_1":
                        spawnable = Log_1_grabbable;
                        break;
                    case "Log_3":
                        spawnable = Log_3_grabbable;
                        break;
                    case "Plant_1":
                        spawnable = Plant_1_grabbable;
                        break;
                    case "Plant_2":
                        spawnable = Plant_2_grabbable;
                        break;
                    case "Plant_3":
                        spawnable = Plant_3_grabbable;
                        break;
                    case "Plant_6":
                        spawnable = Plant_6_grabbable;
                        break;
                    case "Plant_7":
                        spawnable = Plant_7_grabbable;
                        break;
                    case "Rock_1":
                        spawnable = Rock_1_grabbable;
                        break;
                    case "Rock_2":
                        spawnable = Rock_2_grabbable;
                        break;
                    case "Rock_3":
                        spawnable = Rock_3_grabbable;
                        break;
                    default:
                        break;
                }
                cliquedObject = other.gameObject;

                Debug.Log("Clic détecté: Spawnable = " + spawnable);
            }
            else if(other.gameObject.tag == "table"){
                Debug.Log("Table détecté.");
                if (spawnable != empty)
                {
                    snap = false;
                    spawnNewItem(spawnable, indexCube, cliquedObject);
                    spawnable = empty;
                }
            }
            else
            {
                Debug.Log("Pas une palette." + other.gameObject);
            }
            collision = true;
        }
        Debug.Log("Entré? "+other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        collision = false;
        Debug.Log("Sortie de l'élément: "+other.name);
    }

    private void Update()
    {
        /*if(snap = true)
        {
            spawnable.transform.position = indexCube.transform.position;

        }*/
    }

    private GameObject spawnNewItem(GameObject spawnable, GameObject indexCube, GameObject cliquedObject)
    {
        GameObject newElement;
        newElement = Instantiate(spawnable, indexCube.transform.position, Quaternion.identity);

        float rapport = 0;
        if(table.transform.localScale.x > table.transform.localScale.z)
        { rapport = table.transform.localScale.x; }
        else { rapport = table.transform.localScale.z; }

        Debug.Log("Rapport: "+rapport);
        newElement.transform.localScale = new Vector3(newElement.transform.localScale.x * rapport, newElement.transform.localScale.y * rapport, newElement.transform.localScale.z * rapport);

        return newElement;
    }

}
