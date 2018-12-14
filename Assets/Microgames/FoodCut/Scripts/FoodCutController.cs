﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCutController : MonoBehaviour {

    [Header("How fast the knife moves")]
    [SerializeField]
    private float speed = 1f;

    [Header("Minimum x position the knife can reach")]
    [SerializeField]
    private float minX = -5f;

    [Header("Maximum x position the knife can reach")]
    [SerializeField]
    private float maxX = 5f;

    [Header("Number of cuts needed")]
    [SerializeField]
    private int cutsNeeded = 1;

    [Header("Put distance of each mask from center here:")]
    [SerializeField]
    private float[] distance;

    private Collider2D knifeCollider;
    private int cutCount = 0;
    private Collider2D currentTrigger = null;
    public bool isCutting = false;
    public GameObject knifeChild;
    public GameObject xChild;
    public GameObject[] masks;


    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Knife will stop moving while animations are playing
        if (knifeChild.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FoodCutKnife")
            || xChild.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FoodCutX"))
        {
        }
        else
        {
            isCutting = false;
        }

        // Handle Movement
        if (!isCutting)
        {
            transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0f, 0f);
        }

        // Restrict Movement
        if (transform.position.x <= minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        else if (transform.position.x >= maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }

        // Checks to see if there is a dotted line to cut
        if (Input.GetKeyDown(KeyCode.Space) && currentTrigger != null)
        {
            isCutting = true;
            knifeChild.GetComponent<Animator>().Play("FoodCutKnife");

            for (int i = 0; i < masks.Length; i++)
            {
                masks[i].transform.position = new Vector2((xChild.transform.position.x + distance[i]), transform.position.y);
            }

            cutCount++;
            Debug.Log("Object Cut");
            Destroy(currentTrigger.gameObject);
            currentTrigger = null;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isCutting == false)
        {
            isCutting = true;
            xChild.GetComponent<Animator>().Play("FoodCutX");
        }

        // Player wins if they cut the proper amount of lines
        if (cutCount == cutsNeeded)
            MicrogameController.instance.setVictory(victory: true, final: true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentTrigger = other;
        Debug.Log(currentTrigger);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        currentTrigger = other;
        Debug.Log(currentTrigger);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentTrigger = null;
        Debug.Log(currentTrigger);
    }
}
