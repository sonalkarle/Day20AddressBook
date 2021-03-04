﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddressBookDay13
{
    public class Program
    {
        Validation validation = new Validation();
        List<ContactDetails> contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        private Dictionary<string, Dictionary<string, ContactDetails>> multipleAddressBookMap;
        private List<ContactDetails> sortedBookList;


        public Program()
        {
            contactDetailsList = new List<ContactDetails>();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
            multipleAddressBookMap = new Dictionary<string, Dictionary<string, ContactDetails>>();
            sortedBookList = new List<ContactDetails>();

        }
        public void ContactlistEntry()
        {
            ContactDetails personEntered = new ContactDetails();
            Console.WriteLine("Enter First name");
            string firstName = Console.ReadLine();
            validation.FirstName(firstName);
            personEntered.firstName = firstName;

            Console.WriteLine("Enter Last name");
            string lastName = Console.ReadLine();
            validation.LastName(lastName);
            personEntered.lastName = lastName;

            if (contactDetailsList.Find(i => personEntered.Equals(i)) != null)
            {
                Console.WriteLine("Person already Exists, enter new person!");
                return;
            }
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            validation.Address(address);
            personEntered.address = address;
            Console.WriteLine("Enter City");
            personEntered.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            personEntered.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            int zip = Convert.ToInt32(Console.ReadLine());
            string zipString = zip.ToString();
            validation.Zip(zipString);
            personEntered.zip = zip;
            Console.WriteLine("Enter phoneNumber");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            string phoneNumberString = phoneNumber.ToString();
            validation.MobileNumber(phoneNumberString);
            personEntered.phoneNumber = phoneNumber;
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            validation.EmailAddress(email);
            personEntered.email = email;
            contactDetailsList.Add(personEntered);

        }
        /// <summary>
        /// UC12: Sorted person in alphabatical order as per the city or zip or state
        /// </summary>
        public void SortByCityOrStateOrZip()
        {
            List<ContactDetails> sortedList;
            Console.WriteLine(" Sort the contacts by City or State or Zip ");
            Console.WriteLine("1: Entered for sorting list by City ");
            Console.WriteLine("2: Entered for sorting list by State");
            Console.WriteLine("3: Entered for sorting list by zip");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    sortedList = contactDetailsList.OrderBy(x => x.city).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
                case 2:
                    sortedList = contactDetailsList.OrderBy(x => x.state).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
                case 3:
                    sortedList = contactDetailsList.OrderBy(x => x.zip).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
            }

        }
        public List<ContactDetails> AddDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber, email);
            contactDetailsList.Add(contactDetails);

            return contactDetailsList;

        }
        /// <summary>
        /// UC11: Sort the contactlist in alphabetical order of first name
        /// </summary>
        public void SortByFirstName()
        {
            Console.WriteLine(" Sort the contacts alphabetically ");
            sortedBookList = contactDetailsList.OrderBy(x => x.firstName).ToList();
            foreach (ContactDetails book in sortedBookList)
            {
                Console.WriteLine(book.toString());
            }

        }


        public void AddressBook(string addressBook)
        {
            multipleAddressBookMap.Add(addressBook, contactDetailsMap);
        }



        /// <summary>
        /// UC8: Ability to search person from the contactlist
        /// UC9: Ability to view person from the contactlist
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ContactDetails> Search()
        {
            Console.WriteLine(" Enter state ");
            string state = Console.ReadLine();
            var stateCheck = contactDetailsList.FindAll(x => x.state == state);
            Console.WriteLine(" Enter city ");
            string city = Console.ReadLine();
            var cityCheck = stateCheck.FindAll(x => x.city == city);
            Console.WriteLine(" Find Person ");
            string firstName = Console.ReadLine();
            var person = cityCheck.Where(x => x.firstName == firstName).FirstOrDefault();
            if (person != null)
            {
                Console.WriteLine(firstName + " is  in " + city);
            }
            else
            {
                Console.WriteLine(firstName + " is not  in " + city);
            }
            Dictionary<string, ContactDetails> detailCity = new Dictionary<string, ContactDetails>();
            Dictionary<string, ContactDetails> detailState = new Dictionary<string, ContactDetails>();
            detailCity.Add(city, person);
            detailState.Add(state, person);
            foreach (KeyValuePair<string, ContactDetails> i in detailCity)
            {
                Console.WriteLine("City: {0}  {1}", i.Key, i.Value.toString());
            }

            foreach (KeyValuePair<string, ContactDetails> i in detailState)
            {
                Console.WriteLine("State: {0}  {1}", i.Key, i.Value.toString());
            }

            Console.WriteLine(detailCity.Count());
            return detailCity;
        }
        /// <summary>
        /// UC10: Ability to count the person from the same state
        /// </summary>
        public void Count()
        {
            Console.WriteLine(" Enter state ");
            string state = Console.ReadLine();
            var stateCheck = contactDetailsList.FindAll(x => x.state == state);
            Console.WriteLine(" No of contacts from the state: " + state + " are " + stateCheck.Count);
        }
        public void ComputeDetails()
        {
            foreach (ContactDetails book in contactDetailsList)
            {
                Console.WriteLine(book.toString());
            }
        }
       
    }
}