using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool isCheck = false;
    public bool isTrue = false;
    public bool data = false;
    [SerializeField] GameObject dataIntel;
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        isCheck = false;
        dataIntel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheck ==true)
        {

            isCheck = true;
        }
        else if (isCheck == false)
        {
            isCheck = false;

        }
    }
    public void CheckTrue()
    {
        
        if (isCheck == false)
        {
            isCheck = true;
            text.text = "Back";
            AudioManager.Instance.PlaySound("Button");
        }
        else if(isCheck == true)
        {
            isCheck = false;
            text.text = "Check";
            AudioManager.Instance.PlaySound("Button");
        }
        
        //StartCoroutine(StarCheck());
    }
    public void Back()
    {
        
        
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // โหลด Scene ตามชื่อที่กำหนด
    }
    IEnumerator StarCheck()
    {
        yield return new WaitForSeconds(0.5f);
        isCheck = false;
    }
    public void ResetScene()
    {
        // โหลดซีนปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.Instance.PlaySound("Button");
    }
    public void Data()
    {
        if(data == false)
        {
            dataIntel.SetActive(true);
            data = true;
            AudioManager.Instance.PlaySound("Button");
        }
        else if(data == true)
        {
            dataIntel.SetActive(false);
            data = false;
            AudioManager.Instance.PlaySound("Button");
        }
    }
}
