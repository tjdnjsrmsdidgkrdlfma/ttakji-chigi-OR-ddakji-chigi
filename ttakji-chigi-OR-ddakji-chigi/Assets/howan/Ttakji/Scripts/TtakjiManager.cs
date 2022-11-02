using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TtakjiManager : MonoBehaviour
{
    GameObject ttakji0;
    GameObject ttakji1;
    GameObject gauge;
    GameObject blink;

    void Awake()
    {
        ttakji0 = GameObject.Find("Ttakji0");
        ttakji1 = GameObject.Find("Ttakji1");
        gauge = GameObject.Find("Gauge/Gauge");
        blink = GameObject.Find("Canvas").transform.Find("Blink").gameObject;
    }

    public void OnTtakjiMoveButtonClicked()
    {
        gauge.GetComponent<Gauge>().stop_gauge_moving = true;

        StartCoroutine("MoveTtakji");
    }

    IEnumerator MoveTtakji()
    {
        float ttakji0_y = ttakji0.transform.position.y;
        float temp;

        while (ttakji1.transform.position.y > ttakji0_y)
        {
            ttakji1.transform.position = new Vector3(ttakji1.transform.position.x, ttakji1.transform.position.y - 0.2f, ttakji1.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 50; i++)
        {
            temp = Mathf.Lerp(ttakji0.transform.position.y, 0, 0.05f);
            ttakji0.transform.position = new Vector3(ttakji0.transform.position.x, temp, ttakji0.transform.position.z);
            yield return null;
        }

        for (int i = 0; i < 15; i++)
        {
            ttakji0.transform.Rotate(new Vector3(0, 0, i * -7));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        blink.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        blink.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        FlipTtakji();

        while (ttakji0.transform.position.y > -3.3f)
        {
            ttakji0.transform.position = new Vector3(ttakji0.transform.position.x, ttakji0.transform.position.y - 0.2f, ttakji0.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(ShowEffect());
    }

    void FlipTtakji()
    {
        float gauge = this.gauge.GetComponent<Gauge>().gauge;

        ttakji0.GetComponent<SpriteRenderer>().sortingOrder = 3;

        if (gauge > 0.85f)
        {
            ttakji0.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ttakji/TtakjiBack0");// as Sprite; <- ÀÌ°Ç ¾È µÊ
            //Ttakji0.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/µüÁö µÚÁýÈù ½ºÇÁ¶óÀÌÆ®");// as Sprite;
        }
    }

    IEnumerator ShowEffect()
    {
        float gauge = this.gauge.GetComponent<Gauge>().gauge;

        GameObject effect = GameObject.Find("Ttakji0/Effect");

        if (gauge > 0.85f)
        {
            effect.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ttakji/Success");
        }
        else
        {
            effect.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ttakji/Fail");
        }

        for (int i = 0; i < 60; i++)
        {
            effect.transform.Rotate(new Vector3(0, 0, i * 5));
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }

        effect.GetComponent<SpriteRenderer>().sprite = null;
    }
}
