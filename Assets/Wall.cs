using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
    bool killMe = false;
    // Use this for initialization
    void Start()
    {
    }
	// Update is called once per frame
	void Update () {
	    
	}

    public void killYourself()
    {
        Debug.Log("there are" + GameLogic.listOfWalls.Count);
        Debug.Log("i am number" + GameLogic.listOfWalls.IndexOf(this));
        foreach (Wall myWallInList in GameLogic.listOfWalls)
        {
            if (GameLogic.listOfWalls.IndexOf(myWallInList) != GameLogic.listOfWalls.IndexOf(this))
            {
                if (Vector3.Distance(myWallInList.transform.position, GetComponent<Collider>().ClosestPointOnBounds(myWallInList.transform.position)) < 10)
                //if (Vector3.Distance(GameLogic.listOfWalls[0].transform.position, transform.position) < 0)
                {
                    killMe = true;
                }
            }
        }
        if (killMe)
        {
            Debug.Log("kill me");
            Destroy(this.gameObject);
            GameLogic.listOfWalls.RemoveAt(GameLogic.listOfWalls.IndexOf(this));
            WallMaker.counter--;
        }
    
    }

}
