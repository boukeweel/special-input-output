using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public List<Transform> objectivPoints;

    public int current;

    public int speed;
    private float wpRadius = 0.5f;
    private void Update()
    {
        if(Vector3.Distance(objectivPoints[current].position,transform.position) < wpRadius)
        {
            current++;
            if(current >= objectivPoints.Count)
            {
                current = 0;
            }
        }
        transform.LookAt(objectivPoints[current]);
        transform.position = Vector3.MoveTowards(transform.position, objectivPoints[current].position, speed * Time.deltaTime);
        
    }
}
