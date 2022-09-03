using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlight : MonoBehaviour
{
    [Header("Variables")]
    private float rotate;
    public float speed = 30;
    public bool incline = true;
    private bool isFly = false;
    public bool isCanFly = false;
    private string tags;
    private int fail_Condition_Count = 0;

    [Header("Particle")]
    public GameObject explosion_Effect;
    public GameObject temp_Explosion;

    [Header("Scripts")]
    public Creaters creaters;
    public LevelManag level_Manager;

    void Update()
    {
        Controller();
        Rocket_Flight();
    }

    void Rocket_Flight() // Durumlara göre roketin dikey veya açýlý uçmasý
    {
        if (!isFly)
        {
            if (incline == true)
            {
                rotate = -45;
                Inclined_Flight(rotate);
            }
            else
            {
                rotate = -140;
                Inclined_Flight(rotate);
            }
        }
        else
        {
            Fly(rotate);
        }
    }
    void Inclined_Flight(float rota) // Roketin açýlý uçma kodu
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, 0, rota), Time.deltaTime * 17f);
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LoseGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        tags = other.gameObject.tag;
        switch (tags)
        {
            case "Plus5":
                creaters.nextCount += 10;
                break;
            case "Times2":
                creaters.nextCount *= 5;
                break;
            case "Minus3":
                if (creaters.nextCount <= 0)
                {
                    fail_Condition_Count++;
                    if (fail_Condition_Count >= 3)
                    {
                        LoseGame();
                    }
                }
                creaters.nextCount -= 3;
                break;
            case "Div2":
                if (creaters.nextCount <= 0)
                {
                    fail_Condition_Count++;
                    if (fail_Condition_Count >= 3)
                    {
                        LoseGame();
                    }
                }
                creaters.nextCount -= 10;
                break;
            case "Down":
                FlyTheLowest();
                break;
            case "Up":
                FlyTheHighest();
                break;
            default:
                break;
        }

    }
    void FlyTheHighest() // Roketin yukarý doðru düz uçmasý
    {
        isFly = true;
        if (isFly)
        {
            rotate = 0;
        }
        Invoke("Current_Rocket", 1.3f);
    }
    void FlyTheLowest() // Roketing aþaðý doðru düz uçmasý
    {
        isFly = true;
        if (isFly)
        {
            rotate = 180;
        }
        Invoke("Current_Rocket", 1.3f);
    }

    void Fly(float rotates) // Roketin dik uçarken ki pozisyonu ve hýzý ayarlanmasý
    {
        transform.position += transform.up * 55 * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, 0, rotates), .5f);
    }

    void Current_Rocket() // Roket yukarý-aþaðý uçarken isFly false olmalý yoksa açýsý karýþabiliyor.
    {
        isFly = false; ;
    }

    public void Controller() // Roket touch ve mouse ile kontrolleri
    {
        #region pc controller
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isCanFly)
            {
                incline = !incline;
            }
        }
        #endregion
        #region phone controller
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.phase == TouchPhase.Ended)
            {
                if (isCanFly)
                {
                    incline = !incline;
                    Handheld.Vibrate();
                }
            }
        }
        #endregion
    }

    public void LoseGame() // Roket patlama efekti ve restart paneli açma
    {
        level_Manager = FindObjectOfType<LevelManag>();
        temp_Explosion = Instantiate(explosion_Effect, new Vector3(transform.position.x, 1.5f, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        level_Manager.restart_Panel.SetActive(true);
    }
}
