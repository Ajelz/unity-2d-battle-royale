﻿using UnityEngine;

namespace Assets.HeroEditor.Common.CharacterScripts
{
    /// <summary>
    /// Makes character to look at cursor side (flip by X scale).
    /// </summary>
    public class CharacterFlip : MonoBehaviour
    {
        TestBar myTestBar;
        bool isAlive;
        bool isFacingRight;
        Transform myTransform;
        public void Start()
        {
            myTransform = GetComponent<Transform>();
            isAlive = true;
            myTestBar = GetComponent<TestBar>();
        }

        public bool Direction()
        {
            isFacingRight = true;
            if (myTransform.localScale.x >= 0)
            {
                isFacingRight = true;
            }
            else
            {
                isFacingRight = false;
            }
            return isFacingRight;
        }

        public void Update()
        {
            bool isAlive = myTestBar.LifeStatus();
            if (isAlive)
            {
                var scale = transform.localScale;

                scale.x = Mathf.Abs(scale.x);

                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
                {
                    scale.x *= -1;
                }

                transform.localScale = scale;
            }
        }
    }
}