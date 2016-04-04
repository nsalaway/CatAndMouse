using UnityEngine;
using System.Collections;

public class WallMaker : MonoBehaviour {

    public static int counter = 0;
    public Wall wallPrefab;

    void Start()
    {
        counter = 0;
    }

	// Use this for initialization
	void Update () {
        if (counter < 8)
        {
            counter++;
            //Debug.Log("making a wall");
            int xPos =  Random.Range(-2, 3)*10;
            int zPos = Random.Range(-2, 3)*10;
            Vector3 spawnHere = new Vector3(xPos, 1.66f, zPos);
            int direction = Random.Range(0, 2);
            Wall myWall = (Wall)Instantiate(wallPrefab, spawnHere, Quaternion.identity);
            GameLogic.listOfWalls.Add(myWall);
            //Debug.Log(GameLogic.listOfWalls.Count);
            if (direction == 0) //rotate
            {
                myWall.transform.Rotate(0, 90f, 0);
            }
            myWall.killYourself();


           
        }
    
    }
}
