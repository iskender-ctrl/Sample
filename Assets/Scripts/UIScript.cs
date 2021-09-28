using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void OnClickRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
