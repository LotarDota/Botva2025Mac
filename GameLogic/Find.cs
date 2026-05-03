using System.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Botva2025.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Botva2025;

public static class Find
{
	private delegate bool GetBoolValue();

	public static bool TimerRabota(this IWebDriver _driver, out DateTime dateTime)
	{
		if (DateTime.TryParseExact(_driver.IsFindElement(By.XPath("//div[@id=\"rmenu1\"]/div/a[@class=\"timer link\"]/span")).isGetAttribute("outerText"), "HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime))
		{
			dateTime = DateTime.Now.AddSeconds(dateTime.Second).AddMinutes(dateTime.Minute).AddHours(dateTime.Hour);
			return true;
		}
		dateTime = DateTime.Now;
		return false;
	}

	public static bool ByePredmet(this IWebDriver _driver)
	{
		_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		_driver.IsFindElement(By.XPath("//a[@href='/dressingroom.php'][not(contains(@class,'open'))]")).IsClick("Одевалка");
		int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@id='bag0_free']")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out var _);
		string[] source = new string[48]
		{
			"items/r_Weap_47s.jpg", "items/u_Weap_47s.jpg", "items/r_Weap_54s.jpg", "items/u_Weap_54s.jpg", "items/r_Weap_55s.jpg", "items/u_Weap_55s.jpg", "items/r_Weap_62s.jpg", "items/u_Weap_62s.jpg", "items/r_Weap_69s.jpg", "items/u_Weap_69s.jpg",
			"items/r_Weap_70s.jpg", "items/u_Weap_70s.jpg", "items/r_Weap_90s.jpg", "items/u_Weap_90s.jpg", "items/r_Shield_23s.jpg", "items/u_Shield_23s.jpg", "items/r_Shield_25s.jpg", "items/u_Shield_25s.jpg", "items/r_Shield_29s.jpg", "items/u_Shield_29s.jpg",
			"items/r_Shield_31s.jpg", "items/u_Shield_31s.jpg", "items/r_Shield_32s.jpg", "items/u_Shield_32s.jpg", "items/r_Shield_33s.jpg", "items/u_Shield_33s.jpg", "items/r_Arm_33s.jpg", "items/u_Arm_33s.jpg", "items/r_Arm_39s.jpg", "items/u_Arm_39s.jpg",
			"items/r_Arm_42s.jpg", "items/u_Arm_42s.jpg", "items/r_Arm_50s.jpg", "items/u_Arm_50s.jpg", "items/r_Helm_39s.jpg", "items/u_Helm_39s.jpg", "items/r_Helm_43s.jpg", "items/u_Helm_43s.jpg", "items/r_Helm_49s.jpg", "items/u_Helm_49s.jpg",
			"items/r_Glove_20s.jpg", "items/u_Glove_20s.jpg", "items/r_Glove_30s.jpg", "items/u_Glove_30s.jpg", "items/r_Glove_39s.jpg", "items/u_Glove_39s.jpg", "items/r_Glove_32s.jpg", "items/u_Glove_32s.jpg"
		};
		string text = string.Join(" or ", source.Select((string img) => "contains(@src, '" + img + "')"));
		string xpathToFind = "//span[@id='listBag0']//img[" + text + "]";
		ReadOnlyCollection<IWebElement> readOnlyCollection = _driver.FindElements(By.XPath(xpathToFind));
		bool result2 = false;
		int num = 10;
		int num2 = 0;
		for (int num3 = 0; num3 < readOnlyCollection.Count; num3++)
		{
			if (num2 >= num)
			{
				break;
			}
			if (readOnlyCollection[num3].IsFindElement(By.XPath("./parent::span[@actions]")).IsClick("Выбрать"))
			{
				_driver.isExecuteScriptClick(By.XPath("//a[@id='cmd_drop'][not(contains(@class,'cmd_blocked'))]"), "выбросить", 1000);
				By obj = By.XPath("//div[contains(@class,\"box_controls\")]//span[contains(string(.),\"ОК\")]");
				_driver.WaitFind(obj, TimeSpan.FromSeconds(2L));
				_driver.isExecuteScriptClick(obj, "выбросить", 1000);
				result2 = true;
				readOnlyCollection = _driver.FindElements(By.XPath(xpathToFind));
				num3 = -1;
				num2++;
			}
		}
		return result2;
	}

	public static bool TryUntil(this WebDriverWait wait, Func<IWebDriver, IWebElement> condition)
	{
		try
		{
			wait.Until(condition);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void LabelStatus(string status)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		if (((ReadOnlyCollectionBase)(object)Application.OpenForms).Count <= 0)
		{
			return;
		}
		Form val = Application.OpenForms[0];
		Form1 form = val as Form1;
		if (form != null)
		{
			((Control)form.labelStatus).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)form.labelStatus).Text = status;
			});
		}
	}

	public static string IsUrl(this IWebDriver driver)
	{
		try
		{
			return driver.Url;
		}
		catch
		{
			return "";
		}
	}

	public static void Avatar_Kach_Pirashka_Post(this IWebDriver _driver)
	{
		bool[] array = new bool[5]
		{
			AppSettings.Get("checkBoxAvatar_Kach1", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach2", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach3", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach4", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach5", defaultValue: false)
		};
		if (AppSettings.Get("checkBoxKachPirashkiPost", defaultValue: false))
		{
			LabelStatus("Статус:Аватар Качать Статы Пирашки Post");
			if (!_driver.IsUrl().Contains("botva.ru/index.php"))
			{
				_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
			}
			_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and @onclick=\"avatar_training_tabs_handler.click(1002)\"]")).IsClick("Тренировка за рыбу");
			string text = _driver.IsFindElement(By.XPath("//input[@name='total_discount']")).isGetAttribute("value");
			LabelStatus("Статус:");
		}
	}

	private static bool Kach_Pirashka_Post(this IWebDriver _driver, string statToTrain, string discount)
	{
		WebBrowserLog("Качаю Post " + statToTrain + " Post ");
		string initialPirashkaValue = _driver.ResyPiraShki().ToString();
		IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
		string script = $"\r\n\r\n// Получаем discount одним выражением (ваш вариант)\r\nlet discountElement = document.getElementById('avatar_{statToTrain}_fish_amount').closest('form').querySelector('input[name=\"total_discount\"]');\r\nlet discount = discountElement ? discountElement.value : '0';\r\n\r\nconsole.log('Discount для', '{statToTrain} :', discount);\r\n\r\n// Выполняем запрос с полученным discount\r\n$.post('index.php?a=basic', {{ \r\n    k: KEY,\r\n    autobuy: '0',\r\n    greenpack: '0',\r\n    '{statToTrain}': '99999',\r\n    cmd: 'do_upgrade_fish_fast',\r\n    'total_discount': discount,\r\n    do_content_as_json: '1'\r\n}},\r\nfunction(result) {{\r\n    // Проверяем ответ сервера\r\n    if (!result || !result.update) {{\r\n        console.error('Некорректный ответ сервера');\r\n        return KEY;\r\n    }}\r\n\r\n    // Обновляем отображение рыбы\r\n    if (result.update.fish && result.update.fish.data) {{\r\n        var fishElement = document.getElementById('fish_upd_data');\r\n        if (fishElement) {{\r\n            var newValue = result.update.fish.data;\r\n            var valueWithoutDots = newValue.toString().replace(/\\./g, '');\r\n            fishElement.textContent = valueWithoutDots;\r\n            console.log('Рыба обновлена ', valueWithoutDots);\r\n\r\n        }}\r\n    }}\r\n\r\n    // Обновляем интерфейс\r\n    if (result.update.body && result.update.body.data) {{\r\n        try {{\r\n            const tempDiv = document.createElement('div');\r\n            tempDiv.innerHTML = result.update.body.data;\r\n\r\n            // 1. Обновление стата\r\n         const statElement = tempDiv.querySelector(`div[onmouseover*=\"doItem('${statToTrain}\"] div.value1avatar:not([class*=\"avatar_stat_\"])`);\r\n\t\tif (statElement) {{\r\n  \t\t  var avatarStat = document.querySelector(`div[onmouseover*=\"doItem('${statToTrain}\"] div.value1avatar:not([class*=\"avatar_stat_\"])`);\r\n   \t\t if (avatarStat) {{\r\n   \t\t     avatarStat.innerHTML = statElement.innerHTML;\r\n    \t\t    console.log('Стат обновлен ', statElement.innerHTML);\r\n    }}\r\n}}\r\n\r\n            // 2. Обновление discount (если изменился)\r\n            const discountElement = tempDiv.querySelector('.training_{statToTrain}_fish input[name=\"total_discount\"]');       \r\n            if (discountElement) {{\r\n                var avatarDiscount = document.querySelector('.training_{statToTrain}_fish input[name=\"total_discount\"]');\r\n                if (avatarDiscount) {{\r\n                    avatarDiscount.value = discountElement.value || discountElement.getAttribute('value') || '';\r\n\t\t    console.log('Дискоунт обновлен ', avatarDiscount.value);\r\n\r\n                }}\r\n            }}\r\n\r\n            // 3. Обновление цены\r\n            const priceElement = tempDiv.querySelector('#price_{statToTrain}_fish.ability_price');       \r\n            if (priceElement) {{\r\n                var avatarPrice = document.querySelector('#price_{statToTrain}_fish.ability_price');\r\n                if (avatarPrice) {{\r\n                    avatarPrice.innerHTML = priceElement.innerHTML;\r\n\t\t    console.log('Цена стата обновлен ', priceElement.innerHTML);\r\n\r\n                }}\r\n            }}\r\n        }} catch (e) {{\r\n            console.error('Ошибка при парсинге HTML:', e);\r\n        }}\r\n    }}\r\n\r\n    // Обновляем KEY\r\n    if (result.data && result.data.key) {{\r\n        KEY = result.data.key;\r\n        console.log('KEY обновлен:', KEY);\r\n    }}\r\n\r\n   \r\n}},\r\n'JSON'); \r\nreturn KEY;";
		string text = javaScriptExecutor.ExecuteScript(script).ToString();
		int num = 5;
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(num));
		webDriverWait.Until(delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(By.Id("fish_upd_data"));
				string text2 = webElement.Text;
				return !string.IsNullOrEmpty(text2) && text2 != initialPirashkaValue;
			}
			catch
			{
				return false;
			}
		});
		Thread.Sleep(1000);
		return true;
	}

	public static void Avatar_Kach_Pirashka(this IWebDriver _driver)
	{
		bool[] array = new bool[5]
		{
			AppSettings.Get("checkBoxAvatar_Kach1", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach2", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach3", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach4", defaultValue: false),
			AppSettings.Get("checkBoxAvatar_Kach5", defaultValue: false)
		};
		GetBoolValue[] array2 = new GetBoolValue[5]
		{
			() => AppSettings.Get("checkBoxAvatar_Kach1", defaultValue: false),
			() => AppSettings.Get("checkBoxAvatar_Kach2", defaultValue: false),
			() => AppSettings.Get("checkBoxAvatar_Kach3", defaultValue: false),
			() => AppSettings.Get("checkBoxAvatar_Kach4", defaultValue: false),
			() => AppSettings.Get("checkBoxAvatar_Kach5", defaultValue: false)
		};
		LabelStatus("Статус:Аватар Качать Статы Пирашки");
		if (!_driver.IsUrl().Contains("botva.ru/index.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		}
		_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and @onclick=\"avatar_training_tabs_handler.click(1002)\"]")).IsClick("Тренировка за рыбу");
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10L));
		int num = 0;
		long num2 = 0L;
		while (true)
		{
			for (int num3 = 0; num3 < 100; num3++)
			{
				if (!AppSettings.Get("checkBoxAvatarKachPirashka", defaultValue: false))
				{
					UpdateCheckboxState(state: false);
					return;
				}
				string[] array3 = new string[5] { "power", "block", "dexterity", "endurance", "charisma" };
				long[] array4 = new long[5];
				_driver.WaitFind(By.XPath("//div[contains(@class,\"training_power_fish\")]//div[@data-fish][not(contains(@class,\"cmd_blocked\"))]"), TimeSpan.FromSeconds(10L));
				num2++;
				long num4 = _driver.ResyPiraShki();
				if (num4 < 10000 || num > 20)
				{
					UpdateCheckboxState(state: false);
					return;
				}
				for (int num5 = 0; num5 < 5; num5++)
				{
					if (array2[num5]())
					{
						string source = _driver.IsFindElement(By.XPath("//span[@id=\"price_" + array3[num5] + "_fish\"]")).isGetAttribute("outerText");
						long.TryParse(string.Join("", source.Where((char c) => char.IsDigit(c))), out array4[num5]);
					}
				}
				Array.Sort(array4, array3);
				string text = "";
				long num6 = 0L;
				for (int num7 = 0; num7 < 5; num7++)
				{
					if (array4[num7] != 0L)
					{
						num6 = array4[num7];
						text = array3[num7];
						break;
					}
				}
				string text2 = "//input[@id='" + text + "_fish']";
				if (num6 == 0L)
				{
					continue;
				}
				if (num4 / num6 < 99999)
				{
					if (_driver.IsFindElement(By.XPath("//a[contains(@onclick,\"getFishPriceMaxAvatar('" + text + "')\")]")).IsClick("качаю " + text) && _driver.IsFindElement(By.XPath("//div[contains(@class,\"training_" + text + "_fish\")]//div[@data-fish][not(contains(@class,\"cmd_blocked\"))]//input[@value=\"УЛУЧШИТЬ\"]")).IsClick("Тренирую < 99999 " + text))
					{
						continue;
					}
				}
				else
				{
					string xpathToFind = "//div[contains(@class,\"training_" + text + "_fish\")]//div[@data-fish][not(contains(@class,\"cmd_blocked\"))]//input[@value=\"УЛУЧШИТЬ\"]";
					_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(10L));
					_driver.IsFindElement(By.Id(text + "_fish")).IsClear();
					_driver.IsFindElement(By.Id(text + "_fish")).IsSendKeys("99999");
					if (_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Тренирую " + text + " " + num2))
					{
						_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(10L));
						continue;
					}
				}
				num++;
				LogService.LogConsole("Кач Рыба Ошибка " + num);
				if (num != 4)
				{
					continue;
				}
				_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
				_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and @onclick=\"avatar_training_tabs_handler.click(1002)\"]")).IsClick("Тренировка за рыбу");
				bool flag = true;
				for (int num8 = 0; num8 < 5; num8++)
				{
					if (array2[num8]() && array4[num8] == 0L)
					{
						flag = false;
					}
				}
				if (flag)
				{
					string xpathToFind2 = "//div[contains(@class,\"training_" + text + "_fish\")]//div[@data-fish][not(contains(@class,\"cmd_blocked\"))]//input[@value=\"УЛУЧШИТЬ\"]";
					if (_driver.IsFindElement(By.XPath(xpathToFind2)).IsDisplayed())
					{
						num = 0;
					}
				}
			}
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
			_driver.IsFindElement(By.XPath("//div[@class=\"btn\" and @onclick=\"avatar_training_tabs_handler.click(1002)\"]")).IsClick("Тренировка за рыбу");
		}
		static void UpdateCheckboxState(bool state)
		{
			if (Application.OpenForms[0] is Form1 form)
			{
				Checked((Control)(object)form.checkBoxAvatarKachPirashka, state);
				AppSettings.Set("checkBoxAvatarKachPirashka", state);
				Checked((Control)(object)form.checkBoxGo, !state);
				LabelStatus("Статус:");
			}
		}
	}

	private static void Checked(Control control, bool bo)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (control == null)
		{
			return;
		}
		if (control.InvokeRequired)
		{
			control.Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				((CheckBox)control).Checked = bo;
			});
		}
		else
		{
			((CheckBox)control).Checked = bo;
		}
	}

	public static DateTime DateTimeCountChat(this IWebDriver driver, string st)
	{
		DateTime now = DateTime.Now;
		IWebElement webElement = driver.IsFindElement(By.XPath(st));
		if (webElement == null)
		{
			return now;
		}
		string text = GetCleanedOuterText(webElement);
		int num = ParseDigit(webElement.IsFindElement(By.XPath(".//span[@class='countDays']")));
		now = now.AddDays(num);
		int num2 = ParseDigit(webElement.IsFindElement(By.XPath(".//span[@class='countHours']")));
		now = now.AddHours(num2);
		int num3 = ParseDigit(webElement.IsFindElement(By.XPath(".//span[@class='countMinutes']")));
		if (num3 > 60)
		{
			return DateTime.Now;
		}
		now = now.AddMinutes(num3);
		int num4 = ParseDigit(webElement.IsFindElement(By.XPath(".//span[@class='countSeconds']")));
		if (num4 > 60)
		{
			return DateTime.Now;
		}
		return now.AddSeconds(num4);
		static string GetCleanedOuterText(IWebElement element)
		{
			return element.isGetAttribute("outerText").Replace("\r\n", "").Replace(" ", "");
		}
		static int ParseDigit(IWebElement element)
		{
			if (element == null)
			{
				return 0;
			}
			string text2 = "";
			ReadOnlyCollection<IWebElement> readOnlyCollection = element.FindElements(By.XPath(".//span[@class=\"position\" and not(@style=\"display: none;\")]/span[contains(@class,\"digit\")]"));
			if (readOnlyCollection.Count >= 2)
			{
				IEnumerable<IWebElement> enumerable = readOnlyCollection.Take(2);
				foreach (IWebElement item in enumerable)
				{
					text2 += item.isGetAttribute("outerText");
				}
			}
			else
			{
				text2 = "0";
			}
			return int.Parse(string.Join("", (string)text2));
		}
	}

	public static DateTime DateTimeCount(this IWebDriver _driver, string _st)
	{
		return _driver.DateTimeCountChat(_st);
	}

	public static bool ResyPanda(this IWebDriver _driver, out int[] ari)
	{
		ari = new int[2];
		ari[0] = 0;
		ari[1] = 0;
		IWebElement webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i36\"]"));
		if (webElement == null)
		{
			return false;
		}
		string[] array = webElement.GetAttribute("outerText").Split('/');
		int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out ari[0]);
		int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out ari[1]);
		return true;
	}

	public static bool WaitFind(this IWebDriver _driver, By by, TimeSpan _interval)
	{
		DateTime utcNow = DateTime.UtcNow;
		do
		{
			IWebElement webElement = _driver.IsFindElement(by);
			if (webElement != null)
			{
				return true;
			}
			Sleep(300);
		}
		while (!(DateTime.UtcNow - utcNow >= _interval));
		return false;
	}

	public static async Task SleepTask(int msec)
	{
		await SleepAsync(msec);
	}

	public static void Sleep(int msec)
	{
		SleepTask(msec).GetAwaiter().GetResult();
	}

	public static async Task SleepAsync(int milliseconds)
	{
		if (milliseconds > 0)
		{
			await Task.Delay(milliseconds).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public static void BonusFermaDozor(this IWebDriver _driver)
	{
		List<(string[], string)> list = new List<(string[], string)>();
		list.Add((new string[1] { "item_1702" }, ""));
		list.Add((new string[1] { "item_1488" }, ""));
		list.Add((new string[1] { "ico_bday14_worker_bonus" }, ""));
		list.Add((new string[1] { "effect_97170" }, ""));
		list.Add((new string[1] { "icon_heart_earth" }, ""));
		list.Add((new string[1] { "item_2537" }, ""));
		list.Add((new string[1] { "ico_fresh_2330" }, ""));
		list.Add((new string[1] { "ico_fresh_2324" }, ""));
		list.Add((new string[1] { "ico_fresh_2325" }, ""));
		list.Add((new string[1] { "ico_fresh_2326" }, ""));
		list.Add((new string[1] { "ico_fresh_2328" }, ""));
		list.Add((new string[1] { "ico_2457" }, ""));
		list.Add((new string[1] { "ico_2458" }, ""));
		list.Add((new string[1] { "item_2676" }, ""));
		list.Add((new string[1] { "ico_2459" }, ""));
		List<(string[], string)> effects = list;
		string[] effectLiHtmls = ProcessEffects(_driver, effects);
		_driver.SozdatPanelJava("FermaDozor", effectLiHtmls);
	}

	public static void BonusZolotoKach(this IWebDriver _driver)
	{
		List<(string[], string)> list = new List<(string[], string)>();
		list.Add((new string[1] { "item_1854" }, ""));
		list.Add((new string[1] { "effect_97190" }, ""));
		list.Add((new string[1] { "icon_heart_ice" }, ""));
		list.Add((new string[1] { "ico_2457" }, ""));
		list.Add((new string[1] { "ico_2458" }, ""));
		list.Add((new string[1] { "ico_2459" }, ""));
		list.Add((new string[1] { "item_2537" }, ""));
		list.Add((new string[1] { "ico_fresh_2333" }, ""));
		list.Add((new string[1] { "ico_fresh_2326" }, ""));
		list.Add((new string[1] { "ico_fresh_2327" }, ""));
		list.Add((new string[1] { "ico_fresh_2328" }, ""));
		list.Add((new string[1] { "item_1490" }, ""));
		List<(string[], string)> effects = list;
		List<string> list2 = ProcessEffects(_driver, effects).ToList();
		List<(string, string)> list3 = new List<(string, string)>
		{
			("//div[contains(@class,\"item_box6\")][contains(@onmouseover,\"2593\")]", "2593"),
			("//div[contains(@class,\"item_box16\")]/img[contains(@src,\"Pet_55\")]", "Pet_55")
		};
		foreach (var item2 in list3)
		{
			string value = ((_driver.IsFindElement(By.XPath(item2.Item1)) != null) ? "Активно" : "Не активно");
			string item = $"<li class=\"small title_is_bind\" title=\"\">\r\n                    <b class=\"icon2 icon2 {item2.Item2} title_is_bind\" title=\"\"></b>\r\n                    <span title=\"Эффект {item2.Item2}\" class=\"title_is_bind\">\r\n                        <span id=\"counter_\" class=\"\">{value}</span>\r\n                    </span>\r\n                </li>";
			list2.Add(item);
		}
		_driver.SozdatPanelJava("ZolotoKach", list2.ToArray());
	}

	public static void BonusPirash(this IWebDriver _driver)
	{
		List<(string[], string)> list = new List<(string[], string)>();
		list.Add((new string[1] { "item_1841" }, ""));
		list.Add((new string[1] { "effect_97190" }, ""));
		list.Add((new string[1] { "item_2286" }, ""));
		list.Add((new string[1] { "ico_2457" }, ""));
		list.Add((new string[1] { "ico_2458" }, ""));
		list.Add((new string[1] { "ico_2459" }, ""));
		list.Add((new string[1] { "item_2495_3" }, ""));
		list.Add((new string[1] { "item_2537" }, ""));
		list.Add((new string[1] { "icon_2611_6" }, ""));
		list.Add((new string[1] { "item_2611" }, ""));
		list.Add((new string[1] { "lost_medallion_3" }, ""));
		list.Add((new string[2] { "item_2617", "в пирашках" }, ""));
		list.Add((new string[2] { "item_2648", "за золото и пирашки" }, ""));
		List<(string[], string)> effects = list;
		string[] effectLiHtmls = ProcessEffects(_driver, effects);
		_driver.SozdatPanelJava("Fish-Kach", effectLiHtmls);
	}

	private static string[] ProcessEffects(IWebDriver driver, List<(string[] classNames, string liHtml)> effects)
	{
		string pageSource = driver.PageSource;
		MatchCollection liMatches = Regex.Matches(pageSource, "<li[^>]*>.*?</li>", RegexOptions.Singleline);
		(string[] classNames, string liHtml)[] results = new(string[], string)[effects.Count];
		int maxDegreeOfParallelism = Math.Min(4, effects.Count);
		Parallel.For(0, effects.Count, new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		}, delegate(int i)
		{
			try
			{
				(string[] classNames, string liHtml) tuple = effects[i];
				string[] item = tuple.classNames;
				string item2 = tuple.liHtml;
				bool flag = false;
				string item3 = "";
				foreach (Match item6 in liMatches)
				{
					string value = item6.Value;
					bool flag2 = true;
					string[] array = item;
					foreach (string text in array)
					{
						if (text.Contains(" "))
						{
							if (!value.Contains(text))
							{
								flag2 = false;
								break;
							}
						}
						else
						{
							string pattern = "class\\s*=\\s*\"[^\"]*\\b" + Regex.Escape(text) + "\\b[^\"]*\"";
							if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
							{
								flag2 = false;
								break;
							}
						}
					}
					if (flag2)
					{
						flag = true;
						item3 = value;
						break;
					}
				}
				if (flag)
				{
					results[i] = (classNames: item, liHtml: item3);
				}
				else
				{
					string item4 = $"<li class=\"small title_is_bind\" title=\"\">\r\n                <b class=\"icon2 icon2 {item[0]} title_is_bind\" title=\"\"></b>\r\n                <span title=\"Эффект {item[0]}\" class=\"title_is_bind\">\r\n                    <span id=\"counter_{i}\" class=\"\">Не активен</span>\r\n                </span>\r\n            </li>";
					results[i] = (classNames: item, liHtml: item4);
				}
			}
			catch (Exception)
			{
				string item5 = $"<li class=\"small title_is_bind\" title=\"\">\r\n                <b class=\"icon2 icon2 {effects[i].classNames[0]} title_is_bind\" title=\"\"></b>\r\n                <span title=\"Эффект {effects[i].classNames[0]}\" class=\"title_is_bind\">\r\n                    <span id=\"counter_{i}\" class=\"\">Ошибка</span>\r\n                </span>\r\n            </li>";
				results[i] = (classNames: effects[i].classNames, liHtml: item5);
			}
		});
		return results.Select(((string[] classNames, string liHtml) e) => e.liHtml).ToArray();
	}

	public static void SozdatPanelJava(this IWebDriver _driver, string name, string[] effectLiHtmls)
	{
		string script = "\r\n      var name = arguments[0];\r\n      var effectLiHtmls = arguments[1];\r\n      var timerItems = '';\r\n    \r\n      // Создаем HTML для каждого эффекта\r\n      for (var i = 0; i < effectLiHtmls.length; i++) \r\n      {\r\n              timerItems += effectLiHtmls[i]; \r\n      }\r\n    \r\n      var tab = document.createElement('div');\r\n      tab.innerHTML = `\r\n          <div class=\"bonus-panel-${name}\">\r\n              <h3>${name}</h3>\r\n              <div class=\"scroll jspScrollable\">\r\n                  <div class=\"jspContainer\">\r\n                      <div class=\"timers\">\r\n                          <ul class=\"r clear_fix pb1 mr-3\">\r\n                              ${timerItems}\r\n                          </ul>\r\n                      </div>\r\n                  </div>\r\n              </div>\r\n          </div>\r\n      `;\r\n    \r\n      var target = document.querySelector('div.tab_right[name=\"100\"]');\r\n      if (target && target.parentNode) {\r\n          // Удаляем существующую панель если есть\r\n          var existingPanel = document.querySelector('.bonus-panel-' + name);\r\n          if (existingPanel) {\r\n              existingPanel.remove();\r\n              console.log('Старая панель удалена');\r\n          }\r\n          \r\n          target.parentNode.insertBefore(tab.firstElementChild, target);\r\n          console.log('Панель успешно создана/обновлена');\r\n          return true;\r\n      }\r\n    \r\n      console.log('Целевой элемент не найден');\r\n      return false;\r\n  ";
		try
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
			object obj = javaScriptExecutor.ExecuteScript(script, name, effectLiHtmls);
		}
		catch (Exception)
		{
		}
	}

	public static void BonusFerma(this IWebDriver _driver)
	{
	}

	public static void BonusZoloto(this IWebDriver _driver)
	{
	}

	public static void Podarki(this IWebDriver _driver)
	{
		LabelStatus("Статус:Открываем Подарки ");
		for (int i = 1; i < 7; i++)
		{
			int num = 0;
			int num2 = 0;
			int result = 0;
			string text = "(//form[@action='/event.php?a=maygifts'])[" + i + "]";
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath(text + "//b[@class='modern_amount']")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out result);
			if (result == 0)
			{
				continue;
			}
			while (AppSettings.Get("checkBoxPodarok", defaultValue: false))
			{
				int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath(text + "//b[@class='modern_amount']")).isGetAttribute("outerText")
					where char.IsDigit(c)
					select c), out result);
				if (num == 10)
				{
					break;
				}
				if (result == 0 || result == num2)
				{
					num++;
					Sleep(300);
					continue;
				}
				if (_driver.IsFindElement(By.XPath(text + "//span/input")).IsClick("Открыть", 300))
				{
					num = 0;
				}
				num2 = result;
			}
		}
		LabelStatus("Статус:");
	}

	public static void AvatarSyndykProdat(this IWebDriver _driver)
	{
		if (!AppSettings.Get("checkBoxProdatSundyk", defaultValue: false))
		{
			return;
		}
		LabelStatus("Статус: Продаем Сундуки ");
		if (!_driver.IsUrl().Contains("botva.ru/index.php"))
		{
			_driver.isExecuteScriptClick(By.Id("m1"), "Персонаж");
		}
		List<(bool, string)> list = new List<(bool, string)>
		{
			(AppSettings.Get("checkBoxProdatSundykDerevynyi", defaultValue: false), "1657"),
			(AppSettings.Get("checkBoxProdatSundykSerebrynyi", defaultValue: false), "1658"),
			(AppSettings.Get("checkBoxProdatSundykZolotoy", defaultValue: false), "1659"),
			(AppSettings.Get("checkBoxProdatSundykLekar", defaultValue: false), "1507"),
			(AppSettings.Get("checkBoxProdatSundykZvery", defaultValue: false), "1506"),
			(AppSettings.Get("checkBoxProdatSundykNinzy", defaultValue: false), "***"),
			(AppSettings.Get("checkBoxProdatSundykTank", defaultValue: false), "***")
		};
		bool flag = false;
		foreach (var item in list)
		{
			if (item.Item1 && _driver.IsFindElement(By.XPath("//div[contains(@onmouseover,\"doItem('" + item.Item2 + "\")]")) != null)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			LabelStatus("Статус:");
			return;
		}
		_driver.isExecuteScriptClick(By.Id("m3"), "Деревня");
		_driver.IsFindElement(By.XPath("//a[@href=\"shop.php\"]")).IsClick("Лавка");
		_driver.IsFindElement(By.XPath("//a[string(.)=\"Продать\"]")).IsClick("Продать");
		_driver.IsFindElement(By.XPath("//div[string(.)=\"ДРУГОЕ\"]")).IsClick("ДРУГОЕ");
		int num = 0;
		int num2 = 0;
		foreach (var item2 in list)
		{
			if (!item2.Item1)
			{
				continue;
			}
			string xpathToFind = "//span[@id=\"cell_cmd_" + item2.Item2 + "\"]/input[@value=\"ПРОДАТЬ\"]";
			if (_driver.IsFindElement(By.XPath(xpathToFind)) == null)
			{
				continue;
			}
			for (int i = 0; i < 50; i++)
			{
				if (!AppSettings.Get("checkBoxProdatSundyk", defaultValue: false))
				{
					break;
				}
				num2++;
				if (num > 5)
				{
					LabelStatus("Статус:");
					break;
				}
				_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(5L));
				num = ((!_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Продать " + num2, 1000)) ? (num + 1) : 0);
			}
		}
		LabelStatus("Статус:");
	}

	public static void Syndyk(this IWebDriver _driver)
	{
		LabelStatus("Статус:Открываем сундук ");
		int[] array = new int[2];
		int num = 0;
		int num2 = 0;
		_driver.IsFindElement(By.XPath("//span/img[contains(@src, 'drill_cont_1s.jpg')]")).IsClick("сундук ", 1000);
		while (AppSettings.Get("checkBoxAvatarDerevSyndyk", defaultValue: false))
		{
			num2++;
			if (num > 5)
			{
				break;
			}
			string xpathToFind = "//span[@id=\"button1_1\" and contains(string(.),\"ЕЩЁ ОДИН\")]  | //div[@class=\"button_new btn_start\"]/span";
			_driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(5L));
			if (!_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("ЕЩЕ Один " + num2, 1000))
			{
				num++;
				_driver.isExecuteScriptClick(By.XPath("//span/img[contains(@src, 'drill_cont_1s.jpg')]"), "drill_cont_1s.jpg");
			}
			else
			{
				num = 0;
			}
		}
		LabelStatus("Статус:");
	}

	public static void Taverna_Naperstok(this IWebDriver _driver)
	{
		if (!AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			return;
		}
		int num = 5000;
		int num2 = 500;
		string[] array = new string[3] { "Золото", "Кристалл", "Зелень" };
		int[] array2 = new int[3] { 1, 2, 3 };
		int num3 = 1;
		int num4 = 2;
		int num5 = 3;
		int num6 = 5;
		bool flag = true;
		int num7 = num4;
		int num8 = 500;
		string text = array[num7 - 1];
		_driver.isExecuteScriptClick(By.Id("m3"), "Клик Деревня");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Таверна", 1000);
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"?a=game&id=2\")]")).IsClick("Наперстки", 1000);
		_driver.IsFindElement(By.XPath("//input[@name='cup' and @value='2']//..")).IsClick("Cup 2");
		_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
		int num9 = 0;
		while (flag && AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			flag = false;
			_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value='1']")).IsClick("Выбираю золото");
			_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
			_driver.IsFindElement(By.XPath("//input[@name='cup' and @value='2']//..")).IsClick("Cup 2");
			if (CheckResult("проиграли"))
			{
				flag = true;
				num9++;
			}
			if (CheckResult("победили"))
			{
				flag = true;
				num9 = 0;
			}
			_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
			if (num9 < num6)
			{
				continue;
			}
			int num10 = num8;
			while (AppSettings.Get("checkBoxKriMax", defaultValue: false) && num10 <= num)
			{
				_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value=" + num7 + "]")).IsClick("Выбираю " + text);
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@id='amount'][@name='amount']"));
				elem.IsClear();
				elem.IsSendKeys(num10.ToString());
				_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
				_driver.IsFindElement(By.XPath("//input[@name='cup' and @value='" + num7 + "']//..")).IsClick("Cup 2");
				if (CheckResult("проиграли"))
				{
					num10 *= 2;
				}
				if (CheckResult("победили"))
				{
					num9 = 0;
					break;
				}
				_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
			}
		}
		bool CheckResult(string resultText)
		{
			return _driver.IsFindElement(By.XPath("//b[contains(text(),'" + resultText + "')]")) != null;
		}
	}

	public static void Taverna_NaperstokRandom(this IWebDriver _driver)
	{
		string text = "Кристалл";
		int num = 100;
		int num2 = 5;
		if (!AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			return;
		}
		Dictionary<string, (string, int)> dictionary = new Dictionary<string, (string, int)>
		{
			{
				"Золото",
				("1", 1000000)
			},
			{
				"Кристалл",
				("2", 5000)
			},
			{
				"Зелень",
				("3", 500)
			}
		};
		bool flag = true;
		Random random = new Random();
		_driver.isExecuteScriptClick(By.Id("m3"), "Клик Деревня");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Таверна", 1000);
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"?a=game&id=2\")]")).IsClick("Наперстки", 1000);
		int num3 = 0;
		int num4 = num;
		while (flag && AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			flag = false;
			if (random.Next(0, 2) == 0)
			{
				_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value='1']")).IsClick("Выбираю золото");
				_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
				_driver.IsFindElement(By.XPath("//input[@name='cup' and @value='2']//..")).IsClick("Cup 2");
				if (CheckResult("проиграли"))
				{
					flag = true;
					num3++;
				}
				if (CheckResult("победили"))
				{
					flag = true;
					num3 = 0;
				}
				_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
				continue;
			}
			if (num4 <= dictionary[text].Item2)
			{
				_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value=" + dictionary[text].Item1 + "]")).IsClick("Выбираю " + text);
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@id='amount'][@name='amount']"));
				elem.IsClear();
				elem.IsSendKeys(num4.ToString());
				_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
				_driver.IsFindElement(By.XPath("//input[@name='cup' and @value='2']//..")).IsClick("Cup 2");
				if (CheckResult("проиграли"))
				{
					num4 *= 2;
					flag = true;
				}
				if (CheckResult("победили"))
				{
					num3 = 0;
					num4 = num;
					flag = true;
				}
				_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
				continue;
			}
			break;
		}
		bool CheckResult(string resultText)
		{
			return _driver.IsFindElement(By.XPath("//b[contains(text(),'" + resultText + "')]")) != null;
		}
	}

	public static void Taverna_Tat_il_Tak(this IWebDriver _driver)
	{
		if (!AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			return;
		}
		int num = 5000;
		int num2 = 500;
		string[] array = new string[3] { "Золото", "Кристалл", "Зелень" };
		int[] array2 = new int[3] { 1, 2, 3 };
		int num3 = 1;
		int num4 = 2;
		int num5 = 3;
		int num6 = 5;
		bool flag = true;
		int num7 = num4;
		string text = array[num7 - 1];
		int num8 = 1000;
		_driver.isExecuteScriptClick(By.Id("m3"), "Клик Деревня");
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"tavern.php\")]")).IsClick("Таверна", 1000);
		_driver.IsFindElement(By.XPath("//a[contains(@href,\"?a=game&id=3\")]")).IsClick("Так иль так?", 1000);
		int num9 = 0;
		while (flag && AppSettings.Get("checkBoxKriMax", defaultValue: false))
		{
			flag = false;
			_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value='1']")).IsClick("Выбираю золото");
			_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
			if (CheckResult("проиграли"))
			{
				flag = true;
				num9++;
			}
			if (CheckResult("победили"))
			{
				flag = true;
				num9 = 0;
			}
			_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
			if (num9 < num6)
			{
				continue;
			}
			int num10 = num8;
			while (AppSettings.Get("checkBoxKriMax", defaultValue: false) && num10 <= num)
			{
				_driver.IsFindElement(By.XPath("//select[@id=\"money\"]/option[@value=" + num7 + "]")).IsClick("Выбираю " + text);
				IWebElement elem = _driver.IsFindElement(By.XPath("//input[@id='amount'][@name='amount']"));
				elem.IsClear();
				elem.IsSendKeys(num10.ToString());
				_driver.IsFindElement(By.XPath("//input[@value='ИГРАТЬ'][@type='submit']")).IsClick("Играть");
				if (CheckResult("проиграли"))
				{
					num10 *= 2;
				}
				if (CheckResult("победили"))
				{
					num9 = 0;
					break;
				}
				_driver.IsFindElement(By.XPath("//input[@value='ЕЩЁ РАЗ'][@type='submit']")).IsClick("ЕЩЁ РАЗ");
			}
		}
		bool CheckResult(string resultText)
		{
			return _driver.IsFindElement(By.XPath("//b[contains(text(),'" + resultText + "')]")) != null;
		}
	}

	public static void OtkrytZolotayPanda(this IWebDriver _driver)
	{
		LabelStatus("Статус:Открываем Золотые Панды ");
		int[] ari = new int[2];
		_driver.ResyZPanda(out ari);
		int num = 0;
		int result = 0;
		int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@id=\"pandora_left_count\"]")).isGetAttribute("outerText")
			where char.IsDigit(c)
			select c), out result);
		int num2 = 0;
		int result2 = 0;
		for (int num3 = 0; num3 < result; num3++)
		{
			if (!AppSettings.Get("checkBoxZolotayPanda", defaultValue: false))
			{
				break;
			}
			if (num > 3)
			{
				break;
			}
			string text = "";
			string text2 = _driver.IsFindElement(By.XPath("//img[@id=\"path_rotate_image\"]")).isGetAttribute("outerHTML");
			string xpathToFind = "//div[contains(@class,\"inlineb\") and not(contains(@style,\"none\")) ]//div[contains(@onclick,\"PANDORA_GOLD\")]//span";
			for (int num4 = 0; num4 < 10; num4++)
			{
				if (!AppSettings.Get("checkBoxZolotayPanda", defaultValue: false))
				{
					break;
				}
				text = _driver.IsFindElement(By.XPath("//img[@id=\"path_rotate_image\"]")).isGetAttribute("outerHTML");
				if (text2 != text)
				{
					text2 = text;
					Sleep(300);
				}
			}
			if (!_driver.IsFindElement(By.XPath(xpathToFind)).IsClick("ЕЩЕ ОДНУ " + num3, 2000))
			{
				break;
			}
			int.TryParse(string.Join("", from c in _driver.IsFindElement(By.XPath("//span[@id=\"pandora_left_count\"]")).isGetAttribute("outerText")
				where char.IsDigit(c)
				select c), out result2);
			num = ((num2 == result2) ? (num + 1) : 0);
			num2 = result2;
		}
		LabelStatus("Статус:");
	}

	public static bool ResyZPanda(this IWebDriver _driver, out int[] ari)
	{
		ari = new int[2];
		ari[0] = 0;
		ari[1] = 0;
		IWebElement webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i49\"]"));
		if (webElement == null)
		{
			return false;
		}
		string[] array = webElement.isGetAttribute("outerText").Split('/');
		int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out ari[0]);
		int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out ari[1]);
		return true;
	}

	public static bool ResyRaby(this IWebDriver _driver, out int[] ari)
	{
		ari = new int[2];
		IWebElement webElement = _driver.IsFindElement(By.XPath("//li[@id=\"i70\"]"));
		if (webElement == null)
		{
			return false;
		}
		string[] array = webElement.GetAttribute("outerText").Split('/');
		int.TryParse(string.Join("", array[0].Where((char c) => char.IsDigit(c))), out ari[0]);
		int.TryParse(string.Join("", array[1].Where((char c) => char.IsDigit(c))), out ari[1]);
		return true;
	}

	public static ulong ResyKri(this IWebDriver _driver)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		ulong.TryParse(_driver.IsFindElement(By.Id("crystal_upd_data")).isGetAttribute("outerText").Replace(".", "")
			.Replace("\r\n", ""), out var i);
		Form1 mainForm = ((IEnumerable)Application.OpenForms).OfType<Form1>().FirstOrDefault();
		if (mainForm == null)
		{
			return 0uL;
		}
		if (((Control)mainForm.labelKri).Text != i.ToString())
		{
			((Control)mainForm.labelKri).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)mainForm.labelKri).Text = i.ToString();
			});
		}
		return i;
	}

	public static string nikName(this IWebDriver _driver)
	{
		return _driver.IsFindElement(By.ClassName("name")).isGetAttribute("innerText");
	}

	public static BigInteger ResyZoloto(this IWebDriver _driver)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		string text = _driver.IsFindElement(By.XPath("//span[@id=\"gold_upd_data\"]//..")).isGetAttribute("outerText").Replace(".", "")
			.Replace("\r\n", "");
		if (text.IndexOf("слитки", 0) > -1)
		{
			text += "000000";
		}
		BigInteger.TryParse(string.Join("", text.Where((char c) => char.IsDigit(c))), out var i);
		Form1 mainForm = ((IEnumerable)Application.OpenForms).OfType<Form1>().FirstOrDefault();
		if (mainForm != null && ((Control)mainForm.labelZoloto).Text != i.ToString())
		{
			((Control)mainForm.labelZoloto).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)mainForm.labelZoloto).Text = i.ToString();
			});
		}
		return i;
	}

	public static long ResyPiraShki(this IWebDriver _driver)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		long i = -1L;
		long.TryParse(_driver.IsFindElement(By.Id("fish")).isGetAttribute("outerText").Replace(".", "")
			.Replace("\r\n", "")
			.Replace("пирашки:", ""), out i);
		Form1 mainForm = ((IEnumerable)Application.OpenForms).OfType<Form1>().FirstOrDefault();
		if (mainForm != null && ((Control)mainForm.labelPir).Text != i.ToString())
		{
			((Control)mainForm.labelPir).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)mainForm.labelPir).Text = i.ToString();
			});
		}
		return i;
	}

	public static int ResyZizny(this IWebDriver _driver)
	{
		int.TryParse(_driver.IsFindElement(By.XPath("//i[@class=\"life_perc\"]")).isGetAttribute("outerText").Replace("%", ""), out var result);
		return result;
	}

	public static void TextBoxConsole(string _st)
	{
		LogService.LogConsole(_st);
	}

	public static void WebBrowserLog(string _st)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		((Control)Form1._Form1.webBrowserLog).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
		{
			HtmlElement val = Form1._Form1.webBrowserLog.Document.CreateElement("div");
			if (Regex.Replace(_st, "(<.*?>)", "").Length > 40)
			{
				_st = "<div style=\"font-size:7px;line-height: 10px\">" + DateTime.Now.ToShortTimeString().ToString() + " " + _st + "</div>";
			}
			else
			{
				_st = "<div style=\"font-size:9px;line-height: 10px\">" + DateTime.Now.ToShortTimeString().ToString() + " " + _st + "</div>";
			}
			val.InnerHtml = _st;
			Form1._Form1.webBrowserLog.Document.Body.InsertAdjacentElement((HtmlElementInsertionOrientation)1, val);
		});
	}

	public static bool Fast(this IWebDriver _driver, string st, string st1)
	{
		if (_driver.IsFindElement(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\" " + st + " \")]/..")).IsClick(st1))
		{
			Thread.Sleep(500);
			return true;
		}
		if (_driver.isExecuteScriptClick(By.XPath("//div[@id=\"fast\"]//div[contains(@class,\" " + st + " \")]/.."), st1))
		{
			Thread.Sleep(500);
			return true;
		}
		WebBrowserLog("<FONT COLOR=red>НЕ вижу иконку " + st1 + "</FONT>");
		return false;
	}

	public static IWebElement IsFindElement1(this IWebDriver _driver, By by)
	{
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5L));
		webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
		try
		{
			return webDriverWait.Until(delegate
			{
				IWebElement webElement = _driver.FindElement(by);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			});
		}
		catch (WebDriverTimeoutException)
		{
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static IWebElement IsFindElement(this IWebDriver _driver, By by)
	{
		try
		{
			return _driver.FindElement(by);
		}
		catch (NoSuchElementException)
		{
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static IWebElement IsFindElement(this IWebElement _el, By by)
	{
		try
		{
			return _el.FindElement(by);
		}
		catch (NoSuchElementException)
		{
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static bool isExecuteScriptClick1(this IWebDriver _driver, By by, string _st)
	{
		IWebElement webElement = _driver.IsFindElement(by);
		if (webElement != null)
		{
			IJavaScriptExecutor javaScriptExecutor = _driver as IJavaScriptExecutor;
			javaScriptExecutor.ExecuteScript("arguments[0].click();", webElement);
			LogService.LogConsole(_st);
			return true;
		}
		return false;
	}

	public static bool isExecuteScriptClick(this IWebDriver driver, By by, string message, int sleep = 300)
	{
		IWebElement webElement = driver.IsFindElement(by);
		if (webElement != null)
		{
			try
			{
				WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2L));
				webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
			}
			catch (StaleElementReferenceException)
			{
			}
			catch (Exception)
			{
			}
			try
			{
				WebDriverWait webDriverWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5L));
				webDriverWait2.Until((IWebDriver webDriver) => driver.Manage().Cookies.AllCookies.Count > 0);
				ReadOnlyCollection<Cookie> allCookies = driver.Manage().Cookies.AllCookies;
				driver.ExecuteJavaScript("arguments[0].click();", webElement);
				LogService.LogConsole(message);
				Sleep(sleep);
				allCookies = driver.Manage().Cookies.AllCookies;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		return false;
	}

	public static string isGetAttribute(this IWebElement _elem, string _st)
	{
		if (_elem != null)
		{
			try
			{
				return _elem.GetAttribute(_st);
			}
			catch
			{
				return "";
			}
		}
		return "";
	}

	public static bool IsClear(this IWebElement _elem)
	{
		if (_elem != null)
		{
			try
			{
				_elem.Clear();
				Thread.Sleep(500);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public static bool IsSendKeys(this IWebElement _elem, string _st = "")
	{
		if (_elem != null)
		{
			try
			{
				_elem.SendKeys(_st);
				Thread.Sleep(500);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public static bool IsDisplayed(this IWebElement elem)
	{
		try
		{
			return elem?.Displayed ?? false;
		}
		catch (StaleElementReferenceException)
		{
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsClickGPT(this IWebElement element, string displayText = "", int sleep = 500)
	{
		if (element == null)
		{
			return false;
		}
		try
		{
			string attribute = element.GetAttribute("outerText");
			string attribute2 = element.GetAttribute("outerHTML");
			string text = (string.IsNullOrEmpty(displayText) ? attribute : displayText);
			LogService.LogConsole(text);
			element.Click();
			if (sleep > 0)
			{
				Thread.Sleep(sleep);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsClick(this IWebElement _elem, string _st = "", int sleep = 500, string _st1 = "")
	{
		if (_elem != null)
		{
			try
			{
				string attribute = _elem.GetAttribute("outerText");
				string attribute2 = _elem.GetAttribute("outerHTML");
				_elem.Click();
				if (_st == "")
				{
					LogService.LogConsole(attribute);
				}
				else
				{
					LogService.LogConsole(_st);
					_ = _st1 != "";
				}
				Thread.Sleep(sleep);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}
}
