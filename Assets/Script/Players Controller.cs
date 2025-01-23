using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    [SerializeField] Transform [] charactersTab;
    [SerializeField] bool isMoving = false;
    private Transform activePlayer;
    public Color initialColor = Color.white;
    public Color activeColor = Color.red;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if ( isMoving ==false)
        {
            MovingPlayer();
        }
      
    }

    void MovingPlayer()
    {
        activePlayer = charactersTab[Random.Range(0, charactersTab.Length)];
        Renderer activeRedPlayer = activePlayer.GetComponent<Renderer>();
        activeRedPlayer.material.color = activeColor;
        isMoving = true;

    }

    void stopMoving()
    {
        Renderer activeRedPlayer = activePlayer.GetComponent<Renderer>();
        activeRedPlayer.material.color = initialColor;
    }
}
