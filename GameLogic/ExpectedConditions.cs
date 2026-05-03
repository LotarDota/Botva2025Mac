using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace SeleniumExtras.WaitHelpers;

public sealed class ExpectedConditions
{
	private ExpectedConditions()
	{
	}

	public static Func<IWebDriver, bool> TitleIs(string title)
	{
		return (IWebDriver driver) => title == driver.Title;
	}

	public static Func<IWebDriver, bool> TitleContains(string title)
	{
		return (IWebDriver driver) => driver.Title.Contains(title);
	}

	public static Func<IWebDriver, bool> UrlToBe(string url)
	{
		return (IWebDriver driver) => driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant());
	}

	public static Func<IWebDriver, bool> UrlContains(string fraction)
	{
		return (IWebDriver driver) => driver.Url.ToLowerInvariant().Contains(fraction.ToLowerInvariant());
	}

	public static Func<IWebDriver, bool> UrlMatches(string regex)
	{
		return delegate(IWebDriver driver)
		{
			string url = driver.Url;
			Regex regex2 = new Regex(regex, RegexOptions.IgnoreCase);
			Match match = regex2.Match(url);
			return match.Success;
		};
	}

	public static Func<IWebDriver, IWebElement> ElementExists(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				return driver.FindElement(locator);
			}
			catch
			{
				return (IWebElement)null;
			}
		};
	}

	public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				return ElementIfVisible(driver.FindElement(locator));
			}
			catch (StaleElementReferenceException)
			{
				return (IWebElement)null;
			}
		};
	}

	public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
				if (readOnlyCollection.Any((IWebElement element) => !element.Displayed))
				{
					return (ReadOnlyCollection<IWebElement>)null;
				}
				return readOnlyCollection.Any() ? readOnlyCollection : null;
			}
			catch (StaleElementReferenceException)
			{
				return (ReadOnlyCollection<IWebElement>)null;
			}
		};
	}

	public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
	{
		return delegate
		{
			try
			{
				if (elements.Any((IWebElement element) => !element.Displayed))
				{
					return (ReadOnlyCollection<IWebElement>)null;
				}
				return elements.Any() ? elements : null;
			}
			catch (StaleElementReferenceException)
			{
				return (ReadOnlyCollection<IWebElement>)null;
			}
		};
	}

	public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				ReadOnlyCollection<IWebElement> readOnlyCollection = driver.FindElements(locator);
				return readOnlyCollection.Any() ? readOnlyCollection : null;
			}
			catch (StaleElementReferenceException)
			{
				return (ReadOnlyCollection<IWebElement>)null;
			}
		};
	}

	public static Func<IWebDriver, bool> TextToBePresentInElement(IWebElement element, string text)
	{
		return delegate
		{
			try
			{
				string text2 = element.Text;
				return text2.Contains(text);
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		};
	}

	public static Func<IWebDriver, bool> TextToBePresentInElementLocated(By locator, string text)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(locator);
				string text2 = webElement.Text;
				return text2.Contains(text);
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		};
	}

	public static Func<IWebDriver, bool> TextToBePresentInElementValue(IWebElement element, string text)
	{
		return delegate
		{
			try
			{
				return element.GetAttribute("value")?.Contains(text) ?? false;
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		};
	}

	public static Func<IWebDriver, bool> TextToBePresentInElementValue(By locator, string text)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(locator);
				return webElement.GetAttribute("value")?.Contains(text) ?? false;
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		};
	}

	public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(string frameLocator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				return driver.SwitchTo().Frame(frameLocator);
			}
			catch (NoSuchFrameException)
			{
				return (IWebDriver)null;
			}
		};
	}

	public static Func<IWebDriver, IWebDriver> FrameToBeAvailableAndSwitchToIt(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement frameElement = driver.FindElement(locator);
				return driver.SwitchTo().Frame(frameElement);
			}
			catch (NoSuchFrameException)
			{
				return (IWebDriver)null;
			}
		};
	}

	public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(locator);
				return !webElement.Displayed;
			}
			catch (NoSuchElementException)
			{
				return true;
			}
			catch (StaleElementReferenceException)
			{
				return true;
			}
		};
	}

	public static Func<IWebDriver, bool> InvisibilityOfElementWithText(By locator, string text)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(locator);
				string text2 = webElement.Text;
				if (string.IsNullOrEmpty(text2))
				{
					return true;
				}
				return !text2.Equals(text);
			}
			catch (NoSuchElementException)
			{
				return true;
			}
			catch (StaleElementReferenceException)
			{
				return true;
			}
		};
	}

	public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
	{
		return delegate(IWebDriver driver)
		{
			IWebElement webElement = ElementIfVisible(driver.FindElement(locator));
			try
			{
				if (webElement != null && webElement.Enabled)
				{
					return webElement;
				}
				return (IWebElement)null;
			}
			catch (StaleElementReferenceException)
			{
				return (IWebElement)null;
			}
		};
	}

	public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
	{
		return delegate
		{
			try
			{
				if (element != null && element.Displayed && element.Enabled)
				{
					return element;
				}
				return (IWebElement)null;
			}
			catch (StaleElementReferenceException)
			{
				return (IWebElement)null;
			}
		};
	}

	public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
	{
		return delegate
		{
			try
			{
				return element == null || !element.Enabled;
			}
			catch (StaleElementReferenceException)
			{
				return true;
			}
		};
	}

	public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element)
	{
		return ElementSelectionStateToBe(element, selected: true);
	}

	public static Func<IWebDriver, bool> ElementToBeSelected(IWebElement element, bool selected)
	{
		return (IWebDriver driver) => element.Selected == selected;
	}

	public static Func<IWebDriver, bool> ElementSelectionStateToBe(IWebElement element, bool selected)
	{
		return (IWebDriver driver) => element.Selected == selected;
	}

	public static Func<IWebDriver, bool> ElementToBeSelected(By locator)
	{
		return ElementSelectionStateToBe(locator, selected: true);
	}

	public static Func<IWebDriver, bool> ElementSelectionStateToBe(By locator, bool selected)
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				IWebElement webElement = driver.FindElement(locator);
				return webElement.Selected == selected;
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		};
	}

	public static Func<IWebDriver, IAlert> AlertIsPresent()
	{
		return delegate(IWebDriver driver)
		{
			try
			{
				return driver.SwitchTo().Alert();
			}
			catch (NoAlertPresentException)
			{
				return (IAlert)null;
			}
		};
	}

	public static Func<IWebDriver, bool> AlertState(bool state)
	{
		return delegate(IWebDriver driver)
		{
			bool flag = false;
			try
			{
				driver.SwitchTo().Alert();
				flag = true;
				return flag == state;
			}
			catch (NoAlertPresentException)
			{
				flag = false;
				return flag == state;
			}
		};
	}

	private static IWebElement ElementIfVisible(IWebElement element)
	{
		if (element == null)
		{
			return null;
		}
		if (!element.Displayed)
		{
			return null;
		}
		return element;
	}
}
