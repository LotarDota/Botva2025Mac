using Botva2025.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Botva2025;

public class Arena
{
	public static IWebDriver _driver;

	public static readonly int[] arMax = new int[19]
	{
		0, 250, 500, 750, 1000, 1500, 2000, 2500, 3000, 4000,
		5000, 6000, 7000, 9000, 12000, 15000, 20000, 25000, 30000
	};

	private Form1 _mainForm;

	public List<string> winners { get; set; }

	public List<string> losers { get; set; }

	public DateTime arenaDatetime { get; set; }

	public Arena(IWebDriver driver)
	{
		_driver = driver;
		arenaDatetime = DateTime.Now;
		winners = new List<string>();
		losers = new List<string>();
	}

	public void AddPlayerResult(string resultType, string playerName)
	{
		if (string.IsNullOrEmpty(playerName) || ((winners.Count == 0 || losers.Count == 0) && !LoadFromTextArea()))
		{
			return;
		}
		List<string> list = ((resultType == "Win") ? winners : losers);
		List<string> list2 = ((resultType == "Win") ? losers : winners);
		if (!list.Contains(playerName))
		{
			if (list2.Contains(playerName))
			{
				list2.Remove(playerName);
			}
			list.Add(playerName);
			SaveToTextArea();
		}
	}

	public bool LoadFromTextArea()
	{
		IWebElement elem = ArenaShtabNotes();
		string text = elem.isGetAttribute("value");
		if (text == null)
		{
			return false;
		}
		string[] lines = text.Split('\n');
		winners = ParsePlayerList(lines, "ArenaWin");
		losers = ParsePlayerList(lines, "ArenaLost");
		return true;
	}

	private List<string> ParsePlayerList(string[] lines, string prefix)
	{
		string text = lines.FirstOrDefault((string l) => l.StartsWith(prefix));
		if (text == null)
		{
			return new List<string>();
		}
		return (from s in text.Split(':')[1].Split(',')
			select s.Trim() into name
			where !string.IsNullOrEmpty(name)
			select name).ToList();
	}

	public IWebElement ArenaShtabNotes()
	{
		if (!_driver.Url.Contains("shtab.php?m=text"))
		{
			_driver.isExecuteScriptClick(By.Id("m9"), "Клик Штаб");
		}
		_driver.IsFindElement(By.XPath("//a[@href=\"shtab.php?m=text\"][not(contains(@class,\"cmd_selected\"))]")).IsClick();
		return _driver.IsFindElement(By.Id("text"));
	}

	public void SaveToTextArea()
	{
		IWebElement elem = ArenaShtabNotes();
		string text = "ArenaWin: " + string.Join(", ", winners) + "\nArenaLost: " + string.Join(", ", losers);
		while (text.Length > 1900)
		{
			if (winners.Count > losers.Count)
			{
				if (winners.Count > 0)
				{
					winners.RemoveAt(1);
				}
			}
			else if (losers.Count > 0)
			{
				losers.RemoveAt(1);
			}
			if (winners.Count == 0 && losers.Count == 0)
			{
				break;
			}
			text = "ArenaWin: " + string.Join(", ", winners) + "\nArenaLost: " + string.Join(", ", losers);
		}
		elem.IsClear();
		elem.IsSendKeys(text);
		_driver.IsFindElement(By.XPath("//form[@action=\"?m=text&a=add\"]//input[@value=\"СОХРАНИТЬ\"]")).IsClick("Сохранить");
	}

	public void PrintResults()
	{
	}

