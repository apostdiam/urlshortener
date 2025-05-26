using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using URL_Shortener.Data;
using URL_Shortener.Models;


namespace URL_Shortener.Controllers
{

    public class UrlShortenerController : Controller
    {

        private readonly UrlShortenerDBContext _dbContext;

        public UrlShortenerController(UrlShortenerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var links = await _dbContext.UrlLinks.ToListAsync();
            if (links != null)
            {
                ViewBag.Message = links;
                return View();
            }

            return Redirect("/");

            //return View(new URLLinks());
        }
         

        [Route("/converturl")]
        [HttpPost]
        public async Task<IActionResult> ConvertURL(URLLinks urllinks)
        {
            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }

            var originalUrl = urllinks.OriginalUrl;
            var shortenedUrlPrefix = urllinks.ShortenedUrlPrefix;
            var shortUrl = Helpers.Helpers.ConvertUrlToShortenedForm(shortenedUrlPrefix, originalUrl);
            var visitedAt = urllinks.VisitedAt;
            var timesVisited = urllinks.TimesVisited;
            var ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            var browser = Request.Headers.UserAgent.ToString();
            var convertedAt = urllinks.ConvertedAt;
            
          
            // prepare the model
            var model = new URLLinks()
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortUrl,
                VisitedAt = visitedAt,
                TimesVisited = timesVisited,
                VisitorsIpAddress = ipAddress,
                VisitorsUserAgent = browser,
                ConvertedAt = convertedAt,
                ShortenedUrlPrefix = shortenedUrlPrefix,
            };

            var existing = await _dbContext.UrlLinks.FirstOrDefaultAsync(x => x.OriginalUrl == originalUrl && x.ShortenedUrl == shortUrl);
            if (existing != null)
            {
                //Conflict("Record already converted!"); // 409
                ViewBag.Error = "URL already converted! Enter a different URL to be converted. Or else, visit the URL!";
                ViewBag.ExistingRecord = existing;
                //existing.TimesVisited++;

                return View("Index", urllinks);
            }

            //model.TimesVisited++;

            // save changes to db
            _dbContext.UrlLinks.Add(model);
            await _dbContext.SaveChangesAsync();

            ViewBag.Message = model;

            return View("ConvertURL");
        }


        [HttpGet]
        public async Task<IActionResult> VisitURL(int id)
        {
            var link = await _dbContext.UrlLinks.FindAsync(id);

            if (link == null) { return NotFound(); }

            var url = link.OriginalUrl;

            link.TimesVisited++;
            link.VisitedAt = DateTime.Now;
            link.VisitorsIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4();
            link.VisitorsUserAgent = Request.Headers.UserAgent.ToString();

            await _dbContext.SaveChangesAsync();

            if ((url == null) || (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute)))
            {
                ViewBag.Error = "Invalid URL";
                return BadRequest("Not a valid URL!");
                //return Redirect("/visiturl");
            }

            return Redirect(url);
        }
        
        [Route("/stats")]
        public async Task<IActionResult> Statistics()
        {
            var links = await _dbContext.UrlLinks.ToListAsync();
            if (links != null)
            {
                ViewBag.Message = links;
                return View();
            }

            return Redirect("/");
        }

    }
}
 