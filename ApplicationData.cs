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
    }
}
