using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoSummary : MonoBehaviour {

    public void OnClick() {
        SceneManager.LoadScene("Weekly Summary");
    }


}
