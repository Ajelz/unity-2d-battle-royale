using Assets.HeroEditor.Common.EditorScripts;
using Assets.HeroEditor.Common.Enums;
using HeroEditor.Common;
using HeroEditor.Common.Enums;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class userHeadPanel : MonoBehaviour
{
    [SerializeField] HeadPanel myHeadPanel;
    public SpriteRenderer mySpriteRenderer;
    public Sprite mySprites;
    SpriteRenderer[] mySpriteRenderers;
    Sprite head, eyes, beard, mouth, eyebrows, hair, ears, earrings, mask, glasses, helmet;
    Color headcolor, eyescolor, beardcolor, mouthcolor, eyebrowscolor, haircolor, earscolor, earringscolor, maskcolor, glassescolor, helmetcolor;
    void Start()
    {
        mySpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        SetNames();
        TriggerHeadPanel();
    }

    private void SetNames()
    {
        for (int i = 0; i < mySpriteRenderers.Length; i++)
        {
            if (mySpriteRenderers[i].name == "Head")
            {
                head = mySpriteRenderers[i].sprite;
                headcolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Eyes")
            {
                eyes = mySpriteRenderers[i].sprite;
                eyescolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Beard")
            {
                beard = mySpriteRenderers[i].sprite;
                beardcolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Mouth")
            {
                mouth = mySpriteRenderers[i].sprite;
                mouthcolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Eyebrows")
            {
                eyebrows = mySpriteRenderers[i].sprite;
                eyebrowscolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Hair")
            {
                hair = mySpriteRenderers[i].sprite;
                haircolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Ears")
            {
                ears = mySpriteRenderers[i].sprite;
                earscolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Earrings")
            {
                earrings = mySpriteRenderers[i].sprite;
                earringscolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Mask")
            {
                mask = mySpriteRenderers[i].sprite;
                maskcolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Glasses")
            {
                glasses = mySpriteRenderers[i].sprite;
                glassescolor = mySpriteRenderers[i].color;
            }
            if (mySpriteRenderers[i].name == "Helmet")
            {
                helmet = mySpriteRenderers[i].sprite;
                helmetcolor = mySpriteRenderers[i].color;
            }
        }
    }

    public void TriggerHeadPanel()
    {
        myHeadPanel.ChangeHead(head, headcolor);
        myHeadPanel.ChangeEyes(eyes);
        myHeadPanel.ChangeBeard(beard, beardcolor);
        myHeadPanel.ChangeMouth(mouth, mouthcolor);
        myHeadPanel.ChangeEyebrows(eyebrows, eyebrowscolor);
        myHeadPanel.ChangeHair(hair, haircolor);
        myHeadPanel.ChangeEars(ears, earscolor);
        myHeadPanel.ChangeEarrings(earrings, earringscolor);
        myHeadPanel.ChangeMask(mask, maskcolor);
        myHeadPanel.ChangeGlasses(glasses, glassescolor);
        myHeadPanel.ChangeHelmet(helmet, helmetcolor);
    }
}
