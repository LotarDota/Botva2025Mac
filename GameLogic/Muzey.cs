using Botva2025.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Botva2025;

public class Muzey
{
	private readonly IWebDriver driver;

	private DateTime muzeyDatetime;

	private List<(string Name, string EventId, string HrefId, By Action, string Close)> muzeyItems = GetMuzeyItems();

	public Muzey(IWebDriver _driver)
	{
		driver = _driver;
		muzeyDatetime = DateTime.Now;
	}

	private static List<(string Name, string EventId, string HrefId, By Action, string Close)> GetMuzeyItems()
	{
		return new List<(string, string, string, By, string)>
		{
			("Повозка Торговца", "event_98", "'1086", null, ""),
			("Реликтовый защитник", "*****", "'1719", null, "ЗАКРЫТЬ"),
			("Балалайка", "event_90", "'1025", By.XPath("//div[contains(@class,'button')]//span[contains(text(),'Потрындеть')]"), "ЗАКРЫТЬ"),
			("Бойкий фермер", "event_9", "'695", null, ""),
			("Скатерть Самобранка", "event_89", "'1024", By.XPath("//span[contains(text(), 'НАКРЫТЬ')]"), "ЗАКРЫТЬ"),
			("Книга знаний", "event_8", "'688", null, ""),
			("Молотилка", "event_160", "'2286", By.XPath("//span[contains(text(), 'Перемолоть')][not(contains(string(.),'7'))]"), "ЗАКРЫТЬ"),
			("Обледеневший ларец Хрякуса", "event_153", "'2226", By.XPath("//div[contains(@class,'button')]//span[contains(text(), 'Открыть!')][not(contains(string(.),'10'))]"), "ЗАКРЫТЬ"),
			("Подзорная труба", "event_149", "'1911", By.XPath("//span[contains(text(), 'АКТИВИРОВАТЬ')]"), "ЗАКРЫТЬ"),
			("Гадальные кубики", "event_146", "'1889", By.XPath("//span[contains(text(), 'БРОСИТЬ КУБИКИ')]"), "ЗАКРЫТЬ"),
			("Тарабанище", "event_136", "'1738", By.XPath("//span[contains(text(), 'Тарабанить')][not(contains(string(.),'5'))]"), "ЗАКРЫТЬ"),
			("Ботвинский Сухпаек", "event_131", "'1781", By.XPath("//span[contains(text(), 'ИСПОЛЬЗОВАТЬ')]"), "ЗАКРЫТЬ"),
			("Кристальный дракон", "event_135", "'1652", By.XPath("//span[contains(string(.), 'ПОКОРМИТЬ')]/input"), ""),
			("Рождественский раздаватель призов", "event_134", "'1579", By.XPath("//div[contains(@class,'button')]//span[contains(text(), 'ОТКРЫТЬ')]"), "ЗАКРЫТЬ"),
			("Карты предсказаний прошлого", "event_130", "'1633", By.XPath("//div[@class='knowledgecard not_active']/div[@class='wrapper']/div"), ""),
			("Яйцо Леприкона", "event_132", "'1628", null, ""),
			("Золотой кубок", "event_129", "'1666", null, "НАЗАД"),
			("Горн похвалы", "event_11", "'819", null, ""),
			("Шкатулка разрушителя", "event_10", "'835", null, ""),
			("Лампа знаний", "", "'1142", null, ""),
			("Печать", "", "'1224", null, ""),
			("Походный Котелок", "", "'1975", null, ""),
			("Шкатулка илюзиониста", "", "'2071", By.XPath("//span[contains(text(), 'Получить бонус!')]"), ""),
			("Вечный двигатель", "", "'1242", null, "УРА!"),
			("Деревенский Баян", "", "'1929", null, ""),
			("Включи пятак", "event_169", "'2600", null, ""),
			("Исполнятор желаний", "", "'1364", By.XPath("//div[@class='ball']"), ""),
			("Пирашковый котелок", "", "'2043", By.XPath("//span[contains(text(), 'Наварить!')]"), ""),
			("Гипно-Свин", "event_182", "'2658", null, ""),
			("Галстук", "event_178", "'2614", null, ""),
			("Солдатский ремень", "", "'2648", By.XPath("//span[contains(string(.), 'Активировать эффект бойца')]"), ""),
			("Используйте катушку!", "event_176", "'2615", null, ""),
			("Шарик часовщика", "", "'2617", By.XPath("//button[contains(text(), 'Завести Шарик')]"), ""),
			("Запесочиться", "", "'2675", null, ""),
			("Накопытники для лепки снежков", "", "'2463", null, ""),
			("Леденящие очки", "", "'2460", By.XPath("//div[contains(@class,'button')]//span[contains(text(), 'Активировать')]"), ""),
			("Золотая Рыбка", "", "'2729", null, ""),
			("Чертовы Рожки", "", "'2723", null, ""),
			("Флейта Морозуса", "", "'2619", null, ""),
			("Ледяной Трон", "", "'2263", By.XPath("//span[contains(text(), 'Воссесть')]"), "ЗАКРЫТЬ")
		};
	}

