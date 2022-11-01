using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TtakjiManager : MonoBehaviour
{
    GameObject Ttakji0;
    GameObject Ttakji1;
    GameObject Gauge;

    void Awake()
    {
        Ttakji0 = GameObject.Find("Ttakji0");
        Ttakji1 = GameObject.Find("Ttakji1");
        Gauge = GameObject.Find("Gauge/Gauge");
    }

    public void OnTtakjiMoveButtonClicked()
    {
        Gauge.GetComponent<Gauge>().stop_gauge_moving = true;

        StartCoroutine("MoveTtakji");
    }

    IEnumerator MoveTtakji()
    {
        float ttakji0_y = Ttakji0.transform.position.y;
        float temp;

        while (Ttakji1.transform.position.y > ttakji0_y)
        {
            Ttakji1.transform.position = new Vector3(Ttakji1.transform.position.x, Ttakji1.transform.position.y - 0.2f, Ttakji1.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 50; i++)
        {
            temp = Mathf.Lerp(Ttakji0.transform.position.y, 0, 0.05f);
            Ttakji0.transform.position = new Vector3(Ttakji0.transform.position.x, temp, Ttakji0.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        while (Ttakji0.transform.position.y > -3.3f)
        {
            Ttakji0.transform.position = new Vector3(Ttakji0.transform.position.x, Ttakji0.transform.position.y - 0.2f, Ttakji0.transform.position.z);
            yield return null;
        }

        FlipTtakji();
    }

    void FlipTtakji()
    {
        float gauge = Gauge.GetComponent<Gauge>().gauge;

        Ttakji0.GetComponent<SpriteRenderer>().sortingOrder = 3;

        if (gauge > 0.9f)
        {
            Ttakji0.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ttakji/Ttakji1");// as Sprite; <- ÀÌ°Ç ¾È µÊ
            //Ttakji0.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/µüÁö µÚÁýÈù ½ºÇÁ¶óÀÌÆ®");// as Sprite;
        }
    }


}
