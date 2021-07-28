using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Root
{
    public static class ClearingHelper
    {


        public static readonly Dictionary<int, TopLeftStr> clearingLocationData =
        new Dictionary<int, TopLeftStr>
          {
            {1, new TopLeftStr( 60, 70)},
            {2, new TopLeftStr(160,830)},
            {3, new TopLeftStr(730,780)},
            {4, new TopLeftStr(690, 80)},
            {5, new TopLeftStr( 40,510)},
            {6, new TopLeftStr(420,850)},
            {7, new TopLeftStr(650,530)},
            {8, new TopLeftStr(750,320)},
            {9, new TopLeftStr(310, 70)},
            {10,new TopLeftStr(210,370)},
            {11,new TopLeftStr(380,600)},
            {12,new TopLeftStr(450,270)},
          };
    }

    public class ClearingDataModel
    {
        public ClearingDataModel(int top, int left)
        {
            Top = top;
            Left = left;
            Components = new List<Component>();
        }

        public int Top;
        public int Left;
        public List<Component> Components;
    }

    public class Component
    {
        public Race Owner;

    }

    public class Warrior : Component
    {

    }

    public enum Race
    {
        Marquise,
        Eyrie,
        Alliance,
        Vagabond,
        Cult,
        Riverfolk
    }

    public static class GameManager
    {
        private static Dictionary<int, ClearingDataModel> Clearings = new Dictionary<int, ClearingDataModel>();


        public static void InitBoard()
        {
            InitClearings();
        }

        private static void InitClearings()
        {
            Clearings.Clear();
            for (int i = 1; i <= 12; i++)
            {
                var s = ClearingHelper.clearingLocationData[i];
                Clearings.Add(i, new ClearingDataModel(s.Top, s.Left));
            }
        }

        public static void StartGame()
        {

        }

        public static ClearingDataModel GetClearingData(int clearingNumber)
        {
            try
            {
                return Clearings[clearingNumber];
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public struct TopLeftStr
    {
        public TopLeftStr(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public int Top;
        public int Left;
    }
}
