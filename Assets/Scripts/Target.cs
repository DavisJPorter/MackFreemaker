using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public SpriteRenderer aliveSprite;
    //this script goes on the enemy along with a box collider
    //Tobias, a note about Sprite Renderers. They are gameobjects in themselves. You previously change this script to
    //create a second gameobject variable to call the render false in the death, no need to convulute the code if we can just
    //call the render false on it's own.
    //Please check with me before making changes to the sprite functions. 
    public void Start()
    {
        aliveSprite = GetComponent<SpriteRenderer>(); //basically instantiating the color pallette in the scene
    }
    public void takeDamage(float amount)
    {
        StartCoroutine(DamageEffect()); //loops the color change sequence upon taking damage
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }
    IEnumerator DamageEffect()
    {
        aliveSprite.color = Color.red;

        yield return new WaitForSeconds(0.05f); //timer changing the color back to white/default

        aliveSprite.color = Color.white;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
