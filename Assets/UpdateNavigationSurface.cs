using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavigationSurface : MonoBehaviour
{
    NavMeshSurface navigationSurface;
    public NavMeshData navMeshData;
    // Start is called before the first frame update
    void Start()
    {
        navigationSurface = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        //navigationSurface.UpdateNavMesh(navMeshData);
    }
}
