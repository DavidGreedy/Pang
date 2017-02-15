using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class LineController : Singleton<LineController>
{
    [SerializeField]
    private Color[] colors;

    public enum ColorScheme
    {
        Player, Level, Opponent, Ball
    }

    [SerializeField]
    private Color m_lineColor;

    [SerializeField]
    private float m_lineWidth;

    [SerializeField, Range(0, 1)]
    private float m_glowFactor;

    [SerializeField]
    private float glowSpeed;

    private void Awake()
    {
        base.Awake();
        colors = new Color[4];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    private void Start()
    {
        Invoke("t", 0f);
    }

    private void t()
    {
        StartCoroutine(Pulse(10));
        foreach (VolumetricLineBehavior line in VolumetricLineBehavior.lines)
        {
            line.LineColor = m_lineColor;
            line.LineWidth = m_lineWidth;
            line.GlowFactor = m_glowFactor;
        }
    }

    void Update()
    {
        foreach (VolumetricLineBehavior line in VolumetricLineBehavior.lines)
        {
            line.LineColor = m_lineColor;
            line.LineWidth = m_lineWidth;
            line.GlowFactor = m_glowFactor;
        }
    }

    public IEnumerator Pulse(float t)
    {
        while (true)
        {
            foreach (VolumetricLineBehavior line in VolumetricLineBehavior.lines)
            {
                //line.GlowFactor = Mathf.Lerp();
            }
            yield return new WaitForSeconds(t);
            break;
        }
        yield break;
    }

    public Color GetColor(ColorScheme colorScheme)
    {
        return colors[(int)colorScheme];
    }
}