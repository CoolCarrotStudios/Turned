using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayerMovement();
    }
    
    private void FollowPlayerMovement()
    {
        transform.position = new Vector3(player.transform.position.x,165,player.transform.position.z);
    }
}
