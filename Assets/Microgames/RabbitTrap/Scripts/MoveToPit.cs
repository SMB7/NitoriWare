using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MoveToPit : MonoBehaviour
{
    /*Moves Reisen towards the pit trap.*/
	/*//NOTE: Currently not functional. Should be able to trivialize movement with a Vector2 like in ReimuDodge, but
	//not sure how to implement it yet. If I have to bail and someone else picks this up, this is probably the place to start.

	private int pattern; //the pattern Reisen will move in. Randomly selected in Start().

	void Start()
	{
		//Choose a pattern. Should be expanded to three total later (range of 0 to 3).
		pattern = Random.Range(0, 2);
	}

	void Update()
	{
		//move in the chosen pattern
		moveInPattern(pattern);
	}

	//TODO: these functions probably need to be renamed

	void moveInPattern(int p) //move in a pattern
	{
		//TODO: this should probably be done by cases, but I don't know offhand how to do that in C# :P
		if (p == 0)
		{
			//Trying to cast these to vector2s isn't working, find a workaround.
			transform.position = moveX((Vector2)-10);
			transform.position = moveX((Vector2)5);
			transform.position = moveX((Vector2)-15);
			//net movement of 20 to the left. Add more movement after this, perhaps another chance to step on the trap.
		}

		if (p == 1)
		{
			transform.position = moveX ((Vector2)-15);
			//net movement of 15 to the left.
		}

		else
		{
			transform.position = moveX((Vector2)200000); //debug, delete when not needed
		}
		//None of the effects of these if statements are working. Need to write a better moveX(), I think. Will look into later, it's getting late :(
	}
		
	Vector2 moveX(Vector2 m) //move a particular distance along the X axis
	{
		//TODO: make this an actual smooth motion, rather than jumping between positions, maybe with .normalized
		Vector2 newPosition = (Vector2)transform.position + m;
		return newPosition;
	}

	//Implement moveY below. Not done for now, because it's not terribly relevant and may not actually be necessary, depending on the animation.*/
	//Entire script currently disabled because it's broken and I need sleep. >.>
	//Need to figure out how to properly implement movement.
}