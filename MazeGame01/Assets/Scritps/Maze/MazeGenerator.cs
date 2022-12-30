using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Walls: ")]
    [SerializeField] private GameObject _wallPref;

    private Maze _maze;


    private void Start()
    {
        GenerateMazeBasic();
    }

    public void GenerateMazeBasic()
    {
        _maze = new Maze();
        _maze.InitData(_wallPref);
    }

    public void GenerateRandomPaths()
    {
        _maze.SetRandomPath();
    }

    public void DestroyMaze()
    {
        _maze.ClearMaze();
    }
}
