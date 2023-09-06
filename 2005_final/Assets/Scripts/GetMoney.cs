using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    bool DoOnce = true, SliderGo = false;
    public static bool IsRestartPressed = false;
    Slider _slider;
    int OtoDelete = 0;

    private void Start()
    {
        _slider = gameObject.transform.Find("Bar").GetComponent<Slider>();

        _slider.value = 0;
    }

    private void Update()
    {
        if (SliderGo && !IsRestartPressed)
        {
            _slider.value += Time.deltaTime * 20;
        }
        else
        {
            _slider.value = 0;
            SliderGo = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Finish") && DoOnce)
        {
            DoOnce = false;
            StartCoroutine(WaitAndPrint(collider2D));
        }
    }

    private IEnumerator WaitAndPrint(Collider2D collider2D)
    {
        SliderGo = true;
        IsRestartPressed = false;

        do
        {
            yield return new WaitForSeconds(5);

            if (!IsRestartPressed)
            {
                _slider.value = 0;

                if (collider2D == null)
                {
                    break;
                }

                if (collider2D.name == "Building_A")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card1[0], GoldAndGem.Card1[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card1[0], GoldAndGem.Card1[1]);
                }
                else if (collider2D.name == "Building_B")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card2[0], GoldAndGem.Card2[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card2[0], GoldAndGem.Card2[1]);
                }
                else if (collider2D.name == "Building_C")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card3[0], GoldAndGem.Card3[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card3[0], GoldAndGem.Card3[1]);
                }
                else if (collider2D.name == "Building_D")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card4[0], GoldAndGem.Card4[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card4[0], GoldAndGem.Card4[1]);
                }
                else if (collider2D.name == "Building_E")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card5[0], GoldAndGem.Card5[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card5[0], GoldAndGem.Card5[1]);
                }
                else if (collider2D.name == "Building_F")
                {
                    GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] + Random.Range(GoldAndGem.Card6[0], GoldAndGem.Card6[1]);
                    GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] + Random.Range(GoldAndGem.Card6[0], GoldAndGem.Card6[1]);
                }

                PlayerPrefs.SetInt("GoldInt", GoldAndGem.GoldAndGemInt[0]);
                PlayerPrefs.SetInt("GemInt", GoldAndGem.GoldAndGemInt[1]);

                OtoDelete++;
                if (OtoDelete >= 3)
                {
                    PlayerPrefs.DeleteKey(gameObject.name);
                    Destroy(collider2D.gameObject);
                    SliderGo = false;
                    DoOnce = true;
                    _slider.value = 0;
                    OtoDelete = 0;
                }
            }
            
        } while (!DoOnce && !IsRestartPressed);
    }
}
