using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;
    public GameObject panel11;
    public GameObject panel12;
    public GameObject panel13;
    public GameObject panel14;
    public GameObject panel15;
    public GameObject panel16;
    public GameObject panel17;
    public GameObject panel18;
    public GameObject panel19;
    public GameObject panel20;
    public int counter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter++;
        }

        if (counter == 1)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);

        }
        if (counter == 2)
        {
            panel2.SetActive(false);
            panel3.SetActive(true);

        }
        if (counter == 3)
        {
            panel3.SetActive(false);
            panel4.SetActive(true);

        }
        if (counter == 4)
        {
            panel4.SetActive(false);
            panel5.SetActive(true);

        }
        if (counter == 5)
        {
            panel5.SetActive(false);
            panel6.SetActive(true);

        }
        if (counter == 6)
        {
            panel6.SetActive(false);
            panel7.SetActive(true);

        }
        if (counter == 7)
        {
            panel7.SetActive(false);
            panel8.SetActive(true);

        }
        if (counter == 8)
        {
            panel8.SetActive(false);
            panel9.SetActive(true);

        }
        if (counter == 9)
        {
            panel9.SetActive(false);
            panel10.SetActive(true);

        }
        if (counter == 10)
        {
            panel10.SetActive(false);
            panel11.SetActive(true);

        }
        if (counter == 11)
        {
            panel11.SetActive(false);
            panel12.SetActive(true);

        }
        if (counter == 12)
        {
            panel12.SetActive(false);
            panel13.SetActive(true);

        }
        if (counter == 13)
        {
            panel13.SetActive(false);
            panel14.SetActive(true);

        }
        if (counter == 14)
        {
            panel14.SetActive(false);
            panel15.SetActive(true);

        }
        if (counter == 15)
        {
            panel15.SetActive(false);
            panel16.SetActive(true);

        }
        if (counter == 16)
        {
            panel16.SetActive(false);
            panel17.SetActive(true);

        }
        if (counter == 17)
        {
            panel17.SetActive(false);
            panel18.SetActive(true);

        }
        if (counter == 18)
        {
            panel18.SetActive(false);
            panel19.SetActive(true);

        }
        if (counter == 19)
        {
            panel19.SetActive(false);
            panel20.SetActive(true);

        }

        if(counter==20)
        {
            SceneManager.LoadScene("SetUp");
        }


    }
}
