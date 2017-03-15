namespace FourthHomeWork
{
    public static class ApplicationData
    {
        public static string username = "admin";
        public static string password = "admin";
        public static string applicationAddress = "http://localhost/litecart/en/";
        public static string administatorPanelAddress = "http://localhost/litecart/admin";
        public static string leftBoxLocation = "div#box-apps-menu-wrapper li";

        //Locator Factory! //Builder 
        public static string imagesOnLeftPanel = "td[id=sidebar] i";
        public static string imagesOnRightPanel = "td[id=content] i";
        public static string imagesOnLowerRightPanel = "td[id=content] form i";
        //change names
        public static string getListedCountires = "form[name='countries_form'] tr[class=row] td:nth-of-type(5)";
        public static string getListedZones = "form[name='geo_zones_form'] tr[class=row] td:nth-of-type(3) a";
        public static string getCountyGeoZones = "tr select:not([class=select2-hidden-accessible]) [selected=selected]";
    }
}
