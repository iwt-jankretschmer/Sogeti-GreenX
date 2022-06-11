
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(CircleCollider2D))]
    public class TowerSpot : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D cirCollider;
        [SerializeField] private SpriteRenderer[] graphics;
        private Tower tower;
        public bool isOccupied => tower;

        private bool mouseIsHover
        {
            get
            {
                if (Camera.main is null) return false;
                
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                return Vector2.Distance(transform.position, mousePosition) < 0.5f;

            }
        }
        
        private void Update()
        {
            if(!tower)
            {
                if (Tower.TowerBeingPlaced)
                {
                    if(mouseIsHover) GetVisible();
                    else GraphicsEffects.ApplyTransparencyToGraphics(graphics,0.3f);
                }
                else GetVisible(false);
            }
        }

        private void OnValidate()
        {
            if (!cirCollider) TryGetComponent(out cirCollider);
            if (cirCollider) cirCollider.radius = 0.5f;
        }

        private void GetVisible(bool visible = true)
        {
            GraphicsEffects.ApplyTransparencyToGraphics(graphics, visible ? 0.8f : 0);
        }
        
        public void Occupy(Tower towerWhoOccupy)
        {
            tower = towerWhoOccupy;
        }
        

    }
