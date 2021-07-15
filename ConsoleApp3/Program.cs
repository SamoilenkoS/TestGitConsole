using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public static class Solution
    {
        public static bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
            {
                return false;
            }

            var leftSide = new List<char>();
            var rightSide = new List<char>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != goal[i])
                {
                    leftSide.Add(s[i]);
                    rightSide.Add(goal[i]);
                }
            }

            if (leftSide.Count == 0)//equivalent strings
            {
                Dictionary<char, int> counts = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (!counts.ContainsKey(s[i]))
                    {
                        counts.Add(s[i], 1);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            if (leftSide.Count != 2)
            {
                return false;
            }

            foreach (var ch in leftSide)
            {
                if (!rightSide.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public static int ThirdMax(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach (var num in nums)
            {
                if (hashSet.Count < 3)
                {
                    hashSet.Add(num);
                }
                else
                {
                    hashSet.ReplaceMax(num);
                }
            }

            return hashSet.Count == 3 ? hashSet.Min() : hashSet.Max();
        }

        public static void ReplaceMax(this HashSet<int> hashSet, int value)
        {
            if (hashSet.Contains(value))
            {
                return;
            }
            var setMin = hashSet.Min();
            if (setMin < value)
            {
                hashSet.Remove(setMin);
                hashSet.Add(value);
            }
        }

    //[1,2,10,5,7]
    //[2,3,1,2]
    //[1,1,1]
    public static bool CanBeIncreasing(int[] nums)
    {
      bool res = true;
      int chance = 1;

      for (int i = 1; i < nums.Length; i++)
      {
        if (nums[i - 1] >= nums[i])
        {
          chance -= 1;

          if (i >= 2 && nums[i - 2] >= nums[i])
          {
            nums[i] = nums[i - 1];
          }
        }
        if (chance < 0)
        {
          res = false;
        }
      }

      return res;
    }

    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
      for (int i = 0; i < flowerbed.Length && n >0; i++)
      {
        if (CanPlant(flowerbed, i))
        {
          flowerbed[i] = 1;
          --n;
        }
      }

      return n <= 0;
    }

    private static bool CanPlant(int[] flowerbed, int i)
    {
      if (i == 0 && flowerbed[i] == 0)
      {
        return flowerbed.Length == 1 || flowerbed[i + 1] == 0;
      }

      if (flowerbed[i] == 0 && flowerbed[i - 1] == 0)
      {
        return flowerbed.Length < i + 1 || flowerbed[i + 1] == 0;
      }

      return false;
    }
  }
    class Program
    {
        static void Main(string[] args)
        {
            var result = Solution.CanBeIncreasing(new []{1, 1, 1});
            Console.ReadKey();
        }
  }
}