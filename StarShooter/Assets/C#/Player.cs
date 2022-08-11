using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float MinX, MaxX, MinY, MaxY;
    public  bool isTouch;
    public GameObject Bullet;
    [Header("�X���ͤ@���l�u")]
    public float SetTime;
    float ScriptTime;
    [Header("�l�u���ѦҦ�m")]
    public Transform TargetPoint;

    // Update is called once per frame
    void Update()
    {
        /*
        //Input.GetKey("wasd") �ק��V��
        if (Input.GetKey(Staticvar.KeyboardsState[0]))
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else if (Input.GetKey(Staticvar.KeyboardsState[1]))
        {
            transform.Translate(0, 0, -Speed * Time.deltaTime);
        }
        else if (Input.GetKey(Staticvar.KeyboardsState[2]))
        {
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(Staticvar.KeyboardsState[3]))
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        */
        /*
        #if UNITY_STANDALONE_WIN
            transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        #endif

        #if UNITY_ANDROID
            transform.Translate(Input.acceleration.x * Speed * Time.deltaTime, 0, Input.acceleration.y * Speed * Time.deltaTime);
        #endif
        */

        if (isTouch)
        {
            //Camera.main.ScreenToWorldPoint(�C���������ƹ��Τ����Vector2�ƭ�); �C���������ƹ��Τ����Vector2�ഫ��Unity�s�����Ҥ���3D�ƭȡC
            //Camera.main.WorldtoScreenPoint(3D���󪺮y�Ц�m)Unity �s�����Ҥ���3D�ƭ� �ഫ�� �C���������ƹ��Τ����Vector2�ƭȡC
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -0.3f);  //-0.3f�O����z�b����
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);

        ScriptTime += Time.deltaTime;
        if (ScriptTime >= SetTime)
        {
            Instantiate(Bullet, TargetPoint.transform.position, TargetPoint.transform.rotation);
            ScriptTime = 0;
        }
    }

        private void OnMouseDown()
        {
        isTouch = true;
        }

        private void OnMouseUp()
        {
        isTouch = false;
        }


}
