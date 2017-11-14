//hello this will raise conflicts(added in feature1 local)

//Hey I added in Master. Will see who wins
using System;
using System.Collections.Generic;
using System.Linq;

//dude see this
namespace CanDelete
{
    //This is from Feature1 branch in local and added this via github
    public class FinalLRUCache
    {
        private int capacity, size;
        private Dictionary<int, listnode> map;
        public class listnode
        {
            public int key, val, count;
            public DateTime accessedDate;

            public listnode(int k, int v)
            {
                key = k;
                val = v;
                count = 1;
                accessedDate = DateTime.Now;
            }
        }

        public FinalLRUCache(int capacity)
        {
            if (capacity <= 0)
            {
                //throw new IllegalArgumentException("Positive capacity required.");
                return;
            }

            this.capacity = capacity;
            map = new Dictionary<int, listnode>();
        }

        public int get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }

            listnode target = map[key];
            target.count++;
            target.accessedDate = DateTime.Now;
            return target.val;
        }

        public void set(int key, int value)
        {
            if (map.ContainsKey(key))
            { // update old value of the key
                listnode target = map[key];
                target.val = value;
                target.count++;
                target.accessedDate = DateTime.Now;
            }
            else
            { // insert new key value pair, need to check current size
                if (size == capacity)
                {
                    var temp = map.OrderBy(x => x.Value.count).ThenBy(x => x.Value.accessedDate).FirstOrDefault();
                    map.Remove(temp.Key);
                    --size;
                }

                listnode newNode = new listnode(key, value);
                map.Add(key, newNode);
                ++size;
            }
        }
        static void Main(string[] args)
        {

            FinalLRUCache cache = new FinalLRUCache(4);

            int[][] keyValuePair = new int[5][]{
                new int[2]{1,1},
                new int[2]{2,1},
                new int[2]{3,1},
                new int[2]{4,1},
                new int[2]{5,1}
                };

            for (int i = 0; i < 4; i++)
                cache.set(keyValuePair[i][0], keyValuePair[i][1]);

            int value = cache.get(1);  // key 1 is in LRU, so the value is 1; and also 1 is visited, then, remove key 1, and add key 1 to  to last one instead. 

            cache.set(keyValuePair[4][0], keyValuePair[4][1]); // should remove key 1, but 1 is visited recently; 2 is one to remove. 

            int value2 = cache.get(1);  // return 1
            int value3 = cache.get(2);  // return -1
            int value4 = cache.get(3);
        }
    }
}