	public DateTime ArenaMain()
	{
		if (arenaDatetime > DateTime.Now)
		{
			return arenaDatetime;
		}
		if (!AppSettings.Get("checkBoxArena", defaultValue: false))
		{
			return DateTime.Now.AddSeconds(10.0);
		}
		if (AppSettings.Get("checkBoxArenaShtab", defaultValue: false) && (winners == null || losers == null))
		{
			LoadFromTextArea();
		}
		List<EnemyData> list = new List<EnemyData>();
		Find.LabelStatus("Статус: Арена");
		IWebElement webElement = _driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span"));
		if (webElement != null && !AppSettings.Get("checkBoxSnejnyGolem", defaultValue: false))
		{
			if (webElement.Text == "00:00:00")
			{
				_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
				if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_search\")]")) == null)
				{
					Find.LabelStatus("Статус:");
					return arenaDatetime = DateTime.Now.AddMinutes(5.0);
				}
			}
			Find.LabelStatus("Статус:");
			return arenaDatetime = DateTime.Now.AddMinutes(1.0);
		}
		if (_driver.ResyKri() < 10)
		{
			Find.LabelStatus("Статус:");
			return arenaDatetime = DateTime.Now.AddMinutes(1.0);
		}
		if (!_driver.Url.Contains("botva.ru/dozor.php") || _driver.Url.Contains("a=log"))
		{
			_driver.isExecuteScriptClick(By.Id("m8"), "Клик Бодалка");
		}
		arenaDatetime = _driver.DateTimeCount("//div[@class=\"fl_r arena_wait_till\"]");
		if (arenaDatetime > DateTime.Now)
		{
			Find.LabelStatus("Статус:");
			return arenaDatetime = arenaDatetime.AddSeconds(20.0);
		}
		if (AppSettings.Get("checkBoxArenaList", defaultValue: false))
		{
			string source = _driver.IsFindElement(By.XPath("//li[@id=\"i159\"]")).isGetAttribute("outerText");
			long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out var result);
			if (result > 10)
			{
				_driver.IsFindElement(By.XPath("//a[contains(@href,'m=arena') and contains(@href,'do_cmd=search')]//*[@title=\"Капустный лист\"]/../..")).IsClick("Капуста", 600);
			}
		}
		_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_search\")]")).IsClick();
		int num = arMax[AppSettings.Get("comboBoxArenaMax", 0)];
		for (int num2 = 0; num2 < 4; num2++)
		{
			long num3 = Convert.ToInt64(_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + (num2 + 1) + "]//div[contains(@class,'arena_enemy_stat')]//div[1]")).isGetAttribute("outerText").Replace(".", ""));
			long num4 = Convert.ToInt64(_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + (num2 + 1) + "]//div[contains(@class,'arena_enemy_stat')]//div[2]")).isGetAttribute("outerText").Replace(".", ""));
			int length = num4.ToString().Length;
			list.Add(new EnemyData
			{
				Index = num2 + 1,
				Repytaciy = num3,
				BoevayMosh = num4,
				Power = num4 + num3 * Convert.ToInt64(Math.Pow(10.0, length)),
				Name = _driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + (num2 + 1) + "]/div[@class=\"arena_enemy_name\"]")).isGetAttribute("outerText")
			});
		}
		list.Sort((EnemyData a, EnemyData b) => a.Power.CompareTo(b.Power));
		foreach (EnemyData item in list)
		{
		}
		bool flag = AppSettings.Get("checkBoxArenaShtab", defaultValue: false);
		string text = "";
		bool flag2 = false;
		if (flag)
		{
			EnemyData enemyData = ((winners != null) ? list.FirstOrDefault((EnemyData enemy) => winners.Contains(enemy.Name)) : null);
			if (enemyData != null)
			{
				_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + enemyData.Index + "]")).IsClick("Арена Атака");
				text = enemyData.Name;
				flag2 = true;
			}
		}
		foreach (EnemyData item2 in list)
		{
			if (flag2)
			{
				break;
			}
			if ((num == 0 || item2.Repytaciy <= num) && (!flag || !losers.Contains(item2.Name)))
			{
				if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + item2.Index + "]")).IsClick("Арена Атака"))
				{
					text = item2.Name;
				}
				webElement = _driver.IsFindElement(By.Id("balert_wrap"));
				if (webElement != null)
				{
					flag2 = true;
					break;
				}
			}
		}
		foreach (EnemyData item3 in list)
		{
			if (flag2)
			{
				break;
			}
			if (AppSettings.Get("checkBoxArenaList", defaultValue: false))
			{
				string source2 = _driver.IsFindElement(By.XPath("//li[@id=\"i159\"]")).isGetAttribute("outerText");
				long.TryParse(string.Join("", source2.Where((char c) => char.IsDigit(c))), out var result2);
				if (result2 > 10)
				{
					break;
				}
			}
			if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"arena_enemy \")][" + item3.Index + "]")).IsClick("Арена Атака"))
			{
				text = item3.Name;
			}
			webElement = _driver.IsFindElement(By.Id("balert_wrap"));
			if (webElement != null)
			{
				break;
			}
		}
		if (webElement != null && webElement.Text.Contains("Вы проиграли. Пичалька."))
		{
			LogService.LogHtml("Арена <FONT COLOR=red>Проиграл " + text + "</FONT>");
			arenaDatetime = _driver.DateTimeCount("//div[@class=\"fl_r arena_wait_till\"]");
			AddPlayerResult("Lost", text);
			if (arenaDatetime > DateTime.Now)
			{
				Find.LabelStatus("Статус:");
				return arenaDatetime = arenaDatetime.AddSeconds(20.0);
			}
			Find.LabelStatus("Статус:");
			return DateTime.Now.AddSeconds(10.0);
		}
		if (webElement != null && webElement.Text.Contains("Вы победили. Ура!"))
		{
			LogService.LogHtml("Арена <FONT COLOR=green>Победили</FONT>");
			arenaDatetime = _driver.DateTimeCount("//div[@class=\"fl_r arena_wait_till\"]");
			AddPlayerResult("Win", text);
			if (arenaDatetime > DateTime.Now)
			{
				Find.LabelStatus("Статус:");
				return arenaDatetime = arenaDatetime.AddSeconds(20.0);
			}
			Find.LabelStatus("Статус:");
			return DateTime.Now.AddSeconds(10.0);
		}
		arenaDatetime = _driver.DateTimeCount("//div[@class=\"fl_r arena_wait_till\"]");
		if (arenaDatetime > DateTime.Now)
		{
			Find.LabelStatus("Статус:");
			return arenaDatetime = arenaDatetime.AddSeconds(20.0);
		}
		Find.LabelStatus("Статус:");
		return DateTime.Now.AddMinutes(5.0);
	}
}
