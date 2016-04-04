using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishGod : MonoBehaviour {


    public Fish fishPrefab;
    List<Fish> listOfFish = new List<Fish>();


	// Use this for initialization
	void Start () {
        while (listOfFish.Count < 500)
        {
            Fish newFish = (Fish)Instantiate(fishPrefab, Random.insideUnitSphere * 10f, Random.rotation);
            listOfFish.Add(newFish);
        }


	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out rayHitInfo, 1000f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (Fish thisFish in listOfFish)
                {
                    thisFish.destination = rayHitInfo.point;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Fish thisFish in listOfFish)
            {
                thisFish.destination = Random.onUnitSphere * 10f;
            }
        }
    }
}
