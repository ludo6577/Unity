using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation;
using RAIN.Navigation.Graph;

[RAINAction]
public class WayPathLocation : RAINAction
{
	private static float _startTime = 0f;

    public WayPathLocation()
    {
        actionName = "WayPathLocation";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);

		_startTime += Time.time;
    }

    public override ActionResult Execute(AI ai)
    {
		Vector3 loc = Vector3.zero;//Default
		//Create a navigation graph collection
		List<RAINNavigationGraph> found = new List<RAINNavigationGraph>();
		
		//Create a vector location based on our AI current location 
		//plus random range values for x and z coordinates
		do
		{
			loc = new Vector3(ai.Kinematic.Position.x + Random.Range(-8f, 8f),
			                  ai.Kinematic.Position.y,
			                  ai.Kinematic.Position.z + Random.Range(-8f, 8f));
			
			//We will create navigation points using the above calculated value, the AI current positon and ensure it is within the bounds of our navigation graph
			found = NavigationManager.instance.GraphsForPoints(ai.Kinematic.Position, loc, ai.Motor.StepUpHeight, NavigationManager.GraphType.Navmesh, ((BasicNavigator)ai.Navigator).GraphTags);
			
		} while ((Vector3.Distance(ai.Kinematic.Position, loc) < 2f) || (found.Count == 0)); //We want to be sure the location found is far enough away from each one we move to so we don't pick anything to close or the same one
		
		//We will define a runtime variable in the AIRigs Memory element panel. You can select this in your inspector to see the output at runtime.
		ai.WorkingMemory.SetItem<Vector3>("varMoveTo", loc);

		if(_startTime > 500f)
		{
			ai.WorkingMemory.SetItem("isSearching", false);
			_startTime = 0;
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}