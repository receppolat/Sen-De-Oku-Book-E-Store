using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Math.EC.Rfc7748;
using SenDeOku.Entities;
using SenDeOku.Models;

namespace SenDeOku.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly OfficeContext _context;
        public KullaniciController(OfficeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            var booksOrderByEx = (from books1 in _context.Books
                                  join authors in _context.Authors
                                  on books1.Author.AuthorID equals authors.AuthorID
                                  join categories1 in _context.Categories
                                  on books1.category.CategoryID equals categories1.CategoryID
                                  where categories1.Name == "Sınavlara Hazırlık Kitapları"
                                  select new { books1, authors }).Take(12);
            List<BookAuthorSHKModel> bookAuthorSHKModel = new List<BookAuthorSHKModel>();
            foreach (var item in booksOrderByEx)
            {
                bookAuthorSHKModel.Add(new BookAuthorSHKModel
                {
                    Author = item.authors,
                    Book = item.books1
                });
            }

            var booksOrderByExKPSS = (from books1 in _context.Books
                                      join authors in _context.Authors
                                      on books1.Author.AuthorID equals authors.AuthorID
                                      join categories1 in _context.Categories
                                      on books1.category.CategoryID equals categories1.CategoryID
                                      where categories1.Name == "KPSS Hazırlık Kitapları"
                                      select new { books1, authors }).Take(12);
            List<BookAuthorKPSSModel> bookAuthorKPSSModel = new List<BookAuthorKPSSModel>();
            foreach (var item in booksOrderByExKPSS)
            {
                bookAuthorKPSSModel.Add(new BookAuthorKPSSModel
                {
                    Author = item.authors,
                    Book = item.books1
                });
            }

            /*ESKİ EN ÇOK SATANLAR*/
            /*var booksNAuthor = (from orders in _context.Orders
                                join books in _context.Books
                                on orders.Book.BookID equals books.BookID
                                join aut in _context.Authors
                                on books.Author.AuthorID equals aut.AuthorID
                                select new { orders, books, aut }
                                /*group new
                                {
                                    orders,
                                    books,
                                    aut
                                } by books.BookID into grp
                                select new
                                {
                                    Books = grp.Select(o => o.books),
                                    Orders = grp.Select(o => o.orders),
                                    Authors = grp.Select(o => o.aut),
                                    Count = grp.Sum(o => o.orders.BookCount)
                                }

                                /*group books by books.BookID into a
                                select new { Books = a.Key, Count = a.Count() }*/
            /*group x by new { x.books, x.aut, x.orders } into g
            select new
            {
                Orders = g.Key.orders,
                Authors = g.Key.aut,
                Books = g.Key.books,
                Count = g.Count(o => o.books)
            }*//*
            ).Take(12);*/
            /*ESKİ EN ÇOK SATANLAR*/
            /*YENİ EN ÇOK SATANLAR*/
            List<BookNSaleCount> bestSales = new List<BookNSaleCount>();
            var expression = (
                    from o in _context.Orders
                    join b in _context.Books
                    on o.Book.BookID equals b.BookID
                    select new { o, b }
                ).OrderBy(p => p.b.BookID);
            int recentID = -1;
            int topCount = 0;
            int sayac = 0;
            if (expression.Count() > 0)
            {
                recentID = expression.FirstOrDefault().b.BookID;
                bestSales.Add(new BookNSaleCount
                {
                    BookID = recentID,
                    SaleCount = 0
                });
            }
            foreach (var item in expression)
            {
                if (recentID != item.b.BookID)
                {
                    bestSales[sayac].SaleCount = topCount;
                    sayac++;
                    recentID = item.b.BookID;
                    bestSales.Add(new BookNSaleCount
                    {
                        BookID = recentID,
                        SaleCount = 0
                    });
                    topCount = 0;
                }
                topCount += item.o.BookCount;
            }
            if (expression.Count() > 0)
                bestSales[sayac].SaleCount = topCount;
            bestSales = bestSales.OrderByDescending(bs => bs.SaleCount).Take(12).ToList<BookNSaleCount>();
            List<BookNAuthorModel> bookNAuthorList = new List<BookNAuthorModel>();
            foreach (var item in bestSales)
            {
                bookNAuthorList.Add(new BookNAuthorModel
                {
                    Author = (from a in _context.Authors
                              join b in _context.Books
                              on a.AuthorID equals b.Author.AuthorID
                              where b.BookID == item.BookID
                              select a).FirstOrDefault(),
                    Book = (from b in _context.Books
                            where b.BookID == item.BookID
                            select b).FirstOrDefault()
                });
            }

            /*YENİ EN ÇOK SATANLAR*/
            /*ESKİ EN ÇOK SATANLAR 2*/
            /*
            List<BookNAuthorModel> bookNAuthor = new List<BookNAuthorModel>();
            foreach (var item in booksNAuthor)
            {
                bookNAuthor.Add(new BookNAuthorModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }
            */
            /*ESKİ ENÇOK SATANLAR 2*/

            var booksAuthorBest = (from books in _context.Books
                                   join aut in _context.Authors
                                   on books.Author.AuthorID equals aut.AuthorID
                                   select new { books, aut });
            List<BookAuthorBestModel> bookAuthorBest = new List<BookAuthorBestModel>();
            foreach (var item in booksAuthorBest)
            {
                bookAuthorBest.Add(new BookAuthorBestModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }

            var booksAuthorOrderByDate = (from books in _context.Books
                                          join aut in _context.Authors
                                          on books.Author.AuthorID equals aut.AuthorID
                                          select new { books, aut }).OrderByDescending(o => o.books.BookID).Take(12);
            List<BookAuthorOrderByDateModel> bookAuthorOrderByDateModel = new List<BookAuthorOrderByDateModel>();
            foreach (var item in booksAuthorOrderByDate)
            {
                bookAuthorOrderByDateModel.Add(new BookAuthorOrderByDateModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }

            var booksAuthorOrderByDiscount = (from books in _context.Books
                                              join aut in _context.Authors
                                              on books.Author.AuthorID equals aut.AuthorID
                                              select new { books, aut }).OrderByDescending(o => o.books.Discount).Take(12);
            List<BookAuthorOrderByDiscountModel> bookAuthorOrderByDiscountModel = new List<BookAuthorOrderByDiscountModel>();
            foreach (var item in booksAuthorOrderByDiscount)
            {
                bookAuthorOrderByDiscountModel.Add(new BookAuthorOrderByDiscountModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }


            IndexModel indexModel = new IndexModel
            {
                Sliders = _context.Sliders.ToList<Slider>(),
                BookNAuthorBest = bookAuthorBest,
                BookNAuthor = bookNAuthorList,
                BookNAuthorOrderByDate = bookAuthorOrderByDateModel,
                BookNAuthorOrderByDiscount = bookAuthorOrderByDiscountModel,
                BookAuthorSHK = bookAuthorSHKModel,
                BookAuthorKPSS = bookAuthorKPSSModel
            };
            return View(indexModel);
        }
        public async Task<IActionResult> BookDetails(int? id)
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            if (id == null)
            {
                return NotFound();
            }
            var bookList = (from book in _context.Books
                            join authors in _context.Authors
                            on book.Author.AuthorID equals authors.AuthorID
                            join publishers in _context.Publishers
                            on book.Publisher.PublisherID equals publishers.PublisherID
                            join category in _context.Categories
                            on book.category.CategoryID equals category.CategoryID
                            where book.BookID == id
                            select new { book, category, authors, publishers }).Take(6);

            var booksAuthor = (from books in _context.Books
                               join aut in _context.Authors
                               on books.Author.AuthorID equals aut.AuthorID
                               select new { books, aut }).Take(12);
            List<BookAuthorBestDetailModel> bookAuthorBestDetailModel = new List<BookAuthorBestDetailModel>();
            foreach (var item in booksAuthor)
            {
                bookAuthorBestDetailModel.Add(new BookAuthorBestDetailModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }

            var booksAuthorBest = (from books in _context.Books
                                   join aut in _context.Authors
                                   on books.Author.AuthorID equals aut.AuthorID
                                   select new { books, aut });
            List<BookAuthorSameDetailModel> bookAuthorSameDetailModel = new List<BookAuthorSameDetailModel>();
            foreach (var item in booksAuthorBest)
            {
                bookAuthorSameDetailModel.Add(new BookAuthorSameDetailModel
                {
                    Author = item.aut,
                    Book = item.books
                });
            }

            Book book1 = bookList.FirstOrDefault().book;
            Category category1 = bookList.FirstOrDefault().category;
            book1.category = category1;

            Author author = bookList.FirstOrDefault().authors;
            book1.Author = author;

            Publisher publisher = bookList.FirstOrDefault().publishers;
            book1.Publisher = publisher;

            BookDetailsModel bookDetailsModel = new BookDetailsModel
            {
                Book = book1,
                BookAuthorBestDetailModel = bookAuthorBestDetailModel,
                BookAuthorSameDetailModel = bookAuthorSameDetailModel
            };
            if (book1 == null)
            {
                return NotFound();
            }

            return View(bookDetailsModel);
        }
        public IActionResult Authors()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;
            ViewData["Name"] = "YAZARLAR | Sen De Oku";

            List<Author> authors = (from aut in _context.Authors
                                    select aut).OrderBy(o => o.Name).ToList<Author>();
            AuthorModel authorModel = new AuthorModel
            {
                Authors = authors
            };
            return View(authorModel);
        }
        public IActionResult AuthorBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            List<Author> authors = (from aut in _context.Authors
                                    where aut.AuthorID == id
                                    select aut).ToList<Author>();
            ViewData["Name"] = authors[0].Name + " | Sen De Oku";

            var bookss = from book in _context.Books
                         join cate in _context.Authors
                         on book.Author.AuthorID equals cate.AuthorID
                         where cate.AuthorID == id
                         select new { book, cate };
            List<Book> books = bookss.Select(o => o.book).ToList<Book>();

            List<BookPublisherDetailModel> bookPublisherDetailModel = new List<BookPublisherDetailModel>();
            foreach (var item in bookss)
            {
                bookPublisherDetailModel.Add(new BookPublisherDetailModel
                {
                    Author = item.cate,
                    Book = item.book
                });
            }
            ProductsModel productsModel = new ProductsModel
            {
                Name = authors[0].Name + " Kitapları",
                BookPublisherSameDetailModel = bookPublisherDetailModel
            };
            return View(productsModel);
        }
        public IActionResult Publishers()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;
            ViewData["Name"] = "YAYIN EVLERİ | Sen De Oku";

            List<Publisher> publishers = (from aut in _context.Publishers
                                          select aut).OrderBy(o => o.Name).ToList<Publisher>();
            PublisherModel publisherModel = new PublisherModel
            {
                Publishers = publishers
            };
            return View(publisherModel);
        }
        public IActionResult PublisherBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            var bookPublisher = (from books1 in _context.Books
                                 join aut in _context.Authors
                                 on books1.Author.AuthorID equals aut.AuthorID
                                 where books1.Publisher.PublisherID == id
                                 select new { books1, aut });
            List<BookPublisherDetailModel> bookPublisherDetailModel = new List<BookPublisherDetailModel>();
            foreach (var item in bookPublisher)
            {
                bookPublisherDetailModel.Add(new BookPublisherDetailModel
                {
                    Author = item.aut,
                    Book = item.books1
                });
            }

            List<Publisher> publishers = (from pub in _context.Publishers
                                          where pub.PublisherID == id
                                          select pub).ToList<Publisher>();
            var bookss = from book in _context.Books
                         join cate in _context.Publishers
                         on book.Publisher.PublisherID equals cate.PublisherID
                         where cate.PublisherID == id
                         select new { book, cate };
            List<Book> books = bookss.Select(o => o.book).ToList<Book>();
            ViewData["Name"] = publishers[0].Name + " | Sen De Oku";

            ProductsModel productsModel = new ProductsModel
            {
                Name = publishers[0].Name + " Kitapları",
                BookPublisherSameDetailModel = bookPublisherDetailModel
            };
            return View(productsModel);
        }
        public IActionResult Books(int? id, string? key)
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;


            if (id == null)
            {
                ViewData["Name"] = "Tüm Kitaplar | Sen De Oku";
                var bookPublisher = (from books1 in _context.Books
                                     join aut in _context.Authors
                                     on books1.Author.AuthorID equals aut.AuthorID
                                     select new { books1, aut });
                if (!String.IsNullOrEmpty(key))
                {
                    bookPublisher = bookPublisher.Where(b => b.books1.Name.Contains(key));
                }
                List<BookPublisherDetailModel> bookPublisherDetailModel = new List<BookPublisherDetailModel>();
                foreach (var item in bookPublisher)
                {
                    bookPublisherDetailModel.Add(new BookPublisherDetailModel
                    {
                        Author = item.aut,
                        Book = item.books1
                    });
                }

                List<Book> book = (from books in _context.Books
                                   select books).ToList<Book>();
                ProductsModel productsModel = new ProductsModel
                {
                    Name = String.IsNullOrEmpty(key) ? "TÜM ÜRÜNLER" : "'" + key + "' " + "Sonuçları",
                    BookPublisherSameDetailModel = bookPublisherDetailModel
                };
                return View(productsModel);
            }
            else if (id == -1)
            {
                ViewData["Name"] = "ÇOK SATANLAR | Sen De Oku";
                List<BookNSaleCount> bestSales = new List<BookNSaleCount>();
                var expression = (
                        from o in _context.Orders
                        join b in _context.Books
                        on o.Book.BookID equals b.BookID
                        select new { o, b }
                    ).OrderBy(p => p.b.BookID);
                int recentID = -1;
                int topCount = 0;
                int sayac = 0;
                if (expression.Count() > 0)
                {
                    recentID = expression.FirstOrDefault().b.BookID;
                    bestSales.Add(new BookNSaleCount
                    {
                        BookID = recentID,
                        SaleCount = 0
                    });
                }
                foreach (var item in expression)
                {
                    if (recentID != item.b.BookID)
                    {
                        bestSales[sayac].SaleCount = topCount;
                        sayac++;
                        recentID = item.b.BookID;
                        bestSales.Add(new BookNSaleCount
                        {
                            BookID = recentID,
                            SaleCount = 0
                        });
                        topCount = 0;
                    }
                    topCount += item.o.BookCount;
                }
                if (expression.Count() > 0)
                    bestSales[sayac].SaleCount = topCount;
                bestSales = bestSales.OrderByDescending(bs => bs.SaleCount).Take(12).ToList<BookNSaleCount>();
                List<BookPublisherDetailModel> bookPublisherDetailModel = new List<BookPublisherDetailModel>();
                foreach (var item in bestSales)
                {
                    bookPublisherDetailModel.Add(new BookPublisherDetailModel
                    {
                        Author = (from a in _context.Authors
                                  join b in _context.Books
                                  on a.AuthorID equals b.Author.AuthorID
                                  where b.BookID == item.BookID
                                  select a).FirstOrDefault(),
                        Book = (from b in _context.Books
                                where b.BookID == item.BookID
                                select b).FirstOrDefault()
                    });
                }


                /* var bookPublisher = (from books1 in _context.Books
                                      join aut in _context.Authors
                                      on books1.Author.AuthorID equals aut.AuthorID
                                      select new { books1, aut });
                 List<BookPublisherDetailModel> bookPublisherDetailModel = new List<BookPublisherDetailModel>();
                 foreach (var item in bookPublisher)
                 {
                     bookPublisherDetailModel.Add(new BookPublisherDetailModel
                     {
                         Author = item.aut,
                         Book = item.books1
                     });
                 }

                 List<Book> book = (from books in _context.Books
                                    select books).ToList<Book>();*/
                ProductsModel productsModel = new ProductsModel
                {
                    Name = "ÇOK SATANLAR",
                    BookPublisherSameDetailModel = bookPublisherDetailModel
                };
                return View(productsModel);

            }
            else if (id == -2)
            {
                ViewData["Name"] = "SON ÇIKANLAR | Sen De Oku";

                var bookPublisherOrderByDate = (from books1 in _context.Books
                                                join aut in _context.Authors
                                                on books1.Author.AuthorID equals aut.AuthorID
                                                select new { books1, aut }).OrderByDescending(o => o.books1.BookID);
                List<BookPublisherDetailModel> bookPublisherDetailModelOrderByDate = new List<BookPublisherDetailModel>();
                foreach (var item in bookPublisherOrderByDate)
                {
                    bookPublisherDetailModelOrderByDate.Add(new BookPublisherDetailModel
                    {
                        Author = item.aut,
                        Book = item.books1
                    });
                }
                ProductsModel productsModel = new ProductsModel
                {
                    Name = "EN SON ÇIKANLAR",
                    BookPublisherSameDetailModel = bookPublisherDetailModelOrderByDate
                };
                return View(productsModel);

            }
            else if (id == -3)
            {
                ViewData["Name"] = "FIRSAT KÖŞESİ | Sen De Oku";
                var bookPublisherOrderByDiscount = (from books1 in _context.Books
                                                    join aut in _context.Authors
                                                    on books1.Author.AuthorID equals aut.AuthorID
                                                    select new { books1, aut }).OrderByDescending(o => o.books1.Discount);
                List<BookPublisherDetailModel> bookPublisherDetailModelOrderByDiscount = new List<BookPublisherDetailModel>();
                foreach (var item in bookPublisherOrderByDiscount)
                {
                    bookPublisherDetailModelOrderByDiscount.Add(new BookPublisherDetailModel
                    {
                        Author = item.aut,
                        Book = item.books1
                    });
                }
                ProductsModel productsModel = new ProductsModel
                {
                    Name = "FIRSAT KÖŞESİ",
                    BookPublisherSameDetailModel = bookPublisherDetailModelOrderByDiscount
                };
                return View(productsModel);

            }
            else if (id == -4)
            {
                ViewData["Name"] = "SINAVLARA HAZIRLIK KİTAPLARI | Sen De Oku";
                var bookPublisherSHK = (from books1 in _context.Books
                                        join cat in _context.Categories
                                        on books1.category.CategoryID equals cat.CategoryID
                                        join aut in _context.Authors
                                        on books1.Author.AuthorID equals aut.AuthorID
                                        where cat.Name == "Sınavlara Hazırlık Kitapları"
                                        select new { books1, aut });

                List<BookPublisherDetailModel> bookPublisherDetailModelSHK = new List<BookPublisherDetailModel>();
                foreach (var item in bookPublisherSHK)
                {
                    bookPublisherDetailModelSHK.Add(new BookPublisherDetailModel
                    {
                        Author = item.aut,
                        Book = item.books1
                    });
                }

                ProductsModel productsModel = new ProductsModel
                {
                    Name = "SINAVLARA HAZIRLIK KİTAPLARI",
                    BookPublisherSameDetailModel = bookPublisherDetailModelSHK
                };
                return View(productsModel);

            }
            else if (id == -5)
            {
                ViewData["Name"] = "KPSS HAZIRLIK KİTAPLARI | Sen De Oku";
                var bookPublisherKPSS = (from books1 in _context.Books
                                         join cat in _context.Categories
                                         on books1.category.CategoryID equals cat.CategoryID
                                         join aut in _context.Authors
                                         on books1.Author.AuthorID equals aut.AuthorID
                                         where cat.Name == "KPSS Hazırlık Kitapları"
                                         select new { books1, aut });

                List<BookPublisherDetailModel> bookPublisherDetailModelKPSS = new List<BookPublisherDetailModel>();
                foreach (var item in bookPublisherKPSS)
                {
                    bookPublisherDetailModelKPSS.Add(new BookPublisherDetailModel
                    {
                        Author = item.aut,
                        Book = item.books1
                    });
                }

                ProductsModel productsModel = new ProductsModel
                {
                    Name = "KPSS HAZIRLIK KİTAPLARI",
                    BookPublisherSameDetailModel = bookPublisherDetailModelKPSS
                };
                return View(productsModel);

            }
            else if (id > 0)
            {
                List<Category> categories1 = _context.Categories.OrderByDescending(o => o.CategoryID).ToList<Category>();
                int idKkontrol = categories1.FirstOrDefault<Category>().CategoryID;
                if (id <= idKkontrol)
                {
                    List<Category> category = (from cat in _context.Categories
                                               where cat.CategoryID == id
                                               select cat).ToList<Category>();
                    var bookss = from book in _context.Books
                                 join aut in _context.Authors
                                 on book.Author.AuthorID equals aut.AuthorID
                                 join cate in _context.Categories
                                 on book.category.CategoryID equals cate.CategoryID
                                 where cate.CategoryID == id
                                 select new { book, cate, aut };
                    List<BookPublisherDetailModel> bookPublisherDetailModelBooks = new List<BookPublisherDetailModel>();
                    foreach (var item in bookss)
                    {
                        bookPublisherDetailModelBooks.Add(new BookPublisherDetailModel
                        {
                            Author = item.aut,
                            Book = item.book
                        });
                    }
                    List<Book> books = bookss.Select(o => o.book).ToList<Book>();
                    ViewData["Name"] = category[0].Name + " | Sen De Oku";

                    ProductsModel productsModel = new ProductsModel
                    {
                        Name = category[0].Name,
                        BookPublisherSameDetailModel = bookPublisherDetailModelBooks
                    };
                    return View(productsModel);

                }
                else
                    return NotFound();

            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Alinti()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            ViewData["Name"] = "GÜNLÜK ALINTI | Sen De Oku";

            var bookA = (from bookC in _context.Books
                         join author in _context.Authors
                         on bookC.Author.AuthorID equals author.AuthorID
                         join alinti in _context.Alinties
                         on bookC.BookID equals alinti.Book.BookID
                         select new { bookC, alinti, author }).OrderByDescending(o => o.alinti.AlintiID);

            Book book = bookA.Select(o => o.bookC).FirstOrDefault();
            Alinti alinti1 = bookA.Select(o => o.alinti).FirstOrDefault();
            Author author1 = bookA.Select(o => o.author).FirstOrDefault();
            AlintiModel alintiModel = new AlintiModel
            {
                Book = book,
                Alinti = alinti1,
                Author = author1
            };
            return View(alintiModel);
        }
        [Authorize(Roles = "Kullanici")]
        [HttpGet]
        public IActionResult Card()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;

            ViewData["Name"] = "SEPETİM | Sen De Oku";

            var order = from cards in _context.Cards
                        join books in _context.Books
                        on cards.Book.BookID equals books.BookID
                        join publisher in _context.Publishers
                        on books.Publisher.PublisherID equals publisher.PublisherID
                        join author in _context.Authors
                        on books.Author.AuthorID equals author.AuthorID
                        join customers in _context.Customers
                        on cards.Customer.CustomerID equals customers.CustomerID
                        where customers.CustomerID == User.FindFirstValue(ClaimTypes.NameIdentifier)
                        select new { cards, books, author, publisher };
            List<Card> Cards = order.Select(o => o.cards).ToList<Card>();
            List<Book> Book = order.Select(o => o.books).ToList<Book>();
            List<Author> Author = order.Select(o => o.author).ToList<Author>();
            List<Publisher> Publisher = order.Select(o => o.publisher).ToList<Publisher>();
            CardModel cardModel = new CardModel
            {
                Cards = Cards,
                Book = Book,
                Author = Author,
                Publisher = Publisher
            };
            return View(cardModel);
        }
        [Authorize(Roles = "Kullanici")]
        [HttpPost]
        public IActionResult Card(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Card card = new Card
            {
                Book = _context.Books.Find(id),
                BookCount = 1,
                Customer = _context.Customers.Find(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };
            _context.Cards.Add(card);
            _context.SaveChanges();
            return RedirectToAction("Card", "Kullanici");
        }

        [Authorize(Roles = "Kullanici")]
        public async Task<IActionResult> OrderDelete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            _context.Cards.Remove(_context.Cards.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Card", "Kullanici");
        }
        [Authorize(Roles = "Kullanici")]
        [HttpPost]
        public async Task<IActionResult> OrderUpdate(int? id, int count)
        {
            if (id == null)
            {
                return NotFound();
            }
            Card newCard = _context.Cards.Find(id);
            newCard.BookCount = count;
            _context.SaveChanges();
            return RedirectToAction("Card", "Kullanici");
        }
        [Authorize(Roles = "Kullanici")]
        public IActionResult Buy(int totalPrice)
        {
            Receipt receipt = new Receipt
            {
                Date = DateTime.Now.ToShortDateString(),
                customer = _context.Customers.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Details = "Sipariş Alındı",
                TotalPrice = totalPrice,
                Shipper = _context.Shippers.Find(1)
            };
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            List<Card> cards = (from card in _context.Cards
                                join c in _context.Customers
                                on card.Customer.CustomerID equals c.CustomerID
                                where c.CustomerID == User.FindFirstValue(ClaimTypes.NameIdentifier)
                                select card).ToList<Card>();
            foreach (var card in cards)
            {
                Book book = (from c in _context.Cards
                             join b in _context.Books
                             on c.Book.BookID equals b.BookID
                             where c.CardID == card.CardID
                             select b).FirstOrDefault();
                _context.Orders.Add(new Order
                {
                    Book = book,
                    BookCount = card.BookCount,
                    Receipt = receipt
                });
                _context.SaveChanges();
                Book updateBook = _context.Books.Find(book.BookID);
                updateBook.Count = book.Count - 1;
                _context.SaveChanges();
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
            return RedirectToAction("Orders", "Kullanici");
        }
        public IActionResult Login()
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
            {
                List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
                ViewData["Menuler"] = categories;
                ViewData["Name"] = "Giriş Yap | Sen De Oku";
                return View();
            }
            else
            {
                return RedirectToAction("Account", "User");
            }


        }
        [Authorize(Roles = "Kullanici")]
        public IActionResult Orders()
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;
            ViewData["Name"] = "SİPARİŞLERİM | Sen De Oku";
            OrderModel model = new OrderModel();
            var receipts = (from r in _context.Receipts
                            join s in _context.Shippers
                            on r.Shipper.ShipperID equals s.ShipperID
                            join c in _context.Customers
                            on r.customer.CustomerID equals c.CustomerID
                            where c.CustomerID == User.FindFirstValue(ClaimTypes.NameIdentifier)
                            select new { r, s }).OrderByDescending(o => o.r.ReceiptID);
            List<Receipt> receipt = receipts.Select(o => o.r).ToList<Receipt>();
            List<Shipper> shipper = receipts.Select(o => o.s).ToList<Shipper>();
            model.Receipt = receipt;
            model.Shipper = shipper;
            return View(model);
        }
        public IActionResult OrdersDetails(int? id)
        {
            List<Category> categories = (from Category in _context.Categories select Category).ToList<Category>();
            ViewData["Menuler"] = categories;
            if (id == null)
            {
                return NotFound();
            }

            var result = from r in _context.Receipts
                         join o in _context.Orders
                         on r.ReceiptID equals o.Receipt.ReceiptID
                         join b in _context.Books
                         on o.Book.BookID equals b.BookID
                         join a in _context.Authors
                         on b.Author.AuthorID equals a.AuthorID
                         join p in _context.Publishers
                         on b.Publisher.PublisherID equals p.PublisherID
                         join s in _context.Shippers
                         on r.Shipper.ShipperID equals s.ShipperID
                         join c in _context.Customers
                         on r.customer.CustomerID equals c.CustomerID
                         where c.CustomerID == User.FindFirstValue(ClaimTypes.NameIdentifier) && r.ReceiptID == id
                         select new { r, b, a, s, p, o };

            Receipt receipt = result.Select(o => o.r).FirstOrDefault();
            List<Book> books = result.Select(o => o.b).ToList<Book>();
            List<Author> authors = result.Select(o => o.a).ToList<Author>();
            List<Publisher> publishers = result.Select(o => o.p).ToList<Publisher>();
            List<Order> orders = result.Select(o => o.o).ToList<Order>();
            List<Shipper> shippers = result.Select(o => o.s).ToList<Shipper>();
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.Receipt = receipt;
            orderDetails.Books = books;
            orderDetails.Authors = authors;
            orderDetails.Publishers = publishers;
            orderDetails.Orders = orders;
            orderDetails.Shippers = shippers;
            ViewData["Name"] = "#" + receipt.ReceiptID.ToString() + " | Sen De Oku";
            return View(orderDetails);
        }

    }
}