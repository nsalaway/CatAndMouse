using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForestManager : MonoBehaviour {

    public GameObject treeOnePrefab;
    public GameObject treeTwoPrefab;

    List<GameObject> listOfTrees = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo = new RaycastHit();

        if (Physics.Raycast(ray, out rayHitInfo, 1000f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject myTree = Instantiate(treeOnePrefab, rayHitInfo.point, Quaternion.identity) as GameObject;
                listOfTrees.Add(myTree);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GameObject myTree = Instantiate(treeTwoPrefab, rayHitInfo.point, Quaternion.identity) as GameObject;
                listOfTrees.Add(myTree);
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log(listOfTrees.Count);
            foreach(GameObject myTree in listOfTrees)
            {
                myTree.transform.localScale *= 1.1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach (GameObject myTree in listOfTrees)
            {
                myTree.transform.localScale *= .9f;
            }
        }


    }
}
