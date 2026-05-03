using System;
using System.Collections.Generic;
using System.Linq;

namespace Botva2025;

public class MinesweeperSolver
{
	public class ClickResult
	{
		public int Index { get; set; }

		public double Probability { get; set; }

		public string Reason { get; set; }
	}

	public ClickResult FindSafestClick(int[] field)
	{
		if (field == null)
		{
			throw new ArgumentException("Поле не может быть null");
		}
		int num = field.Length;
		int num2 = (int)Math.Sqrt(num);
		if (num2 * num2 != num)
		{
			throw new ArgumentException("Поле должно быть квадратным (16, 25, 36 клеток)");
		}
		List<int> source = FindSafeCells(field, num2);
		if (source.Any())
		{
			return new ClickResult
			{
				Index = source.First(),
				Probability = 0.0,
				Reason = "Гарантированно безопасная клетка"
			};
		}
		Dictionary<int, double> source2 = CalculateProbabilities(field, num2);
		if (!source2.Any())
		{
			return new ClickResult
			{
				Index = -1,
				Probability = 1.0,
				Reason = "Нет неизвестных клеток"
			};
		}
		KeyValuePair<int, double> keyValuePair = source2.OrderBy((KeyValuePair<int, double> p) => p.Value).First();
		return new ClickResult
		{
			Index = keyValuePair.Key,
			Probability = keyValuePair.Value,
			Reason = "Минимальная вероятность мины среди неизвестных клеток"
		};
	}

	private List<int> FindSafeCells(int[] field, int gridSize)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < field.Length; i++)
		{
			if (field[i] != -1)
			{
				continue;
			}
			List<int> neighbors = GetNeighbors(i, gridSize);
			foreach (int item in neighbors)
			{
				if (field[item] >= 0 && field[item] <= 8)
				{
					int num = field[item];
					List<int> neighbors2 = GetNeighbors(item, gridSize);
					int num2 = neighbors2.Count((int idx) => field[idx] == 10);
					int num3 = neighbors2.Count((int idx) => field[idx] == -1);
					if (num2 == num && num3 > 0)
					{
						list.Add(i);
						break;
					}
				}
			}
		}
		return list;
	}

	private Dictionary<int, double> CalculateProbabilities(int[] field, int gridSize)
	{
		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		for (int i = 0; i < field.Length; i++)
		{
			if (field[i] == -1)
			{
				dictionary[i] = 0.0;
			}
		}
		for (int j = 0; j < field.Length; j++)
		{
			if (field[j] >= 0 && field[j] <= 8)
			{
				UpdateProbabilitiesFromNumber(field, j, dictionary, gridSize);
			}
		}
		int count = dictionary.Count;
		if (count > 0)
		{
			double value = 1.0 / (double)count;
			foreach (int item in dictionary.Keys.ToList())
			{
				if (dictionary[item] == 0.0)
				{
					dictionary[item] = value;
				}
			}
		}
		return dictionary;
	}

	private void UpdateProbabilitiesFromNumber(int[] field, int numberIndex, Dictionary<int, double> probabilities, int gridSize)
	{
		int num = field[numberIndex];
		List<int> neighbors = GetNeighbors(numberIndex, gridSize);
		List<int> list = neighbors.Where((int idx) => field[idx] == -1).ToList();
		int num2 = neighbors.Count((int idx) => field[idx] == 10);
		int num3 = num - num2;
		int count = list.Count;
		if (count <= 0 || num3 < 0 || num3 > count)
		{
			return;
		}
		double val = (double)num3 / (double)count;
		foreach (int item in list)
		{
			if (probabilities.ContainsKey(item))
			{
				probabilities[item] = Math.Max(probabilities[item], val);
			}
		}
	}

	private List<int> GetNeighbors(int index, int gridSize)
	{
		List<int> list = new List<int>();
		int num = index / gridSize;
		int num2 = index % gridSize;
		for (int i = num - 1; i <= num + 1; i++)
		{
			for (int j = num2 - 1; j <= num2 + 1; j++)
			{
				if (i >= 0 && i < gridSize && j >= 0 && j < gridSize && (i != num || j != num2))
				{
					list.Add(i * gridSize + j);
				}
			}
		}
		return list;
	}

	public void PrintField(int[] field)
	{
		int num = (int)Math.Sqrt(field.Length);
		for (int i = 0; i < field.Length; i++)
		{
			_ = i % num;
			string value = field[i] switch
			{
				-1 => "?", 
				10 => "X", 
				_ => field[i].ToString(), 
			};
			Console.Write($"{value,2} ");
		}
	}
}
