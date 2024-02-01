﻿using UnityEngine;

public class PowerUp : MonoBehaviour {

    //when colliding with another object, if another objct is 'Player', sending command to the 'Player'
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            PlayerShooting.instance.weaponPower++;
            Destroy(gameObject);
        }
    }
}
