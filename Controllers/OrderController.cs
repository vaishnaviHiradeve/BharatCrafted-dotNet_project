using BharatCrafted.Models;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;

namespace BharatCrafted.Controllers
{
    public class OrderController : Controller
    {
        [BindProperty]
        public OrderEntity _OrderDetails {  get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitiateOrder ()
        {
            string key = "rzp_test_kU0Adz3x89THZi";
            string secret = "b4JxK3KR6omjQ8XMTOglBA19";

            RazorpayClient client = new RazorpayClient(key, secret);

            Random _random = new Random();
            string TransactionalId = _random.Next(0,10000).ToString();

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToDecimal(_OrderDetails.TotalAmount)*100);
            input.Add("currency", "INR");
            input.Add("receipt", TransactionalId);


            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.orderId = order["id"].ToString();

            return View("Payment", _OrderDetails);
        }

        public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id);
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentLinkSignature(attributes);

            OrderEntity orderdetails = new OrderEntity();
            orderdetails.TransactionId = razorpay_payment_id;
            orderdetails.OrderId = razorpay_order_id;

            return View("PaymentSuccess", orderdetails);
        }
    }
}
