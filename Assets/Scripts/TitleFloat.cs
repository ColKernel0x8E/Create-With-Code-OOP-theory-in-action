using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFloat : MonoBehaviour
{

    Vector3 randomRotation;
    Vector3 randomDirection;
    float yBound = 5f;
    float xBound = 10f;
        
    // Start is called before the first frame update
    void Start()
    {
        randomRotation = Random.insideUnitSphere * 0.5f;
        randomDirection = Random.insideUnitSphere;
        transform.position = new Vector3(randomDirection.x, randomDirection.y, 0) * 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation.x, randomRotation.y, randomRotation.z);
        transform.Translate(randomDirection.x * Time.deltaTime, randomDirection.y * Time.deltaTime, 0f, Space.World);

        if (transform.position.y > yBound)
        {
            randomDirection.y -= 1f;
        }
        else if (transform.position.y < -yBound)
        {
            randomDirection.y += 1f;
        }
        else if (transform.position.x > xBound)
        {
            randomDirection.x -= 1f;
        }
        else if (transform.position.x < -xBound)
        {
            randomDirection.x += 1f;
        }
    }
}
