using FITCCRS2App.Models.Models;
using FITCCRS2App.Models.RequestObjects;
using FITCCRS2App.Models.SearchObjects;
using FITCCRS2App.Services.Services.RabbitMQ;
using FITCCRS2App.Services.Services.SponzorService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    public class SponzorTakmicarController : BaseCRUDController<Sponzor, BaseSearchObject, SponzorUpsertRequest, SponzorUpsertRequest>
    {
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public SponzorTakmicarController(IRabbitMQProducer rabitMQProducer,ILogger<BaseController<Sponzor, BaseSearchObject>> logger, ISponzorService service) : base(logger, service)
        {
            _rabbitMQProducer = rabitMQProducer;
        }
        public class EmailModel
        {
            public string Sender { get; set; }
            public string Recipient { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
        }

        [HttpPost("SendConfirmationEmail")]
        public IActionResult SendConfirmationEmail([FromBody] EmailModel emailModel)
        {
            try
            {
                _rabbitMQProducer.SendMessage(emailModel);
                Thread.Sleep(TimeSpan.FromSeconds(15));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

