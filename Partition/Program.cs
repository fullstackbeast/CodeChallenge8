using System;
using System.Collections.Generic;
using System.Linq;

namespace Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetPivots(new[] { 22, 4, -33, -20, -15, 15, -16, 7, 19, -10, 0, -13, -14 });

            // GetMaximunPivotCount(new[] { 22, 4, -25, -20, -15, 15, -16, 7, 19, -10, 0, -13, -14 }, -33);
            // GetMaximunPivotCount(new[] { 22, 4, -25, -20, -15, 15, -16, 7, 19, -10, 0, -13, -14 }, -33);
            GetMaximunPivotCount(new[] { 2,-1,2 }, 3);
        }

        static int GetMaximunPivotCount(int[] nums, int k)
        {
            int max = GetPivots(nums.ToList());
            
            for (int i = 0; i < nums.Length; i++)
            {
                var numList = nums.ToList();
                numList.Insert(i, k);
                numList.RemoveAt(i + 1);
                 
                max = Math.Max(max, GetPivots(numList));
                
            }
            
            return max;
        }


        static int GetPivots(List<int> nums)
        {
            var pivots = new List<int>();
            for (int i = 1; i < nums.Count; i++)
            {
                var preAdd = 0;
                for (int j = 0; j < i; j++) preAdd += nums[j];
                
                var postAdd = 0;

                for (int j = i; j < nums.Count; j++) postAdd += nums[j];
                
                if(preAdd == postAdd) pivots.Add(nums[i]);
            }

            return pivots.Count;
        }
    }
}