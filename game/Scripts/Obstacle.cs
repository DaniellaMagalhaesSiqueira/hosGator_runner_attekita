using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D obstRB;

    public GameConfiguration config;
    void Start()
    {
        obstRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        obstRB.velocity = new Vector2(-config.speed, 0f);
    }
}
