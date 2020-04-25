using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float life;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Delay());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Delay()
    {
       yield return new WaitForSeconds(life);
       Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.tag == "Enemy")
       {
          col.gameObject.GetComponent<EnemyController>().Death();
          Destroy(gameObject);
       }
    }
}
