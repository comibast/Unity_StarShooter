using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        //舊式換場景:(玩家要等加載)
        //Application.LoadLevel("下一個場景名稱");
        //Application.LoadLevel(ID);
        //新式換場景:(預先加載,玩家不用等)
        //SceneManager.LoadScene("下一個場景名稱");
        //SceneManager.LoadScene(ID);
        SceneManager.LoadScene("level");

    }

    public void Quit()
    {
        Application.Quit();
    }
    


}
