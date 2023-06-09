using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    [SerializeField] public GameObject shadowWorldPostProcessing;

    WorldBlankState currentState;
    public RealWorldState realWorldState = new RealWorldState();
    public ShadowWorldState shadowWorldState = new ShadowWorldState();
    MusicManager musicManager;

    ShadowStateManager[] shadows;

    // Start is called before the first frame update
    void Start()
    {
        shadows = FindObjectsOfType<ShadowStateManager>();
        musicManager = FindObjectOfType<MusicManager>();
        currentState = realWorldState;
        realWorldState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SwitchState(WorldBlankState newState)
    {
        currentState = newState;
        newState.EnterState(this);
        musicManager.setmusicstate(newState.MusicState);
    }

    public IEnumerator ShadowWorldTimer()
    {
        yield return new WaitForSeconds(2.5f);
        SwitchState(realWorldState);

    }

    public void ShadowsVisible(bool setter)
    {
        foreach (ShadowStateManager shadow in shadows)
        {
            // only change the shadows that haven't been caught
            if (!shadow.captured)
            {
                if (currentState == shadowWorldState)
                {
                    shadow.SetShadowSprite(shadow.shadowWorldSprite);
                }

                else if (currentState == realWorldState)
                {
                    shadow.SetShadowSprite(shadow.shadowWorldSprite);
                }

                shadow.MakeVisible(setter);
            }
        }
    }

    // After we come back into the real world, we turn isWithinCapRange off again
    public void ResetAllWithinCapRange()
    {
        foreach (ShadowStateManager shadow in shadows)
        {
            shadow.isWithinCapRange = false;
        }
    }

}
