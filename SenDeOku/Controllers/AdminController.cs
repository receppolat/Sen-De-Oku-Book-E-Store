using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SenDeOku.Entities;
using SenDeOku.Models;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;

namespace SenDeOku.Controllers
{
    [Authorize(Roles = "Yonetici")]
    public class AdminController : Controller
    {
        private readonly OfficeContext _context;

        public AdminController(OfficeContext context)
        {
            _context = context;
        }
        public bool UploadFileBook(IFormFile file, int id)
        {
            try
            {
                if (file != null)
                {
                    string fileName = id.ToString() + "_" + DateTime.Now.ToShortDateString() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/assets/books", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _context.Books.Find(id).Photo = fileName;
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool UploadFileSlide(IFormFile file, int id, string ad)
        {
            try
            {
                if (file != null)
                {
                    string fileName = ad + "_" + DateTime.Now.ToShortDateString() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/assets/slider", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _context.Sliders.Find(id).Photo = fileName;
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool UploadFileAuthor(IFormFile file, int id, string ad)
        {
            try
            {
                if (file != null)
                {
                    string fileName = ad + "_" + DateTime.Now.ToShortDateString() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/assets/authors", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _context.Authors.Find(id).Photo = fileName;
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UploadFilePublisher(IFormFile file, int id, string ad)
        {
            try
            {
                if (file != null)
                {
                    string fileName = ad + "_" + DateTime.Now.ToShortDateString() + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/assets/publishers", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    _context.Publishers.Find(id).Photo = fileName;
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IActionResult> KitapIslemleri(string hataMesaji = "")
        {
            ViewBag.error = hataMesaji;
            var bookList = from book in _context.Books
                           join category in _context.Categories
                           on book.category.CategoryID equals category.CategoryID
                           join author in _context.Authors
                           on book.Author.AuthorID equals author.AuthorID
                           join publisher in _context.Publishers
                           on book.Publisher.PublisherID equals publisher.PublisherID
                           select new { book, category, author, publisher };
            List<Book> book1 = bookList.Select(o => o.book).ToList<Book>();
            List<Category> category1 = bookList.Select(o => o.category).ToList<Category>();
            List<Author> author1 = bookList.Select(o => o.author).ToList<Author>();
            List<Publisher> publisher1 = bookList.Select(o => o.publisher).ToList<Publisher>();
            BookAdminListView bookAdminListView = new BookAdminListView
            {
                Books = book1,
                Authors = author1,
                Publishers = publisher1,
                Categories = category1
            };
            if (book1 == null)
            {
                return NotFound();
            }
            return View(bookAdminListView);
        }
        public async Task<IActionResult> KitapDetaylari(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookList = from book in _context.Books
                           join category in _context.Categories
                           on book.category.CategoryID equals category.CategoryID
                           join author in _context.Authors
                           on book.Author.AuthorID equals author.AuthorID
                           join publisher in _context.Publishers
                           on book.Publisher.PublisherID equals publisher.PublisherID
                           where book.BookID == id
                           select new { book, category, author, publisher };
            Book book1 = bookList.FirstOrDefault().book;
            Category category1 = bookList.FirstOrDefault().category;
            Author author1 = bookList.FirstOrDefault().author;
            Publisher publisher1 = bookList.FirstOrDefault().publisher;
            book1.category = category1;
            book1.Author = author1;
            book1.Publisher = publisher1;
            if (book1 == null)
            {
                return NotFound();
            }
            return View(book1);
        }
        [HttpGet]
        public IActionResult KitapEkle()
        {
            List<Category> categoryResult = (from Category in _context.Categories
                                             select Category).ToList<Category>();
            List<Author> authorResult = (from author in _context.Authors
                                         select author).ToList<Author>();
            List<Publisher> publisherResult = (from publisher in _context.Publishers
                                               select publisher).ToList<Publisher>();
            BookAddModel bookAddModel = new BookAddModel
            {
                Book = new Book(),
                Categories = new SelectList(categoryResult, "CategoryID", "Name"),
                Authors = new SelectList(authorResult, "AuthorID", "Name"),
                Publishers = new SelectList(publisherResult, "PublisherID", "Name")
            };
            return View(bookAddModel);
        }
        [HttpPost]
        public IActionResult KitapEkle(Book book, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            Category category = _context.Categories.Find(book.category.CategoryID);
            Author author = _context.Authors.Find(book.Author.AuthorID);
            Publisher publisher = _context.Publishers.Find(book.Publisher.PublisherID);
            book.category = category;
            book.Author = author;
            book.Publisher = publisher;
            _context.Books.Add(book);
            _context.SaveChanges();
            UploadFileBook(image, (book.BookID));
            return RedirectToAction("KitapIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> KitapDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            List<Category> categoryResult = (from Category in _context.Categories
                                             select Category).ToList<Category>();
            List<Author> authorResult = (from author in _context.Authors
                                         select author).ToList<Author>();
            List<Publisher> publisherResult = (from publisher in _context.Publishers
                                               select publisher).ToList<Publisher>();

            BookListViewModel bookListViewModel = new BookListViewModel
            {
                Book = book,
                Category = new SelectList(categoryResult, "CategoryID", "Name"),
                Authors = new SelectList(authorResult, "AuthorID", "Name"),
                Publishers = new SelectList(publisherResult, "PublisherID", "Name")
            };
            if (book == null)
            {
                return NotFound();
            }
            return View(bookListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> KitapDuzenle(Book book, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            Book newBook = _context.Books.Find(book.BookID);
            Author author = _context.Authors.Find(book.Author.AuthorID);
            Publisher publisher = _context.Publishers.Find(book.Publisher.PublisherID);
            newBook.ISBN = book.ISBN;
            newBook.Name = book.Name;
            newBook.Author = author;
            newBook.Publisher = publisher;
            newBook.Translater = book.Translater;
            newBook.Count = book.Count;
            newBook.PageCount = book.PageCount;
            newBook.Price = book.Price;
            newBook.Discount = book.Discount;
            newBook.Language = book.Language;
            newBook.Information = book.Information;
            newBook.category = _context.Categories.Find(book.category.CategoryID);
            if (image != null)
            {
                if (newBook.Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/assets/books", newBook.Photo);
                    System.IO.File.Delete(path);
                }
                _context.SaveChanges();
                if (UploadFileBook(image, book.BookID))
                {
                    return RedirectToAction("KitapIslemleri");
                }
                else

                {
                    return RedirectToAction("KitapIslemleri");
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(KitapIslemleri));
            }
        }
        public async Task<IActionResult> KitapSil(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Book newBook = _context.Books.Find(id);
                try
                {
                    _context.Books.Remove(newBook);
                    _context.SaveChanges();
                    return RedirectToAction("KitapIslemleri");
                }
                catch (Exception error)
                {
                    return RedirectToAction("KitapIslemleri", new { hataMesaji = "Bu kitaba ait siparis/siparisler bulunmaktadir." });
                }

            }
        }

        public async Task<IActionResult> MenuIslemleri(string hataMesaji = "")
        {
            ViewBag.error = hataMesaji;
            return View(await _context.Categories.ToListAsync());
        }
        public IActionResult MenuEkle()
        {
            CategoryAddModel categoryAddModel = new CategoryAddModel
            {
                Category = new Category(),
            };
            return View(categoryAddModel);
        }
        [HttpPost]
        public IActionResult MenuEkle(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("MenuIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> MenuDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            CategoryAddModel categoryAddModel = new CategoryAddModel
            {
                Category = category
            };

            if (category == null)
            {
                return NotFound();
            }
            return View(categoryAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> MenuDuzenle(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            Category newCategori = _context.Categories.Find(category.CategoryID);
            newCategori.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(MenuIslemleri));
        }

        public IActionResult MenuSil(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Category newCategory = _context.Categories.Find(id);
                try
                {
                    _context.Categories.Remove(newCategory);
                    _context.SaveChanges();
                    return RedirectToAction("MenuIslemleri");
                }
                catch (Exception error)
                {
                    return RedirectToAction("MenuIslemleri", new { hataMesaji = "Bu kategoriye ait kitaplar bulunmakta. Once o kitaplari siliniz" });
                }

            }
        }
        public async Task<IActionResult> SlaytIslemleri()
        {
            return View(await _context.Sliders.ToListAsync());
        }
        public IActionResult SlaytEkle()
        {
            SliderAddModel sliderAddModel = new SliderAddModel
            {
                Slider = new Slider(),
            };
            return View(sliderAddModel);
        }
        [HttpPost]
        public IActionResult SlaytEkle(Slider slider, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            _context.Sliders.Add(slider);
            string ad = slider.Name;
            _context.SaveChanges();
            UploadFileSlide(image, (slider.SliderID), ad);
            return RedirectToAction("SlaytIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> SlaytDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slider = await _context.Sliders.FindAsync(id);
            SliderAddModel sliderAddModel = new SliderAddModel
            {
                Slider = slider
            };
            if (slider == null)
            {
                return NotFound();
            }
            return View(sliderAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> SlaytDuzenle(Slider slider, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }
            Slider newSlider = _context.Sliders.Find(slider.SliderID);
            newSlider.Name = slider.Name;
            string ad = slider.Name;
            if (image != null)
            {
                if (newSlider.Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/slider", slider.Photo);
                    System.IO.File.Delete(path);
                }
                _context.SaveChanges();
                if (UploadFileSlide(image, slider.SliderID, ad))
                {
                    return RedirectToAction("SlaytIslemleri");
                }
                else
                {
                    return RedirectToAction("SlaytIslemleri");
                }
            }
            else
            {

                _context.SaveChanges();
                return RedirectToAction(nameof(SlaytIslemleri));
            }
        }

        public IActionResult SlaytSil(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Slider newSlider = _context.Sliders.Find(id);
                _context.Sliders.Remove(newSlider);
                _context.SaveChanges();
                return RedirectToAction("SlaytIslemleri");
            }
        }
        public IActionResult Siparisler()
        {
            var result = (
                    from r in _context.Receipts
                    join c in _context.Customers
                    on r.customer.CustomerID equals c.CustomerID
                    where r.Details == "Sipariş Alındı"
                    select new { r, c }
                );
            ReceiptViewModel model = new ReceiptViewModel();
            model.ReceiptList = new List<ReceiptCustomerModel>();
            foreach (var item in result)
            {
                model.ReceiptList.Add(new ReceiptCustomerModel
                {
                    Customer = item.c,
                    Receipt = item.r
                });
            }
            return View(model);
        }
        public IActionResult KargolanmisSiparisler()
        {
            var result = (from r in _context.Receipts
                          join c in _context.Customers
                          on r.customer.CustomerID equals c.CustomerID
                          where r.Details == "Sipariş Kargoda"
                          select new { r, c });
            ReceiptViewModel model = new ReceiptViewModel();
            model.ReceiptList = new List<ReceiptCustomerModel>();
            foreach (var item in result)
            {
                model.ReceiptList.Add(new ReceiptCustomerModel
                {
                    Customer = item.c,
                    Receipt = item.r
                });
            }
            return View(model);
        }
        public IActionResult EskiSiparisler()
        {
            var result = (from r in _context.Receipts
                          join c in _context.Customers
                          on r.customer.CustomerID equals c.CustomerID
                          where r.Details == "Teslim Edildi"
                          select new { r, c });
            ReceiptViewModel model = new ReceiptViewModel();
            model.ReceiptList = new List<ReceiptCustomerModel>();
            foreach (var item in result)
            {
                model.ReceiptList.Add(new ReceiptCustomerModel
                {
                    Customer = item.c,
                    Receipt = item.r
                });
            }
            return View(model);
        }
        public IActionResult OrdersDetails(int? id)
        {
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
                         where r.ReceiptID == id
                         select new { r, b, a, s, p, o, c };

            Receipt receipt = result.Select(o => o.r).FirstOrDefault();
            List<Book> books = result.Select(o => o.b).ToList<Book>();
            List<Author> authors = result.Select(o => o.a).ToList<Author>();
            List<Publisher> publishers = result.Select(o => o.p).ToList<Publisher>();
            List<Order> orders = result.Select(o => o.o).ToList<Order>();
            List<Customer> customers = result.Select(o => o.c).ToList<Customer>();
            Shipper shipper = result.Select(o => o.s).FirstOrDefault();
            List<Shipper> shippers = result.Select(o => o.s).ToList<Shipper>();
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.Receipt = receipt;
            orderDetails.Books = books;
            orderDetails.Authors = authors;
            orderDetails.Publishers = publishers;
            orderDetails.Orders = orders;
            orderDetails.Shippers = shippers;
            orderDetails.Shipper = shipper;
            orderDetails.Customer = customers;
            orderDetails.ShipperList = new SelectList(_context.Shippers.ToList<Shipper>(), "ShipperID", "ShipperName");
            return View(orderDetails);
        }
        [HttpPost]
        public IActionResult ChangeReceiptDetails(int statusid, Shipper shipper, int receiptid)
        {
            if (statusid == 1)
            {
                Receipt receipt = _context.Receipts.Find(receiptid);
                receipt.Details = "Sipariş Kargoda";
                receipt.Shipper = _context.Shippers.Find(shipper.ShipperID);
                _context.SaveChanges();
            }
            else if (statusid == 2)
            {
                Receipt receipt = _context.Receipts.Find(receiptid);
                receipt.Details = "Teslim Edildi";
                _context.SaveChanges();
            }
            return RedirectToAction("Siparisler", "Admin");
        }
        public async Task<IActionResult> YazarIslemleri(string hataMesaji = "")
        {
            ViewBag.error = hataMesaji;
            return View(await _context.Authors.ToListAsync());
        }
        public IActionResult YazarEkle()
        {
            AuthorAddModel authorAddModel = new AuthorAddModel
            {
                Author = new Author(),
            };
            return View(authorAddModel);
        }
        [HttpPost]
        public IActionResult YazarEkle(Author author, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            _context.Authors.Add(author);
            string ad = author.Name;
            _context.SaveChanges();
            UploadFileAuthor(image, (author.AuthorID), ad);
            return RedirectToAction("YazarIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> YazarDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            AuthorAddModel authorAddModel = new AuthorAddModel
            {
                Author = author
            };
            if (author == null)
            {
                return NotFound();
            }
            return View(authorAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> YazarDuzenle(Author author, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            Author newAuthor = _context.Authors.Find(author.AuthorID);
            newAuthor.Name = author.Name;
            string ad = author.Name;
            if (image != null)
            {
                if (newAuthor.Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/authors", author.Photo);
                    System.IO.File.Delete(path);
                }
                _context.SaveChanges();
                if (UploadFileAuthor(image, author.AuthorID, ad))
                {
                    return RedirectToAction("YazarIslemleri");
                }
                else
                {
                    return RedirectToAction("YazarIslemleri");
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(YazarIslemleri));
            }
        }

        public IActionResult YazarSil(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Author author = _context.Authors.Find(id);
                try
                {
                    _context.Authors.Remove(author);
                    _context.SaveChanges();
                    return RedirectToAction("YazarIslemleri");
                }
                catch (Exception error)
                {
                    return RedirectToAction("YazarIslemleri", new { hataMesaji = "Bu yazara ait kitaplar bulunmakta. Once o kitaplari siliniz" });
                }
            }
        }

        public async Task<IActionResult> YayineviIslemleri(string hataMesaji = "")
        {
            ViewBag.error = hataMesaji;
            return View(await _context.Publishers.ToListAsync());
        }
        public IActionResult YayineviEkle()
        {
            PublisherAddModel publisherAddModel = new PublisherAddModel
            {
                Publisher = new Publisher(),
            };
            return View(publisherAddModel);
        }
        [HttpPost]
        public IActionResult YayineviEkle(Publisher publisher, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            _context.Publishers.Add(publisher);
            string ad = publisher.Name;
            _context.SaveChanges();
            UploadFilePublisher(image, (publisher.PublisherID), ad);
            return RedirectToAction("YayineviIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> YayineviDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var publisher = await _context.Publishers.FindAsync(id);
            PublisherAddModel publisherAddModel = new PublisherAddModel
            {
                Publisher = publisher
            };
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisherAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> YayineviDuzenle(Publisher publisher, [FromForm(Name = "ImageFileName")]IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            Publisher newPublisher = _context.Publishers.Find(publisher.PublisherID);
            newPublisher.Name = publisher.Name;
            string ad = publisher.Name;
            if (image != null)
            {
                if (publisher.Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/mydoc/img/publishers", publisher.Photo);
                    System.IO.File.Delete(path);
                }
                _context.SaveChanges();
                if (UploadFilePublisher(image, publisher.PublisherID, ad))
                {
                    return RedirectToAction("YayineviIslemleri", "Admin");
                }
                else
                {
                    return RedirectToAction("YayineviIslemleri", "Admin");
                }
            }
            else
            {
                _context.SaveChanges();
                return RedirectToAction("YayineviIslemleri", "Admin");
            }
        }

        public IActionResult YayineviSil(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Publisher publisher = _context.Publishers.Find(id);
                try
                {
                    _context.Publishers.Remove(publisher);
                    _context.SaveChanges();
                    return RedirectToAction("YayineviIslemleri", "Admin");
                }
                catch (Exception error)
                {
                    return RedirectToAction("YayineviIslemleri", new { hataMesaji = "Bu yayinevine ait kitaplar bulunmakta. Once o kitaplari siliniz" });
                }

            }

        }

        public async Task<IActionResult> KargoIslemleri()
        {

            return View(await _context.Shippers.ToListAsync());
        }
        public IActionResult KargoEkle()
        {
            ShipperAddModel shipperAddModel = new ShipperAddModel
            {
                Shipper = new Shipper(),
            };
            return View(shipperAddModel);
        }
        [HttpPost]
        public IActionResult KargoEkle(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            string ad = shipper.ShipperName;
            _context.SaveChanges();
            return RedirectToAction("KargoIslemleri");
        }
        [HttpGet]
        public async Task<IActionResult> KargoDuzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shipper = await _context.Shippers.FindAsync(id);
            ShipperAddModel shipperAddModel = new ShipperAddModel
            {
                Shipper = shipper
            };
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipperAddModel);
        }

        [HttpPost]
        public async Task<IActionResult> KargoDuzenle(Shipper shipper)
        {
            if (!ModelState.IsValid)
            {
                return View(shipper);
            }
            Shipper newShipper = _context.Shippers.Find(shipper.ShipperID);
            newShipper.ShipperName = shipper.ShipperName;
            string ad = shipper.ShipperName;
            _context.SaveChanges();
            return RedirectToAction("KargoIslemleri", "Admin");
        }

        public IActionResult KargoSil(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Shipper shipper = _context.Shippers.Find(id);
                _context.Shippers.Remove(shipper);
                _context.SaveChanges();
                return RedirectToAction("KargoIslemleri", "Admin");
            }
        }
        [HttpGet]
        public IActionResult AlintiEkle()
        {
            List<Book> bookResult = (from book in _context.Books
                                     select book).ToList<Book>();
            AlintiAddModel alintiAddModel = new AlintiAddModel
            {
                Alinti = new Alinti(),
                Books = new SelectList(bookResult, "BookID", "Name")
            };
            return View(alintiAddModel);
        }
        [HttpPost]
        public IActionResult AlintiEkle(Alinti alinti, string info)
        {
            Book book = _context.Books.Find(alinti.Book.BookID);
            alinti.Book = book;
            alinti.AlintiInformation = info;
            alinti.Date = DateTime.Now.ToString();
            _context.Alinties.Add(alinti);
            _context.SaveChanges();
            return RedirectToAction("AlintiEkle", "Admin");
        }
    }
}