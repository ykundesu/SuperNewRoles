using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SuperNewRoles.CustomObject
{
    public class Kunai
    {
        public SpriteRenderer image;
        public GameObject kunai;

        private static Sprite sprite;
        public static Sprite getSprite()
        {
            if (sprite) return sprite;
            sprite = ModHelpers.loadSpriteFromResources("SuperNewRoles.Resources.KunoichiKunai.png", 200f);
            return sprite;
        }

        public Kunai()
        {
            kunai = new GameObject("Kunai")
            {
                layer = 5
            };
            image = kunai.AddComponent<SpriteRenderer>();
            image.sprite = getSprite();
        }
    }
}
