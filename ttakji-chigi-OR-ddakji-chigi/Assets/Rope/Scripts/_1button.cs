using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class _1button : MonoBehaviour
{
    public int ti = 0, round = 0,reti=30;
    public bool moveup = false;
    public bool movedown = false;
    public GUIStyle Guis;
    GameObject rw;
    GameObject Libbon;
    GameObject head;
    GameObject head1;
    GameObject ghead;
    GameObject ghead1;
    GameObject sound;
    GameObject sd;
    GameObject wistle;
    GameObject bs;
    GameObject success;
    GameObject restart;
    GameObject main;
    Coroutine temptemp;
    AudioSource temptemptemp;
    public GameObject[] Gn;
    int touch1 = 0, touch2 = 0, checkGame = 0;
    int p1score = 0, p2score = 4;
    bool temp = false;

    public void _1pattack()
    {
        rw.transform.position = new Vector3(rw.transform.position.x, rw.transform.position.y - 10, rw.transform.position.z);
        Libbon.transform.position = new Vector3(Libbon.transform.position.x, Libbon.transform.position.y - 10, Libbon.transform.position.z);
        touch1++;
    }

    public void _2pattack()
    {
        rw.transform.position = new Vector3(rw.transform.position.x, rw.transform.position.y + 10, rw.transform.position.z);
        Libbon.transform.position = new Vector3(Libbon.transform.position.x, Libbon.transform.position.y + 10, Libbon.transform.position.z);
        touch2++;
    }

    void Start()
    {
        temptemp = StartCoroutine(time());

        rw = GameObject.Find("row1/row");
        Libbon = GameObject.Find("libbon");
        sound = GameObject.Find("sound");
        head = GameObject.Find("호완/greens");
        head1 = GameObject.Find("호완/greenin");
        ghead = GameObject.Find("성인/inan");
        ghead1 = GameObject.Find("성인/smiley");
        sd = GameObject.Find("p2 sound");
        wistle = GameObject.Find("Wistle");
        bs = GameObject.Find("bksound");
        success = GameObject.Find("Canvas").transform.Find("Success").gameObject;
        restart = GameObject.Find("Canvas").transform.Find("Restart").gameObject;
        main = GameObject.Find("Canvas").transform.Find("Main").gameObject;
        temptemptemp = GameObject.Find("TempTempTemp").GetComponent<AudioSource>();
    }

    IEnumerator time()
    {
        while (round <= 3)
        {
            yield return new WaitForSeconds(1.0f);
            ti++;
            if (ti == 31)
                break;
        }
    }

    private void OnGUI()
    {
        reti = 30 - ti;
        GUI.Label(new Rect(0, 1100, 100, 100), reti.ToString(), Guis);
        if (round == 3 && temp == false)
        {
            temp = true;
            StartCoroutine(OnEndGame());
        }
    }

    [Obsolete]
    void Update()
    {
        if (checkGame == 0)
        {
            if (ti == 30)
            {
                for (int i = 0; i < 8; i++)
                    Gn[i].active = false;
                if (round == 3)
                    checkGame = 1;
                else if (touch1 >= touch2)
                    p1score++;
                else if (touch1 < touch2)
                    p2score++;

                Gn[p1score].active = true;
                Gn[p2score].active = true;
                Libbon.transform.position = new Vector3((float)528, (float)1234, (float)0);
                round++;
                ti = 0;
                touch1 = 0;
                touch2 = 0;

                wistle.GetComponent<AudioSource>().Play();
            }

            if (touch1 == touch2)
            {
                sound.gameObject.SetActive(false);
                head1.gameObject.SetActive(false);
                head.gameObject.SetActive(true);
                ghead1.gameObject.SetActive(true);
                ghead.gameObject.SetActive(false);
                sd.gameObject.SetActive(false);
            }
            else if (touch1 > touch2)
            {
                for (int i = 0; i <= 2; i++)
                    sound.gameObject.SetActive(true);
                head.gameObject.SetActive(true);
                head1.gameObject.SetActive(false);
                ghead.gameObject.SetActive(true);
                ghead1.gameObject.SetActive(false);

            }
            else if (touch1 < touch2)
            {
                for (int i = 0; i <= 2; i++)
                    sd.gameObject.SetActive(true);
                head.gameObject.SetActive(false);
                head1.gameObject.SetActive(true);
                ghead.gameObject.SetActive(false);
                ghead1.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator OnEndGame()
    {
        bs.SetActive(false);
        sound.SetActive(false);
        wistle.SetActive(false);
        StopCoroutine(temptemp);

        success.SetActive(true);
        temptemptemp.PlayOneShot(Resources.Load("SuccessSound") as AudioClip);

        yield return new WaitForSeconds(0.5f);

        restart.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        main.SetActive(true);
    }
}