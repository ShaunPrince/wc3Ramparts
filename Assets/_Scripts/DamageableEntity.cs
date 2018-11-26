using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour {


    public int health = 50;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getHealth()
    {
        return health;
    }

    public void takeDamage( int damage )
    {
        health -= damage;
        if (health <= 0)
            GameObject.Destroy(gameObject);
    }
}
