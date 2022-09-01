using Exsm3945_Assignment.Data;
using Exsm3945_Assignment.Models;
using Exsm3945_Assignment.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Globalization;

namespace MVC_Demo.Controllers
{
    public class NewUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult GenerateNewClients()
        {
            // If there are exceptions, store them in the view data/bag so we can inform the user about them.
            if (TempData["Exceptions"] != null)
                ViewData["Exceptions"] = JsonConvert.DeserializeObject(TempData["Exceptions"].ToString(), typeof(BLLValidationException));


            ViewData["AccountTypes"] = new SelectList(_context.AccountTypes, "Id", "Name");
            ViewData["Accounts"] = new SelectList(_context.Accounts, "Id", "Name");
           // ViewData["TestData"] = "Here's some data I put in ViewData!";
            return View();
        }

        public ActionResult DoTheGeneration(string acc_TypeId, string c_FirstName, string c_LastName, string c_DoB, string c_Address, decimal acc_Balance)
        {

            string[] formats = { "yyyy-MM-dd" };

            DateOnly dt;
            // Let's do some validation!
            BLLValidationException validationState = new();

            // Do validation, if something fails, add it as a sub exception.

            // TEST EACH ITEM INDIVIDUALLY FIRST.

            // First validation item is typically "does this even exist", before we test it.
            if (string.IsNullOrWhiteSpace(acc_TypeId))
                validationState.SubExceptions.Add(new Exception("You did not select your Account Type Id."));
            else
                // Do any other validation with this item - does it exist in the database, does it have necessary properties/permissions, etc.
                // Remember, if we're dealing with ID's, to test and make sure they are integers before querying the database.
                if (!int.TryParse(acc_TypeId, out int temp))
                validationState.SubExceptions.Add(new Exception("No Account Type in the proper format. "));
            else
                    // Test to see if this customer exists or not.
                    if (!_context.AccountTypes.Any(x => x.Id == temp))
                validationState.SubExceptions.Add(new Exception("There was not any Account Type provided... **Account Type Not Found**"));


            if (string.IsNullOrWhiteSpace(c_FirstName))
                validationState.SubExceptions.Add(new Exception("First name was not provided."));
            else
                if (!int.TryParse(c_FirstName, out int temp))
                validationState.SubExceptions.Add(new Exception("First name was not in the correct format."));


            if (string.IsNullOrWhiteSpace(c_LastName))
                validationState.SubExceptions.Add(new Exception("Last name was not provided."));
            else
                if (!int.TryParse(c_LastName, out int temp))
                validationState.SubExceptions.Add(new Exception("Last name was not in the correct format."));
            else

           /* if (string.IsNullOrWhiteSpace(c_DoB))
            {
                validationState.SubExceptions.Add(new Exception("Your date of birth was not provided."));
            } */
            
            if (c_DoB == null)
                validationState.SubExceptions.Add(new Exception("You did not provide our BirthDate!"));
            else
                if (!DateOnly.TryParseExact(c_DoB, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                validationState.SubExceptions.Add(new Exception("Quantity was not in the correct format."));

            if (string.IsNullOrWhiteSpace(c_Address))
                validationState.SubExceptions.Add(new Exception("You did not provide your Address."));
            else
                if (c_Address.Length < 15 || c_Address.Length > 50)
                validationState.SubExceptions.Add(new Exception("Your home address was not in the correct format."));
            else
                    if (acc_Balance <= 0)
                validationState.SubExceptions.Add(new Exception("Your starting account balance must be greater than zero."));

            // ONCE EACH ITEM IS TESTED, THEN DO ANY TESTS THAT RELY ON MULTIPLE INPUTS.


            if (validationState.Any)
            {
                TempData["Exceptions"] = JsonConvert.SerializeObject(validationState);
            }
            // If we go in here, we've not encountered any validation issues, so we are good to proceed.
            else
            {
                Client client = new()
                {
                    FirstName = c_FirstName,
                    LastName = c_LastName,
                    Dob = DateOnly.Parse(c_DoB),
                    Address = c_Address
                };
            

                _context.Clients.Add(client);
                _context.SaveChanges();

                var clientsId = _context.Clients.Where(x => x.FirstName == c_FirstName && x.LastName == c_LastName).Single();
                _context.Entry(clientsId).Collection(x => x.Accounts).Load();
                var tempUpdateAccount = clientsId.Id;


               
               _context.Accounts.Add(new Account()
                {
                    AccountTypeId = int.Parse(acc_TypeId),
                    ClientId = tempUpdateAccount,
                    Balance = acc_Balance,
                    InterestAppliedDate =  DateTime.Now
                });
                _context.SaveChanges(); 
            }
            return RedirectToAction("GenerateNewClients");
        }
    }
}