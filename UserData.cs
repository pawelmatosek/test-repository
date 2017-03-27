using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject3
{
    ///<summary>
    /// Abstract data about user to register
    ///</summary>
    abstract class UserParameter
    {
        public virtual string GetValue() { return ""; }
    }


    class TaxId : UserParameter
    {
        string _taxId;

        public override string GetValue() { return _taxId; }
        public TaxId() {}
        TaxId(string taxId) { _taxId = taxId; }     
    }

    class Company : UserParameter
    {
        string _company;

        public override string GetValue() { return _company; }
        public Company() {}
        public Company(string company) { _company = company; }
    }

    class FirstName : UserParameter
    {
        string _firstName { get; set; }

        public override string GetValue() { return _firstName; }
        public FirstName() {}
        public FirstName(string firstName) { _firstName = firstName; }    
    }

    class LastName : UserParameter
    {
        string _lastName { get; set; }

        public override string GetValue() { return _lastName; }
        public LastName() {}
        public LastName(string lastName) { _lastName = lastName; }     
    }


    class AddressPart1 : UserParameter
    {
        string _addressPart1 { get; set; }

        public override string GetValue() { return _addressPart1; }
        public AddressPart1() {}
        public AddressPart1(string addressPart1) { _addressPart1 = addressPart1; }  
    }

    class AddressPart2 : UserParameter
    {
        string _addressPart2 { get; set; }

        public override string GetValue() { return _addressPart2; }
        public AddressPart2() {}
        public AddressPart2(string addressPart2) { _addressPart2 = addressPart2; }  
    }

    class PostalCode : UserParameter
    {
        string _postalCode;

        public override string GetValue() { return _postalCode; }
        public PostalCode() {}
        public PostalCode(string postalCode) { _postalCode = postalCode; }       
    }

    class City : UserParameter
    {
        public string _city { get; set; }

        public override string GetValue() { return _city; }
        public City() {}
        public City(string city) { _city = city; }   
    }

    class Country : UserParameter
    {
        public string _country { get; set; }

        public override string GetValue() { return _country; }
        public Country() {}
        public Country(string country) { _country = country; }
    }

    class Email : UserParameter
    {
        public string _email { get; private set; }

        public override string GetValue() { return _email; }
        public Email() {}
        public Email(string email) { _email = email; }
    }

    class PhoneNumber : UserParameter
    {
        string _phoneNumber { get; set; }

        public override string GetValue() { return _phoneNumber; }
        public PhoneNumber() {}
        public PhoneNumber(string phoneNumber) { _phoneNumber = phoneNumber; }
    }

    class Password : UserParameter
    {
        string _password { get; set; }

        public override string GetValue() { return _password; }
        public Password() {}
        public Password(string password) { _password = password; }
    }

    class ConfirmPassword : UserParameter
    {
        string _confirmPassword { get;  set; }

        public override string GetValue() { return _confirmPassword; }
        public ConfirmPassword() {}
        public ConfirmPassword(string confirmPassword) { _confirmPassword = confirmPassword; }
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Registration
    {
        List<UserParameter> _userData = new List<UserParameter>();

        // Constructor calls abstract Factory method
        public Registration()
        {
            this.CreateUser("Pawel", "Matosek", "Makowiecka", "80-336", "@gmail.com", "777111999", "123", "123");
        }

        public List<UserParameter> Data
        {
            get { return _userData; }
        }

        public UserParameter GetObject(string objectToFind)
        {
            foreach(var data in _userData)
            {
                if(data.GetType().Name == objectToFind)
                    return data;
            }
            return null;
        }

        // Factory Method
        public abstract void CreateUser(string firstName, string lastName, string address, string postalCode, 
             string email, string phoneNumber, string password, string confirmPassword);
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class BasicUser : Registration
    {
        string uniqueEmail;
        
        // Factory Method implementation
        public override void CreateUser(string firstName = "Pawel", string lastName = "Matosek", string address = "Makowiecka", string postalCode = "80-336", 
             string email = "@gmail.com", string phoneNumber = "777111999", string password = "123", string confirmPassword = "123")
        {
            uniqueEmail = Guid.NewGuid().ToString() + email;
            Data.Add(new FirstName(firstName));
            Data.Add(new LastName(lastName));
            Data.Add(new AddressPart1(address));
            Data.Add(new PostalCode(postalCode));
            Data.Add(new Email(uniqueEmail));
            Data.Add(new PhoneNumber(phoneNumber));
            Data.Add(new Password(password));
            Data.Add(new ConfirmPassword(confirmPassword));
        }
    }
}
