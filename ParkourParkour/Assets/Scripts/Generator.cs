using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Place your building prefabs in here")]
    public GameObject[] buildings;

    [Header("How far apart do you want them?")]
    [Space(25)]
    public float distanceApart;

    [Header("How many buildings do you want?")]
    [Space(25)]

    public int amount;
    private List<GameObject> buildingsPlaced = new List<GameObject>();
    private bool canPlace;
    private Vector3 tempPos;
    private Vector3 bestPos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject buildingsSpawnedParent = new GameObject("BuildingSeed");
        buildingsSpawnedParent.transform.position = Vector3.zero;
        //buildingsPlaced = new List<GameObject>(amount);
        for (int i = 0; i < amount; i++)
        {
            while(canPlace == false)
            {

                if(buildingsPlaced.Count == 0) // if placing 1st building put it at 000
                {
                    GameObject tempBuilding = (GameObject)Instantiate(buildings[Random.Range(0, buildings.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    tempBuilding.transform.parent = buildingsSpawnedParent.transform;
                    tempBuilding.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    buildingsPlaced.Add(tempBuilding);
                    canPlace = true;
                }
                else if(buildingsPlaced.Count>=1)// if placing 2nd building
                {
                    for (int  j = 0;  j <buildingsPlaced.Count;  j++) // cycle through buildings
                    {
                        
                            tempPos = Random.insideUnitSphere * distanceApart + buildingsPlaced[j].transform.position;
                           // Debug.Log(tempPos);
                        
                        
                        if(Vector3.Distance(tempPos, buildingsPlaced[j].transform.position) > distanceApart/2) // if distance is good, this is our best pos
                        {  
                                bestPos = tempPos;
                               // Debug.Log(bestPos);
                            
                        }

                    }
                    if(bestPos!= Vector3.zero)
                    {
                        GameObject tempBuilding = (GameObject)Instantiate(buildings[Random.Range(0, buildings.Length)], new Vector3(bestPos.x, 0, bestPos.z), Quaternion.identity);
                        tempBuilding.transform.parent = buildingsSpawnedParent.transform;
                        tempBuilding.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                        buildingsPlaced.Add(tempBuilding);
                        
                        canPlace = true;
                        bestPos = Vector3.zero;
                    }
                    

                }
               
            }
            canPlace = false;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