	public List<(string displayName, List<(string settingName, string tooltip)>)> MuzeyNastroyki(string server)
	{
		List<(string, List<(string, string)>)> list = new List<(string, List<(string, string)>)>();
		if (server != "Avatar")
		{
			list.Add(("Вороний оберег", new List<(string, string)>
			{
				("checkBoxVoronObereg_1", "Мощный взмах(увеличить характеристики в Бодалке 30%)"),
				("checkBoxVoronObereg_2", "Воронья хитрость (Скидка прокачки за пирашки и мандаринки)"),
				("checkBoxVoronObereg_3", "По зернышку(доход на ферме и дозоре 30%)"),
				("checkBoxVoronObereg_4", "ВоЗоркий глаз(доход в Храме 30%)")
			}));
			list.Add(("Обменять мелочь", new List<(string, string)>
			{
				("checkBox_Meloch_1", "Суп Силы (Увеличение показатели Арены)"),
				("checkBox_Meloch_2", "Салат Выгоды(Скидка на прокачку в Сражалке)"),
				("checkBox_Meloch_3", "Шашлык превосходства(уменишить показатели противника на Арене)")
			}));
			list.Add(("Солдатский ремень", new List<(string, string)>
			{
				("checkBox_Remeny_1", "Золотая лихорадка(Скидка за золото)"),
				("checkBox_Remeny_2", "Доза подкача(Увеличение Силы)"),
				("checkBox_Remeny_3", "Глаз-алмаз(Доход в Хижене Туриста)"),
				("checkBox_Remeny_4", "Ценный цитрус(Скидка за Очищеные Мандарины)")
			}));
			list.Add(("Флейта Морозуса", new List<(string, string)>
			{
				("checkBox_Fleyta_1", "Снежинка (Доход золота в Дозоре 30%)"),
				("checkBox_Fleyta_2", "Хлопушка (Доход при поиску Клада 30%)"),
				("checkBox_Fleyta_3", "Игрушка (Доход золота Храм Истин 30%)"),
				("checkBox_Fleyta_4", "Леденец (Характеристики в Бодалке 30%)"),
				("checkBox_Fleyta_5", "Гирлянда (Характеристики в Сражалке 30%)"),
				("checkBox_Fleyta_6", "Салат (Характеристики на Арене 30%)")
			}));
			list.Add(("Золотая Рыбка", new List<(string, string)>
			{
				("checkBox_Fish_1", "Характеристики в Бодалке %"),
				("checkBox_Fish_2", "Характеристики в Сражалке %"),
				("checkBox_Fish_3", "Характеристики в Арене %"),
				("checkBox_Fish_4", "Скидка за Золото"),
				("checkBox_Fish_5", "Скидка за Пирашки")
			}));
			list.Add(("Ларец желаний", new List<(string, string)>
			{
				("checkBox_Larec_Open", "Открывать Ларец"),
				("checkBox_Larec_Wyjimalka", "Использовать удачю , соковыжималка"),
				("checkBox_Larec_Bye", "Освобождать место , продавать вещи")
			}));
		}
		else
		{
			list.Add(("Солдатский ремень", new List<(string, string)>
			{
				("checkBoxAvatar_Remeny_1", "Вот это авторитет (увеличить влияние 10%)"),
				("checkBoxAvatar_Remeny_2", "Драки-драки у собаки (характеристики в Бодалке 40%)"),
				("checkBoxAvatar_Remeny_3", "Друг Ушканчика(Увеличение доход на Ферме 50%)"),
				("checkBoxAvatar_Remeny_4", "Ощутимая выгода(Скидка на прокачку за Золото и Пирашки 25%)")
			}));
			list.Add(("Зубастый сударь", new List<(string, string)>
			{
				("checkBoxAvatar_Sydary_1", "Кариес силы (ХАРАКТЕРИСТИКИ в Бодалке)"),
				("checkBoxAvatar_Sydary_2", "Щетка доблести(Увеличение очков в битвах за земли)"),
				("checkBoxAvatar_Sydary_3", "Деморализующий язык(Уменьшение характеристик противника в Бодалке)")
			}));
			list.Add(("Флейта Морозуса", new List<(string, string)>
			{
				("checkBoxAvatar_Fleyta_1", "Снежинка (Доход золота в Дозоре 30%)"),
				("checkBoxAvatar_Fleyta_2", "Хлопушка (Уменьшает характеристики противника в бодалке 30%)"),
				("checkBoxAvatar_Fleyta_3", "Игрушка (Доход золота на Ферме 30%)"),
				("checkBoxAvatar_Fleyta_4", "Леденец (Характеристики в Бодалке 30%)"),
				("checkBoxAvatar_Fleyta_5", "Гирлянда (Доход золота в подземе 30%)"),
				("checkBoxAvatar_Fleyta_6", "Салат (Скидка на прокачку за Пирашки 30%)")
			}));
			list.Add(("Деревенский Баян", new List<(string, string)>
			{
				("checkBoxAvatar_Bayn_1", "Доски (Повысить характеристики в защите на 15%)"),
				("checkBoxAvatar_Bayn_2", "Глина (Повысить характеристики в нападении на 15%)"),
				("checkBoxAvatar_Bayn_3", "Бочка (Забрать все золото)"),
				("checkBoxAvatar_Bayn_4", "Бананы (Доход золота Дозор и Ферма 30%)"),
				("checkBoxAvatar_Bayn_5", "Ткань (Повышает заточку на 10%)"),
				("checkBoxAvatar_Bayn_6", "Инструменты (Скидка кач Золота 15%)")
			}));
			list.Add(("Золотая Рыбка", new List<(string, string)>
			{
				("checkBox_Avatar_Fish_1", "Увеличивает Характеристики в Бодалке %"),
				("checkBox_Avatar_Fish_2", "Характеристики в Подземелье %"),
				("checkBox_Avatar_Fish_3", "Уменьшает Характеристики в Бодалке %"),
				("checkBox_Avatar_Fish_4", "Скидка за Золото"),
				("checkBox_Avatar_Fish_5", "Скидка за Пирашки")
			}));
		}
		return list;
	}

