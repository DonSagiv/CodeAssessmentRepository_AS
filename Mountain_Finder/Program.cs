using System;
using System.Collections.Generic;
using System.Linq;

namespace Mountain_Finder
{
    /// <summary>
    /// Consider a two-dimensional matrix comprised entirely of integers, where each integer value represents elevation.
    /// Given such a matrix, your goal is to find the total number of mountains in this "map."
    /// A mountain is defined as a group of contiguous tiles whose value is greater than or equal to 2.
    /// Two tiles are considered contiguous if they are adjacent in either in the horizontal or vertical direction - two tiles are NOT considered contiguous if they are adjacent to one another on a diagonal.
    /// 
    /// In the following three cases, only the "2" tiles in the first two cases are considered contiguous and thus form a single mountain. The last case shows two separate mountains, since the tiles are not adjacent in the horizontal or vertical direction, but instead are at a diagonal with respect to one another.
    ///
    ///  2 2        2 0        2 0
    ///  0 0        2 0        0 2
    ///
    /// Map:
    /// Two-dimensional matrix
    /// Comprised exclusively of integers
    /// Each element represents a tile in the map
    /// Each element's integer value represents elevation
    /// Mountain:
    /// A single contiguous area of tiles whose values are all at least 2
    /// Two tiles are considered contiguous (touching) when they are adjacent in the horizontal direction or in the vertical direction, but not in a diagonal
    /// 
    /// For example, take the following input:
    /// 1 1 0 1 2 0
    /// 0 2 3 1 2 0
    /// 1 3 3 1 2 0
    /// 0 1 1 1 3 0
    /// 1 2 3 2 1 1
    /// 1 3 4 3 1 1
    /// 
    /// This is a 6x6 map. The map itself contains a total of three (3) mountains, so your function should return "3."
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var map = new int[6][]
            {
                new int[6]{ 1, 1, 0, 1, 2, 0 },
                new int[6]{ 0, 2, 3, 1, 2, 0 },
                new int[6]{ 1, 3, 3, 1, 2, 0 },
                new int[6]{ 0, 1, 1, 1, 3, 0 },
                new int[6]{ 1, 2, 3, 2, 1, 1 },
                new int[6]{ 1, 3, 4, 3, 1, 1 },
            };

            var returnString = $"Number of mountains found: {getNumberMountains(map)}";

            Console.WriteLine(returnString);
            Console.ReadKey();
        }

        static int getNumberMountains(int[][] map)
        {
            var mountains = new List<Mountain>();

            /* I call this the "crystallize" algorithm, where a single "mountain" point is found.
             * Once the point is found, the algorithm keeps finding contiguous points until it can no longer find any.
             * It then continues the search for mountain points, excluding mountain points that were already found. */
            for(var i = 0; i < map.Length; i++)
            {
                for(var j = 0; j < map.First().Length; j++)
                {
                    // Is the point a "mountain point?"
                    if(map[i][j] >= 2)
                    {
                        // Mountain crystalization "nucleus", aka the starting point
                        var mountainMapPoint = new MapPoint(i, j, map);

                        // Ensures the found "nucleus" is not part of another mountain
                        var mountainMapPointFound = mountains
                            .SelectMany(x => x.mountainCoordinates)
                            .Where(x => x.i == mountainMapPoint.i)
                            .Any(x => x.j == mountainMapPoint.j);

                        // If so, move on.
                        if (mountainMapPointFound) continue;

                        Console.WriteLine($"New mountain found at point ({i}, {j})");

                        // Create a new mountain
                        var mountain = new Mountain(mountainMapPoint, map);

                        // Determines if the mountain has enough points to be considered a "mountain" by the specification
                        if (!mountain.isMountain)
                            Console.WriteLine($"Not enough points to be considered a mountain.");
                        else
                            mountains.Add(mountain);
                    }
                }
            }

            return mountains
                .Where(x => x.isMountain)
                .Count();
        }

        public class MapPoint
        {
            public int i { get; set; }
            public int j { get; set; }
            public bool isMountainPoint { get; set; }

            public MapPoint(int i, int j, int[][] map)
            {
                this.i = i;
                this.j = j;

                // Boundary conditions. All points outside the boundary are not considered mountain points.
                if (i < 0) isMountainPoint = false;
                else if (i >= map.Length) isMountainPoint = false;
                else if (j < 0) isMountainPoint = false;
                else if (j >= map.First().Length) isMountainPoint = false;
                else isMountainPoint = map[i][j] >= 2; // Determines if the point is a mountain point.
            }
        }

        public class Mountain
        {
            public IList<MapPoint> mountainCoordinates { get; set; }
            public bool isMountain => mountainCoordinates.Count >= 2;

            public Mountain(MapPoint initialMapPoint, int[][] map)
            {
                mountainCoordinates = new List<MapPoint>();
                addMountainPoint(map, initialMapPoint);
            }

            private void addMountainPoint(int[][] map, MapPoint mountainPoint)
            {
                // Ensures recursive scan doesn't re-use previously added mountain points.
                if (mountainCoordinates
                    .Where(x => x.i == mountainPoint.i)
                    .Any(x => x.j == mountainPoint.j)) return;

                Console.WriteLine($"Mountain point added at ({mountainPoint.i},{mountainPoint.j})");

                mountainCoordinates.Add(mountainPoint);
                findContingouousMountainCoordinates(mountainPoint, map);
            }

            private void findContingouousMountainCoordinates(MapPoint coordinate, int[][] map)
            {
                // Creates a map point for all contiguous points, and finds which of them are mountain points.
                var contiguousMountainCoordinates = new List<MapPoint>
                {
                    new MapPoint(coordinate.i - 1, coordinate.j, map), // Top 
                    new MapPoint(coordinate.i + 1, coordinate.j, map), // Bottom
                    new MapPoint(coordinate.i, coordinate.j + 1, map), // Left
                    new MapPoint(coordinate.i, coordinate.j - 1, map), // Right
                }
                .Where(x => x.isMountainPoint)
                .ToList();

                // Recursively scans for and adds mountain points
                foreach(var mountainPoint in contiguousMountainCoordinates)
                    addMountainPoint(map, mountainPoint);
            }
        }
    }
}
