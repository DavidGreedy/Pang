using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]
    private Slider diffSlider, scoreSlider;

    [SerializeField]
    private Text diffText, scoreText;

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateText(Text text) // FIXME: This is retarded
    {
        if (text == scoreText)
        {
            scoreText.text = scoreSlider.value.ToString();
            Gameplay.Instance.targetScore = (int)scoreSlider.value;
        }
        if (text == diffText)
        {
            diffText.text = diffSlider.value.ToString();
            Gameplay.Instance.difficulty = (int)diffSlider.value;
        }
    }

    public void InvokeRecenter()
    {
        Invoke("RecenterView", 3f);
    }

    void RecenterView()
    {
        GvrViewer.Instance.Recenter();
    }
}