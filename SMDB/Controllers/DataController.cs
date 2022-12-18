using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SMDP.SMDPModels;
using Microsoft.AspNetCore.Authorization;
using SMDP;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SMDP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


    public class DataController : ControllerBase
    {
        SmdpContext db = new SmdpContext();
             
        private LogSingleton _logger;
        public DataController()
        {
        
            _logger = LogSingleton.Instance;
        }

        [HttpGet("/DailyPrice")]
        
        public dynamic DailyPrice(long a)
         {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            var dailypricelist = db.DailyPrices.Where(i =>
              i.InsCode== a).ToList();
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return dailypricelist;          
         }
        [HttpGet("/Fund")]
        

        public dynamic Fund()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            var fundlist = db.Funds.Select(i =>
            new { i }).ToList();
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return fundlist;
        }
        [HttpGet("/Industry")]
        
        public dynamic Industry()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            var industrylist = db.Industries.Select(i =>
            new { i }).ToList();
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return industrylist;
        }
        [HttpGet("/Instrument")]
        
        public dynamic Instrument()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            var instrumentlist = db.Instruments.Select(i =>
            new { i }).ToList();
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return instrumentlist;
        }
        [HttpGet("/LetterType")]

        public dynamic LetterType()
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
            var letterTypelist = db.LetterTypes.Select(i =>
            new { i }).ToList();
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            return letterTypelist;
        }

    }
}