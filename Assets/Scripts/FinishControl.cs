using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishControl : MonoBehaviour
{
    [Header("Variables")]
    public bool isFinished = false;
    public GameObject particle_Effect;
    public GameObject temp_Effect;
    public GameObject temp_Effect2;
    public GameObject temp_Effect3;

    [Header("Scripts")]
    LevelManag level_Manager;
    RocketFlight rocket_Flight;

    [Header("Cameras")]
    public Camera finish_Camera;

    private void OnTriggerExit(Collider other) // Finish'den sonra olmasý gerekenler
    {
        level_Manager = FindObjectOfType<LevelManag>();
        rocket_Flight = FindObjectOfType<RocketFlight>();

        

        if (other.gameObject.CompareTag("Player"))
        {
            isFinished = true;
            rocket_Flight.speed = 2f;

            Destroy(other.gameObject, 1f);
            temp_Effect = Instantiate(particle_Effect, new Vector3(Camera.main.transform.position.x + 30, 1.30f, Camera.main.transform.position.z - 10), Quaternion.identity);
            temp_Effect2 = Instantiate(particle_Effect, new Vector3(Camera.main.transform.position.x + 60, 1.30f, Camera.main.transform.position.z - 10), Quaternion.identity);
            temp_Effect3 = Instantiate(particle_Effect, new Vector3(Camera.main.transform.position.x + 10, 1.30f, Camera.main.transform.position.z - 10), Quaternion.identity);
            Destroy(temp_Effect, 4f);
            Destroy(temp_Effect2, 4f);
            Destroy(temp_Effect3, 4f);

            level_Manager.next_Panel.SetActive(true);
            cameraFollow.Instance.Look_Finish();
        }
    }
}
