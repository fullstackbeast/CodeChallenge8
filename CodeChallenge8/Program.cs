using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountTripLet(new[] { 4, 0, 1, 3, 2 }, new[] { 4, 1, 0, 2, 3 }));
        }
 

        static int CountTripLet(int[] nums1, int[] nums2)
        {
            var result = GetCombinations(Enumerable.Range(0, nums1.Length), 3).Where(r => r.Distinct().Count() == 3);

            var validListCount = result
                .Select(triplet =>
                    triplet.ToList())
                .Count(t => Array.IndexOf(nums1, t[0]) < Array.IndexOf(nums1, t[1])
                            && Array.IndexOf(nums1, t[1]) < Array.IndexOf(nums1, t[2])
                            && Array.IndexOf(nums2, t[0]) < Array.IndexOf(nums2, t[1])
                            && Array.IndexOf(nums2, t[1]) < Array.IndexOf(nums2, t[2]));
            
            return validListCount;
        }


        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetCombinations(list, length - 1)
                .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}