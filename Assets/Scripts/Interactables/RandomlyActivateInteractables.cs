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
        private int currentActivatedObjectIndex;
        private int currentRandomIndex;

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
               
                interactableActivationHandlers[GetRandomObjectToActivate()].ActivateObject();
            }
        }

        private int GetRandomObjectToActivate()
        {
            while(currentRandomIndex == currentActivatedObjectIndex)
                currentRandomIndex = Random.Range(0, interactableActivationHandlers.Length);

            currentActivatedObjectIndex = currentRandomIndex;
            return currentRandomIndex;
        }

    }
}