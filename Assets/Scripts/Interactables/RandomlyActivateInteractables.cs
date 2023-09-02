using UnityEngine;

namespace Interaction
{
    public class RandomlyActivateInteractables : MonoBehaviour
    {
        private InteractableActivationHandler[] interactableActivationHandlers;
        [SerializeField] private GameObject interactableActivationParent;
        [SerializeField] private StageData stageData;
        private float activationTime;
        private float activateTimer;

        private void Start()
        {
            interactableActivationHandlers = interactableActivationParent.GetComponentsInChildren<InteractableActivationHandler>();
            GetRandomActivationTime();
        }

        private void GetRandomActivationTime()
        {
            activationTime = Random.Range(stageData.objectActivationTime.min, stageData.objectActivationTime.min);
        }

        private void Update()
        {
            activateTimer += Time.deltaTime;
            if(activateTimer > activationTime)
            {
                activateTimer = 0;
                GetRandomActivationTime();
                interactableActivationHandlers[Random.Range(0, interactableActivationHandlers.Length)].ActivateObject();
            }
        }

    }
}