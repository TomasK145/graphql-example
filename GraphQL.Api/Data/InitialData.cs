using GraphQL.Api.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Api.Data
{
    public static class InitialData
    {
        public static void Seed(this LibraryDbContext dbContext)
        {
            if (dbContext.Books.Any())
            {
                return;
            }

            var customerJozkoMrkvicka = new Customer
            {
                Name = "Jozko",
                Surname = "Mrkvicka",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Bratislava",
                    Street = "Plynarenska",
                    StreetNumber = "1/C",
                    PostCode = "85802"
                },
                BorrowedBooks = new List<Book>(),
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "jozko.mrkvicka@gmail.com" }
                }                
            };

            var customerJanMaly = new Customer
            {
                Name = "Jan",
                Surname = "Maly",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Kosice",
                    Street = "Hlavna",
                    StreetNumber = "1052",
                    PostCode = "85852"
                },
                BorrowedBooks = new List<Book>(),
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "jan.maly@gmail.com" }
                }
            };

            var customerPetraBystra = new Customer
            {
                Name = "Petra",
                Surname = "Bystra",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Nitra",
                    Street = "Presovska",
                    StreetNumber = "12/B",
                    PostCode = "92865"
                },
                BorrowedBooks = new List<Book>(),
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "petra.bystra@gmail.com" }
                }
            };

            var bookLazar = new Book
            {
                Title = "Lazár",
                BookStatus = BookStatus.NotAvailable,
                Genre = Genre.Krimi,
                PageCount = 488,
                Reviews = new List<Review>
                {
                    new Review { ReviewAuthor = customerJozkoMrkvicka, Rating = 5, ReviewMessage = "Najlepsia kniha :O" },
                    new Review { ReviewAuthor = customerPetraBystra, Rating = 2, ReviewMessage = "Prilis nasilne a krvave" },
                }
            };

            var bookStalker = new Book
            {
                Title = "Stalker",
                BookStatus = BookStatus.Available,
                Genre = Genre.Krimi,
                PageCount = 560,
                Reviews = new List<Review>()
            };

            var bookTrhlina = new Book
            {
                Title = "Trhlina",
                BookStatus = BookStatus.Available,
                Genre = Genre.Horror,
                PageCount = 368,
                Reviews = new List<Review>
                {
                    new Review{ReviewAuthor = customerJanMaly, Rating = 5, ReviewMessage = "Dych beruci pribeh"}
                }
            };

            var bookKucharskaKniha = new Book
            {
                Title = "Kucharska kniha",
                BookStatus = BookStatus.Available,
                Genre = Genre.Cooking,
                PageCount = 180,
                Reviews = new List<Review>
                {
                    new Review{ ReviewAuthor = customerPetraBystra, Rating = 4, ReviewMessage = "Vyborne jedla"}
                }
            };

            var bookKucharskaKniha2 = new Book
            {
                Title = "Kucharska kniha 2",
                BookStatus = BookStatus.Available,
                Genre = Genre.Cooking,
                PageCount = 130,
                Reviews = new List<Review>
                {
                    new Review{ ReviewAuthor = customerPetraBystra, Rating = 5, ReviewMessage = "Este lepsie jedla ako v prvej knihe"}
                }
            };

            var authorLarsKepler = new Author
            {
                Name = "Lars",
                Surname = "Kepler",
                Address = new Address
                {
                    Country = "Sweden",
                    City = "Stockholm",
                    Street = "Götgatan",
                    StreetNumber = "27",
                    PostCode = "116 21"
                },
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "larskepler@salomonssonagency.com" }
                },
                CreatedBooks = new List<AuthorBook>()
                {
                    new AuthorBook { Book = bookLazar },
                    new AuthorBook { Book = bookStalker }
                }
            };

            var authorJozefKarika = new Author
            {
                Name = "Jozef",
                Surname = "Karika",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Ruzomberok",
                    Street = "Kosicka",
                    StreetNumber = "11",
                    PostCode = "92563"
                },
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "info@jozefkarika.sk" }
                },
                CreatedBooks = new List<AuthorBook>()
                {
                    new AuthorBook { Book = bookTrhlina }
                }
            };

            var authorPeterDrobny = new Author
            {
                Name = "Peter",
                Surname = "Drobny",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Poprad",
                    Street = "Zilinska",
                    StreetNumber = "11C",
                    PostCode = "08563"
                },
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "peter.drobny@drobny.sk" }
                },
                CreatedBooks = new List<AuthorBook>()
                {
                    new AuthorBook {Book = bookKucharskaKniha}
                }
            };

            var authorSilviaDroba = new Author
            {
                Name = "Silvia",
                Surname = "Drobna",
                Address = new Address
                {
                    Country = "Slovakia",
                    City = "Poprad",
                    Street = "Zilinska",
                    StreetNumber = "11C",
                    PostCode = "08563"
                },
                Contacts = new List<Contact>
                {
                    new Contact { ContactType = ContactType.Email, Value = "info@drobny.sk" }
                },
                CreatedBooks = new List<AuthorBook>()
                {
                    new AuthorBook { Book = bookKucharskaKniha },
                    new AuthorBook { Book = bookKucharskaKniha2}
                }
            };

            customerJanMaly.BorrowedBooks.Add(bookLazar);

            dbContext.Authors.Add(authorLarsKepler);
            dbContext.Authors.Add(authorJozefKarika);
            dbContext.Authors.Add(authorPeterDrobny);
            dbContext.Authors.Add(authorSilviaDroba);
            dbContext.SaveChanges();
        }
    }
}
