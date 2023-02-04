using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject RadicalizedEnemy;
    public int value;
    Transform Target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start() {
        //TODO: get player Target = Player.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update() {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) 
        {
            //TODO: damage player
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //trigger with player weapons
        //TODO: check with player weapons

        return;

        if(RadicalizedEnemy == null) {
            //aici cand inamicul nu mai are radical si trebuie dat bonus la player
            //TODO: add bonus to player
            Destroy(this.gameObject);
        }
        else {
            StartCoroutine(WaitToSpawnNextEnemy());
        }

    }

    IEnumerator WaitToSpawnNextEnemy() {
        yield return new WaitForSeconds(1);

        //TODO: add bonus to player
        Instantiate(RadicalizedEnemy, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
