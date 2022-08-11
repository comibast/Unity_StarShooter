using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public PlayerControl PlayerControls;
    public float Speed;
    public float MinX, MaxX, MinY, MaxY;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControls = new PlayerControl();
        PlayerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2d = PlayerControls.Player.Movement.ReadValue<Vector2>();
        transform.Translate(vector2d.x * Speed * Time.deltaTime, 0, vector2d.y * Speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
    }
}
