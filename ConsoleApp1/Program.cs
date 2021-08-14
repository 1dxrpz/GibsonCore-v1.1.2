using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				Random random = new Random();
				int[] nums = new int[20];
				for (int i = 0; i < nums.Length; i++)
				{
					nums[i] = random.Next(1, 255);
				}

				foreach (var item in nums)
				{
					Console.WriteLine($"{item}\t\t{GetBinary(item)}");
				}
				Console.ReadKey();
			}
		}
		static string GetBinary(int num)
		{
			string res = "";
			int cbyte = 0;
			while (cbyte < 8)
			{
				res = num % 2 + res;
				num /= 2;
				cbyte++;
			}
			return res;
		}
		static void Sort(string[] b)
		{
			string[] left = new string[b.Length / 2];
			string[] right = new string[b.Length / 2];

			for (int i = 0; i < b.Length; i++)
			{

			}
		}
	}
}
