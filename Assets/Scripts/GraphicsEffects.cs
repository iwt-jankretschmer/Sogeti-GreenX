using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class GraphicsEffects
    {
        /// <summary>
        /// Tint graphic elements with a certain color
        /// </summary>
        /// <param name="graphics">Graphic elements you wanna tint</param>
        /// <param name="colorToTintIn">Color you want to tint the graphics elements with</param>
        /// <param name="includeTransparency">Does the methode shoud take in count transparency</param>
        public static void TintGraphics(IEnumerable<SpriteRenderer> graphics, Color colorToTintIn, bool includeTransparency = false)
        {
            float alpha = colorToTintIn.a;
            foreach (var graphic in graphics)
            {
                colorToTintIn.a = includeTransparency ? alpha : graphic.color.a;
                graphic.color = colorToTintIn;
            }
        }

        
        /// <summary>
        /// Apply a certain amount of transparency to graphic elements
        /// </summary>
        /// <param name="graphics">Graphic elements you wanna apply a transparency to</param>
        /// <param name="Transparency">the amount of transparency you want to apply (1 by default)</param>
        public static void ApplyTransparencyToGraphics(IEnumerable<SpriteRenderer> graphics, float Transparency = 1)
        {
            foreach (var graphic in graphics)
            {
                Color newColor = graphic.color;
                newColor.a = Transparency;
                graphic.color = newColor;
            }
        }

    }
