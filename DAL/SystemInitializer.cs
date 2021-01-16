using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TicketFinalSys.Models;

namespace TicketFinalSys.DAL
{
    public class SystemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SystemContext>
    {
        protected override void Seed(SystemContext context)
        {
            var tickets = new List<Ticket>
            {
               new Ticket{RequestDate=DateTime.Now, FirstName="Tanya", LastName="Perry", RequestDesc="Technical Issue", TechAssigned="Queen", CompletionDate=DateTime.Now, Note="Missing Remote Scanner App", Status="Open"},
                new Ticket{RequestDate=DateTime.Now, FirstName="Mike", LastName="Lowrey",RequestDesc="Bug Issue", TechAssigned="Myia", CompletionDate=DateTime.Now, Note="Device Managers closes randomly", Status="Closed"},
                new Ticket{RequestDate=DateTime.Now, FirstName="John", LastName="Doe", RequestDesc="Hardware Issue", TechAssigned="Zen", CompletionDate=DateTime.Now, Note="Need new keyboard", Status="Open"}
            };

            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();
        }
    }
}