using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


       
        /*void FixedUpdate()
        {

            RaycastHit hit;
           
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }*/
public class PlayersController : MonoBehaviour
{
    [SerializeField] Transform [] charactersTab;
    [SerializeField] bool isMoving = false;
    public float range = 30f;
    private Transform initialPosition;
    public Transform monolith;
    private Transform activePlayer;
    NavMeshAgent agent;
    public Color initialColor = Color.white;
    public Color activeColor = Color.red;
    //LayerMask layerMask = LayerMask.GetMask("Monolith");



    void Start()
    {
       
    }

    
    void Update()
    {
        //NavMeshHit hit;
        
        
          if (isMoving == false && Input.GetMouseButtonDown(0))
        {
            LayerMask mask = LayerMask.GetMask("Monolith");
            /*if (!agent.Raycast(monolith.position, out hit))
            {
                Debug.Log("Hello: ");
            }*/
            MovingPlayer();
        }
            
        
      
    }

    void MovingPlayer()
    {
        isMoving = true;
        activePlayer = charactersTab[Random.Range(0, charactersTab.Length)];
        Renderer activeRedPlayer = activePlayer.GetComponent<Renderer>();
        Transform initialPositioncharacter = activePlayer.GetComponent<Transform>();
        initialPosition = initialPositioncharacter.transform;
        agent = activeRedPlayer.GetComponent<NavMeshAgent>();
        activeRedPlayer.material.color = activeColor;
        
        agent.SetDestination(monolith.position);

        //StartCoroutine(Wait());

        if (agent.remainingDistance < range && isMoving == true)
        {
            StopMoving();
        }

    }
   
   
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(15);

        
            isMoving = false;
            Renderer activeRedPlayer = activePlayer.GetComponent<Renderer>();
            activeRedPlayer.material.color = initialColor;
            agent.SetDestination(initialPosition.position);
            Debug.Log("Hello: ");
            
           
        
    }*/
    void StopMoving()
    {
        isMoving = false;
        Renderer activeRedPlayer = activePlayer.GetComponent<Renderer>();
        activeRedPlayer.material.color = initialColor;
        agent.SetDestination(initialPosition.position);
        Debug.Log("Hello: ");
        
    }
}
