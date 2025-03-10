using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    

    void Start()
    {
        // �֧ SpriteRenderer �ͧ GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToRed()
    {
        // ����¹����ᴧ
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }
    }

    public void ChangeToGreen()
    {
        // ����¹��������
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green;
        }
    }
    public void ChangeToBrown()
    {
        // ����¹��������
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.yellow;
        }
    }
}
