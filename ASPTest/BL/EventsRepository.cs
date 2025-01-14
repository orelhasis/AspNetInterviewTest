using ASPTest.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTest
{
    public class EventsRepository : IEvents
    {
        IData _DataRepository = new DataRepository();
        List<int> Items = new List<int>();

        int[] NextPositions;
        Dictionary<int, int> ValuesByPositions;

        Random _rand = new Random();
        public EventsRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                int num = _rand.Next(0, 100);
                Items.Add(num);
            }

            initialize();
            for (int j = 0; j < 100; j++)
            {
                updateNextPositions(j, Items[j]);
            }
        }

        private void updateNextPositions(int idx, int num)
        {
            if (this.ValuesByPositions[num] != -1)
            {
                this.NextPositions[this.ValuesByPositions[num]] = idx;
            }
            this.ValuesByPositions[num] = idx;
        }

        private void initialize()
        {
            this.NextPositions = new int[100];
            for (int i = 0; i < this.NextPositions.Length; i++)
            {
                this.NextPositions[i] = -1;
            }

            this.ValuesByPositions = new Dictionary<int, int>();
            for (int i = 0; i < 100; i++)
            {
                this.ValuesByPositions.Add(i, -1);
            }
        }

        public int Next(int position)
        {
            int res = -2;
            if(position>=0 && position <=99)
                res = this.NextPositions[position];
            return res;
        }

        public int[] getNextPositions()
        {
            return this.NextPositions;
        }

        public List<int> GetAllItems()
        {
            return Items;
        }
    }

    interface IEvents
    {
        int Next(int Postion);
        int[] getNextPositions();
        List<int> GetAllItems();

    }
}
