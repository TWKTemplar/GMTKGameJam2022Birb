using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Loads all assets in the "Resources/Textures" folder
// Then picks a random one from the list.
// Note: Random.Range in this case returns [low,high]
// range, i.e. the high value is not included in the range.
public class DiceArt : MonoBehaviour
{
    public Renderer rend1;
    public Renderer rendOutline;
    public Color colorBase;
    public Color colorTop;
    public float DimAmount = 0.5f;
    public Color DimColor;
    private Object[] textures;

    void Start()
    {
        AssignNewTexture();
    }
    public void SetColorKickable()
    {          
        rend1.materials[0].color = colorBase;
        rend1.materials[0].SetColor("_EmissionColor", colorBase);
        rend1.materials[1].color = colorTop;
        rend1.materials[1].SetColor("_EmissionColor", colorTop);
        rendOutline.materials[0].color = colorTop;
        rendOutline.materials[0].SetColor("_EmissionColor", colorTop);
    }
    public void SetColorNOTKickable()
    {
        rend1.materials[0].color = Color.Lerp(colorBase, DimColor, 0.5f);
        rend1.materials[0].SetColor("_EmissionColor", Color.Lerp(colorBase, DimColor, 0.5f));
        rend1.materials[1].color = Color.Lerp(colorTop, DimColor, 0.5f);
        rend1.materials[1].SetColor("_EmissionColor", Color.Lerp(colorTop, DimColor, 0.5f));
    }
    [ContextMenu("AssignNewTexture")]
    public void AssignNewTexture()
    {
        colorTop = new Color(Random.Range(0.5f, 0.99f), Random.Range(0.5f, 0.99f), Random.Range(0.5f, 0.99f));
        colorBase = new Color(Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f), Random.Range(0.01f, 0.5f));
        textures = Resources.LoadAll("Textures", typeof(Texture2D));
        Texture2D texture = (Texture2D)textures[Random.Range(0, textures.Length)];
        rend1.materials[0].color = colorBase;
        rend1.materials[0].SetColor("_EmissionColor", colorBase);
        rend1.materials[1].mainTexture = texture;
        rend1.materials[1].SetColor("_EmissionColor", colorTop);
        rend1.materials[1].color = colorTop;
    }

}
