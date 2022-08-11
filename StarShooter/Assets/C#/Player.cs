using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float MinX, MaxX, MinY, MaxY;
    public  bool isTouch;
    public GameObject Bullet;
    [Header("幾秒產生一顆子彈")]
    public float SetTime;
    float ScriptTime;
    [Header("子彈的參考位置")]
    public Transform TargetPoint;

    // Update is called once per frame
    void Update()
    {
        /*
        //Input.GetKey("wasd") 修改方向鍵
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
            //Camera.main.ScreenToWorldPoint(遊戲視窗的滑鼠或手指的Vector2數值); 遊戲場景的滑鼠或手指的Vector2轉換成Unity編輯環境中的3D數值。
            //Camera.main.WorldtoScreenPoint(3D物件的座標位置)Unity 編輯環境中的3D數值 轉換成 遊戲場景的滑鼠或手指的Vector2數值。
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -0.3f);  //-0.3f是飛機z軸的值
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
