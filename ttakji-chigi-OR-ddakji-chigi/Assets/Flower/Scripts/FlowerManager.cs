using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlowerManager : MonoBehaviour
{
    public bool is_front;
    bool on_game;
    int fire_state;

    GameObject player;
    GameObject fail;
    GameObject face_;
    GameObject go;
    GameObject stop;
    SpriteRenderer face;
    SpriteRenderer fire;
    //Sprite[] fire = new Sprite[2];

    Coroutine flip_face;

    void Awake()
    {
        is_front = false;
        on_game = true;
        fire_state = 0;

        player = GameObject.Find("Player");
        fail = GameObject.Find("Canvas").transform.Find("Fail").gameObject;
        face_ = GameObject.Find("Monster").transform.Find("Face").gameObject;
        go = GameObject.Find("Lights").transform.Find("Go").gameObject;
        stop = GameObject.Find("Lights").transform.Find("Stop").gameObject;
        face = GameObject.Find("Monster").transform.Find("Face").GetComponent<SpriteRenderer>();
        fire = GameObject.Find("Monster").transform.Find("Fire").GetComponent<SpriteRenderer>();

        //fire[0] = Resources.Load("Flower/Fire0") as Texture;
        //fire[1] = Resources.Load("Flower/Fire1") as Texture;
    }

    void Start()
    {
        StartCoroutine(FireEffect());
        flip_face = StartCoroutine(FlipFace());
    }

    void Update()
    {
        if (is_front == true && player.GetComponent<Up>().is_walking == true)
        {
            player.transform.localScale = new Vector2(0.3f, 0.3f);
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<Up>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Flower/Death");
            StopFlipFace();
            fail.SetActive(true);
        }
    }

    IEnumerator FlipFace()
    {
        float time_to_flip;

        while (true)
        {
            time_to_flip = Random.Range(2f, 10f);

            if (is_front == true)
            {
                yield return new WaitForSeconds(time_to_flip);
                go.SetActive(true);
                stop.SetActive(false);
                face.sprite = Resources.Load<Sprite>("Flower/BackFace");
                face_.transform.localScale = new Vector2(0.35f, 0.35f);
            }
            else
            {
                yield return new WaitForSeconds(time_to_flip - 1f);
                go.SetActive(false);
                stop.SetActive(true);
                yield return new WaitForSeconds(1f);
                face.sprite = Resources.Load<Sprite>("Flower/FrontFace");
                face_.transform.localScale = new Vector2(0.5f, 0.5f);
            }

            is_front = !is_front;
        }
    }

    IEnumerator FireEffect()
    {
        while (true)
        {
            if (fire_state == 0)
            {
                //sprite.sprite = Resources.Load<Sprite>("Flower/Fire0"); 이건 되는데
                //sprite.sprite = Resources.Load("Flower/Fire1") as Sprite; 이건 안 됨
                fire.sprite = Resources.Load<Sprite>("Flower/Fire0");
                fire_state = 1;
            }
            else
            {
                fire.sprite = Resources.Load<Sprite>("Flower/Fire1");
                fire_state = 0;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void StopFlipFace()
    {
        StopCoroutine(flip_face);
    }
}