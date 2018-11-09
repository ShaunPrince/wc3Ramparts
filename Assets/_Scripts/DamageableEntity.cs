using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour {


    public int health;

	// Use this for initialization
	void Start ()
    {
        health = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage( int damage )
    {
        health -= damage;
        if (health <= 0)
            GameObject.Destroy(gameObject);
    }
}
