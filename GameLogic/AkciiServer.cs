using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

internal class AkciiServer
{
	private class MoZayka_Kombo
	{
		public class MoZayka_Table_Game
		{
			public string Row { get; set; }

			public string Col { get; set; }

			public string Cell { get; set; }
		}

		public class MoZayka_Jeton
		{
			public string Name { get; set; }

			public int Quantity { get; set; }
		}

		public string Name { get; set; }

		public bool Bool { get; set; }

		public int Con { get; set; }

		public string[,] Kombo { get; set; }

		public string[,] KomboInvert { get; set; }

		public Dictionary<string, int> Collor { get; set; }

		public MoZayka_Kombo(string name, int cenaPovtor, bool boolValue, string[,] kombo)
		{
			Name = name;
			Bool = boolValue;
			Kombo = kombo;
			Con = cenaPovtor;
			GenerateInvert();
			GenerateCollor();
		}

		private void GenerateCollor()
		{
			HashSet<string> hashSet = new HashSet<string>();
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			for (int i = 0; i < Kombo.GetLength(0); i++)
			{
				for (int j = 0; j < Kombo.GetLength(1); j++)
				{
					string text = Kombo[i, j];
					hashSet.Add(text);
					if (dictionary.ContainsKey(text))
					{
						dictionary[text]++;
					}
					else
					{
						dictionary[text] = 1;
					}
				}
			}
			Dictionary<string, int> dictionary2 = dictionary.OrderByDescending((KeyValuePair<string, int> c) => c.Value).ToDictionary((KeyValuePair<string, int> c) => c.Key, (KeyValuePair<string, int> c) => c.Value);
			foreach (KeyValuePair<string, int> item in dictionary2)
			{
			}
			Collor = dictionary2;
		}

		private void GenerateInvert()
		{
			int length = Kombo.GetLength(0);
			int length2 = Kombo.GetLength(1);
			KomboInvert = new string[length, length2];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					if (Kombo[i, j] == "1")
					{
						KomboInvert[i, j] = "2";
					}
					else if (Kombo[i, j] == "2")
					{
						KomboInvert[i, j] = "1";
					}
					else
					{
						KomboInvert[i, j] = Kombo[i, j];
					}
				}
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<MoZayka_Kombo.MoZayka_Jeton, int> _003C_003E9__31_0;

		public static Func<MoZayka_Kombo.MoZayka_Jeton, int> _003C_003E9__31_1;

		public static Func<MoZayka_Kombo.MoZayka_Jeton, string> _003C_003E9__31_2;

		public static Func<string, bool> _003C_003E9__31_3;

		public static Func<MoZayka_Kombo.MoZayka_Jeton, int> _003C_003E9__33_0;

		public static Func<string, bool> _003C_003E9__34_1;

		public static Func<KeyValuePair<int, int>, int> _003C_003E9__34_2;

		public static Func<KeyValuePair<int, int>, int> _003C_003E9__34_0;

		public static Func<char, bool> _003C_003E9__37_0;

		public static Func<char, bool> _003C_003E9__37_1;

		public static Func<char, bool> _003C_003E9__39_0;

		public static Func<char, bool> _003C_003E9__42_0;

		public static Func<_003C_003Ef__AnonymousType1<int, string, bool>, bool> _003C_003E9__46_0;

		public static Func<_003C_003Ef__AnonymousType2<string, int>, bool> _003C_003E9__46_2;

		public static Func<_003C_003Ef__AnonymousType2<string, int>, int> _003C_003E9__46_3;

		public static Func<_003C_003Ef__AnonymousType2<string, int>, string> _003C_003E9__46_4;

		public static Func<char, bool> _003C_003E9__47_0;

		public static Func<char, bool> _003C_003E9__47_1;

		public static Func<char, bool> _003C_003E9__47_2;

		public static Func<IWebDriver, IWebElement?> _003C_003E9__51_0;

		public static Func<char, bool> _003C_003E9__52_0;

		public static Func<IWebDriver, IWebElement?> _003C_003E9__59_0;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__65_0;

		public static Func<char, bool> _003C_003E9__65_2;

		public static Func<char, bool> _003C_003E9__65_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__66_0;

		public static Func<char, bool> _003C_003E9__66_2;

		public static Func<char, bool> _003C_003E9__66_1;

		public static System.Windows.Forms.MethodInvoker _003C_003E9__67_0;

		public static Func<char, bool> _003C_003E9__67_1;

		public static Func<char, bool> _003C_003E9__67_2;

		public static Func<char, bool> _003C_003E9__67_3;

		public static Func<char, bool> _003C_003E9__69_0;

		public static Func<char, bool> _003C_003E9__69_1;

		public static Func<char, bool> _003C_003E9__69_2;

		public static Func<char, bool> _003C_003E9__69_3;

		public static Func<(string Name, int Stat, int Added, int Weight), int> _003C_003E9__72_0;

		public static Func<(string Name, int Stat, int Added, int Weight), (string Name, int Stat, int Added, int Weight)> _003C_003E9__72_1;

		public static Func<(string Name, int Stat, int Added, int Weight), bool> _003C_003E9__72_2;

		public static Func<(string Name, int Stat, int Added, int Weight), int> _003C_003E9__72_3;

		public static Func<(string Name, int Stat, int Added, int Weight), int> _003C_003E9__72_5;

		public static Comparison<(int Id, int Score, int Distance, List<string> Path)> _003C_003E9__74_0;

		public static Func<(int Id, int Score, int Distance, List<string> Path), bool> _003C_003E9__74_1;

		public static Func<(int Id, int Score, int Distance, List<string> Path), int> _003C_003E9__74_2;

		public static Func<char, bool> _003C_003E9__74_3;

		public static Func<char, bool> _003C_003E9__74_4;

		public static Func<char, bool> _003C_003E9__74_5;

		internal int _003CMoZayka_Draw_JPT_003Eb__31_0(MoZayka_Kombo.MoZayka_Jeton jeton)
		{
			return jeton.Quantity;
		}

		internal int _003CMoZayka_Draw_JPT_003Eb__31_1(MoZayka_Kombo.MoZayka_Jeton jeton)
		{
			return jeton.Quantity;
		}

		internal string _003CMoZayka_Draw_JPT_003Eb__31_2(MoZayka_Kombo.MoZayka_Jeton jeton)
		{
			return jeton.Name;
		}

		internal bool _003CMoZayka_Draw_JPT_003Eb__31_3(string value)
		{
			return value != "0";
		}

		internal int _003CGetMoZaykaJetons_003Eb__33_0(MoZayka_Kombo.MoZayka_Jeton j)
		{
			return j.Quantity;
		}

		internal bool _003CBotvaSkachki_003Eb__34_1(string x)
		{
			return x != "0";
		}

		internal int _003CBotvaSkachki_003Eb__34_2(KeyValuePair<int, int> x)
		{
			return x.Key;
		}

		internal int _003CBotvaSkachki_003Eb__34_0(KeyValuePair<int, int> x)
		{
			return x.Value;
		}

		internal bool _003CBotvaDrom_003Eb__37_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CBotvaDrom_003Eb__37_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPiratyMory_003Eb__39_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CDyxRojdestva_003Eb__42_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CMonstrograd_ByePyl_003Eb__46_0(_003C_003Ef__AnonymousType1<int, string, bool> x)
		{
			return x.Bool;
		}

		internal bool _003CMonstrograd_ByePyl_003Eb__46_2(_003C_003Ef__AnonymousType2<string, int> x)
		{
			return x.Price > 0;
		}

		internal int _003CMonstrograd_ByePyl_003Eb__46_3(_003C_003Ef__AnonymousType2<string, int> x)
		{
			return x.Price;
		}

		internal string _003CMonstrograd_ByePyl_003Eb__46_4(_003C_003Ef__AnonymousType2<string, int> x)
		{
			return x.Code;
		}

		internal bool _003CMonstrograd_ByeArty_003Eb__47_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CMonstrograd_ByeArty_003Eb__47_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CMonstrograd_ByeArty_003Eb__47_2(char c)
		{
			return char.IsDigit(c);
		}

		internal IWebElement? _003CCheckEnergy_003Eb__51_0(IWebDriver d)
		{
			return d.IsFindElement(By.XPath("//span[@class='borderred_text']/b[@class='bravery_now']"));
		}

		internal bool _003CProcessActions_003Eb__52_0(char c)
		{
			return char.IsDigit(c);
		}

		internal IWebElement? _003CProcessAdventureRound_003Eb__59_0(IWebDriver d)
		{
			return d.IsFindElement(By.XPath("//span[@class='borderred_text']/b[@class='bravery_now']"));
		}

		internal void _003CAlfaCyrTavra_003Eb__65_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: АльфаСырТавра";
		}

		internal bool _003CAlfaCyrTavra_003Eb__65_2(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CAlfaCyrTavra_003Eb__65_1(char c)
		{
			return char.IsDigit(c);
		}

		internal void _003CAtlantida_003Eb__66_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Атлантида";
		}

