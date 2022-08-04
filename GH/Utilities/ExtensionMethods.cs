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
      

        public static HexDO GetCurrentLocationHex(this GameComponentBase c)
        {
            return GHGameManager.GameState.Hexes.First(_ => _.Components.Contains(c));
        }

        public static List<HexDO> GetHexesInRange(this HexDO h, int range)
        {
            var retVal = new List<HexDO>();

            Action<int, HexDO> f = null;

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
        public static List<HexDO> GetNeighbourHexes(this HexDO h)
        {
            //TODO dependent on the hex orientation
            // odd vertical

            var isEvenColumn = h.Column.IsEven();

            return new List<HexDO>
            {
                Helper.GetHexByCoords(h.Column    , h.Row - 1), //above
                Helper.GetHexByCoords(h.Column    , h.Row + 1), //below

                Helper.GetHexByCoords(h.Column - 1, isEvenColumn ? h.Row - 1 : h.Row    ), //up left
                Helper.GetHexByCoords(h.Column - 1, isEvenColumn ? h.Row     : h.Row + 1), //down left

                Helper.GetHexByCoords(h.Column + 1, isEvenColumn ? h.Row - 1 : h.Row    ), //up right
                Helper.GetHexByCoords(h.Column + 1, isEvenColumn ? h.Row     : h.Row + 1)  //down right
            }.Where(_ => _ != null).ToList();
        }

        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        public static Hex ToLocalHex(this HexDO hex, Gloomhaven gloomhaven)
        {
            return gloomhaven.Hexes.First(h => h.Id == hex.Id);
        }

        public static void UpdateHexes(this IEnumerable<Hex> destinationHexes, IEnumerable<HexDO> sourceHexes)
        {
            foreach (var sourceHex in sourceHexes)
            {
                var destHex = destinationHexes.First(h => h.Id == sourceHex.Id);

                destHex.Components.Clear();
                foreach (var c in sourceHex.Components)
                {
                    destHex.Components.Add(c);
                }
            }
        }
    }
}
