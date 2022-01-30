using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPile : MonoBehaviour
{
    public Sprite Empty, Cat;
    public SpriteRenderer Sr;
    public bool HasCat;
    public KeyCode PileKey;
    
    void Update()
    {
        if(HasCat)
        {
            Sr.sprite = Cat;
        }
        else
        {
            Sr.sprite = Empty;
        }
    }
}
