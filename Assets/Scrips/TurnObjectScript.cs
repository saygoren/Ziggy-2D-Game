using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectScript : MonoBehaviour
{
    private float rotationSpeed = 50f;

    void Update()
    {
       this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
