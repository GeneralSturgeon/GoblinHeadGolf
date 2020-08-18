﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{ 
    public GameObject player;
    public GameObject head;

    public int currentClub;
    public Image[] UIimages;

    public Color selected;
    public Color normal;

    public TextMeshProUGUI pointsText;
    public int points = 0;


    // Start is called before the first frame update
    void Start()
    {
        UpdateUIImages();
        Instantiate(head, FindObjectOfType<Player>().headSpawn, Quaternion.Euler(0f, 0f, 270f));
        pointsText.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && FindObjectOfType<Player>().GetComponent<Player>().swingFinished)
        {
            var pos = FindObjectOfType<Player>().transform.position;
            Destroy(FindObjectOfType<Player>().gameObject);
            var playerObj = Instantiate(player, pos, Quaternion.identity);
            Instantiate(head, playerObj.GetComponent<Player>().headSpawn, Quaternion.Euler(0f, 0f, 270f));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentClub = 0;
            FindObjectOfType<Sword>().SetClubType();
            UpdateUIImages();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentClub = 1;
            FindObjectOfType<Sword>().SetClubType();
            UpdateUIImages();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentClub = 2;
            FindObjectOfType<Sword>().SetClubType();
            UpdateUIImages();
        }
    }

    private void UpdateUIImages()
    {
        foreach (Image im in UIimages)
        {
            im.color = normal;
        }
        UIimages[currentClub].color = selected;

    }

    public void Score()
    {
        points++;
        pointsText.text = points.ToString();
    }

    public void Win()
    {
        Debug.LogWarning("Yeah!");
        Time.timeScale = 0f;
    }
}
