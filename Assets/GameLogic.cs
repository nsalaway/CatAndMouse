using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public static List<Mouse> listOfMice = new List<Mouse>();
    public static List<Cat> listOfCats = new List<Cat>();
    public static List<Wall> listOfWalls = new List<Wall>();
    public Cat cat;
    public Mouse mouse;


	// Use this for initialization
	void Start () {
        listOfCats.Clear();
        listOfMice.Clear();
        listOfWalls.Clear();
        
	}
	
	// Update is called once per frame
	void Update () {
        int layerMask = 1 << 9;
        Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cursorRayHitInfo = new RaycastHit();

        if (Physics.Raycast(cursorRay, out cursorRayHitInfo, 1000f, layerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Mouse myMouse = (Mouse) Instantiate(mouse, cursorRayHitInfo.point, Quaternion.identity);
                listOfMice.Add(myMouse);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Cat myCat = (Cat)Instantiate(cat, cursorRayHitInfo.point, Quaternion.identity);
                listOfCats.Add(myCat);
            }
        }

        

	    if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
	}
}
