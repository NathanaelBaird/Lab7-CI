using Microsoft.VisualStudio.TestPlatform.TestHost;
using Blazor_Lab_Starter_Code;

namespace Lab6_Testing
{
    [TestClass]
    public class MainProBookTests
    {
        [TestInitialize]
        public void Setup()
        {
            // Initialize books list before each test
            MainPro.books = new List<Book>();
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToBooksList()
        {
            // Arrange
            int initialCount = MainPro.books.Count;
            var book = new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                ISBN = "1234567890"
            };

            // Act
            MainPro.books.Add(book);

            // Assert
            Assert.AreEqual(initialCount + 1, MainPro.books.Count);
            Assert.AreEqual("C# Programming", MainPro.books[0].Title);
            Assert.AreEqual("John Doe", MainPro.books[0].Author);
            Assert.AreEqual("1234567890", MainPro.books[0].ISBN);
        }

        [TestMethod]
        public void EditBook_ShouldUpdateExistingBookDetails()
        {
            // Arrange
            var book = new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                ISBN = "1234567890"
            };
            MainPro.books.Add(book);

            // Act
            book.Title = "Advanced C# Programming";
            book.Author = "Jane Doe";
            book.ISBN = "0987654321";

            // Assert
            var editedBook = MainPro.books.FirstOrDefault(b => b.Id == 1);
            Assert.IsNotNull(editedBook);
            Assert.AreEqual("Advanced C# Programming", editedBook.Title);
            Assert.AreEqual("Jane Doe", editedBook.Author);
            Assert.AreEqual("0987654321", editedBook.ISBN);
        }

        [TestMethod]
        public void DeleteBook_ShouldRemoveBookFromBooksList()
        {
            // Arrange
            var book = new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                ISBN = "1234567890"
            };
            MainPro.books.Add(book);

            // Act
            MainPro.books.Remove(book);

            // Assert
            Assert.AreEqual(0, MainPro.books.Count);
        }

        [TestMethod]
        public void ListBooks_ShouldReturnAllBooks()
        {
            // Arrange
            MainPro.books.Add(new Book
            {
                Id = 1,
                Title = "C# Programming",
                Author = "John Doe",
                ISBN = "1234567890"
            });
            MainPro.books.Add(new Book
            {
                Id = 2,
                Title = "Java Programming",
                Author = "Jane Doe",
                ISBN = "0987654321"
            });

            // Act
            var bookList = MainPro.books;

            // Assert
            Assert.AreEqual(2, bookList.Count);
            Assert.IsTrue(bookList.Any(b => b.Title == "C# Programming"));
            Assert.IsTrue(bookList.Any(b => b.Title == "Java Programming"));
        }
    }

    [TestClass]
    public class MainProUserTests
    {
        [TestInitialize]
        public void Setup()
        {
            // Initialize users list before each test
            MainPro.users = new List<User>();
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToUsersList()
        {
            // Arrange
            int initialCount = MainPro.users.Count;

            // Act
            MainPro.users.Add(new User { Id = 1, Name = "Alice", Email = "alice@example.com" });

            // Assert
            Assert.AreEqual(initialCount + 1, MainPro.users.Count);
            Assert.AreEqual("Alice", MainPro.users[0].Name);
            Assert.AreEqual("alice@example.com", MainPro.users[0].Email);
        }

        [TestMethod]
        public void EditUser_ShouldUpdateExistingUser()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Alice", Email = "alice@example.com" };
            MainPro.users.Add(user);

            // Act
            user.Name = "Bob";
            user.Email = "bob@example.com";

            // Assert
            var editedUser = MainPro.users.FirstOrDefault(u => u.Id == 1);
            Assert.IsNotNull(editedUser);
            Assert.AreEqual("Bob", editedUser.Name);
            Assert.AreEqual("bob@example.com", editedUser.Email);
        }

        [TestMethod]
        public void DeleteUser_ShouldRemoveUserFromUsersList()
        {
            // Arrange
            var user = new User { Id = 1, Name = "Alice", Email = "alice@example.com" };
            MainPro.users.Add(user);

            // Act
            MainPro.users.Remove(user);

            // Assert
            Assert.AreEqual(0, MainPro.users.Count);
        }

        [TestMethod]
        public void ListUsers_ShouldReturnAllUsers()
        {
            // Arrange
            MainPro.users.Add(new User { Id = 1, Name = "Alice", Email = "alice@example.com" });
            MainPro.users.Add(new User { Id = 2, Name = "Bob", Email = "bob@example.com" });

            // Act
            var userList = MainPro.users;

            // Assert
            Assert.AreEqual(2, userList.Count);
            Assert.IsTrue(userList.Any(u => u.Name == "Alice"));
            Assert.IsTrue(userList.Any(u => u.Name == "Bob"));
        }
    }
}
