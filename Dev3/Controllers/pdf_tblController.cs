using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dev3.Models;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using Dev3.Local_Classes;

namespace Dev3.Controllers
{
    [Authorize]
    public class pdf_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: pdf_tbl
        public ActionResult Index()
        {
            return View(db.pdf_tbl.Where(d => d.userName == System.Web.HttpContext.Current.User.Identity.Name).ToList());

        }

        // GET: Pdf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // GET: Pdf/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pdf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue,userName")] pdf_tbl pdf_tbl)
        {

           
                pdf_tbl.userName = System.Web.HttpContext.Current.User.Identity.Name;
                db.pdf_tbl.Add(pdf_tbl);
                db.SaveChanges();

                return RedirectToAction("Index");
           
        }




        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Preview")]
        [ValidateAntiForgeryToken]
        public ActionResult Preview([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue,userName")] pdf_tbl pdf_tbl)
        {

            
                pdf_tbl.userName = System.Web.HttpContext.Current.User.Identity.Name;
                db.pdf_tbl.Add(pdf_tbl);

                using (var ms = new MemoryStream())
                {
                    using (var document = new Document(PageSize.A4, 50, 50, 15, 15))
                    {
                        PdfWriter.GetInstance(document, ms);
                        Font titleFont = FontFactory.GetFont("Arial", 40);
                        Paragraph title;
                        title = new Paragraph(pdf_tbl.bookTitle, titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 20;
                        document.Open();
                        document.Add(title);
                        document.Add(new Paragraph(pdf_tbl.bookPrologue));
                        document.Close();

                    }
                    Response.Clear();
                    //Response.ContentType = "application/pdf";
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("content-disposition", "attachment;filename=" + pdf_tbl.bookTitle + ".pdf");
                    Response.Buffer = true;
                    var bytes = ms.ToArray();
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                    ModelState.Clear();
                    Response.OutputStream.Flush();


                }
            return View();
        
            
        }

        // GET: Pdf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // POST: Pdf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue,userName")] pdf_tbl pdf_tbl)
        {
            
                pdf_tbl.userName = System.Web.HttpContext.Current.User.Identity.Name;
                db.Entry(pdf_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }


        [HttpGet]
        public ActionResult editPreview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }


            using (var ms = new MemoryStream())
            {
                using (var document = new Document(PageSize.A4, 50, 50, 15, 15))
                {
                    PdfWriter.GetInstance(document, ms);
                    Font titleFont = FontFactory.GetFont("Arial", 40);
                    Paragraph title;
                    title = new Paragraph(pdf_tbl.bookTitle, titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    document.Open();
                    document.Add(title);
                    document.Add(new Paragraph(pdf_tbl.bookPrologue));
                    document.Close();

                }
                Response.Clear();
                //Response.ContentType = "application/pdf";
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename=" + pdf_tbl.bookTitle + ".pdf");
                Response.Buffer = true;
                var bytes = ms.ToArray();
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                ModelState.Clear();
                Response.OutputStream.Flush();


            }


            return View();
        }



        [HttpPost]
        [MultipleButton(Name = "action", Argument = "editPreview")]
        [ValidateAntiForgeryToken]
        public ActionResult editPreview([Bind(Include = "bookId,authFirstName,authLastName,bookTitle,bookPrologue,userName")] pdf_tbl pdf_tbl)
        {

            if (ModelState.IsValid)
            {
                pdf_tbl.userName = System.Web.HttpContext.Current.User.Identity.Name;
                db.pdf_tbl.Add(pdf_tbl);

                using (var ms = new MemoryStream())
                {
                    using (var document = new Document(PageSize.A4, 50, 50, 15, 15))
                    {
                        PdfWriter.GetInstance(document, ms);
                        Font titleFont = FontFactory.GetFont("Arial", 40);

                        Paragraph title;
                        title = new Paragraph(pdf_tbl.bookTitle, titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 20;
                        document.Open();
                        document.Add(title);
                        document.Add(new Paragraph(pdf_tbl.bookPrologue));
                        document.Close();

                    }
                    Response.Clear();
                    //Response.ContentType = "application/pdf";
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("content-disposition", "attachment;filename=" + pdf_tbl.bookTitle + ".pdf");
                    Response.Buffer = true;
                    var bytes = ms.ToArray();
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                    ModelState.Clear();
                    Response.OutputStream.Flush();


                }

            }
            return View();
        }



        // GET: Pdf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            if (pdf_tbl == null)
            {
                return HttpNotFound();
            }
            return View(pdf_tbl);
        }

        // POST: Pdf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pdf_tbl pdf_tbl = db.pdf_tbl.Find(id);
            db.pdf_tbl.Remove(pdf_tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
