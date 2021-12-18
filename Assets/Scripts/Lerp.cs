using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    // Notes:
    //
    // Jorden is a weirdo
    //
    //=====================================Initalize========================================
    //initalize maximum and minimum values of Lerp

    //initalize load in time
    public float loadTime;

    public bool startTime;

    //Initalize random range
    public float minPosRangeX;
    public float maxPosRangeX;

    public float minPosRangeY;
    public float maxPosRangeY;
    //for X transform scale value
    public float minScaleX = 0;
    public float maxScaleX = 0;

    //for Y transform scale value
    public float minScaleY = 0;
    public float maxScaleY = 0;

    //for X transform pos value
    public float minPosX = 0;
    public float maxPosX = 0;

    //for Y transform pos value
    public float minPosY = 0;
    public float maxPosY = 0;

    //initalize time it takes to complete Lerp
    public float lerpTime = 0;

    //initalize lerpTime reset
    public float lerpTimeReset;

    //initalize timer
    public float tillRiseTime;   

    //initalize timerReset
    public float riseTimeReset;

    //initalize Lerp bool
    public bool lerp = false;

    //Checks if sprite is enemy
    public bool isEnemy;

    //initalize Image render
    public SpriteRenderer renderer;

    //share script values to another
    public GameObject mananger;
    
    //======================================+=========================================

    // Start is called before the first frame update
    void Start()
    {
        //Grabs the renderer of the sprite
        renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //==================================Start Timer======================================
        if (startTime == true)
        {
            //Deactivates renderer
            this.renderer.enabled = false;

            //Subtracts Timer
            loadTime = loadTime - 1 * Time.deltaTime;

            //Clamps Timer
            if (loadTime < 0)
            {
                loadTime = 0;
            }

            //Checks if timer is finished
            if (loadTime == 0)
            {
                lerp = false;
                startTime = false;
            }
        }
        

        //===============================================================================

        //==================================Lerping======================================

        //Detects if lerp is active
        if (lerp == true)
        {
            //Checks if sprite is a enemy
            if (isEnemy == false)
            {
                // Changes maximum based on position
                if (minPosX > 0)
                {
                    maxPosX = minPosX + 15f;
                    if (maxPosRangeX == 2)
                    {
                        maxPosX = minPosX + 50;
                    }

                    if (maxPosRangeX == 3)
                    {
                        maxPosX = minPosX + 85;
                    }
                }

                if (minPosX < 0)
                {
                    maxPosX = minPosX + -15;
                    if (maxPosRangeX == -2)
                    {
                        maxPosX = minPosX - 50;
                    }

                    if (maxPosRangeX == -3)
                    {
                        maxPosX = minPosX - 85;
                    }
                }
            }

            if (isEnemy == true)
            {

                EnemyDest();
                
            }

            //Resets Timer
            tillRiseTime = riseTimeReset;

            //Activates renderer
            this.renderer.enabled = true;

            //Makes the image grow
            transform.localScale = new Vector2(Mathf.Lerp(minScaleX, maxScaleX, lerpTime), Mathf.Lerp(minScaleY, maxScaleY, lerpTime));
            transform.position = new Vector2(Mathf.Lerp(minPosX, maxPosX, lerpTime), Mathf.Lerp(minPosY, maxPosY, lerpTime));

           

            //Makes image grow over a set time
            lerpTime += lerpTime * Time.deltaTime;

            //Checks if maximum was reached
            if (this.transform.localScale.x >= maxScaleX && this.transform.localScale.y <= maxScaleY)
            {
             
                lerp = false;
            }           
            
        }

        //Detects if lerp is deactivated
        if (lerp == false)
        {

            //Picks a random spawn point           
            minPosX = Random.Range(minPosRangeX, maxPosRangeX);
            minPosY = Random.Range(minPosRangeY, maxPosRangeY);

            //Deactivates renderer
            this.renderer.enabled = false;

            //resets Lerp
            lerpTime = lerpTimeReset;
           
            //Subtracts Timer
            tillRiseTime = tillRiseTime - 1 * Time.deltaTime;

            //Clamps Timer
            if (tillRiseTime < 0)
            {
                tillRiseTime = 0;
            }

            //Checks if timer is finished
            if (tillRiseTime == 0)
            {
                maxPosX = 0;
                lerp = true;          
            }
                   
        }
        //======================================+=========================================
        
        //Enemies Destination
        void EnemyDest()
        {
            maxPosX = 0;
        }                
    }
}
