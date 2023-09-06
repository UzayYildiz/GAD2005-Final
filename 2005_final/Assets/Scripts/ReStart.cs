using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void ReStartFonck()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Finish");

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj.gameObject);
        }

        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs DeleteAll");
        PlayerPrefs.SetInt("GoldInt", 5);
        PlayerPrefs.SetInt("GemInt", 8);
        GoldAndGem.GoldAndGemInt[0] = PlayerPrefs.GetInt("GoldInt");
        GoldAndGem.GoldAndGemInt[1] = PlayerPrefs.GetInt("GemInt");
        GetMoney.IsRestartPressed = true;
    }
}
     