	public void MuzeyWithNastroyki()
	{
		Find.LabelStatus("Статус: Музей c настройками");
		Find.LabelStatus("Статус:");
	}

	private void MuzeyRaznoe()
	{
		Find.LabelStatus("Статус: Музей Разное");
		try
		{
			HandlePopandopulus();
			HandleMyBank();
			HandleActivate10();
			HandleUseKholodets();
			HandleBroomStrike();
			HandleTossCoin();
			HandleExperiment();
			HandleSmallChangeExchange();
			MuzeyProgorlivyLarchik();
			HandleFishka();
			HandleKlasterDryjby();
			HandleMemuary();
			HandleKolodaTyrTaro();
		}
		catch (Exception ex)
		{
			Find.WebBrowserLog("Ошибка в MuzeyRaznoe: " + ex.Message);
		}
		finally
		{
			Find.LabelStatus("Статус:");
		}
	}

	private void HandleKolodaTyrTaro()
	{
		if (!driver.isExecuteScriptClick(By.XPath("//div[@id='event_163']/a"), "Колода Тыр-Таро", 1000))
		{
			return;
		}
		string[] array = new string[7] { "taro/fortunewheel.png", "taro/jester.png", "taro/power.png", "taro/wizard.png", "taro/sun.png", "taro/star.png", "taro/lovers.png" };
		string xpathToFind = "//div[@id='start-give-button']/span";
		driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(5L));
		if (driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Начать Расклад", 1000))
		{
			for (int i = 0; i < 5; i++)
			{
				driver.IsFindElement(By.XPath("//div[@id='take-card-button']/span")).IsClick("Взять Карту", 1000);
				driver.WaitFind(By.XPath("//div[@id='content-block']"), TimeSpan.FromSeconds(2L));
				if (driver.IsFindElement(By.XPath("//div[@id='content-block']")) == null)
				{
					break;
				}
				string[] array2 = array;
				foreach (string text in array2)
				{
					driver.isExecuteScriptClick(By.XPath("//div[contains(@style,'" + text + "')]"), "Выбрать карту", 1000);
				}
			}
		}
		driver.IsFindElement(By.XPath("//div[@id='activate-button']/span")).IsClick("Активировать карты", 1000);
	}