		internal bool _003CAtlantida_003Eb__66_2(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CAtlantida_003Eb__66_1(char c)
		{
			return char.IsDigit(c);
		}

		internal void _003CPesochnica_003Eb__67_0()
		{
			((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Песочница";
		}

		internal bool _003CPesochnica_003Eb__67_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_003Eb__67_2(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_003Eb__67_3(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_KlickMi_003Eb__69_0(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_KlickMi_003Eb__69_1(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_KlickMi_003Eb__69_2(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPesochnica_KlickMi_003Eb__69_3(char c)
		{
			return char.IsDigit(c);
		}

		internal int _003CRybalka_DistributePoints_003Eb__72_0((string Name, int Stat, int Added, int Weight) a)
		{
			return a.Weight;
		}

		internal (string Name, int Stat, int Added, int Weight) _003CRybalka_DistributePoints_003Eb__72_1((string Name, int Stat, int Added, int Weight) a)
		{
			return (Name: a.Name, Stat: a.Stat, Added: 0, Weight: a.Weight);
		}

		internal bool _003CRybalka_DistributePoints_003Eb__72_2((string Name, int Stat, int Added, int Weight) a)
		{
			return a.Stat + a.Added < 24;
		}

		internal int _003CRybalka_DistributePoints_003Eb__72_3((string Name, int Stat, int Added, int Weight) a)
		{
			return a.Weight;
		}

		internal int _003CRybalka_DistributePoints_003Eb__72_5((string Name, int Stat, int Added, int Weight) a)
		{
			return a.Stat;
		}

		internal int _003CPrikluchenie_003Eb__74_0((int Id, int Score, int Distance, List<string> Path) x, (int Id, int Score, int Distance, List<string> Path) y)
		{
			return x.Score.CompareTo(y.Score);
		}

		internal bool _003CPrikluchenie_003Eb__74_1((int Id, int Score, int Distance, List<string> Path) i)
		{
			return i.Distance < 3;
		}

		internal int _003CPrikluchenie_003Eb__74_2((int Id, int Score, int Distance, List<string> Path) i)
		{
			return i.Score;
		}

		internal bool _003CPrikluchenie_003Eb__74_3(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPrikluchenie_003Eb__74_4(char c)
		{
			return char.IsDigit(c);
		}

		internal bool _003CPrikluchenie_003Eb__74_5(char c)
		{
			return char.IsDigit(c);
		}
	}

	private IWebDriver _driver;

	public Dictionary<int, string> akcii = Akcii.AkciiDictionary();

	private Dictionary<string, string> akciiString = Akcii.AkciiString();

	public Dictionary<string, int[]> arShedevr = Akcii.AkciiShedevr();

	public Dictionary<string, Func<DateTime>> actionMethods = new Dictionary<string, Func<DateTime>>();

	public DateTime AdateTime { get; set; }

	public string _properties { get; set; }

	private int monstrGradPyl { get; set; }

	private Func<DateTime> GetMethod(string methodName)
	{
		MethodInfo method = typeof(AkciiServer).GetMethod(methodName);
		if (method == null)
		{
			throw new MissingMethodException("Метод " + methodName + " не найден");
		}
		return () => (DateTime)method.Invoke(this, null);
	}

	private void InitializeActionMethods()
	{
		foreach (KeyValuePair<string, string> item in akciiString)
		{
			actionMethods[item.Key] = GetMethod(item.Value);
		}
	}

	public void SetverTimeData()
	{
		AdateTime = DateTime.Now;
	}

	public AkciiServer(IWebDriver driver, string _Properties, string _PropertiesPesochnica)
	{
		_driver = driver;
		_properties = _Properties;
		AdateTime = DateTime.Now;
		monstrGradPyl = 0;
		InitializeActionMethods();
	}

	public DateTime NULL()
	{
		if (AdateTime > DateTime.Now)
		{
			return AdateTime;
		}
		return AdateTime = DateTime.Now.AddMinutes(60.0);
	}

	public DateTime AkciiServerMain()
	{
		if (AdateTime > DateTime.Now)
		{
			return AdateTime;
		}
		if (AppSettings.Get(_properties, 0) == 0)
		{
			return AdateTime.AddMinutes(45.0);
		}
		string key = akcii[AppSettings.Get(_properties, 0)].ToString();
		try
		{
			if (actionMethods.ContainsKey(key))
			{
				return AdateTime = actionMethods[key]();
			}
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime MoZayka()
	{
		List<MoZayka_Kombo> list = new List<MoZayka_Kombo>();
		list.Add(new MoZayka_Kombo("КВАДРАТ БОТВИНИЧА", 7, boolValue: false, new string[3, 3]
		{
			{ "1", "1", "1" },
			{ "1", "2", "1" },
			{ "1", "1", "1" }
		}));
		list.Add(new MoZayka_Kombo("КРЕСТ", 7, boolValue: false, new string[3, 3]
		{
			{ "0", "1", "0" },
			{ "1", "1", "1" },
			{ "0", "1", "0" }
		}));
		list.Add(new MoZayka_Kombo("ВСЕ ВМЕСТЕ", 3, boolValue: false, new string[2, 2]
		{
			{ "1", "2" },
			{ "3", "4" }
		}));
		list.Add(new MoZayka_Kombo("РАМКА", 20, boolValue: false, new string[6, 6]
		{
			{ "1", "1", "1", "1", "1", "1" },
			{ "1", "0", "0", "0", "0", "1" },
			{ "1", "0", "0", "0", "0", "1" },
			{ "1", "0", "0", "0", "0", "1" },
			{ "1", "0", "0", "0", "0", "1" },
			{ "1", "1", "1", "1", "1", "1" }
		}));
		UpdateStatus("Статус: МоЗайка ");
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"event.php?a=mozaika\"]"), "МоЗайка");
		DateTime dateTime = GetMoZaykaDateTime();
		if (dateTime > DateTime.Now)
		{
			UpdateStatus("Статус: ");
			return DateTime.Now.AddMinutes((dateTime - DateTime.Now).TotalMinutes + 3.0);
		}
		list = MaZayka_Kombo_Bool(list);
		foreach (MoZayka_Kombo item in list)
		{
		}
		MoZayka_Logika(list);
		if (_driver.IsFindElement(By.XPath("//span[contains(string(.),'Сбросить')]")).IsClick("Сбросить", 1000))
		{
			_driver.WaitFind(By.XPath("//span[contains(text(),\"Да, сбросить\")]"), TimeSpan.FromSeconds(5L));
			_driver.IsFindElement(By.XPath("//span[contains(text(),\"Да, сбросить\")]")).IsClick("Да, сбросить", 1000);
		}
		if (_driver.IsFindElement(By.XPath("//span[contains(string(.),'Активировать')]")).IsClick("Активировать", 1000))
		{
			_driver.WaitFind(By.XPath("//span[contains(text(),\"Да, активировать\")]"), TimeSpan.FromSeconds(5L));
			_driver.IsFindElement(By.XPath("//span[contains(text(),\"Да, активировать\")]")).IsClick("Да, активировать", 1000);
		}
		dateTime = GetMoZaykaDateTime();
		if (dateTime > DateTime.Now)
		{
			UpdateStatus("Статус: ");
			return DateTime.Now.AddMinutes((dateTime - DateTime.Now).TotalMinutes + 1.0);
		}
		UpdateStatus("Статус: ");
		return DateTime.Now.AddMinutes(5.0);
		DateTime GetMoZaykaDateTime()
		{
			return _driver.DateTimeCount("//div[contains(@id,'mozaika_cooldown')]");
		}
	}

	private List<MoZayka_Kombo> MaZayka_Kombo_Bool(List<MoZayka_Kombo> combos)
	{
		_driver.IsFindElement(By.XPath("//a[contains(string(.),\"Список комбо\") and not(contains(@class,\"open\"))]")).IsClick("Список комбо", 1000);
		foreach (MoZayka_Kombo combo in combos)
		{
			if (_driver.IsFindElement(By.XPath("//h3[contains(string(.),\"" + combo.Name + "\")]//..//..//div[@class=\"buy_block\"]")) != null)
			{
				combo.Bool = true;
			}
		}
		_driver.IsFindElement(By.XPath("//a[contains(string(.),\"Игровая доска\") and not(contains(@class,\"open\"))]")).IsClick("Игровая доска", 1000);
		return combos;
	}

	private void MoZayka_Logika(List<MoZayka_Kombo> combos)
	{
		MoZayka_Kombo combo = ((!combos.ElementAt(1).Bool) ? combos.ElementAt(0) : combos.ElementAt(1));
		List<MoZayka_Kombo.MoZayka_Table_Game> moZayka_Table_Games;
		for (int i = 0; i < 4; i++)
		{
			moZayka_Table_Games = GetMoZayka_Table_Games();
			if (moZayka_Table_Games.Count == 0)
			{
				break;
			}
			foreach (MoZayka_Kombo.MoZayka_Table_Game item in moZayka_Table_Games)
			{
			}
			int[] map = new int[2];
			bool flag = CanPlaceSquare(moZayka_Table_Games, combo, out map);
			if (flag)
			{
				MoZayka_Draw_JPT(map[0], map[1], combo);
			}
			if (!flag)
			{
				break;
			}
		}
		if (!combos.ElementAt(1).Bool || !combos.ElementAt(2).Bool)
		{
			return;
		}
		moZayka_Table_Games = GetMoZayka_Table_Games();
		_ = moZayka_Table_Games.Count;
		foreach (MoZayka_Kombo.MoZayka_Table_Game item2 in moZayka_Table_Games)
		{
		}
		int[] map2 = new int[2];
		if (CanPlaceSquare(moZayka_Table_Games, combos.ElementAt(2), out map2))
		{
			MoZayka_Draw_JPT(map2[0], map2[1], combos.ElementAt(2), reverci: true);
		}
	}

	private List<MoZayka_Kombo.MoZayka_Table_Game> NormalizeGames(List<MoZayka_Kombo.MoZayka_Table_Game> games)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		int num = 1;
		foreach (MoZayka_Kombo.MoZayka_Table_Game game in games)
		{
			string cell = game.Cell;
			if (cell != "0")
			{
				if (!dictionary.ContainsKey(cell))
				{
					dictionary[cell] = num;
					num++;
				}
				game.Cell = dictionary[cell].ToString();
			}
		}
		return games;
	}

	private bool CanPlaceSquare(List<MoZayka_Kombo.MoZayka_Table_Game> field, MoZayka_Kombo combo, out int[] map)
	{
		map = new int[2];
		List<MoZayka_Kombo.MoZayka_Jeton> moZaykaJetons = GetMoZaykaJetons();
		foreach (MoZayka_Kombo.MoZayka_Jeton item in moZaykaJetons)
		{
		}
		if (!canJetonsBool(moZaykaJetons, combo))
		{
			map[0] = 0;
			map[1] = 0;
			return false;
		}
		int length = combo.Kombo.GetLength(0);
		int length2 = combo.Kombo.GetLength(1);
		int num = 6;
		int num2 = 6;
		for (int i = 0; i < num - length + 1; i++)
		{
			for (int j = 0; j < num2 - length2 + 1; j++)
			{
				if (canPlaceBool(field, combo, i, j))
				{
					map[0] = i;
					map[1] = j;
					return true;
				}
			}
		}
		map[0] = 0;
		map[1] = 0;
		return false;
	}

	private bool canJetonsBool(List<MoZayka_Kombo.MoZayka_Jeton> jetons, MoZayka_Kombo combo)
	{
		List<KeyValuePair<string, int>> list = combo.Collor.ToList();
		if (jetons.Count < list.Count)
		{
			return false;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (!(list[i].Key == "0") && jetons[i].Quantity < list[i].Value)
			{
				return false;
			}
		}
		return true;
	}

	private bool canPlaceBool(List<MoZayka_Kombo.MoZayka_Table_Game> field, MoZayka_Kombo combo, int i, int j)
	{
		int length = combo.Kombo.GetLength(0);
		int length2 = combo.Kombo.GetLength(1);
		for (int x = 0; x < length; x++)
		{
			int y;
			for (y = 0; y < length2; y++)
			{
				MoZayka_Kombo.MoZayka_Table_Game moZayka_Table_Game = field.FirstOrDefault((MoZayka_Kombo.MoZayka_Table_Game f) => int.Parse(f.Row) == i + x && int.Parse(f.Col) == j + y);
				if (moZayka_Table_Game == null || moZayka_Table_Game.Cell != "0")
				{
					return false;
				}
			}
		}
		return true;
	}

	private void MoZayka_Draw_JPT(int i, int j, MoZayka_Kombo combo, bool reverci = false)
	{
		string[] array = new string[4] { "1", "2", "3", "4" };
		List<MoZayka_Kombo.MoZayka_Jeton> moZaykaJetons = GetMoZaykaJetons();
		List<MoZayka_Kombo.MoZayka_Jeton> list = ((!reverci) ? moZaykaJetons.OrderByDescending((MoZayka_Kombo.MoZayka_Jeton jeton) => jeton.Quantity).ToList() : moZaykaJetons.OrderBy((MoZayka_Kombo.MoZayka_Jeton jeton) => jeton.Quantity).ToList());
		string[] array2 = list.Select((MoZayka_Kombo.MoZayka_Jeton jeton) => jeton.Name).ToArray();
		if (list == null || list.Count == 0 || list[0].Quantity <= 0)
		{
			return;
		}
		int length = combo.Kombo.GetLength(0);
		int length2 = combo.Kombo.GetLength(1);
		int num = combo.Kombo.Cast<string>().Count((string value) => value != "0");
		int num2 = 0;
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			if (num2 >= num)
			{
				break;
			}
			_driver.IsFindElement(By.XPath("//div[not(contains(@class,'select')) and contains(@class,'" + array2[num3] + "')]")).IsClick(array2[num3], 1000);
			for (int num4 = 0; num4 < length; num4++)
			{
				for (int num5 = 0; num5 < length2; num5++)
				{
					if (!(combo.Kombo[num4, num5] != array[num3]))
					{
						string xpathToFind = $"//td[@data-row=\"{i + num4}\" and @data-col=\"{j + num5}\"]";
						string text = _driver.IsFindElement(By.XPath(xpathToFind)).isGetAttribute("outerHTML");
						_driver.IsFindElement(By.XPath(xpathToFind)).IsClick(array2[num3], 1000);
						string text2 = _driver.IsFindElement(By.XPath(xpathToFind)).isGetAttribute("outerHTML");
						if (text == text2)
						{
							_driver.IsFindElement(By.XPath(xpathToFind)).IsClick(array2[num3], 1000);
						}
						num2++;
					}
				}
			}
		}
	}

	private List<MoZayka_Kombo.MoZayka_Table_Game> GetMoZayka_Table_Games()
	{
		List<MoZayka_Kombo.MoZayka_Table_Game> list = new List<MoZayka_Kombo.MoZayka_Table_Game>();
		Regex regex = new Regex("(?ims)data-row=.(\\d).*?data-col=.(\\d).*?class=.(.*?).>");
		string input = _driver.IsFindElement(By.XPath("//div[@class='game_background game_background1']")).isGetAttribute("outerHTML").Replace("cell", "")
			.Replace(" ", string.Empty)
			.Replace("placed", string.Empty);
		MatchCollection matchCollection = regex.Matches(input);
		foreach (Match item2 in matchCollection)
		{
			string text = item2.Groups[3].Value;
			if (text == "")
			{
				text = "0";
			}
			MoZayka_Kombo.MoZayka_Table_Game item = new MoZayka_Kombo.MoZayka_Table_Game
			{
				Row = item2.Groups[1].Value,
				Col = item2.Groups[2].Value,
				Cell = text
			};
			list.Add(item);
		}
		return NormalizeGames(list);
	}

	private List<MoZayka_Kombo.MoZayka_Jeton> GetMoZaykaJetons()
	{
		List<MoZayka_Kombo.MoZayka_Jeton> list = new List<MoZayka_Kombo.MoZayka_Jeton>();
		Regex regex = new Regex("(?ims)(mozaika__jetons_jeton\\d).*?(\\d+) из");
		MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@class='mozaika__rightBlock']")).isGetAttribute("outerHTML"));
		foreach (Match item2 in matchCollection)
		{
			MoZayka_Kombo.MoZayka_Jeton item = new MoZayka_Kombo.MoZayka_Jeton
			{
				Name = item2.Groups[1].Value,
				Quantity = Convert.ToInt32(item2.Groups[2].Value)
			};
			list.Add(item);
		}
		return list.OrderByDescending((MoZayka_Kombo.MoZayka_Jeton j) => j.Quantity).ToList();
	}

	public DateTime BotvaSkachki()
	{
		UpdateStatus("Статус: Ботвадром Скачки ");
		if (_driver.isExecuteScriptClick(By.XPath("//div[@id=\"event_189\"]/a"), "Бустер Пак", 2000))
		{
			By obj = By.XPath("//div[@class=\"booster-pack-section\"]//span[contains(string(.),\"получить\")]/input");
			_driver.isExecuteScriptClick(obj, "Забрать ПАК", 1000);
		}
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/event.php?a=botvadrom\"]"), "Ботвадром");
		DateTime dateTime = _driver.DateTimeCount("//div[@id=\"timers_block_timer1\"]");
		double totalMinutes = (dateTime - DateTime.Now).TotalMinutes;
		if (totalMinutes < 30.0)
		{
			UpdateStatus("Статус: ");
			return AdateTime = DateTime.Now.AddMinutes(totalMinutes + 20.0);
		}
		if (totalMinutes > 60.0)
		{
			UpdateStatus("Статус: ");
			return AdateTime = DateTime.Now.AddMinutes(totalMinutes - 45.0);
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"flea-list__avatar\"]")).IsClick("В блоху", 1000);
		Dictionary<int, List<string>> dictionary = BotvaSkachkiParseAllFleaCells(_driver.PageSource);
		foreach (KeyValuePair<int, List<string>> item in dictionary)
		{
			int num = item.Value.Count((string x) => x != "0");
		}
		Dictionary<int, int> source = BotvaSkachkiParseBoostersCount(_driver.PageSource);
		foreach (KeyValuePair<int, int> item2 in source.OrderBy((KeyValuePair<int, int> x) => x.Key))
		{
		}
		int num2 = source.Sum((KeyValuePair<int, int> x) => x.Value);
		UpdateStatus("Статус: ");
		return AdateTime = DateTime.Now.AddMinutes(totalMinutes + 20.0);
	}

	public Dictionary<int, List<string>> BotvaSkachkiParseAllFleaCells(string html)
	{
		Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
		Regex regex = new Regex("data-flea-id=\"(\\d+)\"[\\s\\S]*?</tr>", RegexOptions.Singleline);
		Regex regex2 = new Regex("data-cell-index=\"(\\d+).*?cell_item.*?(2m\\.png|4m\\.png|5m\\.png|3m\\.png|none)", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(html);
		foreach (Match item in matchCollection)
		{
			if (!item.Groups[1].Success)
			{
				continue;
			}
			int key = int.Parse(item.Groups[1].Value);
			string value = item.Value;
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new List<string>();
			}
			MatchCollection matchCollection2 = regex2.Matches(value);
			foreach (Match item2 in matchCollection2)
			{
				if (item2.Groups[2].Success)
				{
					string value2 = item2.Groups[2].Value;
					dictionary[key].Add((value2 == "none") ? "0" : value2.Replace("m.png", ""));
				}
			}
		}
		return dictionary;
	}

	public Dictionary<int, int> BotvaSkachkiParseBoostersCount(string htmlContent)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Regex regex = new Regex("data-booster-id=\"(\\d+)\"(?:(?!data-booster-id)[\\s\\S])*?booster_item_count[^>]*>(\\d+)<", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(htmlContent);
		foreach (Match item in matchCollection)
		{
			if (item.Groups[1].Success && item.Groups[2].Success)
			{
				int key = int.Parse(item.Groups[1].Value);
				int value = int.Parse(item.Groups[2].Value);
				dictionary[key] = value;
			}
		}
		return dictionary;
	}

	public DateTime BotvaDrom()
	{
		ulong result = 0uL;
		UpdateStatus("Статус: Ботвадром ");
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/event.php?a=birthday\"]"), "Ботвадром");
		if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"НА СТАРТ\")]//input[@type=\"submit\"]")).IsClick("НА СТАРТ", 1000))
		{
			UpdateStatus("Статус: ");
			return AdateTime = DateTime.Now.AddMinutes(2.0);
		}
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"На гонке\")]/a")).IsClick("На гонке", 1000);
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Посмотреть результаты\")]/a")).IsClick("Посмотреть результаты", 1000);
		if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Принять\")]//input[@type=\"submit\"]")).IsClick("Принять", 1000))
		{
			_driver.WaitFind(By.XPath("//span[contains(string(.),\"Назад\")]/a"), TimeSpan.FromSeconds(5L));
			_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Назад\")]/a")).IsClick("Назад", 1000);
		}
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Принять\")]//input[@type=\"submit\"]")).IsClick("Принять", 1000);
		_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Назад\")]//input[@type=\"submit\"]")).IsClick("Назад", 1000);
		ulong.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//p[contains(string(.),\"У вас:\")]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result);
		if (result != 0)
		{
			string[] array = new string[3] { "agility", "maneuverability", "endurance" };
			ulong[] array2 = new ulong[3];
			int[] array3 = new int[3];
			for (int num = 0; num < array.Length; num++)
			{
				array3[num] = num;
				ulong.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[@statname=\"" + array[num] + "\"]")).isGetAttribute("statvalue")
					where char.IsDigit(c)
					select c), out array2[num]);
			}
			Array.Sort(array2, array3);
			for (int num2 = 0; num2 < array.Length; num2++)
			{
			}
			_driver.IsFindElement(By.XPath("//div[@statname=\"" + array[array3[0]] + "\"]//div[contains(@class,\"stat_update_form__btn max\")]")).IsClick("Улучшить " + array[array3[0]], 2000);
			_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Улучшить\")]//input[@type=\"submit\" and not(@disabled)]")).IsClick("Улучшить", 1000);
		}
		DateTime dateTime2 = _driver.DateTimeCount("//div[contains(@id,\"_rest_timer\")]");
		if (dateTime2 > DateTime.Now)
		{
			UpdateStatus("Статус: ");
			return AdateTime = DateTime.Now.AddMinutes((dateTime2 - DateTime.Now).TotalMinutes + 1.0);
		}
		UpdateStatus("Статус: ");
		return AdateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime Nastavleniy()
	{
		UpdateStatus("Статус: Наставления ");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href='event.php?a=mastertips']"), "Наставления2024"))
		{
			Thread.Sleep(1000);
		}
		for (int i = 0; i < 3; i++)
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"ОТКРЫТЬ НАСТАВЛЕНИЕ\")]")).IsClick("ОТКРЫТЬ НАСТАВЛЕНИЕ", 2000))
			{
				_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Отлично\")]")).IsClick("Отлично", 1000);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"ПОЛУЧИТЬ НАСТАВЛЕНИЕ\")]")).IsClick("ПОЛУЧИТЬ НАСТАВЛЕНИЕ", 2000))
			{
				_driver.IsFindElement(By.XPath("//div/span[contains(string(.),\"Принять\")]")).IsClick("Принять", 1000);
			}
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(40.0);
	}

	public DateTime PiratyMory()
	{
		UpdateStatus("Статус: Пираты Лазурного Моря ");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href='event.php?a=pirates']"), "Пираты"))
		{
			Thread.Sleep(1000);
		}
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3L));
		string[] array = _driver.IsFindElement(By.XPath("//span[@class=\"topblock__scriptPiratesAmountUpdate\"]")).isGetAttribute("outerText").Split('/');
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(string.Join("", array[i].Where((char c) => char.IsDigit(c))), out array2[i]);
		}
		if (_driver.IsFindElement(By.XPath("//span[contains(string(.),\"Открыть\")]//../input")).IsClick("Открыть", 1000))
		{
			string xpathToFind = "//div[contains(@class,\"morro_box_circle_button\") and contains(string(.),\"УРА!\")]";
			webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(xpathToFind)));
			_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Ура");
		}
		for (int num = 0; num < 1; num++)
		{
			if (array2[0] == 0)
			{
				break;
			}
			ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"pirates_map\")]/div[contains(@class,\"BenGunn\") or contains(@class,\"rum\")]"));
			foreach (IWebElement item2 in readOnlyCollection)
			{
				item2.IsClick("Клик " + item2.isGetAttribute("class"));
			}
			readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"cell chest\") ]"));
			foreach (IWebElement item3 in readOnlyCollection)
			{
				item3.IsClick("Клик " + item3.isGetAttribute("class"));
				webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(string(.),\"УРА!\")]")));
				_driver.IsFindElement(By.XPath("//span[contains(string(.),\"УРА!\")]")).IsClick("Ура");
			}
			readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"covered\") and contains(@class,\"available\") and not(contains(@class,\"timer\")) ]"));
			foreach (IWebElement item4 in readOnlyCollection)
			{
				if (array2[0] == 0)
				{
					break;
				}
				item4.IsClick("Кликк Плыть");
				array2[0]--;
			}
			readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"glade\") and not(contains(@class,\"covered\")) and not(contains(@class,\"timer\"))]"));
			foreach (IWebElement item5 in readOnlyCollection)
			{
				if (array2[0] == 0)
				{
					break;
				}
				item5.IsClick("Кликк ловушка/гора");
				array2[0]--;
			}
			readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"trap\") and not(contains(@class,\"covered\")) and not(contains(@class,\"timer\"))]"));
			foreach (IWebElement item6 in readOnlyCollection)
			{
				if (array2[0] == 0)
				{
					break;
				}
				item6.IsClick("Кликк Гора");
				array2[0]--;
			}
			readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"monster\") and not(contains(@class,\"covered\")) and not(contains(@class,\"timer\"))]"));
			foreach (IWebElement item7 in readOnlyCollection)
			{
				item7.IsClick("Кликк Монстр");
				string xpathToFind2 = "//span[contains(string(.),\"Сразиться!\")]";
				webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(xpathToFind2)));
				_driver.IsFindElement(By.XPath(xpathToFind2)).IsClick("Сразиться", 1000);
				xpathToFind2 = "//span[contains(string(.),\"УРА!\")]";
				webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(xpathToFind2)));
				_driver.IsFindElement(By.XPath(xpathToFind2)).IsClick("Ура");
			}
		}
		ReadOnlyCollection<IWebElement> readOnlyCollection2 = _driver.FindElements(By.XPath("(//span[contains(@class,\"timerSpan\")])"));
		List<DateTime> list = new List<DateTime>();
		int num2 = 1;
		foreach (IWebElement item8 in readOnlyCollection2)
		{
			DateTime item = _driver.DateTimeCount("(//span[contains(@class,\"timerSpan\")])[" + num2 + "]");
			list.Add(item);
			num2++;
		}
		if (list.Min() > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return AdateTime = list.Min().AddMinutes(1.0);
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(10.0);
	}

	public DateTime ZeliyVari()
	{
		UpdateStatus("Статус:ЗельяВари");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href='event.php?a=potion_tavern']"), "ЗельяВари"))
		{
			Thread.Sleep(1000);
		}
		DateTime dateTime = _driver.DateTimeCount("//div[@id=\"tavern_main_timer\"]");
		if (dateTime > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return AdateTime = dateTime.AddMinutes(1.0);
		}
		List<(string Name, int Stat, int Added, int Weight)> source = new List<(string Name, int Stat, int Added, int Weight)>
		{
			("А настроения ноль", 0, 4, 0),
			("в догонялки играли", 0, 0, 4),
			("вещи утюгом прожгла", 0, 4, 0),
			("ослаб после работы", 0, 3, 1),
			("Надо избавиться", 2, 0, 2),
			("да убежала зверушка", 0, 1, 3),
			("Ещё и взгрустнул немного", 0, 1, 3),
			("И горло немного приболело", 3, 1, 0),
			("Болит горло, надо лечить", 3, 1, 0),
			("Детки игрались, устали что ужас", 1, 0, 3),
			("Утомилась-утомилась... Звезды говорят", 0, 1, 3),
			("Что-то силёнок маловато...", 1, 1, 2),
			("Кхм. Зелье из Зверолека и Антигруста", 2, 2, 0),
			("Посадила связки, кашель, сигнал красный", 4, 0, 0),
			("У меня впереди автограф-сессия на тысячу человек", 0, 0, 4),
			("Я грустный, очень грустный!", 0, 3, 1),
			("Скоро в путь. Надо избавиться от головной боли и усталости", 2, 0, 2),
			("Выступала под открытым небом, сил нет..", 1, 1, 2),
			("Грустинка в рот попала, эх... Так ещё и голова немного болит", 1, 2, 1),
			("Депрессия. Самая настоящая. Надоело всё, грустно", 0, 4, 0),
			("Детишкам грустно, да силёнки немного кончились...", 0, 3, 1),
			("Очень грустно без внимания сильного мужчины...", 3, 0, 1),
			("Простыл на сквозняке, пока стоял дневальным.", 2, 1, 1),
			("Грусть-напасть, опять завтра полный рабочий день...", 3, 1, 0),
			("Спина отнимается, представляешь?", 3, 1, 0),
			("Мне нужно зелье из Антигруста с щепоткой Зверолека", 1, 3, 0),
			("Караул! Дети слегли с ангиной.", 4, 0, 0),
			("Стоило присесть, как сразу ноги", 2, 0, 2),
			("Фух, так долго пела, что приболела голова!", 2, 1, 1),
			("Фух, всех клиентов приняла, очень устала!", 1, 0, 3),
			("После похода в Храм парящих истин нет сил.", 0, 0, 4),
			("Ноги отнимаются, а к врачу уже не попасть!", 3, 0, 1),
			("Сегодня я совсем без клиентов, аура страдает, грущу...", 0, 3, 1),
			("Детки мои бежали за летуном, да убежала зверушка...", 0, 1, 3),
			("Болит горло, надо лечить. Ещё и загрустила,", 2, 2, 0),
			("Сейчас сгорю, голову жарит от гриппа! К такой напасти бы ещё немного веселья...", 3, 1, 0),
			("Охх, руки болят и ноют... Целый день делала расклады! Ещё и немного устала..", 3, 0, 1),
			("Ферма вымотала! Брр, устал, сил нет...", 1, 0, 3),
			("Нужно зелье из Антигруста с щепоткой Подкача и Зверолека.", 1, 2, 1),
			("Пошла в экспедицию, но ни настроения, ни сил. Говорят, твои зелья помогают", 0, 2, 2),
			("Пока отбивалась от свинтусов, покрылась синяками и ранками. Полечиться бы", 4, 0, 0),
			("Живот так болит! И грустно! Жизнь моя жестянка", 2, 2, 0),
			("Шёл до сада целый день, пришёл к ночи... Плодов ноль! Теперь ни радости, ни сил... Эх", 0, 2, 2)
		};
		List<(string, int, string)> list = new List<(string, int, string)>
		{
			("Антигрус ", 0, "ico_newres29"),
			("Зверолек", 0, "ico_newres30"),
			("Подкач", 0, "ico_newres31")
		};
		string zagadkaText = _driver.IsFindElement(By.XPath("//div[contains(@class,\"tavern_bubble\")]")).isGetAttribute("innerText");
		(string, int, int, int) tuple = source.FirstOrDefault<(string, int, int, int)>(((string Zagadka, int Zverolek, int Antigrust, int Podkach) player) => zagadkaText.Contains(player.Zagadka));
		if (zagadkaText == "" || tuple.Item1 == null)
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"tavern_btn_content\") and contains(string(.),\"Отказать\")]/input[@type=\"submit\"]")).IsClick("Отказать");
			UpdateStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(1.0);
		}
		for (int num = 0; num < list.Count; num++)
		{
			int.TryParse(_driver.IsFindElement(By.XPath("//div[@class=\"tavern_am\"]//b[contains(@class,\"" + list[num].Item3 + "\")]//..")).isGetAttribute("innerText"), out var result);
			list[num] = (list[num].Item1, result, list[num].Item3);
		}
		if (tuple.Item2 > list[0].Item2 || tuple.Item3 > list[1].Item2 || tuple.Item4 > list[2].Item2)
		{
			UpdateStatus("Статус:");
			return AdateTime = dateTime.AddMinutes(10.0);
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int num5 = 0; num5 < 4; num5++)
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"tavern_craft_slot_border\")]//..")).IsClick("+");
			if (num2 < tuple.Item2)
			{
				_driver.IsFindElement(By.XPath("//div[@data-ingredient=\"0\"]")).IsClick("0");
				num2++;
			}
			else if (num3 < tuple.Item3)
			{
				_driver.IsFindElement(By.XPath("//div[@data-ingredient=\"1\"]")).IsClick("1");
				num3++;
			}
			else if (num4 < tuple.Item4)
			{
				_driver.IsFindElement(By.XPath("//div[@data-ingredient=\"2\"]")).IsClick("2");
				num4++;
			}
		}
		if (!_driver.IsFindElement(By.XPath("//div[contains(@class,\"tavern_craft_slot_border\")]//..")).IsClick("+"))
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"tavern_btn_content\") and contains(string(.),\"Предложить\")]/input[@type=\"submit\"]")).IsClick("Предложить");
		}
		dateTime = _driver.DateTimeCount("//div[@id=\"tavern_main_timer\"]");
		if (dateTime > DateTime.Now)
		{
			UpdateStatus("Статус:");
			return AdateTime = dateTime.AddMinutes(1.0);
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime NaOrbitu()
	{
		NaOrbitu naOrbitu = new NaOrbitu(_driver);
		return AdateTime = naOrbitu.NaOrbituMain();
	}

	public DateTime DyxRojdestva()
	{
		UpdateStatus("Статус:Дух Рождества");
		if (_driver.isExecuteScriptClick(By.XPath("//a[contains(@href,\"/event.php?a=wind\")]"), "Подарок", 1000))
		{
			_driver.IsFindElement(By.XPath("//div[@data-cmd=\"take_casket\"]/span")).IsClick("ЗабратьПодарок");
		}
		string text = "checkBoxSnejnyGolem";
		if (_driver.Url.Contains("avatar"))
		{
			text += "_Avatar";
		}
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get(text, defaultValue: false))
		{
			UpdateStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(1.0);
		}
		if (_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m8\"]"), "Клик Бодалка"))
		{
			Thread.Sleep(1000);
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"group_title_image trigger_mode\" and @data-mode=\"2\"]")).IsClick("перейтиВдух", 1000);
		_driver.IsFindElement(By.XPath("//div[@class=\"watch_mode mode2\"]//div[@class=\"flright\"]//input[@value=\"ПОИСК\"]")).IsClick("АтакаДуха1", 1000);
		_driver.IsFindElement(By.XPath("//div[@class=\"watch_mode mode2\"]//div[@class=\"flright\"]//span")).IsClick("АтакаДуха2", 1000);
		IWebElement webElement2 = _driver.IsFindElement(By.XPath("//div[contains(@class,\"bar_red_center\")]"));
		if (webElement2 != null)
		{
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Проиграл Дух");
		}
		webElement2 = _driver.IsFindElement(By.XPath("//div[contains(@class,'bar_green_center')]"));
		if (webElement2 != null)
		{
			(Application.OpenForms[0] as Form1).webBrowserLog.LogThread("Выйграл Дух");
		}
		if (_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m8\"]"), "Клик Бодалка"))
		{
			Find.Sleep(1000);
		}
		DateTime dateTime2 = _driver.DateTimeCount("//div[@id=\"wind_timer\"]");
		if (dateTime2 > DateTime.Now)
		{
			int result = 0;
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//img[contains(@onmouseover,\"'2124\")]//../div")).isGetAttribute("innerText")
				where char.IsDigit(c)
				select c), out result);
			if (result > 0)
			{
				_driver.IsFindElement(By.XPath("//input[@value=\"ИСПОЛЬЗОВАТЬ\"]")).IsClick("ИспользоватьДух", 1000);
				_driver.IsFindElement(By.XPath("//div[@class='group_title_image trigger_mode' and @data-mode='1']")).IsClick("Уйти в Бодалку", 1000);
				UpdateStatus("Статус:");
				return AdateTime = DateTime.Now.AddSeconds(10.0);
			}
			_driver.IsFindElement(By.XPath("//div[@class='group_title_image trigger_mode' and @data-mode='1']")).IsClick("Уйти в Бодалку", 1000);
			UpdateStatus("Статус:");
			return AdateTime = dateTime2.AddSeconds(30.0);
		}
		_driver.IsFindElement(By.XPath("//div[@class='group_title_image trigger_mode' and @data-mode='1']")).IsClick("Уйти в Бодалку", 1000);
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(5.0);
	}

	public DateTime ParyshieOstrova()
	{
		try
		{
			if (_driver.ResyKri() < 300)
			{
				UpdateStatus("Статус:");
				return AdateTime = DateTime.Now.AddMinutes(5.0);
			}
			UpdateStatus("Статус: Парящие Острова");
			if (_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m3\"]"), "Клик Деревня"))
			{
				Thread.Sleep(1000);
			}
			_driver.IsFindElement(By.XPath("//a[@href=\"event.php?a=dragons\"]")).IsClick("Клик Парящие Острова");
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"ОТПРАВИТЬ\")]")).IsClick("Крутить ОТПРАВИТЬ"))
			{
				LogService.LogHtml("Крутить ОТправить ");
				Thread.Sleep(2000);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//span[contains(text(),\"В ПОЛЕТЕ ЕЩЕ\")]/span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
			}
			else
			{
				AdateTime = DateTime.Now.AddMinutes(5.0);
			}
			Find.LabelStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	private int Monstrograd_GetPriceByValue(string value)
	{
		try
		{
			IWebElement elem = _driver.FindElement(By.XPath("//div[contains(@class,'box_layout')]//input[@value='" + value + "']//..//b[@class='pricescarab']"));
			string source = elem.isGetAttribute("outerText").Trim();
			string s = new string(source.Where(char.IsDigit).ToArray());
			int result;
			return int.TryParse(s, out result) ? result : 0;
		}
		catch
		{
			return 0;
		}
	}

	public void Monstrograd_ByePyl()
	{
		_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'box_x_button')]")).IsClick("Закрыть");
		bool flag = _properties.Contains("Avatar");
		bool[] array;
		bool flag2;
		if (flag)
		{
			array = new bool[3]
			{
				AppSettings.Get("checkBox_Monstrograd_Usileniy_Avatar_1", defaultValue: false),
				AppSettings.Get("checkBox_Monstrograd_Usileniy_Avatar_2", defaultValue: false),
				AppSettings.Get("checkBox_Monstrograd_Usileniy_Avatar_3", defaultValue: false)
			};
			flag2 = AppSettings.Get("checkBox_Monstrograd_Key_Avatar_1", defaultValue: false);
		}
		else
		{
			array = new bool[3]
			{
				AppSettings.Get("checkBox_Monstrograd_Usileniy_1", defaultValue: false),
				AppSettings.Get("checkBox_Monstrograd_Usileniy_2", defaultValue: false),
				AppSettings.Get("checkBox_Monstrograd_Usileniy_3", defaultValue: false)
			};
			flag2 = AppSettings.Get("checkBox_Monstrograd_Key_1", defaultValue: false);
		}
		if (!array.Any() && !flag2)
		{
			return;
		}
		string source = _driver.IsFindElement(By.XPath("//img[contains(@src,'scarabs.jpg')]//../span[@class=\"modern_amount\"]")).isGetAttribute("outerText");
		int num = int.Parse(string.Join("", source.Where(char.IsDigit)));
		if (num < monstrGradPyl)
		{
			return;
		}
		_driver.IsFindElement(By.XPath("//div[@id=\"abandoned_shop_button\"]/span")).IsClick("В Магазин");
		_driver.WaitFind(By.XPath("//div[contains(@class,\"box_layout\")]"), TimeSpan.FromSeconds(5L));
		int num2 = 0;
		num2 = ((!flag) ? (flag2 ? Monstrograd_GetPriceByValue("7") : 0) : (flag2 ? Monstrograd_GetPriceByValue("27") : 0));
		var source2 = new[]
		{
			new
			{
				Price = 0,
				Code = "6",
				Bool = array[0]
			},
			new
			{
				Price = 0,
				Code = "8",
				Bool = array[1]
			},
			new
			{
				Price = 0,
				Code = "9",
				Bool = array[2]
			}
		};
		var anon = (from x in source2
			where x.Bool
			select new
			{
				Code = x.Code,
				Price = Monstrograd_GetPriceByValue(x.Code)
			} into x
			where x.Price > 0
			orderby x.Price, x.Code
			select x).DefaultIfEmpty(null).First();
		if (anon != null)
		{
			monstrGradPyl = anon.Price;
			if ((monstrGradPyl != 0) & (num > monstrGradPyl))
			{
				_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'btn')][@rel='2'][not(contains(@class,'open'))]")).IsClick("Во Вкладку ");
				_driver.IsFindElement(By.XPath("//div[contains(@class,\"box_layout\")]//input[@value=\"" + anon.Code + "\"]//..//input[@type=\"submit\"]")).IsClick("Купить");
				monstrGradPyl = 0;
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'box_x_button')]")).IsClick("Закрыть");
			return;
		}
		monstrGradPyl = num2;
		if ((monstrGradPyl != 0) & (num > monstrGradPyl))
		{
			if (flag)
			{
				_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'btn')][@rel='1'][not(contains(@class,'open'))]")).IsClick("Во Вкладку ");
				_driver.IsFindElement(By.XPath("//div[contains(@class,\"box_layout\")]//input[@value='27']//..//input[@type='submit']")).IsClick("Купить свиток");
			}
			else
			{
				_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'btn')][@rel='3'][not(contains(@class,'open'))]")).IsClick("Во Вкладку ");
				_driver.IsFindElement(By.XPath("//div[contains(@class,\"box_layout\")]//input[@value='7']//..//input[@type='submit']")).IsClick("Купить key");
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'box_x_button')]")).IsClick("Закрыть");
		}
		else
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'box_x_button')]")).IsClick("Закрыть");
		}
	}

	public void Monstrograd_ByeArty()
	{
		bool[] array = ((!_properties.Contains("avatar")) ? new bool[3]
		{
			AppSettings.Get("checkBox_MonstrogradArt_1", defaultValue: false),
			AppSettings.Get("checkBox_MonstrogradArt_2", defaultValue: false),
			AppSettings.Get("checkBox_MonstrogradArt_3", defaultValue: false)
		} : new bool[3]
		{
			AppSettings.Get("checkBox_MonstrogradArt_Avatar_1", defaultValue: false),
			AppSettings.Get("checkBox_MonstrogradArt_Avatar_2", defaultValue: false),
			AppSettings.Get("checkBox_MonstrogradArt_Avatar_3", defaultValue: false)
		});
		if (!array.Any())
		{
			return;
		}
		string source = _driver.IsFindElement(By.XPath("//img[contains(@src,\"debriss.jpg\")]//../span[@class=\"modern_amount\"]")).isGetAttribute("outerText");
		int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out var result);
		if (result == int.MinValue)
		{
			return;
		}
		ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"abapb_item\")]"));
		int num = 0;
		foreach (IWebElement item in readOnlyCollection)
		{
			num++;
			if (!array[num - 1])
			{
				continue;
			}
			int.TryParse(string.Join("", from c in item.IsFindElement(By.XPath(".//div[@class=\"modern_amount\"]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result2);
			if (result2 != 100)
			{
				int.TryParse(string.Join("", from c in item.IsFindElement(By.XPath(".//b[@class=\"priceinp\"]")).isGetAttribute("outerText")
					where char.IsDigit(c)
					select c), out var result3);
				if (result3 < result)
				{
					item.IsFindElement(By.XPath(".//span[@class=\"dblock orangebtn\"]")).IsClick("Купить");
				}
				break;
			}
		}
	}

	public List<(string displayName, List<(string settingName, string tooltip)>)> Monstrograd_Nastroyki(string server)
	{
		List<(string, List<(string, string)>)> list = new List<(string, List<(string, string)>)>();
		if (server == "Avatar")
		{
			list.Add(("Покупать Артифакт", new List<(string, string)>
			{
				("CheckBox_MonstrogradArt_Avatar_1", "Первый Артифакт"),
				("CheckBox_MonstrogradArt_Avatar_2", "Второй Артифакт"),
				("CheckBox_MonstrogradArt_Avatar_3", "Третий Артифакт")
			}));
			list.Add(("Покупать усиления", new List<(string, string)>
			{
				("CheckBox_Monstrograd_Usileniy_Avatar_1", "Ужасность +50 ужасности"),
				("CheckBox_Monstrograd_Usileniy_Avatar_2", "Мешок уменьшае потери 50%"),
				("CheckBox_Monstrograd_Usileniy_Avatar_3", "Сачек увеличивает заработок")
			}));
			list.Add(("ЗарплСвиток", new List<(string, string)> { ("CheckBox_Monstrograd_Key_Avatar_1", "Покупать Свиток зарплатный") }));
		}
		else
		{
			list.Add(("Покупать Артифакт", new List<(string, string)>
			{
				("CheckBox_MonstrogradArt_1", "Первый Артифакт"),
				("CheckBox_MonstrogradArt_2", "Второй Артифакт"),
				("CheckBox_MonstrogradArt_3", "Третий Артифакт")
			}));
			list.Add(("Покупать усиления", new List<(string, string)>
			{
				("CheckBox_Monstrograd_Usileniy_1", "Ужасность +50 ужасности"),
				("CheckBox_Monstrograd_Usileniy_2", "Мешок уменьшае потери 50%"),
				("CheckBox_Monstrograd_Usileniy_3", "Сачек увеличивает заработок")
			}));
			list.Add(("Живой Ключ", new List<(string, string)> { ("CheckBox_Monstrograd_Key_1", "Покупать Ключ") }));
		}
		return list;
	}

	public DateTime Monstrograd()
	{
		UpdateStatus("Статус: Монстроград");
		try
		{
			if (!NavigateToMonstrograd())
			{
				UpdateStatus("Статус:");
				return AdateTime = DateTime.Now.AddMinutes(30.0);
			}
			Monstrograd_ByeArty();
			Monstrograd_ByePyl();
			if (!CheckEnergy())
			{
				UpdateStatus("Статус:");
				return AdateTime = DateTime.Now.AddMinutes(30.0);
			}
			return ProcessMonstrogradAdventures();
		}
		catch (WebDriverTimeoutException)
		{
			UpdateStatus("Статус: Ошибка таймаута");
			return AdateTime = DateTime.Now.AddMinutes(30.0);
		}
		catch (Exception)
		{
			UpdateStatus("Статус: Ошибка");
			return AdateTime = DateTime.Now.AddMinutes(30.0);
		}
	}

	private bool NavigateToMonstrograd()
	{
		try
		{
			if (_driver.isExecuteScriptClick(By.XPath("//a[@href='/event.php?a=abandoned']"), "Монстроград"))
			{
				Find.Sleep(1000);
				return true;
			}
			if (_driver.PageSource.Contains("event.php?a=abandoned"))
			{
				string url = _driver.Url;
				Uri uri = new Uri(url);
				string text = uri.GetLeftPart(UriPartial.Path).TrimEnd('/').Substring(0, uri.GetLeftPart(UriPartial.Path).LastIndexOf('/'));
				_driver.Navigate().GoToUrl(text + "/event.php?a=abandoned");
				if (!_driver.PageSource.Contains("Выбери район заброшенного города и начни приключения"))
				{
					_driver.Navigate().GoToUrl(url);
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool CheckEnergy()
	{
		try
		{
			WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
			IWebElement webElement = webDriverWait.Until((IWebDriver d) => d.IsFindElement(By.XPath("//span[@class='borderred_text']/b[@class='bravery_now']")));
			if (webElement == null)
			{
				return false;
			}
			string s = webElement.isGetAttribute("outerText") ?? "0";
			if (int.TryParse(s, out var result) && result >= 125)
			{
				return true;
			}
			return false;
		}
		catch (WebDriverTimeoutException)
		{
			return false;
		}
	}

	private void ProcessActions(List<(string actionName, string alternativeAction)> actions, WebDriverWait wait)
	{
		foreach (var action in actions)
		{
			try
			{
				IWebElement webElement = _driver.IsFindElement(By.XPath("//span[contains(text(),'" + action.actionName + "')]"));
				if (webElement == null)
				{
					continue;
				}
				string source = webElement.isGetAttribute("outerText") ?? "";
				string s = new string(source.Where((char c) => char.IsDigit(c)).ToArray());
				if (int.TryParse(s, out var result))
				{
					string text;
					if (result > 30)
					{
						(text, _) = action;
					}
					else
					{
						text = action.alternativeAction;
					}
					string text2 = text;
					IWebElement webElement2 = _driver.IsFindElement(By.XPath("//span[contains(text(),'" + text2 + "')]"));
					if (webElement2 != null && webElement2.IsClick(action.actionName, 1000))
					{
						wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,'button_new') and not (contains(@style, 'none'))]//span[contains(text(), 'УВЫ!') or contains(text(), 'УРА!')]")));
						Thread.Sleep(1000);
					}
					break;
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private void ProcessPopups()
	{
		try
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,'button_new') and not (contains(@style, 'none'))]//span[contains(text(), 'УВЫ!') or contains(text(), 'УРА!')]"));
			if (webElement != null)
			{
				if (_driver is IJavaScriptExecutor javaScriptExecutor)
				{
					javaScriptExecutor.ExecuteScript("abandonedPopupLogClose();");
				}
				Thread.Sleep(2000);
			}
		}
		catch (Exception)
		{
		}
	}

	private void ProcessButtons((string start, string end) xpathConditions)
	{
		for (int i = 0; i < 5; i++)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,'box_body corner_bottom')]//div[contains(@class,'button_new') and not (contains(@style, 'none'))]//span[" + xpathConditions.end + "]"));
			if (webElement == null || !webElement.IsClick("Кнопка конца"))
			{
				break;
			}
			Thread.Sleep(1000);
		}
		for (int j = 0; j < 5; j++)
		{
			IWebElement webElement2 = _driver.IsFindElement(By.XPath("//div[contains(@class,'box_body corner_bottom')]//div[contains(@class,'button_new') and not (contains(@style, 'none'))]//span[" + xpathConditions.start + "]"));
			if (webElement2 != null && webElement2.IsClick("Кнопка начала"))
			{
				Thread.Sleep(1000);
				continue;
			}
			break;
		}
	}

	private (string start, string end) BuildXpathConditions(string[] monstString)
	{
		string text = "";
		for (int num = monstString.Length - 1; num > 0; num--)
		{
			text = text + "contains(text(), '" + monstString[num] + "') or ";
		}
		text = text + "contains(text(), '" + monstString[0] + "')";
		string text2 = "";
		for (int i = 0; i < monstString.Length - 1; i++)
		{
			text2 = text2 + "contains(text(), '" + monstString[i] + "') or ";
		}
		text2 = text2 + "contains(text(), '" + monstString[^1] + "')";
		return (start: text2, end: text);
	}

	private int[,] InitializeMonsterPower()
	{
		return new int[10, 2]
		{
			{ 85, 165 },
			{ 135, 215 },
			{ 185, 265 },
			{ 235, 315 },
			{ 285, 365 },
			{ 335, 415 },
			{ 385, 465 },
			{ 435, 515 },
			{ 485, 565 },
			{ 535, 615 }
		};
	}

	private List<(string actionName, string alternativeAction)> InitializeActions()
	{
		return new List<(string, string)>
		{
			("НАПАСТЬ", "СБЕЖАТЬ"),
			("ДУЭЛЬ", "УДАР В СПИНУ")
		};
	}

	private DateTime ProcessMonstrogradAdventures()
	{
		string[] monstString = new string[7] { "Ура", "Увы", "НА КЛАДБИЩЕ!", "Поднять", "ВСКРЫТЬ", "СЛЕДОВАТЬ", "Следовать" };
		(string, string) xpathConditions = BuildXpathConditions(monstString);
		int[,] monsterPower = InitializeMonsterPower();
		List<(string, string)> actions = InitializeActions();
		WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(1000);
			if (!ProcessAdventureRound(wait, monsterPower, actions, xpathConditions))
			{
				break;
			}
		}
		if (!CheckEnergy())
		{
			UpdateStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(30.0);
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(5.0);
	}

	private bool ProcessAdventureRound(WebDriverWait wait, int[,] monsterPower, List<(string actionName, string alternativeAction)> actions, (string start, string end) xpathConditions)
	{
		try
		{
			IWebElement webElement = wait.Until((IWebDriver d) => d.IsFindElement(By.XPath("//span[@class='borderred_text']/b[@class='bravery_now']")));
			if (webElement == null)
			{
				return false;
			}
			string s = webElement.isGetAttribute("outerText") ?? "0";
			if (!int.TryParse(s, out var result) || result < 125)
			{
				return false;
			}
			int currentPosition = GetCurrentPosition();
			int yjasnost = GetYjasnost();
			if (currentPosition == -1)
			{
				return false;
			}
			if (ShouldMoveToNextPosition(currentPosition, yjasnost, monsterPower))
			{
				_driver.IsFindElement(By.XPath("//div[contains(@class,'place place" + (currentPosition + 1) + "')]"))?.IsClick("Переходим в " + (currentPosition + 1), 1000);
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'button_1') and contains(text(),'ПРИКЛЮЧЕНИЯ')]"))?.IsClick("Приключение", 3000);
			ProcessActions(actions, wait);
			ProcessPopups();
			ProcessButtons(xpathConditions);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private int GetCurrentPosition()
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,'place player')][@data-pos]"));
		if (webElement != null && int.TryParse(webElement.isGetAttribute("data-pos"), out var result))
		{
			return result;
		}
		return -1;
	}

	private int GetYjasnost()
	{
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@class='text center title_is_bind']/b"));
		if (webElement != null && int.TryParse(webElement.isGetAttribute("outerText"), out var result))
		{
			return result;
		}
		return 0;
	}

	private bool ShouldMoveToNextPosition(int currentPosition, int yjasnost, int[,] monsterPower)
	{
		if (currentPosition == 10)
		{
			return false;
		}
		int num = (int)((double)monsterPower[currentPosition, 1] * 1.3);
		if (num == 0)
		{
			return false;
		}
		return yjasnost > num;
	}

	public DateTime ZolotayLishoradka()
	{
		UpdateStatus("Статус: Золотая лихорадка");
		if (_driver.ResyKri() < 300)
		{
			UpdateStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
		_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m19\"]"), "Путь Война");
		if (!_driver.IsFindElement(By.XPath("//div[@class=\"btn\"][contains(text(),\"Распродажа\")]")).IsClick("Распродажа"))
		{
			UpdateStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(30.0);
		}
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(@class,\"ack_offer black_offer3 sale\")]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
		{
			AdateTime = DateTime.Now.AddSeconds(result.Second + 30).AddMinutes(result.Minute).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return AdateTime;
		}
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
		_driver.IsFindElement(By.XPath("//span[contains(text(),\"МНЕ ПОВЕЗЕТ\")]/b[@title=\"Кристаллы\"]//..")).IsClick("МНЕ ПОВЕЗЕТ");
		webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[not(@style)]/span[@id='button1_2' and text()='Ура!']")));
		_driver.IsFindElement(By.XPath("//div[not(@style)]/span[@id='button1_2' and text()='Ура!']")).IsClick("Ура! ", 1000);
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(@class,\"ack_offer black_offer3 sale\")]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
		{
			AdateTime = DateTime.Now.AddSeconds(result.Second + 30).AddMinutes(result.Minute).AddHours(result.Hour);
			UpdateStatus("Статус:");
			return AdateTime;
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(15.0);
	}

	public DateTime Predskazanie()
	{
		try
		{
			UpdateStatus("Статус: Предсказания");
			_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m3\"]"), "Клик Деревня");
			_driver.IsFindElement(By.XPath("//a[@href=\"channeling.php\"]")).IsClick("Предсказания");
			if (_driver.IsFindElement(By.XPath("//span[text()=\"Прикормить\"]")).IsClick("Клик Прикормить"))
			{
				Thread.Sleep(500);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@class=\"button_new valign_top cmd_blocked\"]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
			}
			else
			{
				AdateTime = DateTime.Now.AddMinutes(5.0);
			}
			UpdateStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime AlfaCyrTavra()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
			object obj = _003C_003Ec._003C_003E9__65_0;
			if (obj == null)
			{
				System.Windows.Forms.MethodInvoker val = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: АльфаСырТавра";
				};
				_003C_003Ec._003C_003E9__65_0 = val;
				obj = (object)val;
			}
			((Control)labelStatus).Invoke((Delegate)obj);
			string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i90\"]")).isGetAttribute("outerText").Split('/');
			int[] array2 = new int[2];
			for (int num = 0; num < array.Length; num++)
			{
				int.TryParse(string.Join("", array[num].Where((char c) => char.IsDigit(c))), out array2[num]);
			}
			if (array2[1] == 0)
			{
				LogService.LogHtml("не вижу летоплан");
				AdateTime = DateTime.Now.AddMinutes(5.0);
				Find.LabelStatus("Статус:");
				return AdateTime;
			}
			if (array2[0] > 8)
			{
				AdateTime = DateTime.Now.AddMinutes(5.0);
				Find.LabelStatus("Статус:");
				return AdateTime;
			}
			_driver.isExecuteScriptClick(By.XPath("//li[@id=\"i90\"]/a"), "Клик Летоплан");
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[contains(text(),\"Всего ваших летапланетов улетело на Альфа-Сыр-Тавру\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result))
			{
				if (result < 8 && _driver.IsFindElement(By.XPath("//input[@value=\"ПОСТРОИТЬ\"  and not(@disabled)]")).IsClick("Клик ПОСТРОИТЬ"))
				{
					Thread.Sleep(2000);
				}
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@value=\"ОТПРАВИТЬ\" and not(contains(@class,\"cmd_blocked\"))]"));
				if (elem.IsDisplayed())
				{
					if (_driver.IsFindElement(By.XPath("//input[@name=\"auto_resend\"]")).IsClick("Клик ОТправлять снова"))
					{
						Thread.Sleep(500);
					}
					if (elem.IsClick("Клик Отправить"))
					{
						Thread.Sleep(2000);
					}
				}
			}
			int num2 = 7200;
			Regex regex = new Regex("(?i)(\\d+):(\\d+):(\\d+)");
			MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@class=\"status-timer\"]")).isGetAttribute("outerText"));
			if (matchCollection.Count > 0)
			{
				for (int num3 = 0; num3 < matchCollection.Count; num3++)
				{
					int num4 = Convert.ToInt16(matchCollection[num3].Groups[1].Value) * 60 * 60 + Convert.ToInt16(matchCollection[num3].Groups[2].Value) * 60 + Convert.ToInt16(matchCollection[num3].Groups[3].Value);
					if (num2 > num4)
					{
						num2 = num4;
					}
				}
			}
			AdateTime = DateTime.Now.AddSeconds(num2 + 120);
			Find.LabelStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime Atlantida()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
			object obj = _003C_003Ec._003C_003E9__66_0;
			if (obj == null)
			{
				System.Windows.Forms.MethodInvoker val = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Атлантида";
				};
				_003C_003Ec._003C_003E9__66_0 = val;
				obj = (object)val;
			}
			((Control)labelStatus).Invoke((Delegate)obj);
			string[] array = _driver.IsFindElement(By.XPath("//li[@id=\"i87\"]")).isGetAttribute("outerText").Split('/');
			int[] array2 = new int[2];
			for (int num = 0; num < array.Length; num++)
			{
				int.TryParse(string.Join("", array[num].Where((char c) => char.IsDigit(c))), out array2[num]);
			}
			if (array2[1] == 0)
			{
				LogService.LogHtml("не вижу батискаф");
				AdateTime = DateTime.Now.AddMinutes(5.0);
				Find.LabelStatus("Статус:");
				return AdateTime;
			}
			if (array2[0] >= 8)
			{
				AdateTime = DateTime.Now.AddMinutes(5.0);
				Find.LabelStatus("Статус:");
				return AdateTime;
			}
			_driver.isExecuteScriptClick(By.XPath("//li[@id=\"i87\"]/a"), "Клик Батискаф");
			if (int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//div[contains(text(),\"Всего ваших батискафчиков исследуют Атлантиду\")]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out var result))
			{
				if (result < 8 && _driver.IsFindElement(By.XPath("//input[@value=\"ПОСТРОИТЬ\"  and not(@disabled)]")).IsClick("Клик ПОСТРОИТЬ"))
				{
					Thread.Sleep(2000);
				}
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@value=\"ОТПРАВИТЬ\" and not(contains(@class,\"cmd_blocked\"))]"));
				if (elem.IsDisplayed())
				{
					if (_driver.IsFindElement(By.XPath("//input[@name=\"auto_resend\"]")).IsClick("Клик ОТправлять снова"))
					{
						Thread.Sleep(500);
					}
					if (elem.IsClick("Клик Отправить"))
					{
						Thread.Sleep(2000);
					}
				}
			}
			int num2 = 7200;
			Regex regex = new Regex("(?i)(\\d+):(\\d+):(\\d+)");
			MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@class=\"harvesters\"]")).isGetAttribute("outerText"));
			if (matchCollection.Count > 0)
			{
				for (int num3 = 0; num3 < matchCollection.Count; num3++)
				{
					int num4 = Convert.ToInt16(matchCollection[num3].Groups[1].Value) * 60 * 60 + Convert.ToInt16(matchCollection[num3].Groups[2].Value) * 60 + Convert.ToInt16(matchCollection[num3].Groups[3].Value);
					if (num2 > num4)
					{
						num2 = num4;
					}
				}
			}
			AdateTime = DateTime.Now.AddSeconds(num2 + 120);
			Find.LabelStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			Find.LabelStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime Pesochnica()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		try
		{
			int[] array = new int[2];
			Label labelStatus = (Application.OpenForms[0] as Form1).labelStatus;
			object obj = _003C_003Ec._003C_003E9__67_0;
			if (obj == null)
			{
				System.Windows.Forms.MethodInvoker val = delegate
				{
					((Control)(Application.OpenForms[0] as Form1).labelStatus).Text = "Статус: Песочница";
				};
				_003C_003Ec._003C_003E9__67_0 = val;
				obj = (object)val;
			}
			((Control)labelStatus).Invoke((Delegate)obj);
			_driver.isExecuteScriptClick(By.XPath("//a[@id=\"m45\"]"), "Клик Песочница");
			DateTime result;
			for (int num = 0; num < 5; num++)
			{
				string[] array2 = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Вы сегодня совершили\")]")).isGetAttribute("outerText").Replace("из", "/")
					.Split('/');
				array[0] = 0;
				array[1] = 0;
				for (int num2 = 0; num2 < array2.Length; num2++)
				{
					int.TryParse(string.Join("", array2[num2].Where((char c) => char.IsDigit(c))), out array[num2]);
				}
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"До бесплатного набега:\")]//span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
				{
					AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
					break;
				}
				if (array[1] != 0 && array[0] == array[1])
				{
					AdateTime = DateTime.Now.AddMinutes(60.0);
					break;
				}
				if (_driver.IsFindElement(By.XPath("//span[@onclick=\"sandboxLoadUser(1)\"]")).IsClick("Клик Братва"))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new small_sl red\")]/span")).IsClick("Клик Гостить"))
				{
					Thread.Sleep(1000);
					Pesochnica_KlickSosed();
				}
				if (_driver.IsFindElement(By.XPath("//input[contains(@class,\"cmd_all green  cmd_small_sl cmd_asmall_sl \")]")).IsClick("Клик Домой"))
				{
					Thread.Sleep(1000);
				}
			}
			for (int num3 = 0; num3 < 5; num3++)
			{
				string[] array2 = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Вы сегодня совершили\")]")).isGetAttribute("outerText").Replace("из", "/")
					.Split('/');
				array[0] = 0;
				array[1] = 0;
				for (int num4 = 0; num4 < array2.Length; num4++)
				{
					int.TryParse(string.Join("", array2[num4].Where((char c) => char.IsDigit(c))), out array[num4]);
				}
				if (array[1] != 0 && array[0] == array[1])
				{
					AdateTime = DateTime.Now.AddMinutes(60.0);
					break;
				}
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"До бесплатного набега:\")]//span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
				{
					AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
					break;
				}
				if (_driver.IsFindElement(By.XPath("//span[@onclick=\"sandboxLoadUser(2)\"]")).IsClick("Клик Соклан"))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new small_sl red\")]/span")).IsClick("Клик Гостить"))
				{
					Thread.Sleep(1000);
					Pesochnica_KlickSosed();
				}
				if (_driver.IsFindElement(By.XPath("//input[contains(@class,\"cmd_all green  cmd_small_sl cmd_asmall_sl \")]")).IsClick("Клик Домой"))
				{
					Thread.Sleep(1000);
				}
			}
			for (int num5 = 0; num5 < 5; num5++)
			{
				string[] array2 = _driver.IsFindElement(By.XPath("//div[contains(text(),\"Вы сегодня совершили\")]")).isGetAttribute("outerText").Replace("из", "/")
					.Split('/');
				array[0] = 0;
				array[1] = 0;
				for (int num6 = 0; num6 < array2.Length; num6++)
				{
					int.TryParse(string.Join("", array2[num6].Where((char c) => char.IsDigit(c))), out array[num6]);
				}
				if (array[1] != 0 && array[0] == array[1])
				{
					AdateTime = DateTime.Now.AddMinutes(60.0);
					break;
				}
				if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[contains(text(),\"До бесплатного набега:\")]//span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out result))
				{
					AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
					break;
				}
				if (_driver.IsFindElement(By.XPath("//span[@onclick=\"sandboxLoadUser(3)\"]")).IsClick("Клик случайно"))
				{
					Thread.Sleep(1000);
				}
				if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_new small_sl red\")]/span")).IsClick("Клик Гостить"))
				{
					Thread.Sleep(1000);
					Pesochnica_KlickSosed();
				}
				if (_driver.IsFindElement(By.XPath("//input[contains(@class,\"cmd_all green  cmd_small_sl cmd_asmall_sl \")]")).IsClick("Клик Домой"))
				{
					Thread.Sleep(1000);
				}
			}
			Pesochnica_KlickMi();
			Find.LabelStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	private void Pesochnica_KlickSosed()
	{
		string text = Regex.Replace(_driver.IsFindElement(By.XPath("//div[contains(text(),\"Я строю\")]/b")).isGetAttribute("outerText"), ".*?\"(.*?)!\".*?", "$1", RegexOptions.Singleline);
		if (text == "" && _driver.IsFindElement(By.XPath("//div[contains(@class,\"item  junk\")]")).IsClick("Клик убрать"))
		{
			Thread.Sleep(1000);
			return;
		}
		Regex regex = new Regex("(?ims)sandbox_block.*?(active|unactive|junk)");
		MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@id=\"sandbox_game_field\"]")).isGetAttribute("outerHTML"));
		if (matchCollection.Count == 0 || matchCollection.Count != 64)
		{
			return;
		}
		for (int i = 0; i < matchCollection.Count; i++)
		{
			if (matchCollection[i].Groups[1].Value == "unactive" && arShedevr[text][i] == 1 && _driver.isExecuteScriptClick(By.XPath("//div[@data-id=\"" + (i + 1) + "\"]/div[@data-id=\"" + (i + 1) + "\"]"), "Клик строим кулич  " + (i + 1)))
			{
				Thread.Sleep(1000);
				return;
			}
		}
		for (int j = 0; j < matchCollection.Count; j++)
		{
			if (matchCollection[j].Groups[1].Value == "active" && arShedevr[text][j] == 0 && _driver.isExecuteScriptClick(By.XPath("//div[@data-id=\"" + (j + 1) + "\"]/div[@data-id=\"" + (j + 1) + "\"]"), "Клик убираем кулич  " + (j + 1)))
			{
				Thread.Sleep(1000);
				return;
			}
		}
		for (int k = 0; k < matchCollection.Count; k++)
		{
			if (matchCollection[k].Groups[1].Value == "junk" && arShedevr[text][k] == 1 && _driver.isExecuteScriptClick(By.XPath("//div[@data-id=\"" + (k + 1) + "\"]/div[@data-id=\"" + (k + 1) + "\"]"), "Клик убираем мусор  " + (k + 1)))
			{
				Thread.Sleep(1000);
				return;
			}
		}
		if (_driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"item  junk\")]"), "Клик убираем мусор  РЭНДОМ"))
		{
			Thread.Sleep(1000);
		}
	}

	private void Pesochnica_KlickMi()
	{
		int[] array = new int[2];
		string[] array2 = _driver.IsFindElement(By.XPath("//div[@id=\"sandbox_big_cell\"]")).isGetAttribute("outerText").Split('/');
		array = new int[2];
		for (int i = 0; i < array2.Length; i++)
		{
			int.TryParse(string.Join("", array2[i].Where((char c) => char.IsDigit(c))), out array[i]);
		}
		if (array[1] == 0 || array[0] < 80)
		{
			return;
		}
		if (_driver.IsFindElement(By.XPath("//div[@id=\"open_sandbox_masterpieces\"]")).IsClick("Клик masterpieces "))
		{
			Thread.Sleep(500);
		}
		string text = _driver.IsFindElement(By.XPath("//span[contains(@class,\"want_ptr\")][contains(@class,\"bold\")]")).isGetAttribute("outerText");
		if (_driver.IsFindElement(By.XPath("//span[text()=\"ЗАКРЫТЬ\"]")).IsClick("Клик Закрыть"))
		{
			Thread.Sleep(500);
		}
		if (text == "")
		{
			return;
		}
		Regex regex = new Regex("(?ims)sandbox_block.*?(active|unactive|junk)");
		MatchCollection matchCollection = regex.Matches(_driver.IsFindElement(By.XPath("//div[@id=\"sandbox_game_field\"]")).isGetAttribute("outerHTML"));
		if (matchCollection.Count == 0 || matchCollection.Count != 64)
		{
			return;
		}
		string[] array3 = new string[matchCollection.Count];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int num4 = 0; num4 < matchCollection.Count; num4++)
		{
			array3[num4] = matchCollection[num4].Groups[1].Value;
			if (array3[num4] == "unactive" && arShedevr[text][num4] == 1)
			{
				num2++;
			}
			if (array3[num4] == "active" && arShedevr[text][num4] == 0)
			{
				num3++;
			}
			if (array3[num4] == "junk" && arShedevr[text][num4] == 1)
			{
				num++;
			}
		}
		for (int num5 = 0; num5 < array3.Length; num5++)
		{
			if (num2 > 2)
			{
				break;
			}
			if (!(array3[num5] == "junk") || arShedevr[text][num5] != 1 || !_driver.IsFindElement(By.XPath("//div[@data-id=\"" + (num5 + 1) + "\"]/div[@data-id=\"" + (num5 + 1) + "\"]")).IsClick("Клик убираем Мусор " + (num5 + 1)))
			{
				continue;
			}
			Thread.Sleep(1500);
			array3[num5] = "unactive";
			num2++;
			array2 = _driver.IsFindElement(By.XPath("//div[@id=\"sandbox_big_cell\"]")).isGetAttribute("outerText").Split('/');
			array = new int[2];
			for (int num6 = 0; num6 < array2.Length; num6++)
			{
				int.TryParse(string.Join("", array2[num6].Where((char c) => char.IsDigit(c))), out array[num6]);
			}
			if (array[1] == 0 || array[0] < 80)
			{
				return;
			}
		}
		for (int num7 = 0; num7 < array3.Length; num7++)
		{
			if (!(array3[num7] == "active") || arShedevr[text][num7] != 0 || !_driver.IsFindElement(By.XPath("//div[@data-id=\"" + (num7 + 1) + "\"]/div[@data-id=\"" + (num7 + 1) + "\"]")).IsClick("Клик убираем куличик " + (num7 + 1)))
			{
				continue;
			}
			Thread.Sleep(1000);
			array3[num7] = "junk";
			num3++;
			array2 = _driver.IsFindElement(By.XPath("//div[@id=\"sandbox_big_cell\"]")).isGetAttribute("outerText").Split('/');
			array = new int[2];
			for (int num8 = 0; num8 < array2.Length; num8++)
			{
				int.TryParse(string.Join("", array2[num8].Where((char c) => char.IsDigit(c))), out array[num8]);
			}
			if (array[1] == 0 || array[0] < 80)
			{
				return;
			}
		}
		for (int num9 = 0; num9 < array3.Length; num9++)
		{
			if (!(array3[num9] == "unactive") || arShedevr[text][num9] != 1 || !_driver.IsFindElement(By.XPath("//div[@data-id=\"" + (num9 + 1) + "\"]/div[@data-id=\"" + (num9 + 1) + "\"]")).IsClick("Клик строим куличик " + (num9 + 1)))
			{
				continue;
			}
			Thread.Sleep(1000);
			array3[num9] = "active";
			array2 = _driver.IsFindElement(By.XPath("//div[@id=\"sandbox_big_cell\"]")).isGetAttribute("outerText").Split('/');
			array = new int[2];
			for (int num10 = 0; num10 < array2.Length; num10++)
			{
				int.TryParse(string.Join("", array2[num10].Where((char c) => char.IsDigit(c))), out array[num10]);
			}
			if (array[1] == 0 || array[0] < 80)
			{
				break;
			}
		}
	}

	public DateTime Kontrabanda()
	{
		try
		{
			Find.LabelStatus("Статус: Контрабанда");
			_driver.isExecuteScriptClick(By.XPath("//a[@href=\"event.php?a=contraband\"]"), "Клик Контрабанда");
			_driver.IsFindElement(By.XPath("//div[@class=\"btn w50p\"][@rel=\"1\"]")).IsClick("Клик рулетка");
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Крутить бесплатно\")]")).IsClick("Крутить бесплатно"))
			{
				LogService.LogHtml("Крутить бесплатно ");
				Thread.Sleep(2000);
			}
			if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"roll1\"]//span[contains(@class,\"js_timer\")]")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				AdateTime = DateTime.Now.AddSeconds(result.Second + 15).AddMinutes(result.Minute).AddHours(result.Hour);
			}
			else
			{
				AdateTime = DateTime.Now.AddMinutes(5.0);
			}
			Find.LabelStatus("Статус:");
			return AdateTime;
		}
		catch
		{
			return AdateTime = DateTime.Now.AddMinutes(5.0);
		}
	}

	public DateTime Rybalka()
	{
		Find.LabelStatus("Статус: Ботвинская Рыбалка");
		_driver.isExecuteScriptClick(By.XPath("//a[@href=\"event.php?a=fishing\"]"), "Перейти в Рыбалку");
		string text = "(//div[@class='fishingMap'])/div[@class='icons']/div[contains(@class,'active')]";
		ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath(text));
		if (readOnlyCollection.Count > 0)
		{
			Random random = new Random();
			int num = random.Next(0, readOnlyCollection.Count);
			_driver.IsFindElement(By.XPath(text + $"[{num + 1}]")).IsClick("Идти");
		}
		string script = " // Функция для поиска и клика по кнопке\r\n                    function clickPullButton() {\r\n                      if (typeof Konva === 'undefined') {\r\n                        console.error('Konva не загружена');\r\n                        return false;\r\n                      }\r\n\r\n                      if (!Konva.stages || Konva.stages.length === 0) {\r\n                        console.error('Сцена Konva не найдена');\r\n                        return false;\r\n                      }\r\n\r\n                      const stage = Konva.stages[0];\r\n                      try {\r\n                        const allTexts = stage.find('Text');\r\n                        const pullText = allTexts.find(text => text.text() === 'ТЯНИ');\r\n    \r\n                        if (pullText) {\r\n                          const parent = pullText.getParent();\r\n                          if (parent && parent.visible()) {\r\n                            parent.fire('click');\r\n                            console.log('Клик по кнопке \"ТЯНИ\" выполнен', new Date().toLocaleTimeString());\r\n                            return true;\r\n                          }\r\n                        }\r\n                      } catch (e) {\r\n                        console.error('Ошибка:', e);\r\n                      }\r\n                      return false;\r\n                    }\r\n\r\n                    // Запускаем проверку каждую секунду\r\n                    const intervalId = setInterval(() => {\r\n                      clickPullButton();\r\n                    }, 500);\r\n\r\n                    // Для остановки интервала выполните:\r\n                    // clearInterval(intervalId);\r\n                    console.log('Автоматическая проверка кнопки \"ТЯНИ\" запущена');";
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		for (int i = 0; i < 5; i++)
		{
			if (RybakZapal() < 100)
			{
				break;
			}
			_driver.WaitFind(By.XPath("//button[string(.)=\"Забросить удочку\"][not(@style)]"), TimeSpan.FromSeconds(30L));
			if (_driver.IsFindElement(By.XPath("//button[string(.)=\"Забросить удочку\"][not(@style)]")).IsClick("Забросить удочку", 5000))
			{
				i = 0;
			}
			javaScriptExecutor.ExecuteScript(script);
			_driver.WaitFind(By.XPath("//span[string(.)=\"ПРИНЯТЬ\"]"), TimeSpan.FromSeconds(30L));
			if (_driver.IsFindElement(By.XPath("//span[string(.)=\"ПРИНЯТЬ\"]")).IsClick("Принять"))
			{
				i = 0;
			}
		}
		int result = 0;
		int.TryParse(_driver.IsFindElement(By.XPath("//div[@class=\"total_points\"]/b")).isGetAttribute("outerText"), out result);
		List<(string Name, int Stat, int Added, int Weight)> abilities = new List<(string Name, int Stat, int Added, int Weight)>
		{
			("enthusiasm", Stat("enthusiasm"), 0, 100),
			("luck", Stat("luck"), 0, 100),
			("gigantism", Stat("gigantism"), 0, 100),
			("instinct", Stat("instinct"), 0, 30)
		};
		int totalPoints = result;
		abilities = Rybalka_DistributePoints(abilities, totalPoints);
		foreach (var item in abilities)
		{
			if (item.Item3 > 0)
			{
				_driver.IsFindElement(By.Id(item.Item1)).IsClear();
				_driver.IsFindElement(By.Id(item.Item1)).IsSendKeys(item.Item3.ToString());
			}
		}
		_driver.IsFindElement(By.XPath("//button[contains(@class,\"training_btn\")][not(contains(@class,\"cmd_blocked\"))]")).IsClick("Подтвердить", 2000);
		Find.LabelStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(30.0);
		int RybakZapal()
		{
			string[] array = _driver.IsFindElement(By.XPath("//div[@class=\"fishing-energy-bar__value\"]")).isGetAttribute("outerText").Split('/');
			if (array.Length >= 1)
			{
				string text2 = array[0].Trim();
				int.TryParse(string.Join("", (string)text2), out var result2);
				return result2;
			}
			return 0;
		}
		int Stat(string statName)
		{
			string text2 = "borderred_text stat_" + statName;
			IWebElement elem = _driver.IsFindElement(By.XPath("//div[@class=\"" + text2 + "\"]"));
			string text3 = elem.isGetAttribute("outerText");
			string text4 = text3.Split(' ')[0];
			int.TryParse(string.Join("", (string)text4), out var result2);
			return result2;
		}
	}

	public List<(string Name, int Stat, int Added, int Weight)> Rybalka_DistributePoints(List<(string Name, int Stat, int Added, int Weight)> abilities, int totalPoints)
	{
		if (abilities == null || abilities.Count == 0 || totalPoints <= 0)
		{
			return abilities;
		}
		if (abilities.Sum(((string Name, int Stat, int Added, int Weight) a) => a.Weight) == 0)
		{
			return abilities;
		}
		int remainingPoints = totalPoints;
		List<(string Name, int Stat, int Added, int Weight)> list = abilities.Select(((string Name, int Stat, int Added, int Weight) a) => (Name: a.Name, Stat: a.Stat, Added: 0, Weight: a.Weight)).ToList();
		while (remainingPoints > 0)
		{
			bool flag = false;
			List<(string Name, int Stat, int Added, int Weight)> source = list.Where<(string, int, int, int)>(((string Name, int Stat, int Added, int Weight) a) => a.Stat + a.Added < 24).ToList();
			if (!source.Any())
			{
				break;
			}
			int eligibleWeight = source.Sum<(string, int, int, int)>(((string Name, int Stat, int Added, int Weight) a) => a.Weight);
			if (eligibleWeight == 0)
			{
				break;
			}
			foreach (var ability in from a in source
				orderby (double)a.Weight / (double)eligibleWeight * (double)remainingPoints descending, a.Stat
				select a)
			{
				if (remainingPoints <= 0)
				{
					break;
				}
				int index = list.FindIndex(((string Name, int Stat, int Added, int Weight) r) => r.Name == ability.Item1);
				if (list[index].Item2 + list[index].Item3 < 24)
				{
					list[index] = (list[index].Item1, list[index].Item2, list[index].Item3 + 1, list[index].Item4);
					int num = remainingPoints;
					remainingPoints = num - 1;
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return list;
	}

	public DateTime Parovoz()
	{
		Find.LabelStatus("Статус: Паровозик");
		string script = "\r\n    // Функция для поиска индекса элемента по классу\r\n    function findElementIndex() {\r\n        // Проверяем, существует ли массив elements\r\n        if (typeof elements !== 'undefined' && elements && elements.length > 0) {\r\n            for (var i = 0; i < elements.length; i++) {\r\n                // Ищем элемент с классом 'notice botvapoly_ad'\r\n                if (elements[i] && elements[i].url && \r\n                    elements[i].url.includes('botvapoly_ad')) {\r\n                    return i;\r\n                }\r\n            }\r\n        }\r\n        return -1; // Возвращаем -1 если элемент не найден\r\n    }\r\n    return findElementIndex();\r\n";
		int num = Convert.ToInt32(((IJavaScriptExecutor)_driver).ExecuteScript(script));
		bool flag = false;
		if (num >= 0)
		{
			_driver.IsFindElement(By.XPath("//div[@class='slider-cell'][" + (num + 1) + "]")).IsClick("выбираю slider-cell " + (num + 1));
			if (_driver.IsFindElement(By.XPath("//a[contains(@onclick,'ajax.php?m=botvapoly')]")).IsClick("Клик botvapoly"))
			{
				flag = true;
			}
			if (!flag)
			{
				Find.LabelStatus("Статус:");
				return AdateTime = DateTime.Now.AddMinutes(30.0);
			}
			_driver.WaitFind(By.XPath("//div[@class='center' and contains(string(.),'локомотивчик')]"), TimeSpan.FromSeconds(5L));
			_driver.IsFindElement(By.XPath("//b[contains(string(.),'подкидывани')]//..")).IsClick("Бросить кубик");
			_driver.IsFindElement(By.XPath("//span[@class='uppercase'][contains(string(.),'дать отпор самому')]")).IsClick("Дать отпор");
			_driver.isExecuteScriptClick(By.XPath("//span[@class='uppercase'][contains(string(.),'дать отпор самому')]"), "Дать отпор ");
			_driver.isExecuteScriptClick(By.XPath("//div[@class='box_title'][contains(string(.),'отпор')]/div[contains(@class,'box_x_button')]"), "закрыть отпор ");
			_driver.IsFindElement(By.XPath("//b[contains(string(.),'подкидывани')]//..")).IsClick("Бросить кубик");
			IWebElement elem = _driver.IsFindElement(By.XPath("//div[contains(@class,'confirm_content_box fake')]//div[contains(@class,'botvapoly_train_lot')]/div[contains(@class,'item_box')]//img"));
			string text = elem.isGetAttribute("src");
			ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,'botvapoly_train_lot')]//img"));
			foreach (IWebElement item in readOnlyCollection)
			{
				text = item.GetAttribute("src");
				Console.WriteLine("src уже есть " + text);
			}
			_driver.IsFindElement(By.XPath("//div[contains(@class,'box_layout')]//div[contains(@class,'box_x_button')]")).IsClick("Закрыть");
			Find.LabelStatus("Статус:");
			return AdateTime = DateTime.Now.AddMinutes(30.0);
		}
		Find.LabelStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(30.0);
	}

	public DateTime Prikluchenie()
	{
		try
		{
			Find.LabelStatus("Статус: Приключения");
			_driver.isExecuteScriptClick(By.XPath("//a[@href=\"/event.php?a=airships\"]"), "Перейти в Приключения");
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"airships_craft_cmd\")][not(contains(@class,\"cmd_blocked\"))]"));
			string text = _driver.IsFindElement(By.XPath("//div[contains(@class,\"current\")]")).isGetAttribute("data-island");
			GraphGPT graphGPT = new GraphGPT();
			for (int i = 1; i <= 10; i++)
			{
				graphGPT.AddVertex(i.ToString());
			}
			graphGPT.AddEdge("1", "2", 0);
			graphGPT.AddEdge("1", "10", 0);
			graphGPT.AddEdge("2", "3", 0);
			graphGPT.AddEdge("3", "4", 0);
			graphGPT.AddEdge("3", "9", 0);
			graphGPT.AddEdge("9", "8", 0);
			graphGPT.AddEdge("8", "7", 0);
			graphGPT.AddEdge("4", "5", 0);
			graphGPT.AddEdge("5", "6", 0);
			graphGPT.AddEdge("6", "7", 0);
			graphGPT.AddEdge("7", "8", 0);
			graphGPT.AddEdge("7", "10", 0);
			graphGPT.AddEdge("8", "9", 0);
			List<(int Id, int Score, int Distance, List<string> Path)> list = new List<(int Id, int Score, int Distance, List<string> Path)>();
			string input = _driver.IsFindElement(By.XPath("//div[@class=\"airships_map\"]")).isGetAttribute("outerHTML").Replace("обычная", "100")
				.Replace("средняя", "125")
				.Replace("низкая", "75")
				.Replace("высокая", "150");
			Regex regex = new Regex("(?ims)island(\\d+).*?Враждебность.*?\\>(.*?)\\<.*?Плодородность.*?(\\d+)");
			MatchCollection matchCollection = regex.Matches(input);
			for (int j = 0; j < matchCollection.Count; j++)
			{
				int item = Convert.ToInt16(matchCollection[j].Groups[1].Value);
				int item2 = 100 * Convert.ToInt16(matchCollection[j].Groups[2].Value) / Convert.ToInt16(matchCollection[j].Groups[3].Value);
				List<string> list2 = graphGPT.FindShortestPath(text, item.ToString());
				list.Add((item, item2, list2.Count, list2));
			}
			list.Sort(((int Id, int Score, int Distance, List<string> Path) x, (int Id, int Score, int Distance, List<string> Path) y) => x.Score.CompareTo(y.Score));
			foreach (var item4 in list)
			{
			}
			(int Id, int Score, int Distance, List<string> Path) tuple = (from tuple3 in list
				where tuple3.Distance < 3
				orderby tuple3.Score
				select tuple3).FirstOrDefault();
			int item3 = tuple.Item1;
			int num = Convert.ToInt16(text);
			string attribute = _driver.IsFindElement(By.XPath("//b[@class=\"airship_energy\"]")).GetAttribute("outerText");
			int result = 0;
			int.TryParse(string.Join("", attribute.Where((char c) => char.IsDigit(c))), out result);
			var (num2, num3, num4, list3) = tuple;
			if ((num2 != 0 || num3 != 0 || num4 != 0 || list3 != null) && num != item3)
			{
				List<string> list4 = graphGPT.FindShortestPath(num.ToString(), item3.ToString());
				for (int num5 = 1; num5 < list4.Count; num5++)
				{
					if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"may_fly\")][@data-island=\"" + list4[num5] + "\"]")).IsClick("Отправить " + list4[num5]))
					{
						Thread.Sleep(1000);
						if (_driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"airships_fly_cmd\")][not(contains(@class,\"cmd_blocked\"))]"), "ОТПРАВИТЬ"))
						{
							Thread.Sleep(2000);
						}
					}
				}
				attribute = _driver.IsFindElement(By.XPath("//b[@class=\"airship_energy\"]")).GetAttribute("outerText");
				int.TryParse(string.Join("", attribute.Where((char c) => char.IsDigit(c))), out var result2);
				if (result2 == result && result2 < 50)
				{
					Find.LabelStatus("Статус:");
					return AdateTime = DateTime.Now.AddMinutes(30.0);
				}
				if (_driver.IsFindElement(By.XPath("//script[contains(string(.),'Недостаточно')]")) != null)
				{
					Find.LabelStatus("Статус:");
					return AdateTime = DateTime.Now.AddMinutes(30.0);
				}
			}
			for (int num6 = 0; num6 < 20; num6++)
			{
				webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"airships_craft_cmd\")][not(contains(@class,\"cmd_blocked\"))]"));
				webElement.IsClick("иследовать");
				Thread.Sleep(500);
				attribute = _driver.IsFindElement(By.XPath("//b[@class=\"airship_energy\"]")).GetAttribute("outerText");
				int result3 = 0;
				int.TryParse(string.Join("", attribute.Where((char c) => char.IsDigit(c))), out result3);
				if (result3 == result && result3 < 50)
				{
					Find.LabelStatus("Статус:");
					AdateTime = DateTime.Now.AddMinutes(30.0);
					return AdateTime;
				}
				if (_driver.IsFindElement(By.XPath("//script[contains(string(.),'Недостаточно')]")) != null)
				{
					Find.LabelStatus("Статус:");
					return AdateTime = DateTime.Now.AddMinutes(30.0);
				}
				result = result3;
			}
		}
		catch
		{
		}
		Find.LabelStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(30.0);
	}
}
