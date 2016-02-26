using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PokeShadow : MonoBehaviour 
{
	public SpriteRenderer shadow;
	public SpriteRenderer pokemon;

	void Start () 
	{
		Vector3 pb = pokemon.bounds.size;
		float sizeX = pb.x / shadow.sprite.bounds.size.x + 2*(pb.x/7);
		float sizeY = pb.y;///3;
		float sizeZ = 0;
		transform.localScale = new Vector3(sizeX,sizeY,1);

	}

}
