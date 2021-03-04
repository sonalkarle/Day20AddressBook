using NUnit.Framework;
using AddressBookDay13;
using System.Collections.Generic;

namespace AddresBookTestcase
{
    
    
    public class Tests
    {
         Program program;

        [SetUp]
        public void Setup()
        {
            program = new Program();
            List<ContactDetails> contactDetailsList;
            contactDetailsList = new List<ContactDetails>();
            private List<ContactDetails> sortedBookList;
           sortedBookList = new List<ContactDetails>();
    }
        
        [Test]
        public void GivenList_PresentinAlphabateorNot_answer()
        {
             sortedBookList = contactDetailsList.OrderBy(x => x.firstName).ToList();
        foreach (ContactDetails book in sortedBookList)
            {
                Console.WriteLine(book.toString());
            }

        }
    }
}