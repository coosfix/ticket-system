using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Services.Implement
{
    public class TicketsManageService : ITicketsManageService
    {
        private readonly TicketDBContext ticketDBContext;

        public TicketsManageService(TicketDBContext ticketDBContext)
        {
            this.ticketDBContext = ticketDBContext;
        }
        public bool Add(TicketsViewModel model,int userId)
        {
            try
            {
                ticketDBContext.Tickets.Add(new Tickets
                {
                    TicketsId = model.TicketsId,
                    Description = model.Description,
                    Summary = model.Summary,
                    Severity = model.Severity,
                    Priority = model.Priority,
                    TicketTypeId = model.TicketsTypeId,
                     UserId = userId,
                    CreateTime = DateTime.Now
                });
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var target = ticketDBContext.Tickets.Find(id);
                ticketDBContext.Tickets.Remove(target);
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TicketsViewModel GetSingle(int id)
        {
            var data = ticketDBContext.Tickets.Include(i => i.User)
                .FirstOrDefault(f => f.TicketsId == id);
            if (data is null) return null;
            return new TicketsViewModel
            {
                TicketsId = data.TicketsId,
                Summary = data.Summary,
                Description = data.Description,
                Priority = data.Priority ?? string.Empty,
                Severity = data.Severity ?? string.Empty,
                UserName = data.User.Name,
                Resolved = data.Resolved,
                TicketsTypeId = data.TicketTypeId,
            };
        }

        public List<TicketsViewModel> GetAll() =>
            ticketDBContext.Tickets
            .AsNoTracking()
            .Include(i => i.User)
            .Select(x => new TicketsViewModel
            {
                TicketsId = x.TicketsId,
                Description = x.Description,
                Summary = x.Summary,
                Priority = x.Priority,
                Severity = x.Severity,
                TicketsTypeId = x.TicketTypeId,
                UserName = x.User.Name,
                Resolved = x.Resolved
            })
            .ToList();

        public bool Update(TicketsViewModel model)
        {
            var target = ticketDBContext.Tickets.Find(model.TicketsId);
            if (target == null) return false;
            try
            {
                target.Summary = model.Summary;
                target.Description = model.Description;
                target.Priority = model.Priority;
                target.Severity = model.Severity;
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SelectListItem> TicketTypeItems(int roleId)
        {

            return ticketDBContext.Role
                .AsNoTracking()
                .Include(i => i.TicketRules)
                .ThenInclude(i => i.TicketType)
                .Where(w => w.RoleId == roleId)
                .FirstOrDefault()
                .TicketRules
                .Select(s =>
                new SelectListItem
                {
                    Value = s.TicketTypeId.ToString(),
                    Text = s.TicketType.Name
                }).ToList();
        }

        public bool Resolve(int id)
        {
            var target = ticketDBContext.Tickets.Find(id);
            if (target == null) return false;
            try
            {
                target.Resolved = true;
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
