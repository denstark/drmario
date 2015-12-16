using UnityEngine;
using System.Collections;

/**
 * Holder for where a virus should be placed on the grid
 */
public struct VirusLocation
{
    public string color;
    public int x;
    public int y;
}

/**
 * Determines virus locations based on a given difficulty (virus count)
 */
public class LevelBuilder
{
    public VirusLocation[] populateViruses(int count, int width, int height)
    {
        VirusLocation[] locs = new VirusLocation[count];

        int topLine = 3;

        // at early levels, don't fill up as high
        if (count < 30)
        {
            topLine = 8;
        }
        else if (count < 40)
        {
            topLine = 6;
        }
        else if (count < 50)
        {
            topLine = 5;
        }

        for (int i = 0; i < count; i++)
        {
            VirusLocation loc = new VirusLocation();

            switch (Random.Range(0, 3))
            {
                case 0:
                    loc.color = "yellow";
                    break;
                case 1:
                    loc.color = "red";
                    break;
                default:
                    loc.color = "blue";
                    break;
            }

            bool taken = true;

            while (taken)
            {
                loc.x = Random.Range(0, width);
                loc.y = Random.Range(topLine, height);

                taken = false;

                foreach (VirusLocation t in locs)
                {
                    if (t.x == loc.x && t.y == loc.y)
                    {
                        taken = true;
                        break;
                    }
                }
            }

            locs[i] = loc;
        }

        return locs;
    }
}
