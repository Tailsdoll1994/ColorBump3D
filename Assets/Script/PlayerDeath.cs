using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Всего есть два способа умереть.
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        DeadZone_Abyss();
    }
    // 1. Когда шарик падает с дороги.
    private void DeadZone_Abyss()
    {
        if (player.transform.position.y < -10)
        {
            SceneManager.LoadScene("Level");
        }
    }
    // 2. Когда шарик сталкивается с барьером другого цвета
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" ||
            collision.gameObject.tag == "Cube" ||
            collision.gameObject.tag == "Sphere" ||
            collision.gameObject.tag == "Cylinder")
        {
            if (!collision.transform.GetComponent<Renderer>().material.color.Equals(player.transform.GetComponent<Renderer>().material.color))
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}
