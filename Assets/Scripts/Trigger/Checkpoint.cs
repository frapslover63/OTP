using System.Collections;
using GameSystem.Entity;
using GameSystem.Service;
using UnityEngine;
using UnityEngine.Events;

namespace Trigger
{
    public class Checkpoint : MonoBehaviour
    {
        public GameObject blockingGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            StartCoroutine(BlockPreviousArea());
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
            Debug.Log(EventService.LoadCheckPoint().XPos);
            Destroy(this);
        }

        private IEnumerator BlockPreviousArea()
        {
            blockingGameObject.SetActive(true);
            blockingGameObject.transform.parent = null;
            yield return true;
        }
    }
}
