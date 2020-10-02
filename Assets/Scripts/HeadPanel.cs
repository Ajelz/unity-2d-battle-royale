using System;
using System.Collections.Generic;
using System.Linq;
using Assets.HeroEditor.Common.CommonScripts.Springs;
using Assets.HeroEditor.Common.Data;
using Assets.HeroEditor.Common.EditorScripts;
using Assets.HeroEditor.Common.Enums;
using HeroEditor.Common;
using HeroEditor.Common.Enums;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HeadPanel : MonoBehaviour
{
    SpriteRenderer[] newSpriteRenderers;
    void Start()
    {
        newSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void ChangeHead(Sprite head, Color spriteColor)
    {
        newSpriteRenderers[1].sprite = head;
        newSpriteRenderers[1].color = spriteColor;
    }
    public void ChangeEyes(Sprite eyes)
    {
        newSpriteRenderers[2].sprite = eyes;
    }
    public void ChangeBeard(Sprite beard, Color spriteColor)
    {
        newSpriteRenderers[3].sprite = beard;
        newSpriteRenderers[3].color = spriteColor;
    }
    public void ChangeMouth(Sprite mouth, Color spriteColor)
    {
        newSpriteRenderers[4].sprite = mouth;
        newSpriteRenderers[4].color = spriteColor;
    }
    public void ChangeEyebrows(Sprite eyebrows, Color spriteColor)
    {
        newSpriteRenderers[5].sprite = eyebrows;
        newSpriteRenderers[5].color = spriteColor;
    }
    public void ChangeHair(Sprite hair, Color spriteColor)
    {
        newSpriteRenderers[6].sprite = hair;
        newSpriteRenderers[6].color = spriteColor;
    }
    public void ChangeEars(Sprite ears, Color spriteColor)
    {
        newSpriteRenderers[7].sprite = ears;
        newSpriteRenderers[7].color = spriteColor;
    }
    public void ChangeEarrings(Sprite earrings, Color spriteColor)
    {
        newSpriteRenderers[8].sprite = earrings;
        newSpriteRenderers[8].color = spriteColor;
    }
    public void ChangeMask(Sprite mask, Color spriteColor)
    {
        newSpriteRenderers[9].sprite = mask;
        newSpriteRenderers[9].color = spriteColor;
    }
    public void ChangeGlasses(Sprite glasses, Color spriteColor)
    {
        newSpriteRenderers[10].sprite = glasses;
        newSpriteRenderers[10].color = spriteColor;
    }
    public void ChangeHelmet(Sprite helmet, Color spriteColor)
    {
        newSpriteRenderers[11].sprite = helmet;
        newSpriteRenderers[11].color = spriteColor;
    }

}
