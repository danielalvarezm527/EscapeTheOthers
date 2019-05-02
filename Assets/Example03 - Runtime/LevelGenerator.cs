using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

    public NavMeshSurface surface;

	public int width = 40;
	public int height = 40;

	public GameObject wall;
	public GameObject player;

	private bool playerSpawned = false;

	void Start () {
		GenerateLevel();
        surface.BuildNavMesh();
	}
	
	// Create a grid based level
	void GenerateLevel()
	{
		// Loop over the grid
		for (int x = -20; x <= width; x+=2)
		{
			for (int y = -20; y <= height; y+=2)
			{
				// Should we place a wall?
				if (Random.value > .7f)
				{
                    // Spawn a wall
                    wall.transform.localScale = new Vector3(2, Random.Range(1, 3), 2);
					Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
                    wall.tag = "Muro";

				} else if (!playerSpawned) // Should we spawn a player?
				{
					// Spawn the player
					Vector3 pos = new Vector3(-10, 1.25f, -34);
                    player.name = "Jugador";
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}
			}
		}
	}

}
