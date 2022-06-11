using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerSpot spot;
    private bool isPlaceed => spot;

    [SerializeField] private SpriteRenderer[] graphics;

    private static Tower towerBeingPlaced;

    public static Tower TowerBeingPlaced => towerBeingPlaced;

    // Start is called before the first frame update
    void Start()
    {
        if (towerBeingPlaced) Destroy(towerBeingPlaced.gameObject);
        if (!isPlaceed) towerBeingPlaced = this;
        if (spot) PlaceTower(spot);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isPlaceed)
        {
            BeingPlacedRoutine();
        }
        else
        {
            TowerRoutine();
        }
    }

    private void PlaceTower(TowerSpot spotToPlaceTO)
    {
        transform.position = spotToPlaceTO.transform.position;
        spot = spotToPlaceTO;
        if(towerBeingPlaced == this) towerBeingPlaced = null;
    }

     
    
    /// <summary>
    /// The routine while the tower is not placed on a spot yet
    /// </summary>
    private void BeingPlacedRoutine()
    {
        FolowMouse();
        GraphicsEffects.ApplyTransparencyToGraphics(graphics, 0.5f);

        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.Escape))
        {
            Destroy(gameObject);
        }

        if (DetectHoveringTowerSpot(out TowerSpot hoveringSpot) && Input.GetMouseButtonUp(0))
        {
            PlaceTower(hoveringSpot);
        }
    }

    private void FolowMouse()
    {
        if (Camera.main is not null) transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool DetectHoveringTowerSpot(out TowerSpot _spot)
    {
        LayerMask maskTowerSpot = LayerMask.GetMask("TowerSpot");
        if (Camera.main is not null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D spotCollider = Physics2D.OverlapCircle(mousePosition, 0.001f, maskTowerSpot);
            
            if (spotCollider && spotCollider.TryGetComponent(out  _spot))
            {
                return true;
            }
        }

        _spot = null;
        return false;
    }
    
    /// <summary>
    /// The routine once the tower is placed on a spot
    /// </summary>
    protected virtual void TowerRoutine()
    {
        
    }
}
