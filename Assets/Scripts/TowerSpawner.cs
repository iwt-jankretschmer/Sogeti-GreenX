
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerSpawner : MonoBehaviour
{
        [SerializeField] private Button button;
        [SerializeField] private Tower baseTower;

        private void OnValidate()
        {
                if (!button) TryGetComponent(out button);
                
        }

        private void Start()
        {
                if (button)
                { 
                        button.onClick.AddListener(SpawnTower);
                }
        }

        private void SpawnTower()
        {
                if (Camera.main is not null)
                {
                        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        if (Instantiate(baseTower.gameObject, spawnPosition, new Quaternion()).TryGetComponent(out Tower newTower))
                        {
                                        
                        }
                }
        }
}