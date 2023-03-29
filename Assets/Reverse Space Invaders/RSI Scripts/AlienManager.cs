using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public AnimationHandler[] prefabs;
    public int rows = 3;
    public int columns = 9;
    //public float speed = 0f;

    //private Vector3 _direction = Vector2.right;

    private void Awake()
    {
        for(int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            
            for(int col = 0; col < this.columns; col++)
            {
                AnimationHandler Aliens = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                Aliens.transform.localPosition = position;
            }
        }
    }
}
