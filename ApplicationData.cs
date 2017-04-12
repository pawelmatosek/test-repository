namespace FifthHomeWork
{
    public static class ApplicationData
    {
        public static string username = "admin";
        public static string password = "admin";
        public static string applicationAddress = "http://localhost/litecart/en/";
        public static string administatorPanelAddress = "http://localhost/litecart/admin";
        public static string leftBoxLocation = "div#box-apps-menu-wrapper li";

        public static string imagesOnLeftPanel = "td[id=sidebar] i";
        public static string imagesOnRightPanel = "td[id=content] i";
        public static string imagesOnLowerRightPanel = "td[id=content] form i";

        public static string getListedCountires = "form[name='countries_form'] tr[class=row] td:nth-of-type(5)";
        public static string getListedZones = "form[name='geo_zones_form'] tr[class=row] td:nth-of-type(3) a";
        public static string getCountyGeoZones = "tr select:not([class=select2-hidden-accessible]) [selected=selected]";

        public static string getCaptchaChangeElement = "table[class='dataTable'] tbody tr:nth-of-type(7) i[class='fa fa-pencil']";
        public static string getFalseCaptchaRadioButton = "table[class='dataTable'] tbody label input[value='0']";
        public static string submitRadioButtonChanges = "table[class='dataTable'] tbody button[type='submit']";

        public static string goToStandardApplication = "div[class='header'] i[class='fa fa-chevron-circle-left']";
        public static string goToNewUserRegistration = "td[class='account'] a[href='http://localhost/litecart/en/create_account']";
        public static string goToFirstName = "tbody input[name='firstname']";
        public static string collectRequiredElements = "tbody input[required='required']";
        public static string goToCityInputData = "tbody input[name='city']";
        public static string getUserLoginConfirmationButton = "table button[type='submit']";
        public static string logOutFromApplication = "div[class=content] a[href='http://localhost/litecart/en/logout'";
        public static string getLoginHandle = "tbody input[type='text']";

        //General Product Information Locators
        public static string addProductButton = "td[id='content'] a[class='button']:nth-of-type(2)";
        public static string enableProductButton = "table tbody label:nth-of-type(1) input";
        public static string buttonToSaveProductLocator = "span[class='button-set'] button[value='Save']";

        public static string productName = "span[class='input-wrapper'] input[name='name[en]']";
        public static string productCode = "input[name='code']"; 
        public static string defaultCategoryOptions = ".//*[tbody]//td[@id='content']//div[@class='tabs']//table//select[@name='default_category_id']//option";
        public static string addProductSubcategory = "tbody input[data-priority='2']"; 
        public static string productCategoryLocator = "div[class='input-wrapper'] input[value='1-1']";

        public static string quantityProductLocator = "div[id='tab-general'] tr input[name='quantity']"; //ToDo Rewrite using Builder Pattern to generate locators      
        public static string quantityUnitLocator = ".//*[tbody]//div[@id='tab-general']//select[@name='quantity_unit_id']//option";
        public static string deliveryStatusIdLocator = ".//*[tbody]//div[@id='tab-general']//select[@name='delivery_status_id']//option"; 
        public static string deliverySoldOutStatusIdLocator = ".//*[tbody]//div[@id='tab-general']//select[@name='sold_out_status_id']//option";

        //Dates Validation
        public static string productDatesFromValidationLocator = ".//*[tbody]//div[@id='tab-general']//input[@name='date_valid_from']"; 
        public static string productDatesToValidationLocator = ".//*[tbody]//div[@id='tab-general']//input[@name='date_valid_to']"; 

        //Move to other Tabs
        public static string moveToInformationTab = "div[class='tabs'] a[href='#tab-information']";
        public static string moveToDataTab = "div[class='tabs'] a[href='#tab-data']";

        //Information Tab Locators
        public static string manufacturerInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//select[@name='manufacturer_id']//option";
        public static string supplierInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//select[@name='supplier_id']//option";

        public static string keywordInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//input[@name='keywords']";
        public static string shortDescriptionInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//input[@name='short_description[en]']";

        public static string descriptionInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//div[@class='trumbowyg-editor']";
        public static string headTitleInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//input[@name='head_title[en]']";
        public static string metaDescriptionInformationLocator = ".//*[tbody]//div[@id='tab-general']//..//input[@name='meta_description[en]']";

        //Data Locators
        public static string skuDataLocator = ".//*[tbody]//div[@id='tab-data']//..//input[@name='sku']";
        public static string gtinDataLocator = ".//*[tbody]//div[@id='tab-data']//..//input[@name='gtin']";
        public static string taricDataLocator = ".//*[tbody]//div[@id='tab-data']//..//input[@name='taric']";
        public static string weightDataLocator = ".//*[tbody]//div[@id='tab-data']//..//input[@name='weight']";

        //Dimension Data locators
        public static string firstDimensionDataLocator = ".//*[tbody]//div[@id='tab-data']//..//span[@class='input-wrapper']//input[@name='dim_x']";
        public static string secoundDimensionDataLocator = ".//*[tbody]//div[@id='tab-data']//..//span[@class='input-wrapper']//input[@name='dim_y']";
        public static string thirdDimensionDataLocator = ".//*[tbody]//div[@id='tab-data']//..//span[@class='input-wrapper']//input[@name='dim_z']";

        public static string attributesDataLocator = "div[id='tab-data'] textarea[name='attributes[en]']";
        
        //Zadanie 13
        public static string standardApplicationLocator = "div[class='header'] i[class='fa fa-chevron-circle-left']";
        public static string ducksProductLocator = "div[id='box-most-popular'] ul[class='listing-wrapper products'] li[class='product column shadow hover-light']";
        public static string homeImageLocator = "li[class='general-0'] i[class='fa fa-home']";
        public static string buttonToAddNewProductLocator = "td[class='quantity'] button[name='add_cart_product']";
        public static string itemCartLocator = "div[id='cart'] a[class='content']";
        public static string removeItemFromCartLocator = "form[enctype='application/x-www-form-urlencoded'] button[value='Remove']";

        public static string waitingTest = "div[class='content'] img[title='ACME Corp.']";
        public static string checkLocator = "td[class='options'] select[name='options[Size]']";

        public static string productSizeSelectorLocator = ".//*[body]//div[@id='main']//..//select[@name='options[Size]']//option";

        //Zad14
        public static string addNewCategoryLocator = "tbody div[style='float: right;'] a[href='http://localhost/litecart/admin/?app=catalog&doc=edit_category&parent_id=0']";
        public static string linkToExternalSite = "div[id='tab-general'] i[class='fa fa-external-link']";
    }
}
