using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{

    public float Speed = 1f;

    public Axis Rotation_Axis;
    void Update()
    {
        if (Rotation_Axis == Axis.X)
        {
			this.transform.Rotate(Vector3.right * Speed * Time.deltaTime,Space.World);
        }
        else if (Rotation_Axis == Axis.Y)
        {
            this.transform.Rotate(Vector3.up * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.Rotate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }
    }
}

public enum Axis
{
    X = 0,
    Y,
    Z
}
