using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{

    private float maxScaleX;
    private float macScaleY;

    float hearts;
    float damageTaken;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //change Input.GetKeyDown to when the enemys gets behind the screen
        if (this.transform.localScale.x >= maxScaleX)
        {
            hearts = hearts - damageTaken;
            Debug.Log("YOU TOOK DAMAGE, " + hearts + " Hearts Left");
        }
    }
}
