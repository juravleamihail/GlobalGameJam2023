using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavigationSurface : MonoBehaviour
{
    NavMeshSurface Surface2D;
    // Start is called before the first frame update

    private void Start() {
        Surface2D = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        Surface2D.UpdateNavMesh(Surface2D.navMeshData);
    }
}
