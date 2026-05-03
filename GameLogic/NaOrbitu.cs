using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

public class NaOrbitu
{
	private readonly IWebDriver _driver;

	private DateTime AdateTime;

	private readonly Dictionary<string, (string name, int capacity, int raznoe)> korablVrag;

	private readonly Dictionary<string, int> korablSvoy;

	private readonly Dictionary<string, int> Oryshie;

	private int numberEtap;

	public NaOrbitu(IWebDriver driver)
	{
		_driver = driver;
		korablVrag = new Dictionary<string, (string, int, int)>();
		korablSvoy = new Dictionary<string, int>();
		Oryshie = new Dictionary<string, int>();
		numberEtap = 0;
	}

	public DateTime NaOrbituMain()
	{
		bool flag = false;
		Dictionary<string, int> dictionary = new Dictionary<string, int>
		{
			{ "item_box lunar_skill skill1 side2", 0 },
			{ "item_box lunar_skill skill2 side2", 0 },
			{ "item_box lunar_skill skill3 side1", 0 },
			{ "item_box lunar_skill skill4 side1", 0 },
			{ "item_box lunar_skill skill5 side1", 0 },
			{ "item_box lunar_skill skill6 side0", 0 },
			{ "item_box lunar_skill skill7 side1", 0 },
			{ "item_box lunar_skill skill8 side0", 0 },
			{ "item_box lunar_skill skill9 side2", 0 },
			{ "item_box lunar_skill skill10 side2", 0 },
			{ "item_box lunar_skill skill11 side0", 0 },
			{ "item_box lunar_skill skill12 side0", 0 }
		};
		UpdateStatus("Статус:На Орбиту");
		if (_driver.isExecuteScriptClick(By.XPath("//a[@href='event.php?a=lunar']"), "На Орбиту"))
		{
			Thread.Sleep(1000);
		}
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span/b[contains(text(),\"Забрать призы\")]/../input")).IsClick("Забрать призы");
		DateTime dateTime = _driver.DateTimeCount("//div[@id=\"lunar_next_battle\"]");
		if (dateTime > DateTime.Now && (dateTime - DateTime.Now).TotalSeconds > 300.0)
		{
			UpdateStatus("Статус:");
			return AdateTime = dateTime.AddMinutes(-2.0);
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(@class, 'button_new')]/span[contains(text(),'Записаться')]/input")).IsClick("Записаться"))
		{
			flag = true;
			Thread.Sleep(1000);
			if (_driver.IsFindElement(By.XPath("//div[contains(@class, 'button_new')]/span[contains(text(),'Записаться')]/input")).IsClick("Записаться"))
			{
				Find.Sleep(1000);
			}
		}
		if (_driver.IsFindElement(By.XPath("//div[contains(@class, 'conflict_battle')][1]")) != null)
		{
			flag = true;
		}
		string text = _driver.IsFindElement(By.CssSelector(".round_block_round_border.round_block_header_cont.p10.clear_fix")).isGetAttribute("innerText");
		if (text.Contains("Вы записались на битву"))
		{
			flag = true;
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"lunar_timer\"]")).IsClick())
		{
			flag = true;
		}
		int num = 0;
		string text2 = _driver.Url;
		int num2 = text2.LastIndexOf('/');
		if (num2 != -1)
		{
			text2 = text2.Substring(0, num2);
		}
		while (flag)
		{
			dateTime = _driver.DateTimeCount("//div[@id=\"lunar_next_battle\"]");
			if (dateTime >= DateTime.Now)
			{
				if ((dateTime - DateTime.Now).TotalSeconds > 300.0)
				{
					UpdateStatus("Статус:");
					_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span/b[contains(text(),\"Забрать призы\")]/../input")).IsClick("Забрать призы");
					return AdateTime = dateTime.AddMinutes(-2.0);
				}
				Thread.Sleep((int)(dateTime.AddSeconds(5.0) - DateTime.Now).TotalSeconds * 1000);
			}
			num++;
			if (num > 15)
			{
				flag = false;
				continue;
			}
			Thread.Sleep(1000);
			if (_driver.IsFindElement(By.XPath("//div[@id=\"lunar_next_battle\"]")) != null)
			{
				continue;
			}
			int.TryParse(_driver.IsFindElement(By.XPath("//div[@class=\"lunar_stage\"]/span")).isGetAttribute("innerText"), out numberEtap);
			string input = _driver.IsFindElement(By.XPath("//div[@class=\"lunar_enemies\"]")).isGetAttribute("innerHTML");
			MatchCollection matchCollection = Regex.Matches(input, "class=\"(user_block.*?)\".*?<div class=.bar. style=.width: (\\d+).*?class=.text.>(.*?)<.*?class=.lunar_name.>(.*?)<", RegexOptions.Singleline);
			korablVrag.Clear();
			for (int i = 0; i < matchCollection.Count; i++)
			{
				int result = int.MaxValue;
				int.TryParse(matchCollection[i].Groups[3].Value, out result);
				korablVrag.Add(matchCollection[i].Groups[1].Value, (matchCollection[i].Groups[4].Value, result, 0));
			}
			if (korablVrag.Count > 0 && korablVrag.Values.Max(((string name, int capacity, int raznoe) x) => x.capacity) == 0)
			{
				continue;
			}
			KeyValuePair<string, (string, int, int)> keyValuePair = korablVrag.OrderBy((KeyValuePair<string, (string name, int capacity, int raznoe)> u) => u.Value.capacity).FirstOrDefault((KeyValuePair<string, (string name, int capacity, int raznoe)> kv) => kv.Value.capacity != 0);
			if (keyValuePair.Key != null && keyValuePair.Key.Contains("disabled"))
			{
				Thread.Sleep(5000);
				continue;
			}
			List<(string, string)> list = new List<(string, string)>();
			MatchCollection matchCollection2 = Regex.Matches(input, "(?<=item_box lunar_skill (skill\\d+).*?)enemy\">(.*?)<", RegexOptions.Singleline);
			for (int num3 = 0; num3 < matchCollection2.Count; num3++)
			{
				list.Add((matchCollection2[num3].Groups[2].Value, matchCollection2[num3].Groups[1].Value));
			}
			string input2 = _driver.IsFindElement(By.XPath("//div[@class=\"lunar_allies\"]")).isGetAttribute("innerHTML");
			MatchCollection matchCollection3 = Regex.Matches(input2, "class=\"(user_block.*?)\".*?<div class=.bar. style=.width: (\\d+).*?class=.text.>(.*?)<.*?class=.lunar_name.>(.*?)<", RegexOptions.Singleline);
			korablSvoy.Clear();
			for (int num4 = 0; num4 < matchCollection3.Count; num4++)
			{
				int result2 = int.MaxValue;
				int.TryParse(matchCollection3[num4].Groups[3].Value, out result2);
				korablSvoy.Add(matchCollection3[num4].Groups[1].Value, result2);
			}
			if (korablSvoy.Count > 0 && korablSvoy.Values.Max() == 0)
			{
				continue;
			}
			Oryshie.Clear();
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				int result3 = 0;
				text = _driver.IsFindElement(By.XPath("//div[contains(@class,'" + item.Key + "')][not(@style)]")).isGetAttribute("innerText").Trim();
				int.TryParse(text, out result3);
				Oryshie.Add(item.Key, result3);
			}
			Oryshie["item_box lunar_skill skill1 side2"] = 100;
			if (korablVrag.Count > 0 && korablVrag.Values.Max(((string name, int capacity, int raznoe) x) => x.capacity) != 0 && korablSvoy.Count > 0 && korablSvoy.Values.Max() != 0)
			{
				num = 0;
			}
			_ = korablSvoy?.Any((KeyValuePair<string, int> kv) => kv.Key.Contains("myself") && kv.Value == 0) ?? false;
			try
			{
				NaOrbityDelat();
			}
			catch
			{
			}
			Thread.Sleep((Lunar_timer() + 7) * 1000);
		}
		string text3 = _driver.IsFindElement(By.XPath("//div[@class='lunar_enemies']")).isGetAttribute("innerHTML");
		if (text3 != null)
		{
			_driver.Navigate().Refresh();
			text3 = _driver.IsFindElement(By.XPath("//div[@class='lunar_enemies']")).isGetAttribute("innerHTML");
			if (text3 != null)
			{
				_driver.Navigate().GoToUrl(text2);
			}
		}
		Thread.Sleep(2000);
		_driver.IsFindElement(By.XPath("//div[contains(@class,\"popup_my_container\")]//span/b[contains(text(),\"Забрать призы\")]/../input")).IsClick("Забрать призы");
		dateTime = _driver.DateTimeCount("//div[@id=\"lunar_next_battle\"]");
		if (dateTime > DateTime.Now && (dateTime - DateTime.Now).TotalSeconds > 300.0)
		{
			UpdateStatus("Статус:");
			return AdateTime = dateTime.AddMinutes(-2.0);
		}
		UpdateStatus("Статус:");
		return AdateTime = DateTime.Now.AddMinutes(15.0);
	}

	private void UpdateStatus(string v)
	{
		Find.LabelStatus(v);
	}

	private int Lunar_timer()
	{
		string text = _driver.IsFindElement(By.XPath("//div[@class=\"lunar_timer\"]")).isGetAttribute("innerText").Trim();
		if (text != null)
		{
			return int.Parse(text);
		}
		return 0;
	}

	private void NaOrbityDelat()
	{
		if (korablVrag.Count == 0 || korablSvoy.Count == 0 || Oryshie.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in Oryshie)
		{
		}
		int num = 700;
		int num2 = 300;
		if (numberEtap > 10 && numberEtap <= 20)
		{
			num = 800;
			num2 = 400;
		}
		else if (numberEtap > 20 && numberEtap <= 30)
		{
			num = 900;
			num2 = 600;
		}
		else if (numberEtap > 30)
		{
			num = 1100;
			num2 = 1000;
		}
		foreach (KeyValuePair<string, int> item2 in korablSvoy)
		{
			if (item2.Key.Contains("myself"))
			{
				if (item2.Value == 0 || (item2.Value < num2 && Oryshie.ElementAt(3).Value > 0 && NaOrbityAction(item2.Key, Oryshie.ElementAt(3).Key)) || (item2.Value < num && Oryshie.ElementAt(2).Value > 0 && NaOrbityAction(item2.Key, Oryshie.ElementAt(2).Key)))
				{
					return;
				}
				break;
			}
		}
		IOrderedEnumerable<KeyValuePair<string, (string, int, int)>> orderedEnumerable = korablVrag.OrderByDescending((KeyValuePair<string, (string name, int capacity, int raznoe)> u) => u.Value.capacity);
		IOrderedEnumerable<KeyValuePair<string, (string, int, int)>> orderedEnumerable2 = korablVrag.OrderBy((KeyValuePair<string, (string name, int capacity, int raznoe)> u) => u.Value.capacity);
		KeyValuePair<string, (string, int, int)> ferstAtaka;
		if (numberEtap > 17 || korablVrag.Count <= 3)
		{
			ferstAtaka = orderedEnumerable.FirstOrDefault<KeyValuePair<string, (string, int, int)>>((KeyValuePair<string, (string name, int capacity, int raznoe)> kv) => kv.Value.capacity != 0);
			foreach (KeyValuePair<string, (string, int, int)> item3 in orderedEnumerable)
			{
			}
		}
		else
		{
			ferstAtaka = orderedEnumerable2.FirstOrDefault<KeyValuePair<string, (string, int, int)>>((KeyValuePair<string, (string name, int capacity, int raznoe)> kv) => kv.Value.capacity != 0);
			foreach (KeyValuePair<string, (string, int, int)> item4 in orderedEnumerable2)
			{
			}
		}
		if (ferstAtaka.Key == null)
		{
			return;
		}
		foreach (KeyValuePair<string, (string, int, int)> item5 in orderedEnumerable)
		{
		}
		if (ferstAtaka.Key.Contains("disabled"))
		{
			Thread.Sleep(10000);
		}
		else if (!AtakaVragDefauld(ferstAtaka))
		{
			NaOrbityAction(ferstAtaka.Key, "item_box lunar_skill skill1 side2");
		}
	}

	private bool AtakaVragDefauld(KeyValuePair<string, (string name, int capacity, int raznoe)> ferstAtaka)
	{
		foreach (KeyValuePair<string, int> item in korablSvoy)
		{
			if (item.Key.Contains("myself"))
			{
				if (item.Value == 0)
				{
					break;
				}
				if (NaOrbityAction(item.Key, Oryshie.ElementAt(4).Key) || NaOrbityAction(item.Key, Oryshie.ElementAt(5).Key) || NaOrbityAction(item.Key, Oryshie.ElementAt(6).Key))
				{
					return true;
				}
			}
		}
		for (int num = Oryshie.Count - 1; num > 0; num--)
		{
			if (num != 2 && num != 3 && num != 6 && num != 4 && num != 5 && Oryshie.ElementAt(num).Value != 0 && NaOrbityAction(ferstAtaka.Key, Oryshie.ElementAt(num).Key))
			{
				return true;
			}
		}
		return false;
	}

	private bool NaOrbityAction(string class1, string class2)
	{
		if (Oryshie[class2] == 0)
		{
			return false;
		}
		if (_driver.IsFindElement(By.XPath("//div[@class=\"lunar_controls\"]/div[contains(@class,\"" + class2 + "\")]")).IsClick("Клик оружие " + class2 + " "))
		{
			Thread.Sleep(500);
			if (_driver.IsFindElement(By.XPath("//div[contains(@class,\"" + class1 + "\")]")).IsClick("Клик корабль " + class1 + " "))
			{
				Thread.Sleep(500);
				return true;
			}
		}
		return false;
	}
}
