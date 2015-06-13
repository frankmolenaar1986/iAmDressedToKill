using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using iAm.Models;

namespace iAm.Controllers
{
    public class PaymentController : ApiController
    {
        List<Payment> payments = new List<Payment> 
        { 
            new Payment { Id = 123, Amount = 20, Debitor = "NL12INGB0123456789", Creditor = "NL12SNSB0123456789", Description = "Desc1" },
            new Payment { Id = 456, Amount = 40, Debitor = "NL24INGB0123456789", Creditor = "NL24SNSB0123456789", Description = "Desc2" }, 
            new Payment { Id = 789, Amount = 60, Debitor = "NL36INGB0123456789", Creditor = "NL36SNSB0123456789", Description = "Desc3" } 
        };

        // GET api/Payment
        public IEnumerable<Payment> Get()
        {
            return payments;
        }

        // GET api/Payment/1
        public Payment Get(int id)
        {
            Payment payment = payments.FirstOrDefault((p) => p.Id == id);

            if (payment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return payment;
            }
        }

        // POST api/values
        public HttpResponseMessage Post(Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.Id = 1;
                payments.Add(payment);

                var response = Request.CreateResponse(HttpStatusCode.Created, payment);

                string uri = Url.Link("DefaultApi", new { id = payment.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/values/5
        public void Put(int id,[FromBody]Payment payment)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class UserController : ApiController
    {
        List<User> users = new List<User>
        {
            new User { UserName = "Alex", Password = "test", UserNameSalt = "AlexSalt", MasterKey = "MasterKey" },
            new User { UserName = "Merijn", Password = "test", UserNameSalt = "MerijnSalt", MasterKey = "MasterKey" }
        };

        // POST api/values
        public HttpResponseMessage Post(User user)
        {
            if (ModelState.IsValid)
            {
                User foundUser = users.FirstOrDefault((p) => p.UserName == user.UserName);

                if (foundUser != null && foundUser.Password == user.Password)
                {
                    user.DNS = Url.Request.RequestUri.DnsSafeHost;
                    user.PasswordHash = user.Password + "|" + foundUser.MasterKey + "|" + user.DNS;
                    user.UserNameHash = user.UserName + "|" + foundUser.UserNameSalt + "|" + user.DNS + "|" + user.PasswordHash;
                    user.UserName = null;
                    user.Password = null;
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    user.UserName = null;
                    user.Password = null;
                    return Request.CreateResponse(HttpStatusCode.NotFound, user);
                }

                //var response = Request.CreateResponse(
                //                  HttpStatusCode.OK, user);

                //string uri = Url.Link("DefaultApi", new { id = payment.Id });
                //response.Headers.Location = new Uri(uri);
                //return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
