using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // โหลด Scene ตามชื่อที่กำหนด
        AudioManager.Instance.PlaySound("Button");
    }
}
