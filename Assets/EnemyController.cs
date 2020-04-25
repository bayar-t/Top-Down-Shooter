using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
   Wander,

   Follow,

   Die


};


public class EnemyController : MonoBehaviour
{
    GameObject player;
    public EnemyState currentState = EnemyState.Wander;
    public float range;
    public float speed;
    public bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;
  //  private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
       switch(currentState)
       {
          case(EnemyState.Wander):
            Wander();
          break;
          case(EnemyState.Follow):
            Follow();
          break;
          case(EnemyState.Die):
            
          break;
       }
        
       if (inRange(range) && currentState != EnemyState.Die)
       {
          currentState = EnemyState.Follow;
       }
       else if(!inRange(range) && currentState != EnemyState.Die)
       {
          currentState = EnemyState.Wander;
       }

    }

    private bool inRange(float range)
    {
       return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

  /*  private IEnumerator ChooseDirection()
    {
       chooseDir = true;
       Vector3 direction = player.transform.position - transform.position;
       float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
       transform.rotation = angle;
       direction.Normalize();
       movement = direction;
   //    yield return new WaitForSeconds(Random.Range(0.5f, 1f));
    //   randomDir = new Vector3(0, 0, Random.Range(0, 360));
     //  Quaternion nextRotation = Quaternion.Euler(randomDir);
      // transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
       chooseDir = false;
    }
    */

    void Wander()
    {
    //   if(!chooseDir)
    //   {
    //      StartCoroutine(ChooseDirection());
          
   //    }
   //    randomDir = new Vector3(0,0, Random.Range(0,360));
      // transform.position += randomDir *speed * Time.deltaTime;
       transform.position += -transform.right * speed * Time.deltaTime;
       if (inRange(range))
       {
          currentState = EnemyState.Follow;
         
       }



    }
    void Follow()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public void Death()
    {
       Destroy(gameObject);
    }
}
