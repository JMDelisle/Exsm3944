using Exsm3945_Assignment.Data;
using Exsm3945_Assignment.Models;
using Exsm3945_Assignment.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MVC_Demo.Controllers
{
    public class NewUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GenerateNewClients()
        {
            // If there are exceptions, store them in the view data/bag so we can inform the user about them.
            if (TempData["Exceptions"] != null)
                ViewData["Exceptions"] = JsonConvert.DeserializeObject(TempData["Exceptions"].ToString(), typeof(BLLValidationException));


            ViewData["AccountTypes"] = new SelectList(_context.AccountTypes, "Id", "Name");//account_type
            return View();
        }

        public ActionResult DoTheGeneration(string acc_TypeId, string c_FirstName, string c_LastName, string c_DoB, string c_Address, decimal acc_Balance)
        {

            string[] formats = { "yyyy-MM-dd" };
            DateTime user;
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
                if (!int.TryParse(acc_TypeId, out int random))
                validationState.SubExceptions.Add(new Exception("No Account Type in the proper format. "));
            else
                    // Test to see if this customer exists or not.
                    if (!_context.AccountTypes.Any(x => x.Id == random))
                validationState.SubExceptions.Add(new Exception("There was not any Account Type provided... **Account Type Not Found**"));

            else
                if (string.IsNullOrWhiteSpace(c_FirstName))
                validationState.SubExceptions.Add(new Exception("First name was not in the correct format."));
            else
            if (c_FirstName.Trim().Length < 2 || c_FirstName.Trim().Length > 25)
                validationState.SubExceptions.Add(new Exception("First name character should be between 2-25."));
            else
                if (!new Regex(@"^[A-Za-z,.'-]{2,25}$").IsMatch(c_FirstName))
                validationState.SubExceptions.Add(new Exception("First name does not contain numbers or symbols."));



            else
                if (string.IsNullOrWhiteSpace(c_LastName))
                validationState.SubExceptions.Add(new Exception("Last name was not in the correct format."));
            else
            if (c_LastName.Length < 2 || c_LastName.Length > 25)
                validationState.SubExceptions.Add(new Exception("Last name character should be between 2-25."));
            else
                if (!new Regex(@"^[A-Za-z,.'-]{2,15}$").IsMatch(c_LastName))
                validationState.SubExceptions.Add(new Exception("Last name does not contain numbers or symbols."));


            else
            
            if (c_DoB == null)//Makes it so you cannot just enter nothing.
                validationState.SubExceptions.Add(new Exception("You did not provide our BirthDate!"));
            else
                if (!DateTime.TryParseExact(c_DoB, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out user))
                validationState.SubExceptions.Add(new Exception("Date of Birth was not in the correct format."));

            //if (!DateTime.TryParseExact(c_DoB, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))


                if (string.IsNullOrWhiteSpace(c_Address))
                validationState.SubExceptions.Add(new Exception("You did not provide your Address."));
           /* else
                if (c_Address.Length < 15 || c_Address.Length > 50)
                validationState.SubExceptions.Add(new Exception("Your home address was not in the correct format."));*/
            
            
            else
                    if (acc_Balance <= 0)
                validationState.SubExceptions.Add(new Exception("Your opening balance should not be less then 0."));

            // ONCE EACH ITEM IS TESTED, THEN DO ANY TESTS THAT RELY ON MULTIPLE INPUTS.


            if (validationState.Any)
            {
                TempData["Exceptions"] = JsonConvert.SerializeObject(validationState);
            }
            // If we go in here, we've not encountered any validation issues, so we are good to proceed.
            else
            {
                Client randomClients = new Client()
                {
                    FirstName = c_FirstName,
                    LastName = c_LastName,
                    Dob = DateOnly.Parse(c_DoB),
                    Address = c_Address
                };
            

                _context.Clients.Add(randomClients);
                _context.SaveChanges();

               // var userClientId = _context.Clients.Where(x => x.FirstName == c_FirstName && x.LastName == c_LastName).Single();
               // _context.Entry(userClientId).Collection(x => x.Accounts).Load();
                var newClientAccountCreation = randomClients.Id;


                /*var clientsId = _context.Clients.Where(x => x.FirstName == c_FirstName && x.LastName == c_LastName).Single();
                _context.Entry(clientsId).Collection(x => x.Accounts).Load();
                var tempUpdateAccount = clientsId.Id; */


               
               _context.Accounts.Add(new Account()
                {
                    AccountTypeId = int.Parse(acc_TypeId),
                    ClientId = newClientAccountCreation,
                    Balance = acc_Balance,
                    InterestAppliedDate =  DateTime.Now
                });
                _context.SaveChanges(); 
            }
            return RedirectToAction("GenerateNewClients");
        }
    }
}