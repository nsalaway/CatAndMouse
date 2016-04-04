using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    float distance;
    public AudioSource aah;

	void FixedUpdate () {

        foreach (Cat myCat in GameLogic.listOfCats)
        {
            Vector3 directionToCat = myCat.transform.position - transform.position;
            float myAngle = Vector3.Angle(transform.forward, directionToCat);
            distance = Vector3.Distance(myCat.transform.position, transform.position);
            if (myAngle < 90f)
            {
                Ray mouseRay = new Ray(transform.position, directionToCat);
                RaycastHit mouseRayHitInfo;
                if (Physics.Raycast(mouseRay, out mouseRayHitInfo, distance))
                {
                    if (mouseRayHitInfo.collider.tag == "Cat")
                    {
                        //GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
                        //aah.Play();
                        transform.forward = -directionToCat;
                        //GetComponent<Rigidbody>().velocity *= 2;
                    }
                }
            }
        }



	}


    void OnDestroy()
    {
        GameLogic.listOfMice.RemoveAt(GameLogic.listOfMice.IndexOf(this));
    }
}




/*
declare a public variable, of type Transform, called "cat" (and assign this in the Inspector)

FIXED UPDATE:
declare a var of type Vector3, called "directionToCat", set to a vector that goes from [current position] to [cat's current position]
// to determine angle between two directions, google "Vector3.Angle"
if the angle between [current forward direction] vs. [directionToCat] is less than 180 degrees, then...
    declare a var of type Ray, called "mouseRay" that starts from [current position] and goes along [directionToCat]
    declare a var of type RaycastHit, called "mouseRayHitInfo"
    if raycast with mouseRay and mouseRayHitInfo for 100 units is TRUE, then... 
        if mouseRayHitInfo.collider.tag is exactly equal to the word "Cat"... (mouse sees cat!)
            add force on rigidbody, along [-directionToCat.normalized * 1000f] (run away!)

    */