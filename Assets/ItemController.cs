using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController instance;
    private int health;
    private int maxHealth;
    private float moveSpeed;
    private float fireRate;
    // Start is called before the first frame update
    private void Awake()
    {
       if(instance == null)
       {
          instance = this;
       }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
