using System.Collections;
using GameSystem.Entity;
using GameSystem.Service;
using UnityEngine;

namespace Trigger
{
    public class Checkpoint : MonoBehaviour
    {
        public GameObject blockingGameObject;
        public Transform blockingPos;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
        
            var o = other.gameObject;
            var position = o.transform.position;
            var rotation = o.transform.rotation;
            var checkPoint = new CheckPoint
            {
                XPos = position.x,
                YPos = position.y,
                ZPos = position.z,
                //StarCount = 
                XRot = rotation.x,
                YRot = rotation.y,
                ZRot = rotation.z,
            };
            EventService.WriteCheckPoint(checkPoint);
        }

        private IEnumerator BlockPreviousArea()
        {
            Instantiate(blockingGameObject, blockingPos);
            yield return true;
        }
    }
}
