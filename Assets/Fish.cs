using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

    [SerializeField] float speed = 5f;
    public Vector3 destination;
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(destination, transform.position) > 1)
        {
            transform.position += Vector3.Normalize(destination - transform.position) * speed * Time.deltaTime;
            transform.LookAt(destination);
        }
        else
        {
        }

	}
}
