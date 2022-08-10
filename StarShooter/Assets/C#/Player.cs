using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float MinX, MaxX, MinY, MaxY;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0, 1, 0);
        }*/

        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);

    }
}
