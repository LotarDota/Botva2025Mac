using Botva2025.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

internal class AvatarBitvaShashta
{
	private static AvatarBitvaShashta _instance;

	private IWebDriver _driver;

	public WebDriverWait wait;

	public static DateTime avatarBitvaShashtaDateTime { get; set; } = DateTime.Now;

	public AvatarBitvaShashta(IWebDriver driver)
	{
		_driver = driver;
		wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
	}

	public static AvatarBitvaShashta GetInstance(IWebDriver driver)
	{
		if (_instance != null)
		{
			return _instance;
		}
		_instance = new AvatarBitvaShashta(driver);
		return _instance;
	}

	public void avatarBitvaShashtaDateTimeReset()
	{
		avatarBitvaShashtaDateTime = DateTime.Now;
	}

	private void UpdateStatus(string text)
	{
		Find.LabelStatus(text);
	}

	public DateTime AvatarBitvaShashtaMain()
	{
		if (!AppSettings.Get("checkBoxAvatarBitvaShashta", defaultValue: false))
		{
			return DateTime.Now.AddMinutes(30.0);
		}
		if (avatarBitvaShashtaDateTime > DateTime.Now)
		{
			return avatarBitvaShashtaDateTime;
		}
		int[] array = new int[4] { 100, 75, 50, 30 };
		Random random = new Random();
		if (random.Next(0, 100) > array[AppSettings.Get("pictureBoxBZZProsent", 0)])
		{
			return DateTime.Now.AddMinutes(10.0);
		}
		UpdateStatus("Статус: Битва за земли");
		Go_dead();
		try
		{
			BitvaVhod();
		}
		catch
		{
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		TimeSpan timeSpan = TimeSpan.FromMinutes(5L);
		int num = 0;
		while (stopwatch.Elapsed < timeSpan)
		{
			if (AppSettings.Get("checkBoxAvatarBitvaShashta_exit_fight_ghost", defaultValue: false))
			{
				_driver.IsFindElement(By.XPath("//a[contains(@href,\"do_cmd=exit_fight\")]")).IsClick("exit_fight_ghost");
			}
			num++;
			if (Go_dead())
			{
				break;
			}
			string pageSource = _driver.PageSource;
			BitvaMappart(pageSource);
			List<Player> list = BitvaIgrokiParser("Враг", pageSource);
			List<Player> list2 = BitvaIgrokiParser("Друг", pageSource);
			List<Skill> list3 = Sskills(pageSource);
			if ((list == null || list.Count == 0) && (list2 == null || list2.Count == 0) && (list3 == null || list3.Count == 0))
			{
				if (!_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_prepare\")][contains(@class,\"active\")][contains(@class,\"status2\")][not(contains(@class,\"my_status2\"))]")).IsClick("Вход в битву"))
				{
					break;
				}
				try
				{
					BitvaVhod();
				}
				catch
				{
					break;
				}
				continue;
			}
			if (BitvaLogikaNew(list, list2, list3))
			{
				timeSpan = timeSpan.Add(TimeSpan.FromSeconds(10L));
			}
			Sleep();
			if (list == null && list2 == null && list3 == null)
			{
				if (!_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_prepare\")][contains(@class,\"active\")][contains(@class,\"status2\")][not(contains(@class,\"my_status2\"))]")).IsClick("Вход в битву"))
				{
					break;
				}
				try
				{
					BitvaVhod();
				}
				catch
				{
					break;
				}
			}
			else if (list.Count == 0 && list2.Count == 0 && list3.Count == 0)
			{
				if (!_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_prepare\")][contains(@class,\"active\")][contains(@class,\"status2\")][not(contains(@class,\"my_status2\"))]")).IsClick("Вход в битву"))
				{
					break;
				}
				try
				{
					BitvaVhod();
				}
				catch
				{
					break;
				}
			}
		}
		stopwatch.Stop();
		Go_dead();
		UpdateStatus("Статус:");
		return BitvaDateTime();
	}

	private bool BitvaLogika(List<Player> playersVrag, List<Player> playersDrug, List<Skill> skills)
	{
		Player player = playersDrug.FirstOrDefault((Player player5) => player5.Myself);
		foreach (Player item in playersDrug)
		{
		}
		if (player == null)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"splayer \")][contains(@class,\"myself\")]"));
			return false;
		}
		if (player.Health == 0)
		{
			return false;
		}
		List<string> list = new List<string> { "Атака", "0", "34", "38", "53", "54", "55", "58", "59" };
		List<string> list2 = new List<string> { "Лечить", "31", "32", "33", "37", "39", "4", "51", "52", "57" };
		List<string> list3 = new List<string> { "ОбщаяАтака", "1", "2", "3", "5", "6", "7", "8", "9" };
		List<string> list4 = new List<string> { "ОбщаяЛечить", "35", "56" };
		List<string> list5 = new List<string> { "Воскресить", "36" };
		Player player2 = MinZdorovie(playersVrag);
		Player player3 = MinZdorovie(playersDrug);
		Player player4 = IgrokiNull(playersDrug);
		int num = IgrokiNeSto(playersDrug);
		bool flag = false;
		foreach (Skill skill in skills)
		{
			if (skill.IsVisible && skill.Amount != 0 && !string.IsNullOrEmpty(skill.Name))
			{
				if (player.Health < 70 && list2.Contains(skill.Name) && Action(skill.Name, player, list2.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (player.Health < 30 && list4.Contains(skill.Name) && Action(skill.Name, player, list4.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (list5.Contains(skill.Name) && player4 != null && Action(skill.Name, player4, list5.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (list.Contains(skill.Name) && player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, list.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (list2.Contains(skill.Name) && player3 != null && player3.Id != "" && Action(skill.Name, player3, list2.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (list3.Contains(skill.Name) && playersVrag.Count > 4 && Action(skill.Name, player2, list3.ElementAt(0)))
				{
					flag = true;
					break;
				}
				if (list4.Contains(skill.Name) && num > 3 && Action(skill.Name, player3, list4.ElementAt(0)))
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	private bool BitvaLogikaNew(List<Player> playersVrag, List<Player> playersDrug, List<Skill> skills)
	{
		Player player = playersDrug.FirstOrDefault((Player player3) => player3.Myself);
		foreach (Player item in playersDrug)
		{
		}
		if (player == null)
		{
			IWebElement webElement = _driver.IsFindElement(By.XPath("//div[contains(@class,\"splayer \")][contains(@class,\"myself\")]"));
			return false;
		}
		if (player.Health == 0)
		{
			return false;
		}
		bool flag = false;
		foreach (Skill skill in skills)
		{
			if (!skill.IsVisible || skill.Amount == 0 || string.IsNullOrEmpty(skill.Name))
			{
				continue;
			}
			if (skill.Name == "0")
			{
				Player player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
				if (Action(skill.Name, player2, "Удар Копытом"))
				{
					flag = true;
					continue;
				}
			}
			if (zver_Shaxta(player, skill, playersDrug, playersVrag))
			{
				flag = true;
			}
			else if (lekar_Shaxta(player, skill, playersDrug, playersVrag))
			{
				flag = true;
			}
			else if (tank_Shaxta(player, skill, playersDrug, playersVrag))
			{
				flag = true;
			}
			else if (ninzy_Shaxta(player, skill, playersDrug, playersVrag))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	private bool zver_Shaxta(Player side_my, Skill skill, List<Player> playersDrug, List<Player> playersVrag)
	{
		if (!IsSkillInRange(skill.Name, 1, 9))
		{
			return false;
		}
		Player player = null;
		switch (skill.Name)
		{
		case "1":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "2":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MaxBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "3":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).Select(delegate(Player player2, int index)
			{
				int num = ((index > 0 && playersVrag[index - 1].Health != 0) ? playersVrag[index - 1].Health : 0);
				int num2 = ((index < playersVrag.Count - 1 && playersVrag[index + 1].Health != 0) ? playersVrag[index + 1].Health : 0);
				return new
				{
					Player = player2,
					Total = player2.Health + num + num2,
					HasTop = (index > 0),
					HasBottom = (index < playersVrag.Count - 1)
				};
			}).MaxBy(x => x.Total)?.Player;
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "4":
			if (side_my.Health < 60 && Action(skill.Name, side_my, "Лечить"))
			{
				return true;
			}
			break;
		case "5":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "6":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && player.Health < 30 && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "7":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "8":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && side_my.Health < 50 && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		case "9":
			player = playersVrag.Where((Player player2) => player2.Id != "" && player2.Health != 0).MinBy((Player player2) => player2.Health);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Атака"))
			{
				return true;
			}
			break;
		}
		return false;
	}

	private bool lekar_Shaxta(Player side_my, Skill skill, List<Player> playersDrug, List<Player> playersVrag)
	{
		if (!IsSkillInRange(skill.Name, 31, 39))
		{
			return false;
		}
		Player player = null;
		Player player2 = null;
		Player player3 = null;
		int num = 0;
		switch (skill.Name)
		{
		case "31":
			if (side_my.Health < 70 && Action(skill.Name, side_my, "Лечить"))
			{
				return true;
			}
			player = playersDrug.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health != 100).MinBy((Player player4) => player4.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Лечить"))
			{
				return true;
			}
			break;
		case "32":
			if (side_my.Health < 20 && Action(skill.Name, side_my, "Лечить"))
			{
				return true;
			}
			player = playersDrug.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health < 70).MinBy((Player player4) => player4.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Лечить"))
			{
				return true;
			}
			break;
		case "33":
			player = playersDrug.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health < 80).MinBy((Player player4) => player4.Health);
			if (player != null && ((player.Id != "") & (side_my.Health < 80)) && Action(skill.Name, player, "Лечить"))
			{
				return true;
			}
			break;
		case "34":
			player2 = playersVrag.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health != 100).MinBy((Player player4) => player4.Health);
			if (player2 != null && player2.Health != 0 && ((player2.Id != "0") & (side_my.Health > 10)) && Action(skill.Name, player2, "Атака"))
			{
				return true;
			}
			break;
		case "35":
			if (side_my.Health < 30 && Action(skill.Name, side_my, "ОбщаяЛечить"))
			{
				return true;
			}
			num = playersDrug.Count((Player player4) => player4.Health != 100);
			if (num > 3)
			{
				player = playersDrug.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health != 100).MinBy((Player player4) => player4.Health);
				if (Action(skill.Name, player, "ОбщаяЛечить"))
				{
					return true;
				}
			}
			break;
		case "36":
			player3 = playersDrug.FirstOrDefault((Player player4) => player4.Health == 0 && !player4.Myself && player4.Id != "" && !player4.Name.Contains("Палатка") && !player4.Name.Contains("Требушет"));
			if (player3 != null && Action(skill.Name, player3, "Воскресить"))
			{
				return true;
			}
			break;
		case "37":
			if (side_my.Health < 70 && Action(skill.Name, side_my, "Лечить"))
			{
				return true;
			}
			break;
		case "38":
			player2 = playersVrag.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health != 100).MinBy((Player player4) => player4.Health);
			if (player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, "Атака"))
			{
				return true;
			}
			break;
		case "39":
			if (side_my.Health < 70 && Action(skill.Name, side_my, "Лечить"))
			{
				return true;
			}
			player = playersDrug.Where((Player player4) => player4.Id != "" && player4.Health != 0 && player4.Health != 100).MinBy((Player player4) => player4.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Лечить"))
			{
				return true;
			}
			break;
		}
		return false;
	}

	private bool tank_Shaxta(Player side_my, Skill skill, List<Player> playersDrug, List<Player> playersVrag)
	{
		if (!IsSkillInRange(skill.Name, 51, 59))
		{
			return false;
		}
		Player player = null;
		Player player2 = null;
		int num = 0;
		switch (skill.Name)
		{
		case "51":
			if (side_my.Health < 20 && Action(skill.Name, side_my, "Укрытие"))
			{
				return true;
			}
			player = playersDrug.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Health != 100).MinBy((Player player3) => player3.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Укрытие"))
			{
				return true;
			}
			break;
		case "52":
			if (Action(skill.Name, side_my, "Защитить тыл!"))
			{
				return true;
			}
			break;
		case "53":
			player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
			if (player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, "Обманный удар"))
			{
				return true;
			}
			break;
		case "54":
			player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
			if (player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, "Удар щитом"))
			{
				return true;
			}
			break;
		case "55":
			player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Shield > 5).MaxBy((Player player3) => player3.Shield);
			if (player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, "Это мое!"))
			{
				return true;
			}
			break;
		case "56":
			num = playersDrug.Count((Player player3) => player3.Health != 100);
			if (num > 3 && side_my.Shield > 5 && Action(skill.Name, side_my, "За родину! За Ботву!"))
			{
				return true;
			}
			break;
		case "57":
			if (side_my.Health < 20 && Action(skill.Name, side_my, "Глухая оборона"))
			{
				return true;
			}
			player = playersDrug.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Health < 50).MinBy((Player player3) => player3.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Глухая оборона"))
			{
				return true;
			}
			break;
		case "58":
			player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Health != 100).MaxBy((Player player3) => player3.Shield);
			if (player2 != null && player2.Health != 0 && player2.Id != "0" && Action(skill.Name, player2, "Ледяное дыхание"))
			{
				return true;
			}
			break;
		case "59":
			player2 = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MaxBy((Player player3) => player3.Fury);
			if (player2 != null && Action(skill.Name, player2, "Ярая защита"))
			{
				return true;
			}
			break;
		}
		return false;
	}

	private bool ninzy_Shaxta(Player side_my, Skill skill, List<Player> playersDrug, List<Player> playersVrag)
	{
		if (!IsSkillInRange(skill.Name, 71, 79))
		{
			return false;
		}
		Player player = null;
		Player player2 = null;
		switch (skill.Name)
		{
		case "71":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MaxBy((Player player3) => player3.Shield);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Обнажающий удар"))
			{
				return true;
			}
			break;
		case "72":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Shield != 0).MaxBy((Player player3) => player3.Shield);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Скрытый маневр"))
			{
				return true;
			}
			break;
		case "73":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0 && player3.Shield != 0).MaxBy((Player player3) => player3.Shield);
			if (player != null && player.Health != 0 && player.Id != "0" && Action(skill.Name, player, "Нечестный обмен"))
			{
				return true;
			}
			break;
		case "74":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MaxBy((Player player3) => player3.Health);
			if (player != null && side_my.Fury > 10 && Action(skill.Name, player, "Заряженный удар"))
			{
				return true;
			}
			break;
		case "75":
			player2 = playersDrug.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Fury);
			if (player2 != null && player2.Id != "" && Action(skill.Name, player2, "Озлобленность"))
			{
				return true;
			}
			break;
		case "76":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Очищение"))
			{
				return true;
			}
			break;
		case "77":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Провокация"))
			{
				return true;
			}
			break;
		case "78":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MinBy((Player player3) => player3.Health);
			if (player != null && player.Id != "" && Action(skill.Name, player, "Удар с тыла"))
			{
				return true;
			}
			break;
		case "79":
			player = playersVrag.Where((Player player3) => player3.Id != "" && player3.Health != 0).MaxBy((Player player3) => player3.Fury);
			if (player != null && side_my.Health < 90 && Action(skill.Name, player, "Восстанавливающий удар"))
			{
				return true;
			}
			break;
		}
		return false;
	}

	private bool IsSkillInRange(string skillName, int startRange, int endRange)
	{
		if (int.TryParse(skillName, out var result))
		{
			if (result >= startRange)
			{
				return result <= endRange;
			}
			return false;
		}
		return false;
	}

	private int IgrokiNeSto(List<Player> players)
	{
		if (players == null || players.Count == 0)
		{
			return 0;
		}
		return players.Count((Player player) => player.Health != 100 && player.Id != "" && player.Health > 0);
	}

	private Player IgrokiNull(List<Player> players)
	{
		if (players == null || players.Count == 0)
		{
			return null;
		}
		return players.FirstOrDefault((Player player) => player.Health == 0 && !player.Myself && player.Id != "" && !player.Name.Contains("Палатка") && !player.Name.Contains("Требушет"));
	}

	private Player MinZdorovie(List<Player> players)
	{
		int num = int.MaxValue;
		Player result = null;
		foreach (Player player in players)
		{
			if (player.Id != "" && player.Health != 0 && player.Health != 100 && player.Health < num)
			{
				num = player.Health;
				result = player;
			}
		}
		return result;
	}

	private bool Action(string skill, Player player, string actionType)
	{
		if (player == null || player.Id == "")
		{
			return false;
		}
		if (skill == "" || skill == null)
		{
			return false;
		}
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		try
		{
			object value = javaScriptExecutor.ExecuteScript($"\r\n    return new Promise((resolve, reject) => {{\r\n        var skillElement = document.evaluate(\r\n            \"//div[contains(@class,'sskill{skill}')]\", \r\n            document, \r\n            null, \r\n            XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, \r\n            null\r\n        ).snapshotItem(0);\r\n\r\n        var playerElement = document.evaluate(\r\n            \"//div[@data-id='{player.Id}']\", \r\n            document, \r\n            null, \r\n            XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, \r\n            null\r\n        ).snapshotItem(0);\r\n\r\n        if (skillElement) {{\r\n            skillElement.click();\r\n            console.log('sskill{skill} клик');\r\n            setTimeout(() => {{\r\n                if (playerElement) {{\r\n                    playerElement.click();\r\n                    console.log('{player.Id} клик');\r\n                    resolve(true); // Успешно выполненный клик\r\n                }} else {{\r\n                    resolve(false); // Элемент не найден\r\n                }}\r\n            }}, 300); // Задержка в 300 мс\r\n        }} else {{\r\n            resolve(false); // Элемент не найден\r\n        }}\r\n    }});\r\n");
			bool flag = Convert.ToBoolean(value);
			if (flag)
			{
				Thread.Sleep(500);
			}
			return flag;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<Player> ParsePlayers(string html)
	{
		List<Player> list = new List<Player>();
		Regex regex = new Regex("<div.*?class=\"splayer .*?data-id=\"(-?\\d+)\".*?>.*?<span class=\"splayer_name_text\">(.*?)<\\/span>.*?<span class=\"health_prc\">(\\d+)<\\/span>%.*?<span class=\"splayer_protect_text info_protect\">(\\d+)<\\/span>.*?<span class=\"splayer_protect_text info_fury\">(\\d+)<\\/span>", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(html);
		foreach (Match item in matchCollection)
		{
			if (item.Success)
			{
				list.Add(new Player
				{
					Id = item.Groups[1].Value,
					Name = item.Groups[2].Value,
					Health = int.Parse(Regex.Match(item.Groups[3].Value, "\\d+").Value),
					Shield = int.Parse(Regex.Match(item.Groups[4].Value, "\\d+").Value),
					Fury = int.Parse(Regex.Match(item.Groups[5].Value, "\\d+").Value)
				});
			}
		}
		return list;
	}

	private List<Player> BitvaIgrokiParser(string Kto, string html)
	{
		List<Player> list = new List<Player>();
		string text = _driver.IsFindElement(By.XPath("//div[contains(@class,\"splayer \")][contains(@class,\"myself\")]")).isGetAttribute("data-side");
		string text2 = ((Kto == "Друг") ? text : ((!(Kto == "Враг")) ? "0" : ((text == "1") ? "2" : "1")));
		if (text2 == "0" || text == "")
		{
			return list;
		}
		Regex regex = new Regex("(?-s)splayer.*?(myself )?type.*?data-id=\"((?:-)?\\d+).*?data-side=\"" + text2 + "\"(?s).*?splayer_name_text\">(.*?)<.*?health_prc.*?>(\\d+)<.*?info_protect.*?>(\\d+)<.*?info_fury.*?>(\\d+)<", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(html);
		foreach (Match item in matchCollection)
		{
			if (item.Success)
			{
				list.Add(new Player
				{
					Id = item.Groups[2].Value,
					Name = item.Groups[3].Value,
					Health = int.Parse(Regex.Match(item.Groups[4].Value, "\\d+").Value),
					Shield = int.Parse(Regex.Match(item.Groups[5].Value, "\\d+").Value),
					Fury = int.Parse(Regex.Match(item.Groups[5].Value, "\\d+").Value),
					Myself = item.Groups[1].Value.Contains("myself")
				});
			}
		}
		foreach (Player item2 in list)
		{
		}
		return list;
	}

	private bool BitvaMappart_timer()
	{
		string text = _driver.IsFindElement(By.XPath("//span[contains(@timer,\"conflict_locations_timer\")]")).isGetAttribute("outerText");
		if (text != "")
		{
			return true;
		}
		return false;
	}

	private bool BitvaMappart(string st)
	{
		if (BitvaMappart_timer())
		{
			return false;
		}
		List<Room> list = new List<Room>();
		string text = _driver.IsFindElement(By.XPath("//div[contains(@class,\"splayer \")][contains(@class,\"myself\")]")).isGetAttribute("data-side");
		Regex regex = new Regex("(?-s)mappart mappart(\\d).*?(active.*?)?data-room(?s).*?(?-s)<div.*?race1.*?>(\\d)<(?s).*?<div(?-s).*?>(\\d)<.*?race2", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(st);
		foreach (Match item in matchCollection)
		{
			if (item.Success)
			{
				int.TryParse(string.Join("", item.Groups[1].Value), out var result);
				int result2;
				int result3;
				if (text == "2")
				{
					int.TryParse(string.Join("", item.Groups[3].Value), out result2);
					int.TryParse(string.Join("", item.Groups[4].Value), out result3);
				}
				else
				{
					int.TryParse(string.Join("", item.Groups[3].Value), out result3);
					int.TryParse(string.Join("", item.Groups[4].Value), out result2);
				}
				bool activ = item.Groups[2].Value.Contains("active");
				list.Add(new Room
				{
					RoomNumber = result,
					Race1Vrag = result2,
					Race2Drug = result3,
					Activ = activ
				});
			}
		}
		foreach (Room item2 in list)
		{
		}
		Room room = list.OrderByDescending((Room room2) => room2.Summa).FirstOrDefault();
		if (room != null && !room.Activ && room.Race2Drug != 8)
		{
			_driver.IsFindElement(By.XPath("//div[contains(@class,\"mappart mappart" + room.RoomNumber + "\")]")).IsClick("Клик Комата " + room.RoomNumber);
		}
		return true;
	}

	private Room BitvaVhodRoom(ReadOnlyCollection<IWebElement> roomElements)
	{
		List<Room> list = new List<Room>();
		string text = _driver.IsFindElement(By.XPath("//div[contains(@class,\"splayer \")][contains(@class,\"myself\")]")).isGetAttribute("data-side");
		foreach (IWebElement roomElement in roomElements)
		{
			try
			{
				int.TryParse(string.Join("", from c in roomElement.IsFindElement(By.XPath(".//input[@name=\"room\"]")).isGetAttribute("value")
					where char.IsDigit(c)
					select c), out var result);
				int result2;
				int result3;
				if (text == "2")
				{
					int.TryParse(string.Join("", roomElement.IsFindElement(By.XPath(".//b[contains(@class,\"icon race1\")]//..")).isGetAttribute("outerText").Split('/')[0].Where((char c) => char.IsDigit(c))), out result2);
					int.TryParse(string.Join("", roomElement.IsFindElement(By.XPath(".//b[contains(@class,\"icon race2\")]//..")).isGetAttribute("outerText").Split('/')[0].Where((char c) => char.IsDigit(c))), out result3);
				}
				else
				{
					int.TryParse(string.Join("", roomElement.IsFindElement(By.XPath(".//b[contains(@class,\"icon race1\")]//..")).isGetAttribute("outerText").Split('/')[0].Where((char c) => char.IsDigit(c))), out result3);
					int.TryParse(string.Join("", roomElement.IsFindElement(By.XPath(".//b[contains(@class,\"icon race2\")]//..")).isGetAttribute("outerText").Split('/')[0].Where((char c) => char.IsDigit(c))), out result2);
				}
				list.Add(new Room
				{
					RoomNumber = result,
					Race1Vrag = result2,
					Race2Drug = result3
				});
			}
			catch (Exception)
			{
			}
		}
		foreach (Room item in list)
		{
		}
		return (from room in list
			where room.Race2Drug != 8
			orderby room.Summa descending
			select room).FirstOrDefault();
	}

	private void BitvaVhod()
	{
		if (!_driver.Url.Contains("botva.ru/conflict.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"button_prepare\")][contains(@class,\"active\")][contains(@class,\"status2\")][not(contains(@class,\"my_status2\"))]")).IsClick("Вход в битву"))
		{
			wait.TryUntil(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class,\"conflict_go_arrow\")][contains(@class,\"active\")]")));
		}
		for (int i = 0; i < 12; i++)
		{
			ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,'conflict_prepare_map')]//div[contains(@class,'part part')]"));
			if (readOnlyCollection.Count != 0)
			{
				Room room = BitvaVhodRoom(readOnlyCollection);
				if (room != null)
				{
					_driver.IsFindElement(By.XPath("//div[" + room.RoomNumber + "]/div[contains(@class,\"conflict_go_arrow\")][contains(@class,\"active\")]")).IsClick("Клик Комата " + room.RoomNumber);
					break;
				}
				Thread.Sleep(5000);
				continue;
			}
			break;
		}
	}

	private int Show_timer()
	{
		int result = 0;
		string source = _driver.IsFindElement(By.XPath("//div[contains(string(.),\"Вы отдыхаете:\")]")).isGetAttribute("outerText");
		int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out result);
		return result;
	}

	private List<Skill> Sskills(string html)
	{
		List<Skill> result = new List<Skill>();
		IWebElement webElement = _driver.IsFindElement(By.CssSelector("div.sskills.center"));
		if (webElement == null)
		{
			return result;
		}
		result = ParserSskills(html);
		foreach (Skill item in result)
		{
		}
		return result;
	}

	private List<Skill> ParserSskills(string html)
	{
		List<Skill> list = new List<Skill>();
		Regex regex = new Regex("<div class=\"item_box sskill.*? data-skill=\"(\\d+)\".*?class=\"modern_amount\">(.*?)<\\/b>.*?class=\"sskill_cd.*?(style=\".*?\")?>", RegexOptions.Singleline);
		MatchCollection matchCollection = regex.Matches(html);
		foreach (Match item in matchCollection)
		{
			if (item.Success)
			{
				string value = item.Groups[1].Value;
				string value2 = item.Groups[2].Value;
				string text = item.Groups[3].Value;
				if (text == "")
				{
					text = "100%";
				}
				bool isVisible = text.Contains("100%");
				int.TryParse(Regex.Replace(value2, "\\D", ""), out var result);
				if (value == "0")
				{
					result = 100;
				}
				list.Add(new Skill
				{
					Name = value,
					Amount = result,
					IsVisible = isVisible
				});
			}
		}
		return list;
	}

	private int Sleep()
	{
		int num = int.MaxValue;
		int[] array = new int[2]
		{
			Show_dead(),
			Show_timer()
		};
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] < num)
			{
				num = array[i];
			}
		}
		return num;
	}

	private int Show_dead()
	{
		int result = 0;
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"cmd_resurrect\")]//span[string(.)=\"ВОСКРЕСНУТЬ!\"]")).IsClick("ВОСКРЕСНУТЬ!");
		string source = _driver.IsFindElement(By.XPath("//div[contains(@text,\"Без воскрешения вы покинете бой через:\")]")).isGetAttribute("outerText");
		int.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out result);
		return result;
	}

	private bool Go_dead()
	{
		if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"button_new\")]/span[contains(string(.),\"ПОКИНУТЬ БОЙ\")]")).IsClick("ПОКИНУТЬ БОЙ"))
		{
			return true;
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span[contains(string(.),\"ДОЖДАТЬСЯ НАГРАДЫ!\")]")).IsClick("ДОЖДАТЬСЯ НАГРАДЫ!", 1000);
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span[contains(string(.),\"ДОЖДАТЬСЯ НАГРАДЫ!\")]")).IsClick("ДОЖДАТЬСЯ НАГРАДЫ!", 1000);
		if (_driver.IsFindElement(By.XPath("//a[contains(@class,\"button_prepare has_chest\")]")).IsClick("Забрать Приз"))
		{
			Thread.Sleep(1000);
			if (_driver.IsFindElement(By.XPath("//span[contains(text(),\"Забрать награду\")]")).IsClick("Забрать награду"))
			{
				LogService.LogHtml("Аватар Забрать Награду ");
				_driver.isExecuteScriptClick(By.Id("m44"), "Битва за земли");
				Thread.Sleep(1000);
			}
		}
		return false;
	}

	public DateTime BitvaDateTime()
	{
		DateTime minDate = DateTime.MaxValue;
		ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath("//div[contains(@class,\"button_prepare active\")]"));
		DateTime today = DateTime.Today;
		foreach (IWebElement item in readOnlyCollection)
		{
			string s = item.isGetAttribute("title").Replace("Бой начнется в <b>", "").Replace("</b>", "");
			if (DateTime.TryParseExact(s, "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out var result))
			{
				if (result.TimeOfDay < today.TimeOfDay)
				{
					result = result.AddDays(1.0);
				}
				if (result < minDate)
				{
					minDate = result;
				}
			}
		}
		if (minDate != DateTime.MaxValue)
		{
			int[] array = new int[1] { 1 };
			int[] array2 = array;
			foreach (int zaderka in array2)
			{
				Task.Run(async delegate
				{
					DateTime dateTime = minDate.AddMinutes(-zaderka);
					TimeSpan delay = dateTime - DateTime.Now;
					if (delay.TotalMilliseconds > 0.0)
					{
						await Task.Delay(delay);
						await Google.SendToGoogleSheetsBBZ($"⚔\ufe0f {zaderka} мин {minDate:HH:mm}");
					}
				});
			}
		}
		else
		{
			minDate = DateTime.Now.AddMinutes(10.0);
		}
		avatarBitvaShashtaDateTime = minDate.AddSeconds(15.0);
		return avatarBitvaShashtaDateTime;
	}
}
