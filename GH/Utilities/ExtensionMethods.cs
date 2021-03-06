using BlazorApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using BlazorApp.Models;
using System.Linq;
using BlazorApp.GH.Pages;
using BlazorApp.GH.Management;
using System;
using BlazorApp.GH.Components;

namespace BlazorApp.GH.Utilities
{

    public static class ExtensionMethods
    {
        /// <summary>
        /// returns hex, null if it doesnt exist
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public static Hex GetHexByCoords(this Gloomhaven gh, int column, int row)
        {
            return gh.Hexes.FirstOrDefault(h => h.Column == column && h.Row == row);
        }

        public static Hex GetCurrentLocationHex(this GameComponentBase c)
        {
            return GHGameManager.GloomhavenHexes.First(_ => _.Components.Contains(c));
        }

        public static List<Hex> GetHexesInRange(this Hex h, int range)
        {
            var retVal = new List<Hex>();

            Action<int, Hex> f = null;

            f = (i, currentHex) =>
            {
                if (i > 0)
                {
                    i--;
                    foreach (var hex in currentHex.GetNeighbourHexes())
                    {
                        if (!retVal.Contains(hex))
                            retVal.Add(hex);

                        f(i, hex);
                    }
                }
            };

            f(range, h);

            retVal.Remove(h);

            return retVal;

        }

        /// <summary>
        /// returns existing neighbour hexes
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static List<Hex> GetNeighbourHexes(this Hex h)
        {
            //TODO dependent on the hex orientation
            // odd vertical

            var isEvenColumn = h.Column.IsEven();

            return new List<Hex>
            {
                Helper.GetHexByCoord(h.Column    , h.Row - 1), //above
                Helper.GetHexByCoord(h.Column    , h.Row + 1), //below

                Helper.GetHexByCoord(h.Column - 1, isEvenColumn ? h.Row - 1 : h.Row    ), //up left
                Helper.GetHexByCoord(h.Column - 1, isEvenColumn ? h.Row     : h.Row + 1), //down left

                Helper.GetHexByCoord(h.Column + 1, isEvenColumn ? h.Row - 1 : h.Row    ), //up right
                Helper.GetHexByCoord(h.Column + 1, isEvenColumn ? h.Row     : h.Row + 1)  //down right
            }.Where(_ => _ != null).ToList();
        }

        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

    }
}
