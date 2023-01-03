using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    const float minSpeed = 4f;
    const float maxSpeed = 6f;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(minSpeed,maxSpeed), Random.Range(minSpeed, maxSpeed)),ForceMode2D.Impulse);
    }
}
