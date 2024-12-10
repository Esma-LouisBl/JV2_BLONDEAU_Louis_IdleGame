using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePokemon : MonoBehaviour
{
    public Team team;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Leave(int member)
    {
        team.members[member] = null;
    }
}
