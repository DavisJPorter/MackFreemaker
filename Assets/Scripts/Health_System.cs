using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_System : MonoBehaviour
{
    //Get rid of any debugs, they dont need to be there unless for testing 
    //initializing all values that will be used 
    public int hearts = 3;
    bool gameOver = false;
    public int damageTaken = 1;
    public int pickUp = 1;

    public bool enemyPassed = false;

    public SpriteRenderer heartOne;
    public SpriteRenderer heartTwo;
    public SpriteRenderer heartThree;
    // Start is called before the first frame update

    // Update is called once per frame
    //make sure to call any extra funtions you add
    void Update()
    {
        Health();
        if (enemyPassed == true)
        {
            TakeDamage();
        }
        HealthCondition();
        HealthPickUp();
     
    }

    //User health, and ranged checked for neg number and turns it back to 0
    
    void Health()
    {
        //change Input.GetKeyDown to when the enemys gets behind the screen or dont use this one because takedamage does the same thing
        if (Input.GetKeyDown(KeyCode.A))
        {
            hearts = hearts - 1;
            Debug.Log(" - 1 heart " + hearts + " Health left");
        }
        if (hearts <= 0)
        {
            hearts = 0;
            gameOver = true;
            //change Bebug here to a death screen 
            Debug.Log("DEAD");
        }
        if (hearts > 3)
        {
            hearts = 3;
            //Debug is unnecessary here, it's just to show that it works
            Debug.Log("Can't go over 3 hearts, your hearts are set to 3 max " + hearts + " hearts left");
        }
    }

    //damage delt by enemy to player
    void TakeDamage()
    {
        //if enemies size reaches 8X/8Y
        
            hearts = hearts - 1;
            Debug.Log("YOU TOOK DAMAGE, " + hearts + " Hearts Left");
            enemyPassed = false;   
    }

    //funtion for medpacks or any healthpickups if thats what we choose to add later on
    void HealthPickUp()
    {
        //just change Input.GetKeyDown to collider of the health pickup if we wanna use that
        if(Input.GetKeyDown(KeyCode.S))
        {
            hearts = hearts + 1;
            Debug.Log("You healed");
        }
    }

    void HealthCondition()
    {
        if (hearts == 3)
        {
            heartOne.color = new Color(1, 1, 1, 1);
            heartTwo.color = new Color(1, 1, 1, 1);
            heartThree.color = new Color(1, 1, 1, 1);
        }

        else if (hearts == 2)
        {
            heartOne.color = new Color(1, 1, 1, 1);
            heartTwo.color = new Color(1, 1, 1, 1);
            heartThree.color = new Color(1, 1, 1, 0); //each time a life is lost, the sprite alpha channel changes to zero
                                                      //making the sprite completely transparent
        }

        else if (hearts == 1)
        {
            heartOne.color = new Color(1, 1, 1, 1);
            heartTwo.color = new Color(1, 1, 1, 0);   //we are calling all each time so that they recognize the reset when healing
            heartThree.color = new Color(1, 1, 1, 0);
        }

        else if (hearts == 0)
        {
            heartOne.color = new Color(1, 1, 1, 0);
            heartTwo.color = new Color(1, 1, 1, 0);
            heartThree.color = new Color(1, 1, 1, 0);
        }
    }
}
