using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {



    float distance;
    public AudioSource num, chomp;
    public AudioClip numClip;

    Vector3 directionToMouse = new Vector3();
    float myAngle;

	void FixedUpdate () {

        //Debug.Log(GameLogic.listOfMice.Count);
        foreach (Mouse myMouse in GameLogic.listOfMice)
        {

            directionToMouse = (myMouse.transform.position - transform.position);
            myAngle = Vector3.Angle(transform.forward, directionToMouse);
            distance = Vector3.Distance(myMouse.transform.position, transform.position);


            //Vector3 directionToMouse = (mouse.position - transform.position);
            // float myAngle = Vector3.Angle(transform.forward, directionToMouse);
            //distance = Vector3.Distance(mouse.position, transform.position);



            if (myAngle < 90f)
            {
                Ray catRay = new Ray(transform.position, directionToMouse);
                RaycastHit catRayHitInfo;

                if (Physics.Raycast(catRay, out catRayHitInfo, distance))
                {
                    Debug.DrawRay(transform.position, directionToMouse, Color.green);
                    if (catRayHitInfo.collider.tag == "Mouse")
                    {

                        if (distance < 5)
                        {
                            Destroy(myMouse.gameObject);
                        }
                        else
                        {
                            transform.forward = directionToMouse;

                        }

                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, directionToMouse, Color.red);
            }            
            
        }

	}
}


/*

    declare a public variable, of type Transform, called "mouse" (and assign this in the Inspector)

FIXED UPDATE:
if mouse is equal to NULL
       then: return (note: "return;" will end the function early)

declare a var of type Vector3, called "directionToMouse", set to a vector that goes from [current position] to [mouse's current position]
// to determine angle between two directions, google "Vector3.Angle"
if the angle between [current forward direction] vs. [directionToMouse] is less than 90 degrees, then...
    declare a var of type Ray, called "catRay" that starts from [current position] and goes along [directionToMouse]
    declare a var of type RaycastHit, called "catRayHitInfo"
    if raycast with catRay and catRayHitInfo for 100 units is TRUE...
        if catRayHitInfo.collider.tag is exactly equal to the word "Mouse"... (Cat sees the mouse!)
            if catRayHitInfo.distance is less than or equal to 5...
                then destroy the mouse gameObject (we caught the mouse!)
            else...
                add force on rigidbody, along [directionToMouse.normalized * 1000f] (chase it!)
*/