	private void HandleMemuary()
	{
		if (driver.isExecuteScriptClick(By.XPath("//div[@id='event_172']/a"), "Мемуары", 1000) && driver.IsFindElement(By.XPath("//div[@id='choose-buttons']/span[@data-list='claners']")).IsClick("Мемуары Соклану", 1000))
		{
			driver.IsFindElement(By.XPath("//input[@value='Отправить']")).IsClick("Отправить мемуары", 1000);
		}
	}

	private void HandleKlasterDryjby()
	{
		if (!driver.isExecuteScriptClick(By.XPath("//div[@id='event_168']/a"), "Кластер Дружбы", 1000))
		{
			return;
		}
		string xpathToFind = "//div[@id='choose-buttons']/span[@data-list='claners']";
		for (int i = 0; i < 5; i++)
		{
			if (!driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Кластер СОклану", 1000))
			{
				break;
			}
			driver.IsFindElement(By.XPath("//input[@value='ПОДАРИТЬ']")).IsClick("Кластер Подарить", 1000);
		}
	}

	private void HandleFishka()
	{
		if (driver.isExecuteScriptClick(By.XPath("//div[@id='event_164']/a"), "Фишка Котануса", 1000))
		{
			string xpathToFind = "//span[@data-value='monsters']/div[contains(string(.),'100/100')]//..";
			driver.WaitFind(By.XPath(xpathToFind), TimeSpan.FromSeconds(2L));
			driver.IsFindElement(By.XPath(xpathToFind)).IsClick("Усилить Фишку Котануса", 1000);
			CloseNewButton("Фишка Котануса");
		}
	}

	private void HandlePopandopulus()
	{
		if (driver.IsFindElement(By.XPath("//div[@id='annoying_npc']//img[contains(@src,'popandopulus.png')]")).IsClick("popandopulus.png", 1000))
		{
			driver.IsFindElement(By.XPath("//span[contains(string(.),'Угоститься')]//input[@type='submit']")).IsClick("Угоститься", 1000);
		}
	}

	private void HandleMyBank()
	{
		driver.isExecuteScriptClick(By.XPath("//img[contains(@src,\"/buildings/man/sloth_man.png\")]//.."), "Мой банк");
	}

	private void HandleActivate10()
	{
		if (driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Пора активировать (10)')]"), "Пора активировать (10)", 1000))
		{
			driver.isExecuteScriptClick(By.XPath("//b[string(.)='Активировать']//..//../input"), "Активировать");
		}
	}

	private void HandleUseKholodets()
	{
		if (driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Используйте холодец!')]"), "Используйте холодец!", 1000))
		{
			By obj = By.XPath("//button[contains(string(.),'Активировать')][not(contains(string(.),'25'))]");
			if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)))
			{
				driver.isExecuteScriptClick(obj, "Активировать", 1000);
			}
			ClosePopup();
		}
	}

