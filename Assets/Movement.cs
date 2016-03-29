using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;




	void FixedUpdate () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed + Physics.gravity;
        Ray moveRay = new Ray(transform.position, transform.forward);




        if (Physics.SphereCast(moveRay, .75f, 3f))
        {
            int direction = Random.Range(0, 2);
            switch (direction)
            {
                case 0:
                    transform.Rotate(0, 90f, 0);
                    break;
                case 1:
                    transform.Rotate(0, -90f, 0);
                    break;
            }
        }	
	}
}

