using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FifthHomeWork
{
    class CheckCountrysOrder
    {
        List<string> countryNames = new List<string>();
        bool isAlphabeticalOrder = true;

        public CheckCountrysOrder(ReadOnlyCollection<IWebElement> countrysToCheck)
        {
            foreach (var element in countrysToCheck)
                countryNames.Add(element.Text);
        }

        public bool Check()
        {
            for (int i = 0; i < countryNames.Count - 1; i++)
            {
                if (StringComparer.Ordinal.Compare(countryNames[i], countryNames[i + 1]) > 0)
                {
                    isAlphabeticalOrder = false;
                    break;
                }
            }
            return isAlphabeticalOrder;
        }
    }
}
