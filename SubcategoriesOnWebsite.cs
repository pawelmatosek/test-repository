using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthHomeWork
{
    public class SubcategoriesOnWebsite 
    {
        List<List<string>> combinedSubcategoriesList = new List<List<string>>();
        private static int numberOfSubcategories = 11;
        private Dictionary<int, List<string>> subcategoriesOnWebsite = new Dictionary<int, List<string>>();

        private void collectLists()
        {
            combinedSubcategoriesList.Add(ApperanceLinksText);
            combinedSubcategoriesList.Add(CatalogLinksText);
            combinedSubcategoriesList.Add(CustomersLinksText);
            combinedSubcategoriesList.Add(LanguagesLinksText);
            combinedSubcategoriesList.Add(ModulesLinksText);
            combinedSubcategoriesList.Add(OrderLinksText);
            combinedSubcategoriesList.Add(ReportsLinksText);
            combinedSubcategoriesList.Add(SettingsLinksText);
            combinedSubcategoriesList.Add(TaxLinksText);
            combinedSubcategoriesList.Add(TranslationLinksText);
            combinedSubcategoriesList.Add(VQModsLinksText);
        }

        public Dictionary<int, List<string>> CollectSubcategoriesOnWebsite()
        {
            collectLists();
            for (int i = 0; i < numberOfSubcategories; i++)
            {
                subcategoriesOnWebsite[i] = combinedSubcategoriesList.ElementAt(i);
            }
            return subcategoriesOnWebsite;
        }


        public static List<string> ApperanceLinksText = new List<string>{ 
                                                    "template", 
                                                    "logotype" 
                                                };

        public static List<string> CatalogLinksText = new List<string>{ 
                                                "catalog", 
                                                "product_groups", 
                                                "option_groups",
                                                "manufacturers",
                                                "suppliers",
                                                "delivery_statuses",
                                                "sold_out_statuses",
                                                "quantity_units",
                                                "csv"
                                              };


        public static List<string> CustomersLinksText = new List<string>{ 
                                                    "customers",
                                                    "csv",
                                                    "newsletter"
                                                };

        public static List<string> LanguagesLinksText = new List<string>{ 
                                                    "languages",
                                                    "storage_encoding"
                                                };


        public static List<string> ModulesLinksText = new List<string>{ 
                                                      "jobs",
                                                      "customer",
                                                      "shipping",
                                                      "payment",
                                                      "order_total",
                                                      "order_success",
                                                      "order_action"
                                                  };

        public static List<string> OrderLinksText = new List<string>{
                                                      "orders",
                                                      "order_statuses"
                                                };

        public static List<string> ReportsLinksText = new List<string>{
                                                      "monthly_sales",
                                                      "most_sold_products",
                                                      "most_shopping_customers"
                                                };

        public static List<string> SettingsLinksText = new List<string>{
                                                      "store_info",
                                                      "defaults",
                                                      "general",
                                                      "listings",
                                                      "images",
                                                      "checkout",
                                                      "advanced",
                                                      "security"
                                                };

        public static List<string> TaxLinksText = new List<string> {
                                                      "tax_classes",
                                                      "tax_rates"
        };

        public static List<string> TranslationLinksText = new List<string> {
                                                      "search",
                                                      "scan",
                                                      "csv"
        };

        public static List<string> VQModsLinksText = new List<string> {
                                                      "vqmods"
        };
    }
}
