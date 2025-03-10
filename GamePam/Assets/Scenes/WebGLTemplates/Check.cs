using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField] bool L1;
    [SerializeField] bool L2;
    [SerializeField] bool L3;

    [SerializeField] bool Level1 = false;
    [SerializeField] bool Level2 = false;
    [SerializeField] bool Level3 = false;

    [SerializeField] ChangeSpriteColor changeSpriteColor;
    [SerializeField] GameManager gameManager;

    [SerializeField] bool Fe = false;
    [SerializeField] bool Mg = false;
    [SerializeField] bool Si = false;
    [SerializeField] bool O = false;
    [SerializeField] bool Ni = false;
    [SerializeField] bool Al = false;
    [SerializeField] bool AlO = false;
    [SerializeField] bool SiO = false;
    // Start is called before the first frame update
    void Start()
    {
        L1 = false;
        L2 = false;
        L3 = false;
       
    }

    // Update is called once per frame
    void Update()
    {


        if (gameManager.isCheck == true)
        {
            /*if(Level1 == true)
            {
                if (L1 == true)
                {
                    changeSpriteColor.ChangeToGreen();
                }
                else if ( L1 == false )
                {
                    changeSpriteColor.ChangeToRed();
                }
                else if (L1 == false)
                {
                    changeSpriteColor.ChangeToRed();
                }
            }
            else if(Level2 == true)
            {
                if (L2 == false)
                {
                    changeSpriteColor.ChangeToRed();
                }
                else if ( L2 == true)
                {
                    changeSpriteColor.ChangeToGreen();

                }
                else if (L2 == false)
                {
                    changeSpriteColor.ChangeToRed();
                }
            }
            else if(Level3 == true)
            {
                if (L3 == false)
                {
                    changeSpriteColor.ChangeToRed();
                }
                else if (L3 == false)
                {
                    changeSpriteColor.ChangeToRed();
                }
                else if (L3 == true)
                {
                    changeSpriteColor.ChangeToGreen();
                }
            }*/

            if (Fe == true)
            {
                if (Level2 == true || Level3 == true)
                {
                    if (L2 == true || L3 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L1 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (Mg == true)
            {
                if (Level2 == true)
                {
                    if (L2 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L1 == true || L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (Si == true)
            {
                if (Level1 == true || Level2 == true)
                {
                    if (L1 == true || L2 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (O == true)
            {
                if (Level1 == true || Level2 == true)
                {
                    if (L1 == true || L2 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }

            }
            else if (Ni == true)
            {
                if (Level3 == true)
                {
                    if (L3 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L1 == true || L2 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (Al == true)
            {
                if (Level1 == true)
                {
                    if (L1 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L2 == true || L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (AlO == true)
            {
                if (Level1 == true)
                {
                    if (L1 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L2 == true || L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            else if (SiO == true)
            {
                if (Level1 == true)
                {
                    if (L1 == true)
                    {
                        changeSpriteColor.ChangeToGreen();
                    }
                    else if (L2 == true || L3 == true)
                    {
                        changeSpriteColor.ChangeToRed();
                    }
                }
            }
            

          
 
 
           
        }
        else if (gameManager.isCheck == false)
        {
            changeSpriteColor.ChangeToBrown();
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("L1") )
        {
            L1 = true;

        }
        if (collision.CompareTag("L2"))
        {
            L2 = true;
        }
        if (collision.CompareTag("L3") )
        {
            L3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("L1"))
        {
            L1 = false;
            //Level1 = false;
            changeSpriteColor.ChangeToBrown();
        }
        if (collision.CompareTag("L2"))
        {
            L2 = false;
            //Level2 = false;
            changeSpriteColor.ChangeToBrown();
        }
        if (collision.CompareTag("L3"))
        {
            L3 = false;
            //Level3 = false;
            changeSpriteColor.ChangeToBrown();
        }
    }


}
