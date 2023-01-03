using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    //jump location support
    const float MinX = -8.14f;
    const float MinY = -2.43f;
    const float MaxX = 8.17f;
    const float MaxY = 2.4f;


    //timer support
    const float TotalJumpDelaySeconds = 0.3f;

    float elapsedJumpDelaySeconds = 0f;

    // Update is called once per frame
    void Update()
    {
        // update timer and check if it's done
        elapsedJumpDelaySeconds += Time.deltaTime;

        if(elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            elapsedJumpDelaySeconds = 0;

            Vector2 position = transform.position;
            position.y = Random.Range(MinY, MaxY);
            position.x = Random.Range(MinX, MaxX);
            transform.position = position;
        }

    }
}
