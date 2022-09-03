using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManag : MonoBehaviour
{
    [Header("Gameobjects")]
    public GameObject[] levels;
    public GameObject start_Panel;
    public GameObject restart_Panel;
    public GameObject next_Panel;
    GameObject temp_Level;

    [Header("Others")]
    int level_Index = 0;
    public RocketFlight rocket_Script;
    public FinishControl finish_Script;
    public Text level_Text;
    int level_Count = 1;


    void Start()
    {
        temp_Level = Instantiate(levels[level_Index], transform.position, transform.rotation);
        rocket_Script = FindObjectOfType<RocketFlight>();
        rocket_Script.speed = 0f;
        level_Text.text = "Level " + level_Count;
    }

    public void Start_Level()
    {
        start_Panel.SetActive(false);
        rocket_Script.isCanFly = true;
        rocket_Script.speed = 30f;
    }

    public void Next_Level()
    {
        next_Panel.SetActive(false);
        Destroy(temp_Level);
        
        level_Index++;
        temp_Level = Instantiate(levels[level_Index], transform.position, transform.rotation);

        level_Count++;
        level_Text.text = "Level " + level_Count;

        rocket_Script = FindObjectOfType<RocketFlight>();
        rocket_Script.isCanFly = true;
        rocket_Script.speed = 30f;

        if (level_Index >= levels.Length - 1)
        {
            level_Index = 0;
        }
    }

    public void Restart_Level()
    {
        restart_Panel.SetActive(false);
        Destroy(rocket_Script.temp_Explosion);
        Destroy(temp_Level);

        temp_Level = Instantiate(levels[level_Index], transform.position, transform.rotation);
        rocket_Script.speed = 0f;

        rocket_Script = FindObjectOfType<RocketFlight>();
        rocket_Script.isCanFly = true;
        rocket_Script.speed = 30f;
    }
}
