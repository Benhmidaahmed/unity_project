using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour
{
    public GameObject camera;
    public float paralaxEffect;
    private float width, positionx;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = camera.transform.position.x * paralaxEffect;
        float remainingDistance = camera.transform.position.x * (1 - paralaxEffect);
        transform.position = new Vector3(positionx + parallaxDistance, transform.position.y, transform.position.z);
        if (remainingDistance > positionx + width)
        {
            positionx += width;
        }
    }
}
