using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidbody;
    public Text score;
    public static int totalScore = 0;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;


    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float shootHorizontal = Input.GetAxis("ShootHorizontal");
        float shootVertical = Input.GetAxis("ShootVertical");

        if((shootHorizontal != 0 || shootVertical != 0) && Time.time > lastFire + fireDelay)
        {
           Shoot(shootHorizontal, shootVertical);
           lastFire = Time.time;

        }

        rigidbody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        
        score.text = "Tacos eaten: " + totalScore;
        rotate(shootHorizontal, shootVertical);

     }

    void Shoot(float x, float y)
    {
       GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
       bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
       bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
         (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
         (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
         0  
       );
    }

    void rotate(float x, float y)
    {
        if (x > 0 && y == 0)
        {
          rigidbody.rotation = 0;
        }
        else if (x< 0 && y== 0)
        {
           rigidbody.rotation = 180;
        }
        else if (y > 0 && x== 0)
        {
           rigidbody.rotation = 90;
        }
        else if (y < 0 && x== 0)
        {
           rigidbody.rotation = 270;
        }
        else if (y> 0 && x < 0)
        {
           rigidbody.rotation = 135;
        }
        else if (y< 0 && x< 0)
        {
           rigidbody.rotation = 225;
        }
        else if (y> 0 && x> 0)
        {
           rigidbody.rotation = 45;
        }
        else if (y< 0 && x> 0)
        {
           rigidbody.rotation = 315;
        }
        else
        {
           rigidbody.rotation = 0;
        }


    }
}