	private void HandleBroomStrike()
	{
		if (driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Хлестни веником!')]"), "Хлестни веником!", 1000))
		{
			By obj = By.XPath("//span[contains(string(.),'Ударить себя')]");
			if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)) && driver.isExecuteScriptClick(obj, "Ударить себя", 1000))
			{
				driver.IsFindElement(By.XPath("//span[contains(string(.),'Подарить')]//input[@type='submit']")).IsClick("Подарить", 1000);
			}
			ClosePopup();
		}
	}

	private void HandleTossCoin()
	{
		if (driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Подкинуть')]"), "Подкинуть", 1000))
		{
			By obj = By.XPath("//button[@id='roll' and string(.)='Подкинуть']");
			if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)))
			{
				driver.isExecuteScriptClick(obj, "Подкинуть", 1000);
			}
			CloseNewButton("Подкинуть");
		}
	}

	private void HandleExperiment()
	{
		if (driver.ResyKri() >= 30000 && driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Экспериментировать')]"), "Экспериментировать", 1000))
		{
			By obj = By.XPath("(//div[contains(string(.),'Начать эксперимент!')]/input)[3]");
			if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)))
			{
				driver.isExecuteScriptClick(obj, "Начать эксперимент", 1000);
			}
			ClosePopup();
		}
	}

	private void HandleSmallChangeExchange()
	{
		if (!driver.isExecuteScriptClick(By.XPath("//span[contains(string(.),'Обменять мелочь')]"), "Обменять мелочь", 1000) || !driver.isExecuteScriptClick(By.XPath("//div[contains(@onmouseover,\"doItem('2673'\")]//a"), "Обменять мелочь внутрь"))
		{
			return;
		}
		By obj = By.XPath("//b[contains(string(.),'Мелочи у вас')]");
		if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)))
		{
			string source = driver.IsFindElement(obj).isGetAttribute("outerText");
			ulong num = ulong.Parse(string.Join("", source.Where(char.IsDigit)));
			if (num > 10000)
			{
				ProcessSmallChangePurchase();
			}
			CloseNewButton("Мелочь");
		}
	}

	private void ProcessSmallChangePurchase()
	{
		driver.IsFindElement(By.XPath("//div[@data-section='2' and contains(string(.),'приобретение бонусов') and not(contains(@class,'selected'))]")).IsClick("приобретение бонусов", 1000);
		for (int i = 1; i < 4; i++)
		{
			if (AppSettings.Get($"checkBox_Meloch_{i}", defaultValue: false))
			{
				driver.IsFindElement(By.XPath($"(//div[contains(@class,'tick-select selectable2')])[{i}]")).IsClick($"выбрать {i}", 1000);
			}
		}
		driver.IsFindElement(By.XPath("//div[not(contains(@class,'disabled'))]/span[contains(string(.),'приобрести')]/input")).IsClick("приобрести", 1000);
	}

	private void ClosePopup()
	{
		driver.isExecuteScriptClick(By.XPath("//div[@id='l_popup_close']"), "l_popup_close", 1000);
	}

	private bool MuzeyProgorlivyLarchik()
	{
		if (driver.isExecuteScriptClick(By.XPath("//div[@id='event_166']//span"), "Прожорливый ларчик", 1000))
		{
			driver.WaitFind(By.XPath("//div[contains(@class,\"slot\")]"), TimeSpan.FromSeconds(5L));
			for (int i = 0; i < 10; i++)
			{
				if (!driver.IsFindElement(By.XPath("//div[contains(@class,\"slot \")  and not (contains(@class,\"locked\"))]")).IsClick("slot " + i, 1000))
				{
					break;
				}
				driver.WaitFind(By.XPath("//div[contains(@class,\"fruit_item item_box\")]"), TimeSpan.FromSeconds(5L));
				if (driver.IsFindElement(By.XPath("//div[@data-fruit=\"2\"]")).isGetAttribute("outerHTML").Contains("на арене"))
				{
					driver.IsFindElement(By.XPath("//div[@data-fruit=\"2\"]")).IsClick("@data-fruit=2", 1000);
					continue;
				}
				if (driver.IsFindElement(By.XPath("//div[@data-fruit=\"0\"]")).isGetAttribute("outerHTML").Contains("за золото"))
				{
					driver.IsFindElement(By.XPath("//div[@data-fruit=\"0\"]")).IsClick("@data-fruit=0", 1000);
					continue;
				}
				ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(By.XPath("//div[@data-fruit]"));
				if (readOnlyCollection.Count > 0)
				{
					Random random = new Random();
					readOnlyCollection[random.Next(0, readOnlyCollection.Count)].IsClick("@data-fruit Random", 1000);
				}
			}
			driver.IsFindElement(By.XPath("//div[contains(@class,\"button-unite\") and not(contains(@class,\"disabled\"))]//b[contains(string(.),\"Объединить\")]//..//../span")).IsClick("Объединить", 1000);
			driver.IsFindElement(By.XPath("//div[contains(@class,\"box_x_button hidden button_new\")]")).IsClick("Выход Ларчик");
			return true;
		}
		return false;
	}

	private bool TryEnterMuseum()
	{
		string xpathToFind = BuildMuseumEntryXPath();
		IWebElement webElement = driver.IsFindElement(By.XPath(xpathToFind));
		if (webElement != null)
		{
			return driver.isExecuteScriptClick(By.XPath(xpathToFind), "Вход музей");
		}
		Find.LabelStatus("Статус:");
		return false;
	}

	private string BuildMuseumEntryXPath()
	{
		string text = "//div[@id=\"events_scroll\"]//div[@id=\"" + muzeyItems[0].EventId + "\"";
		for (int i = 1; i < muzeyItems.Count; i++)
		{
			if (!(muzeyItems[i].EventId == ""))
			{
				text = text + " or @id=\"" + muzeyItems[i].EventId + "\"";
			}
		}
		return text + "]/a";
	}

	private void MuzeyLarecJelaniy()
	{
		if (!AppSettings.Get("checkBox_Larec_Open", defaultValue: false))
		{
			return;
		}
		Find.LabelStatus("Статус: Ларец Желаний");
		if (!driver.isExecuteScriptClick(By.XPath("//div[@id=\"events_scroll\"]//div[@id=\"event_7\"]/a"), "Ларец желаний в музей"))
		{
			Find.LabelStatus("Статус:");
			return;
		}
		if (AppSettings.Get("checkBox_Larec_Wyjimalka", defaultValue: false) && driver.isExecuteScriptClick(By.XPath("//div[contains(@onmouseover,\"1897\")]/span[contains(string(.),\"100\")]//../a"), "Соковыжималка"))
		{
			driver.WaitFind(By.XPath("//div[contains(@class,\"pt5 pb5 pl5 lbordertc\")][contains(string(.),\"Удача при открытии Ларца Желаний\")]//input"), TimeSpan.FromSeconds(2L));
			driver.IsFindElement(By.XPath("//div[contains(@class,\"pt5 pb5 pl5 lbordertc\")][contains(string(.),\"Удача при открытии Ларца Желаний\")]//input")).IsClick("Выжать 10");
			driver.IsFindElement(By.XPath(" //div[contains(@onclick,\"doReload\")]/span[contains(string(.),\"ЗАКРЫТЬ\")]")).IsClick("Закрыть");
		}
		driver.isExecuteScriptClick(By.XPath("//div[contains(string(.),\"Используемые\")]//a[@href=\"/index.php?casket=792\"]"), "Ларец желаний");
		if (new DateTime?(driver.DateTimeCount("//div[@id=\"casket_energy_count\"]")).HasValue)
		{
			driver.IsFindElement(By.XPath("//div[@id=\"play_btn\"]/a[string(.)=\"ИГРАТЬ\"]")).IsClick("ИГРАТЬ");
			if (driver.IsFindElement(By.XPath("//div[contains(@class,\"balert\")][contains(string(.),\"места для даров не хватит\")]")) != null && driver.ByePredmet())
			{
				driver.isExecuteScriptClick(By.XPath("//div[@id=\"events_scroll\"]//div[@id=\"event_7\"]/a"), "Ларец желаний в музей");
				driver.isExecuteScriptClick(By.XPath("//div[contains(string(.),\"Используемые\")]//a[@href=\"/index.php?casket=792\"]"), "Ларец желаний");
				driver.IsFindElement(By.XPath("//div[@id=\"play_btn\"]/a[string(.)=\"ИГРАТЬ\"]")).IsClick("ИГРАТЬ");
			}
			Find.LabelStatus("Статус:");
		}
	}

	public void MuzeyGo()
	{
		try
		{
			MuzeyLarecJelaniy();
			MuzeyRaznoe();
			if (TryEnterMuseum())
			{
				Find.LabelStatus("Статус: Музей");
				ProcessMuseumItems();
			}
		}
		catch (Exception ex)
		{
			Find.WebBrowserLog("Ошибка в MuzeyGo: " + ex.Message);
		}
		finally
		{
			Find.LabelStatus("Статус:");
		}
	}

	private void ProcessMuseumItems()
	{
		foreach (var muzeyItem in muzeyItems)
		{
			try
			{
				if (CanProcessItem(muzeyItem) && OpenItemPopup(muzeyItem))
				{
					ProcessSpecificItem(muzeyItem);
					LogItemProcessed(muzeyItem);
				}
			}
			catch (Exception ex)
			{
				Find.WebBrowserLog("Ошибка при обработке " + muzeyItem.Name + ": " + ex.Message);
			}
		}
	}

	private bool CanProcessItem((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		if (item.EventId.Contains("event_") && driver.IsFindElement(By.XPath("//div[@id=\"events_scroll\"]//div[@id=\"" + item.EventId + "\"]")) == null)
		{
			return false;
		}
		return true;
	}

	private bool OpenItemPopup((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		return driver.isExecuteScriptClick(By.XPath("//div[contains(@onmouseover,\"" + item.HrefId + "\")]//a"), item.Name + " OpenItemPopup");
	}

	private void LogItemProcessed((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		LogService.LogHtml("Музей " + item.Name);
		Thread.Sleep(500);
	}

	private void ProcessSpecificItem((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		Find.Sleep(1000);
		switch (item.Name)
		{
		case "Кристальный дракон":
			ProcessCrystalDragon(item);
			break;
		case "Походный Котелок":
			ProcessCampingPot(item);
			break;
		case "Пирашковый котелок":
			ProcessPirozhkiPot(item);
			break;
		case "Солдатский ремень":
			ProcessSoldierBelt(item);
			break;
		case "Деревенский Баян":
			ProcessVillageAccordion(item);
			break;
		case "Накопытники для лепки снежков":
			ProcessSnowHooves(item);
			break;
		case "Ледяной Трон":
			ProcessIceThrone(item);
			break;
		case "Золотая Рыбка":
			ProcessZolotayFish(item);
			break;
		case "Флейта Морозуса":
			ProcessFleyta(item);
			break;
		default:
			ProcessDefaultItem(item);
			break;
		}
	}

	private void ProcessFleyta((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		string text = (driver.Url.Contains("avatar") ? "checkBox_Avatar_Fleyta_" : "checkBox_Fleyta_");
		for (int i = 1; i < 7; i++)
		{
			if (AppSettings.Get(text + i, defaultValue: false))
			{
				driver.IsFindElement(By.XPath("(//div[contains(@class,'bgr_3')])[" + i + "]//span[contains(string(.),'Делать') and not(contains(string(.),'15'))]")).IsClick("Делать флейта " + i, 1000);
			}
		}
		ClosePopup(item.Name);
		CloseBoxButton(item.Name);
	}

	private void ProcessZolotayFish((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		string text = (driver.Url.Contains("avatar") ? "checkBox_Avatar_Fish_" : "checkBox_Fish_");
		for (int i = 1; i < 5; i++)
		{
			if (AppSettings.Get(text + i, defaultValue: false))
			{
				driver.IsFindElement(By.XPath("(//div[contains(@class,'bgr_2')])[" + i + "]//form//span[contains(string(.),'Получить бонус') and not(contains(string(.),'15'))]//input")).IsClick("Взять рыбку " + i, 1000);
			}
		}
		ClosePopup(item.Name);
		CloseBoxButton(item.Name);
	}

	private void ProcessSoldierBelt((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		By obj = By.XPath("//div[contains(string(.),\"Всего у вас:\")]/b[not(@class)]");
		if (driver.WaitFind(obj, TimeSpan.FromSeconds(2L)))
		{
			string source = driver.IsFindElement(obj).isGetAttribute("outerText");
			ulong num = ulong.Parse(string.Join("", source.Where(char.IsDigit)));
			if (num > 1000)
			{
				PurchaseBelts();
			}
			driver.IsFindElement(By.XPath("//span[contains(string(.), 'Активировать эффект бойца')]")).IsClick(item.Name + " внутри");
			CloseNewButton(item.Name);
		}
	}

	private void PurchaseBelts()
	{
		string text = (driver.Url.Contains("avatar") ? "checkBoxAvatar_Remeny_" : "checkBox_Remeny_");
		for (int i = 1; i < 5; i++)
		{
			if (AppSettings.Get(text + i, defaultValue: false))
			{
				driver.IsFindElement(By.XPath($"//form[contains(@class,\"submit_by_ajax_popup_completed\")]/input[@value=\"{i}\"]//..//span[contains(string(.),\"КУПИТЬ\")]/input")).IsClick("Купить ремень " + i, 1000);
			}
		}
	}

	private void ProcessPirozhkiPot((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		if (driver.ResyPiraShki() > 50000000)
		{
			driver.IsFindElement(By.XPath("//div[@id=\"l_popup\"]//div[contains(string(.),\"Наварить\")]/input")).IsClick(item.Name + " внутри");
		}
		CloseNewButton(item.Name);
	}

	private void ProcessSnowHooves((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		for (int i = 0; i < 10; i++)
		{
			if (driver.IsFindElement(By.XPath("//div[string(.)=\"До бесплатной игры:\"]")) != null)
			{
				break;
			}
			driver.IsFindElement(By.XPath("//table[contains(@class,\"game_field\")]//td[@class=\"slot slot0\"]")).IsClick(item.Name + " внутри");
		}
		CloseBoxButton(item.Name);
	}

	private void ProcessVillageAccordion((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		int[] array = new int[6] { 6, 4, 3, 5, 1, 2 };
		bool flag = driver.Url.Contains("avatar");
		int[] array2 = array;
		foreach (int value in array2)
		{
			string key = $"checkBox{(flag ? "Avatar_" : "_")}Bayn_{value}";
			if (AppSettings.Get(key, defaultValue: false))
			{
				driver.IsFindElement(By.XPath($"//div[@class='ml70' and not(.//b[@title=\"Зелень\"])]/div[@data-bonus=\"{value}\"]/span")).IsClick(item.Name + " внутри");
			}
		}
		driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"popup_my_container\")]//div[@id=\"l_popup_close\"]"), item.Name + " закрыть");
	}

	private void ProcessIceThrone((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		By obj = By.XPath("//div[@class=\"modern_price\"]/span[@timer]");
		if (!driver.IsFindElement(obj).IsDisplayed() && driver.IsFindElement(item.Action).IsClick(item.Name + " Action"))
		{
			Thread.Sleep(1000);
		}
		if (!string.IsNullOrEmpty(item.Close))
		{
			driver.isExecuteScriptClick(By.XPath("//div[@id=\"l_popup\"]//span[string(.)=\"" + item.Close + "\"]"), item.Name + " close", 1000);
		}
		ClosePopup(item.Name);
		CloseBoxButton(item.Name);
	}

	private void ProcessCrystalDragon((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		for (int i = 0; i < 3; i++)
		{
			driver.IsFindElement(item.Action).IsClick(item.Name + " внутри", 1000);
		}
		driver.isExecuteScriptClick(By.XPath("//div[@id=\"l_popup\"]//div[contains(@class,\"box_x_button\")]"), item.Name + " close", 1000);
	}

	private void ProcessCampingPot((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(By.XPath("//div[contains(@class, 'green')]/span[contains(text(), 'Варить зелье')]"));
		if (readOnlyCollection.Count > 0)
		{
			Random random = new Random();
			int index = random.Next(0, readOnlyCollection.Count - 1);
			readOnlyCollection[index].IsClick("Варить Зелье " + index);
		}
		ClosePopup(item.Name);
		CloseBoxButton(item.Name);
	}

	private void ProcessDefaultItem((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		if (!(item.Action == null) && !TryClickAction(item))
		{
			TryClickAlternativeAction(item);
		}
		CloseItemPopup(item);
	}

	private bool TryClickAction((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		return driver.IsFindElement(item.Action).IsClick(item.Name + " внутри");
	}

	private bool TryClickAlternativeAction((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		driver.WaitFind(item.Action, TimeSpan.FromSeconds(2L));
		return driver.IsFindElement(item.Action).IsClick(item.Name + " внутри");
	}

	private void CloseItemPopup((string Name, string EventId, string HrefId, By Action, string Close) item)
	{
		if (!string.IsNullOrEmpty(item.Close) && (driver.IsFindElement(By.XPath("//div[@id=\"l_popup\"]//span[string(.)=\"" + item.Close + "\"]")).IsClick(item.Name + " close") || driver.IsFindElement(By.XPath("//div[contains(@onclick,\"lPopupRemove\")]/span[string(.)=\"" + item.Close + "\"]")).IsClick(item.Name + " close")))
		{
			Thread.Sleep(1000);
		}
		ClosePopup(item.Name);
		CloseBoxButton(item.Name);
	}

	private void ClosePopup(string itemName)
	{
		driver.isExecuteScriptClick(By.XPath("//div[@id=\"l_popup_close\"]"), itemName + " close l_popup_close", 1000);
	}

	private void CloseNewButton(string itemName)
	{
		driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"box_x_button hidden button_new\")]"), itemName + " выход", 1000);
	}

	private void CloseBoxButton(string itemName)
	{
		driver.isExecuteScriptClick(By.XPath("//div[contains(@class,\"box_x_button\") and contains(@class,\"hidden\")]"), itemName + " close box_x_button ", 1000);
	}
}
