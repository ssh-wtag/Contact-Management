using AutoFixture;
using ContactManagerClassLibrary.Domain.Models;
using ContactManagerClassLibrary.Infrastructure.Data;
using ContactManagerClassLibrary.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Test_ContactManager
{
    public class Test_ContactManagerService
    {
        #region Initialization

        private ContactManagerService cmservice;
        private Context context;
        private Fixture fixture;
        public Test_ContactManagerService()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                context.Database.EnsureDeleted();
                context.Dispose();
            }
            catch (Exception ex)
            {
            }

            cmservice = new ContactManagerService();

            var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            context = new Context(options);
            fixture = new Fixture();
            fixture.Behaviors.Remove(fixture.Behaviors.OfType<ThrowingRecursionBehavior>().First());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        #endregion

        #region Test DbContext

        [Fact]
        public void AddContactThroughContext()
        {
            Init();

            var newContact = fixture.Create<Contact>();

            context.Contacts.Add(newContact);
            context.SaveChanges();

            var contact = context.Contacts.FirstOrDefault(c => c.ContactId == newContact.ContactId);
            Assert.NotNull(contact);
            Assert.Equal(newContact.Name, contact.Name);
        }

        [Fact]
        public void AddContactGroupThroughContext()
        {
            Init();

            var contact = fixture.Create<Contact>();
            var group = fixture.Create<Group>();

            context.Contacts.Add(contact);
            context.Groups.Add(group);
            context.SaveChanges();

            contact.Groups = new List<Group> { group };
            context.SaveChanges();

            var savedContact = context.Contacts.Include(c => c.Groups).FirstOrDefault(c => c.ContactId == contact.ContactId);
            Assert.NotNull(savedContact);
            Assert.Single(savedContact.Groups);
            Assert.Equal(group.GroupId, savedContact.Groups.First().GroupId);
        }

        [Fact]
        public void RetrieveContactWithGroups()
        {
            Init();

            var contact = fixture.Create<Contact>();
            var group = fixture.Create<Group>();

            contact.Groups = new List<Group> { group };
            context.Contacts.Add(contact);
            context.Groups.Add(group);
            context.SaveChanges();

            var retrievedContact = context.Contacts.Include(c => c.Groups).FirstOrDefault(c => c.ContactId == contact.ContactId);

            Assert.NotNull(retrievedContact);
            Assert.Single(retrievedContact.Groups);
            Assert.Equal(group.GroupId, retrievedContact.Groups.First().GroupId);
        }

        [Fact]
        public void UpdateExistingContact()
        {
            Init();

            var contact = fixture.Create<Contact>();
            context.Contacts.Add(contact);
            context.SaveChanges();

            var existingContact = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            Assert.NotNull(existingContact);

            existingContact.Name = "Updated Name";
            existingContact.Number = "123-456-789";
            context.SaveChanges();

            var updatedContact = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            Assert.NotNull(updatedContact);
            Assert.Equal("Updated Name", updatedContact.Name);
            Assert.Equal("123-456-789", updatedContact.Number);
        }

        [Fact]
        public void DeleteContact()
        {
            Init();

            var contact = fixture.Create<Contact>();
            context.Contacts.Add(contact);
            context.SaveChanges();

            context.Contacts.Remove(contact);
            context.SaveChanges();

            var deletedContact = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            Assert.Null(deletedContact);
        }

        [Fact]
        public void LazyLoadingGroups()
        {
            Init();

            var contact = fixture.Create<Contact>();
            var group = fixture.Create<Group>();

            contact.Groups = new List<Group> { group };
            context.Contacts.Add(contact);
            context.Groups.Add(group);
            context.SaveChanges();

            var retrievedContact = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);

            Assert.NotNull(retrievedContact);
            Assert.NotNull(retrievedContact.Groups);
            Assert.Single(retrievedContact.Groups);
            Assert.Equal(group.GroupId, retrievedContact.Groups.First().GroupId);
        }

        #endregion

        #region Testing for Exceptions

        [Fact]
        public void AddDuplicateContact()
        {
            Init();

            var newContact = fixture.Create<Contact>();
            context.Contacts.Add(newContact);
            context.SaveChanges();

            var duplicateContact = context.Contacts.Find(newContact.ContactId);
            Exception exception = null;

            try
            {
                context.Contacts.Add(duplicateContact);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void DeleteNonExistingContact()
        {
            Init();

            var contact = fixture.Create<Contact>();

            Exception exception = null;

            try
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.NotNull(exception);
            Assert.IsType<DbUpdateConcurrencyException>(exception);
        }

        [Fact]
        public void RetrieveNonExistingContact()
        {
            Init();

            var contact = fixture.Create<Contact>();

            Exception exception = null;

            try
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                var retrievedContact = context.Contacts.Find(contact.ContactId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.NotNull(exception);
            Assert.IsType<DbUpdateConcurrencyException>(exception);
        }

        #endregion

        #region Input Validation

        //Test Invalid Phone Numbers
        [Theory]
        [InlineData("")]
        [InlineData("-+1234123")]
        [InlineData("+-123-12312-123-123")]
        [InlineData("-123-123213")]
        [InlineData("634563+")]
        [InlineData("432423-")]
        [InlineData("32453245234+-234234")]
        [InlineData("+123412+2341234")]
        [InlineData("ABCD")]
        [InlineData("+asd-asdasd")]
        [InlineData("+-")]
        [InlineData("+3452-345+")]
        public void ValidateNumbersFalse(string number)
        {
            Result result = HelperService.ValidateFields("name", number, "email", "address");
            Assert.False(result.IsSuccess);
        }

        //Test Valid Phone Numbers
        [Theory]
        [InlineData("+12312")]
        [InlineData("+12-34-123")]
        [InlineData("+123-12312-123-123")]
        [InlineData("123-123213")]
        [InlineData("63-45-63")]
        [InlineData("4-324-23")]
        [InlineData("32-4-532-45-234")]
        [InlineData("+1234122341234")]
        [InlineData("2134132134")]
        [InlineData("+234234")]
        [InlineData("+345")]
        [InlineData("34")]
        public void ValidateNumbersTrue(string number)
        {
            Result result = HelperService.ValidateFields("name", number, "email", "address");
            Assert.True(result.IsSuccess);
        }

        //Test for Empty Name or Phone Number
        [Theory]
        [InlineData("", "")]
        [InlineData("Name", "")]
        [InlineData("", "+123123")]
        public void ValidateEmptyOrNull(string name, string number)
        {
            Result result = HelperService.ValidateFields(name, number, "email", "address");
            Assert.False(result.IsSuccess, result.Error);
        }

        #endregion

        #region Testing ContactManagerService

        [Theory]
        [InlineData("Name","-01711111111+")]
        [InlineData("Name","++01711111111")]
        [InlineData("Name","--01711111111")]
        [InlineData("Name","017--11111111")]
        [InlineData("Name","0171111-+1111")]
        [InlineData("Name","01711+-111111")]
        [InlineData("Name","abcd")]
        [InlineData("Name","-01711111111")]
        [InlineData("Name","01711111111-")]
        [InlineData("Name","01711111111+")]
        [InlineData("Name","+017--11111111")]
        [InlineData("", "01711-111111")]
        [InlineData("", "01-711-11111-1")]
        [InlineData("", "+017-11-111-111")]
        [InlineData("", "+01711111111")]
        public async Task TestValidationAddContactAsync(string name, string number)
        {
            var result = await cmservice.AddContactAsync(name, number, "Email", "Address", new bool[] {true, false, true});

            Assert.False(result.IsSuccess, result.Error);
        }

        #endregion
    }
}